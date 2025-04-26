using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a farming session in the system.
/// </summary>
[PrimaryKey(nameof(CropId), nameof(FarmerId), nameof(ToolId))]
public class FarmingSession
{
    /// <summary>
    /// Gets or sets the crop id of the crop that was harvested.
    /// </summary>
    [Required]
    public string CropId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crop that was harvested.
    /// </summary>
    [ForeignKey(nameof(CropId))]
    public virtual Crop Crop { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the farmer.
    /// </summary>
    [Required]
    public string FarmerId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the farmer associated with the harvesting.
    /// </summary>
    [ForeignKey(nameof(FarmerId))]
    public virtual Farmer Farmer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the tool id of the tool that was used for the harvesting.
    /// </summary>
    [Required]
    public string ToolId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the tool that was used for the harvesting.
    /// </summary>
    [ForeignKey(nameof(ToolId))]
    public virtual Tool Tool { get; set; } = null!;

    /// <summary>
    /// Gets or sets the time at which the harvesting started.
    /// </summary>
    [Required]
    public DateTime HarvestedAt { get; set; }
        = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the duration of the harvesting session.
    /// </summary>
    [Required]
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets or sets the time at which the harvesting ended.
    /// </summary>
    public DateTime HarvestedEndedAt
        => this.HarvestedAt.Add(this.Duration);

    /// <summary>
    /// Gets or sets the quantity of the crop that was harvested.
    /// </summary>
    [Required]
    public int FarmedQuantity { get; set; }
}
