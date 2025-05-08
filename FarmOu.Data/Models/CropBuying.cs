using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a crop buying in the system.
/// </summary>
[PrimaryKey(nameof(BoughtAt), nameof(FarmerId), nameof(CropId))]
public class CropBuying
{
    /// <summary>
    /// Gets or sets the crop id of the crop that was bought.
    /// </summary>
    [Required]
    public string CropId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crop that was bought.
    /// </summary>
    [ForeignKey(nameof(CropId))]
    public virtual Crop Crop { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the farmer.
    /// </summary>
    [Required]
    public string FarmerId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the farmer associated with the buying.
    /// </summary>
    [ForeignKey(nameof(FarmerId))]
    public virtual Farmer Farmer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quantity of the crop associated with the buying.
    /// </summary>
    [Required]
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price per quantity.
    /// </summary>
    [Required]
    public decimal BuyPricePerCrop { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the crop was bought.
    /// </summary>
    [Required]
    public DateTime BoughtAt { get; set; }
        = DateTime.UtcNow;

    /// <summary>
    /// Gets the total price of the buying.
    /// </summary>
    public decimal TotalSellPrice
        => this.BuyPricePerCrop * this.Quantity;
}
