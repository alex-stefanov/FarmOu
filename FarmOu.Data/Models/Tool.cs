using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FarmOu.Data.Models.Enums;
using static FarmOu.Common.Constants.ToolConstants;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a tool in the system.
/// </summary>
public class Tool
{
    /// <summary>
    /// Gets or sets the unique identifier for the tool.
    /// </summary>
    [Key]
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the tool.
    /// </summary>
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the numerical value of the level needed for usage of this tool.
    /// </summary>
    [Required]
    public int LevelNeeded { get; set; }

    /// <summary>
    /// Gets or sets the crop id of the crop that this tool is used for.
    /// </summary>
    [Required]
    public string CropId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crop associated with this tool.
    /// </summary>
    [ForeignKey(nameof(CropId))]
    public virtual Crop Crop { get; set; } = null!;

    /// <summary>
    /// Gets or sets the rarity of the tool.
    /// </summary>
    [Required]
    public Rarity Rarity { get; set; }

    /// <summary>
    /// Gets or sets the time the tool saves when harvesting the specified crop.
    /// </summary>
    [Required]
    public int SpecificSavingTimeInMiliSeconds { get; set; }

    /// <summary>
    /// Gets or sets the time the tool saves when harvesting all other crops.
    /// </summary>
    [Required]
    public int GeneralSavingTimeInMiliSeconds { get; set; }

    /// <summary>
    /// Gets or sets the bonus quantity the tool gives when harvesting the specified crop.
    /// </summary>
    [Required]
    public int SpecificBonusQuantityPerHarvest { get; set; }

    /// <summary>
    /// Gets or sets the bonus quantity the tool gives when harvesting all other crops.
    /// </summary>
    [Required]
    public int GeneralBonusQuantityPerHarvest { get; set; }

    /// <summary>
    /// Navigation property for the tools assigned to the farmer.
    /// </summary>
    public virtual ICollection<FarmerTool> FarmerTools { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the tools bought by a farmer.
    /// </summary>
    public virtual ICollection<ToolBuying> ToolBuyings { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the farming sessions the tool has been used in.
    /// </summary>
    public virtual ICollection<FarmingSession> FarmingSessions { get; set; }
         = [];
}
