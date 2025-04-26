using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static FarmOu.Common.Constants.UserConstants;

namespace FarmOu.Data.Models;

/// <summary>
/// Represents a user in the system, extending from IdentityUser.
/// </summary>
public class Farmer
    : IdentityUser
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [Required]
    [PersonalData]
    [MaxLength(FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [Required]
    [PersonalData]
    [MaxLength(LastNameMaxLength)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the number of coins the user has.
    /// </summary>
    [Required]
    public decimal Coins { get; set; } = 0;

    /// <summary>
    /// Gets or sets the unique identifier of the level the farmer is.
    /// </summary>
    [Required]
    public string XpLevelId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the level of the farmer.
    /// </summary>
    [ForeignKey(nameof(XpLevelId))]
    public virtual XpLevel XpLevel { get; set; } = null!;

    /// <summary>
    /// Navigation property for the crops assigned to the farmer.
    /// </summary>
    public virtual ICollection<FarmerCrop> FarmerCrops { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the tools assigned to the farmer.
    /// </summary>
    public virtual ICollection<FarmerTool> FarmerTools { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the crops sold by the farmer.
    /// </summary>
    public virtual ICollection<CropSell> CropSells { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the crops bought by the farmer.
    /// </summary>
    public virtual ICollection<CropBuying> CropBuyings { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the tools bought by the farmer.
    /// </summary>
    public virtual ICollection<ToolBuying> ToolBuyings { get; set; }
        = [];

    /// <summary>
    /// Navigation property for the farming sessions of the farmer.
    /// </summary>
    public virtual ICollection<FarmingSession> FarmingSessions { get; set; }
        = [];
}
