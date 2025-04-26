using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a many-to-many relationship between farmers and crops.
/// </summary>
[PrimaryKey(nameof(FarmerId), nameof(CropId))]
public class FarmerCrop
{
    /// <summary>
    /// Gets or sets the unique identifier for the farmer.
    /// </summary>
    public string FarmerId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the farmer associated with the crop.
    /// </summary>
    [ForeignKey(nameof(FarmerId))]
    public virtual Farmer Farmer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the crop.
    /// </summary>
    public string CropId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crop associated with the farmer.
    /// </summary>
    [ForeignKey(nameof(CropId))]
    public virtual Crop Crop { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quantity of the crop owned by the farmer.
    /// </summary>
    public int Quantity { get; set; }
}
