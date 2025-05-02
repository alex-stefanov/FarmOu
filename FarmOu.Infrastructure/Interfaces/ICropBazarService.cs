using FarmOu.Data.Models;

namespace FarmOu.Infrastructure.Interfaces;

/// <summary>
/// Defines operations for browsing, buying, and selling crops in the Crop Bazaar.
/// </summary>
public interface ICropBazarService
{
    /// <summary>
    /// Retrieves the full list of available crops.
    /// </summary>
    /// <returns>
    /// A collection of <see cref="Crop"/> representing all available crops.
    /// </returns>
    Task<IEnumerable<Crop>> ShowAllCrops();

    /// <summary>
    /// Allows a farmer to buy a specified quantity of a crop.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer making the purchase.</param>
    /// <param name="cropId">The unique identifier of the crop to purchase.</param>
    /// <param name="quantity">The number of units of the crop to buy.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task BuyCrops(
        string farmerId,
        string cropId,
        int quantity);

    /// <summary>
    /// Allows a farmer to sell a specified quantity of a crop they own.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer making the sale.</param>
    /// <param name="cropId">The unique identifier of the crop to sell.</param>
    /// <param name="quantity">The number of units of the crop to sell.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task SellCrops(
        string farmerId,
        string cropId,
        int quantity);

    /// <summary>
    /// Retrieves all crop buy transactions for a given farmer.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer.</param>
    /// <returns>
    /// A collection of <see cref="CropBuying"/> representing the farmer's purchase history.
    /// </returns>
    Task<IEnumerable<CropBuying>> GetAllCropBuyings(
        string farmerId);

    /// <summary>
    /// Retrieves all crop sell transactions for a given farmer.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer.</param>
    /// <returns>
    /// A collection of <see cref="CropSell"/> representing the farmer's sales history.
    /// </returns>
    Task<IEnumerable<CropSell>> GetAllCropSells(
        string farmerId);

    /// <summary>
    /// Gets the current buying price per unit for a specific crop.
    /// </summary>
    /// <param name="cropId">The unique identifier of the crop.</param>
    /// <returns>
    /// A <see cref="decimal"/> representing the price to buy one unit of the crop.
    /// </returns>
    Task<decimal> GetBuyPricePerCrop(
        string cropId);

    /// <summary>
    /// Gets the current selling price per unit for a specific crop.
    /// </summary>
    /// <param name="cropId">The unique identifier of the crop.</param>
    /// <returns>
    /// A <see cref="decimal"/> representing the price to sell one unit of the crop.</returns>
    Task<decimal> GetSellPricePerCrop(
        string cropId);
}
