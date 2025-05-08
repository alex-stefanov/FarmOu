using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a crop sell in the system.
/// </summary>
[PrimaryKey(nameof(SoldAt), nameof(FarmerId), nameof(CropId))]
public class CropSell
{
    /// <summary>
    /// Gets or sets the crop id of the crop that was sold.
    /// </summary>
    [Required]
    public string CropId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crop that was sold.
    /// </summary>
    [ForeignKey(nameof(CropId))]
    public virtual Crop Crop { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the farmer.
    /// </summary>
    [Required]
    public string FarmerId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the farmer associated with the sell.
    /// </summary>
    [ForeignKey(nameof(FarmerId))]
    public virtual Farmer Farmer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quantity of the crop associated with the sell.
    /// </summary>
    [Required]
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price per quantity.
    /// </summary>
    [Required]
    public decimal SellPricePerCrop { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the crop was sold.
    /// </summary>
    [Required]
    public DateTime SoldAt { get; set; }
        = DateTime.UtcNow;

    /// <summary>
    /// Gets the total price of the sell.
    /// </summary>
    public decimal TotalSellPrice
        => this.SellPricePerCrop * this.Quantity;
}