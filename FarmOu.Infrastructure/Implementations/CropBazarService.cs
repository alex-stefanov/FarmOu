using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Infrastructure.Implementations;

/// <summary>
/// Provides operations for browsing, buying, and selling crops within the Crop Bazaar,
/// coordinating data persistence and user management.
/// </summary>
/// <param name="cropRepository">Repository for managing <see cref="Crop"/> entities.</param>
/// <param name="cropBRepository">Repository for managing crop purchase transactions (<see cref="CropBuying"/>).</param>
/// <param name="cropSRepository">Repository for managing crop sale transactions (<see cref="CropSell"/>).</param>
/// <param name="farmerRepository">Repository for managing farmers (<see cref="Farmer"/>).</param>
/// <param name="fcRepository">Repository for managing farmer-crop associations (<see cref="FarmerCrop"/>).</param></param>
public class CropBazarService(
    IRepository<Crop, string> cropRepository,
    IRepository<CropBuying, object> cropBRepository,
    IRepository<CropSell, object> cropSRepository,
    IRepository<Farmer, string> farmerRepository,
    IRepository<FarmerCrop, object> fcRepository)
    : ICropBazarService
{
    #region ICropBazarService Members

    /// <inheritdoc/>
    public async Task BuyCrops(
        string farmerId,
        string cropId,
        int quantity)
    {
        var farmer = await farmerRepository.GetByIdAsync(farmerId)
            ?? throw new ArgumentException($"Farmer with id {farmerId} not found.");

        var crop = await cropRepository.GetByIdAsync(cropId)
            ?? throw new ArgumentException($"Crop with id {cropId} not found.");

        var cropB = new CropBuying
        {
            FarmerId = farmer.Id,
            CropId = crop.Id,
            Quantity = quantity,
            BoughtAt = DateTime.UtcNow,
            BuyPricePerCrop = await GetBuyPricePerCrop(crop.Id),
        };

        if (farmer.Coins < cropB.TotalSellPrice)
        {
            throw new ArgumentException($"Farmer with id {farmerId} does not have enough coins.");
        }

        farmer.Coins -= cropB.TotalSellPrice;

        var farmerCrop = await fcRepository
            .GetAllAttached()
            .Where(x => x.FarmerId == farmer.Id && x.CropId == crop.Id)
            .FirstOrDefaultAsync();

        if (farmerCrop is null)
        {
            farmerCrop = new FarmerCrop
            {
                FarmerId = farmer.Id,
                CropId = crop.Id,
                Quantity = quantity,
            };

            await fcRepository.AddAsync(farmerCrop);
        }
        else
        {
            farmerCrop.Quantity += quantity;
            await fcRepository.UpdateAsync(farmerCrop);
        }

        await farmerRepository.UpdateAsync(farmer);

        await cropBRepository.AddAsync(cropB);

        crop.OverallBought += quantity;

        await cropRepository.UpdateAsync(crop);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CropBuying>> GetAllCropBuyings(
        string farmerId)
        => await cropBRepository.GetAllAttached()
            .Where(x => x.FarmerId == farmerId)
            .ToArrayAsync();

    /// <inheritdoc/>
    public async Task<IEnumerable<CropSell>> GetAllCropSells(
        string farmerId)
        => await cropSRepository.GetAllAttached()
            .Where(x => x.FarmerId == farmerId)
            .ToArrayAsync();

    /// <inheritdoc/>
    public async Task<decimal> GetBuyPricePerCrop(
        string cropId)
    {
        var crop = await cropRepository.GetByIdAsync(cropId)
            ?? throw new ArgumentException($"Crop with id {cropId} not found.");

        return crop.Name switch
        {
            "Wheat" => CalculateBuyPrice(44m, crop.OverallBought, crop.OverallSold, 0.2m, 20m, 70m),
            "Bell Pepper" => CalculateBuyPrice(80m, crop.OverallBought, crop.OverallSold, 0.3m, 50m, 120m),
            "Carrot" => CalculateBuyPrice(36m, crop.OverallBought, crop.OverallSold, 0.2m, 20m, 60m),
            "Mushroom" => CalculateBuyPrice(150m, crop.OverallBought, crop.OverallSold, 0.5m, 100m, 250m),
            "Potato" => CalculateBuyPrice(48m, crop.OverallBought, crop.OverallSold, 0.25m, 30m, 80m),
            "Corn" => CalculateBuyPrice(66m, crop.OverallBought, crop.OverallSold, 0.25m, 40m, 100m),
            "Tomato" => CalculateBuyPrice(80m, crop.OverallBought, crop.OverallSold, 0.3m, 50m, 120m),
            "Rice" => CalculateBuyPrice(132m, crop.OverallBought, crop.OverallSold, 0.4m, 100m, 200m),
            "Strawberry" => CalculateBuyPrice(120m, crop.OverallBought, crop.OverallSold, 0.5m, 90m, 200m),
            "Cotton" => CalculateBuyPrice(110m, crop.OverallBought, crop.OverallSold, 0.4m, 80m, 180m),
            "Dragonfruit" => CalculateBuyPrice(400m, crop.OverallBought, crop.OverallSold, 1.2m, 300m, 700m),
            "Blueberry" => CalculateBuyPrice(180m, crop.OverallBought, crop.OverallSold, 0.6m, 130m, 300m),
            "Grapes" => CalculateBuyPrice(300m, crop.OverallBought, crop.OverallSold, 0.8m, 200m, 500m),
            "Pumpkin" => CalculateBuyPrice(100m, crop.OverallBought, crop.OverallSold, 0.35m, 70m, 160m),
            _ => throw new ArgumentException($"Crop with name {crop.Name} not found."),
        };

    }

    /// <inheritdoc/>
    public async Task<decimal> GetSellPricePerCrop(
        string cropId)
    {
        var crop = await cropRepository.GetByIdAsync(cropId)
           ?? throw new ArgumentException($"Crop with id {cropId} not found.");

        return crop.Name switch
        {
            "Wheat" => CalculateSellPrice(10m, crop.OverallBought, crop.OverallSold, 0.05m, 4m, 14m),
            "Bell Pepper" => CalculateSellPrice(20m, crop.OverallBought, crop.OverallSold, 0.08m, 10m, 30m),
            "Carrot" => CalculateSellPrice(11m, crop.OverallBought, crop.OverallSold, 0.06m, 5m, 18m),
            "Mushroom" => CalculateSellPrice(2m, crop.OverallBought, crop.OverallSold, 0.04m, 1m, 5m),
            "Potato" => CalculateSellPrice(20m, crop.OverallBought, crop.OverallSold, 0.07m, 10m, 30m),
            "Corn" => CalculateSellPrice(21m, crop.OverallBought, crop.OverallSold, 0.07m, 10m, 32m),
            "Tomato" => CalculateSellPrice(38m, crop.OverallBought, crop.OverallSold, 0.1m, 20m, 60m),
            "Rice" => CalculateSellPrice(43m, crop.OverallBought, crop.OverallSold, 0.1m, 25m, 65m),
            "Strawberry" => CalculateSellPrice(58m, crop.OverallBought, crop.OverallSold, 0.12m, 35m, 90m),
            "Cotton" => CalculateSellPrice(54m, crop.OverallBought, crop.OverallSold, 0.1m, 30m, 80m),
            "Dragonfruit" => CalculateSellPrice(150m, crop.OverallBought, crop.OverallSold, 0.4m, 100m, 250m),
            "Blueberry" => CalculateSellPrice(88m, crop.OverallBought, crop.OverallSold, 0.15m, 50m, 130m),
            "Grapes" => CalculateSellPrice(60m, crop.OverallBought, crop.OverallSold, 0.12m, 30m, 100m),
            "Pumpkin" => CalculateSellPrice(95m, crop.OverallBought, crop.OverallSold, 0.2m, 50m, 150m),
            _ => throw new ArgumentException($"Crop with name {crop.Name} not found."),
        };

    }

    /// <inheritdoc/>
    public async Task SellCrops(
        string farmerId,
        string cropId,
        int quantity)
    {
        var farmer = await farmerRepository.GetByIdAsync(farmerId)
            ?? throw new ArgumentException($"Farmer with id {farmerId} not found.");

        var crop = await cropRepository.GetByIdAsync(cropId)
            ?? throw new ArgumentException($"Crop with id {cropId} not found.");

        var cropS = new CropSell
        {
            FarmerId = farmer.Id,
            CropId = crop.Id,
            Quantity = quantity,
            SoldAt = DateTime.UtcNow,
            SellPricePerCrop = await GetSellPricePerCrop(crop.Id),
        };

        farmer.Coins += cropS.TotalSellPrice;

        await farmerRepository.UpdateAsync(farmer);

        await cropSRepository.AddAsync(cropS);

        crop.OverallSold += quantity;

        await cropRepository.UpdateAsync(crop);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Crop>> ShowAllCrops()
        => await cropRepository.GetAllAsync();

    #endregion

    private static decimal CalculateBuyPrice(
        decimal basePrice,
        int overallBought,
        int overallSold,
        decimal sensitivity,
        decimal min,
        decimal max)
    {
        var marketFactor = (overallBought - overallSold) * sensitivity;
        var adjustedPrice = basePrice + marketFactor;
        return Math.Min(Math.Max(adjustedPrice, min), max);
    }

    private static decimal CalculateSellPrice(
        decimal basePrice,
        int overallBought,
        int overallSold,
        decimal sensitivity,
        decimal min,
        decimal max)
    {
        var marketFactor = (overallSold - overallBought) * sensitivity;
        var adjustedPrice = basePrice + marketFactor;
        return Math.Min(Math.Max(adjustedPrice, min), max);
    }
}
