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
    public string Id { get; set; }
        = Guid.NewGuid().ToString();

    /// <summary>
    /// Gets or sets the numerical value of the level.
    /// </summary>
    [Required]
    public int Level { get; set; } = 1;

    /// <summary>
    /// Gets or sets the current xp at the specified level.
    /// </summary>
    [Required]
    public int CurrentFarmerXp { get; set; } = 0;

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
