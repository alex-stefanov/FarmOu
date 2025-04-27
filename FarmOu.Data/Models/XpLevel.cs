using System.ComponentModel.DataAnnotations;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents the experience points (xp) level of a farmer.
/// </summary>
public class XpLevel
{
    /// <summary>
    /// Gets or sets the unique identifier for the xp level.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the numerical value of the level.
    /// </summary>
    [Required]
    public int Level { get; set; } = 1;

    /// <summary>
    /// Gets or sets the needed xp amount for level up.
    /// </summary>
    [Required]
    public int NeededFarmerXp { get; set; }

    /// <summary>
    /// Navigation property for the farmer associated with this xp level.
    /// </summary>
    public virtual ICollection<Farmer> Farmers { get; set; }
        = [];
}
