using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a tool buying in the system.
/// </summary>
[PrimaryKey(nameof(FarmerId), nameof(ToolId))]
public class ToolBuying
{
    /// <summary>
    /// Gets or sets the tool id of the tool that was bought.
    /// </summary>
    [Required]
    public string ToolId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the tool that was bought.
    /// </summary>
    [ForeignKey(nameof(ToolId))]
    public virtual Tool Tool { get; set; } = null!;

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
    /// Gets or sets the price.
    /// </summary>
    [Required]
    public decimal BuyPrice { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the tool was bought.
    /// </summary>
    [Required]
    public DateTime BoughtAt { get; set; }
        = DateTime.UtcNow;
}
