using System.ComponentModel.DataAnnotations;
using static FarmOu.Common.Constants.CropConstants;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a crop in the system.
/// </summary>
public class Crop
{
    /// <summary>
    /// Gets or sets the unique identifier for the crop.
    /// </summary>
    [Key]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the crop.
    /// </summary>
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the time harvesting the crop takes.
    /// </summary>
    [Required]
    public int HarvestingTimeInMiliSeconds { get; set; }

    /// <summary>
    /// Gets or sets the xp gained per crop.
    /// </summary>
    [Required]
    public float XpPerHarvest { get; set; }

    /// <summary>
    /// Gets or sets the quantity gained per crop.
    /// </summary>
    [Required]
    public int QuantityPerHarvest { get; set; }

    /// <summary>
    /// Gets or sets how much crops have been sold in total.
    /// </summary>
    [Required]
    public int OverallSold { get; set; } = 0;

    /// <summary>
    /// Gets or sets how much crops have been bought in total.
    /// </summary>
    [Required]
    public int OverallBought { get; set; } = 0;

    /// <summary>
    /// Navigation property for the crops assigned to the farmer.
    /// </summary>
    public virtual ICollection<FarmerCrop> FarmerCrops { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the tools associated with this crop.
    /// </summary>
    public virtual ICollection<Tool> Tools { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the crops sold by a farmer.
    /// </summary>
    public virtual ICollection<CropSell> CropSells { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the crops bought by a farmer.
    /// </summary>
    public virtual ICollection<CropBuying> CropBuyings { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the farming sessions associated with this crop.
    /// </summary>
    public virtual ICollection<FarmingSession> FarmingSessions { get; set; }
         = [];
}