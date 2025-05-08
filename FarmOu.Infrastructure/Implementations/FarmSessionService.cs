using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Infrastructure.Implementations;

/// <summary>
/// Implements management of farming sessions, linking farmers with crops and tools
/// over specified time intervals, and handling related persistence.
/// </summary>
/// <param name="farmerRepository">Repository for managing <see cref="Farmer"/> entities.</param>
/// <param name="cropRepository">Repository for managing <see cref="Crop"/> entities.</param>
/// <param name="toolRepository">Repository for managing <see cref="Tool"/> entities.</param>
/// <param name="xpLevelRepository">Repository for retrieving <see cref="XpLevel"/> thresholds.</param>
/// <param name="fsRepository">Repository for persisting <see cref="FarmingSession"/> records.</param>
/// <param name="fcRepository">Repository for managing farmer-crop links (<see cref="FarmerCrop"/>).</param>
public class FarmSessionService(
    IRepository<Farmer, string> farmerRepository,
    IRepository<Crop, string> cropRepository,
    IRepository<Tool, string> toolRepository,
    IRepository<XpLevel, int> xpLevelRepository,
    IRepository<FarmingSession, object> fsRepository,
    IRepository<FarmerCrop, object> fcRepository)
    : IFarmSessionService
{
    #region IFarmSessionService Members

    /// <inheritdoc/>
    public async Task<int> CreateSession(
        string farmerId,
        string cropId,
        string toolId,
        DateTime startTime,
        DateTime endTime)
    {
        var farmer = await farmerRepository
            .GetByIdAsync(farmerId)
            ?? throw new ArgumentException($"Farmer with id {farmerId} not found.");

        var crop = await cropRepository
            .GetByIdAsync(cropId)
            ?? throw new ArgumentException($"Crop with id {cropId} not found.");

        var tool = await toolRepository
            .GetByIdAsync(toolId)
            ?? throw new ArgumentException($"Tool with id {toolId} not found.");

        TimeSpan span = endTime - startTime;

        double totalMs = span.TotalMilliseconds;

        long msTruncated = (long)totalMs;

        long savedTimePerCrop;
        int bonusQuantityPerHarvest;

        if (tool.CropId == crop.Id)
        {
            savedTimePerCrop = tool.SpecificSavingTimeInMiliSeconds;
            bonusQuantityPerHarvest = tool.SpecificBonusQuantityPerHarvest;
        }
        else
        {
            savedTimePerCrop = tool.GeneralSavingTimeInMiliSeconds;
            bonusQuantityPerHarvest = tool.GeneralBonusQuantityPerHarvest;
        }

        int harvestedCrops = (int)(msTruncated / (crop.HarvestingTimeInMiliSeconds - savedTimePerCrop));

        int quantityCrops = harvestedCrops * (crop.QuantityPerHarvest + bonusQuantityPerHarvest);

        float xpGained = harvestedCrops * crop.XpPerHarvest;

        var farmingSession = new FarmingSession
        {
            CropId = crop.Id,
            FarmerId = farmer.Id,
            ToolId = tool.Id,
            HarvestedAt = startTime,
            Duration = span,
            FarmedQuantity = quantityCrops,
        };

        farmer.CurrentFarmerXp += (int)xpGained;

        int levelId = farmer.XpLevelId;
        int currentXp = farmer.CurrentFarmerXp;

        while (true)
        {
            var xpLevel = await xpLevelRepository
                .GetByIdAsync(levelId)
                ?? throw new ArgumentException($"XP Level with id {levelId} not found.");

            if (currentXp < xpLevel.NeededFarmerXp)
                break;

            currentXp -= xpLevel.NeededFarmerXp;
            levelId++;
        }

        farmer.XpLevelId = levelId;
        farmer.CurrentFarmerXp = currentXp;

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
                Quantity = quantityCrops,
            };

            await fcRepository.AddAsync(farmerCrop);
        }
        else
        {
            farmerCrop.Quantity += quantityCrops;
            await fcRepository.UpdateAsync(farmerCrop);
        }

        await farmerRepository.UpdateAsync(farmer);
        await fsRepository.AddAsync(farmingSession);

        return quantityCrops;
    }

    #endregion
}
