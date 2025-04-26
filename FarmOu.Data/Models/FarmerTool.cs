using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a many-to-many relationship between farmers and tools.
/// </summary>
[PrimaryKey(nameof(FarmerId), nameof(ToolId))]
public class FarmerTool
{
    /// <summary>
    /// Gets or sets the unique identifier for the farmer.
    /// </summary>
    public string FarmerId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the farmer associated with the tool.
    /// </summary>
    [ForeignKey(nameof(FarmerId))]
    public virtual Farmer Farmer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the tool.
    /// </summary>
    public string ToolId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the tool associated with the farmer.
    /// </summary>
    [ForeignKey(nameof(ToolId))]
    public virtual Tool Tool { get; set; } = null!;
}
