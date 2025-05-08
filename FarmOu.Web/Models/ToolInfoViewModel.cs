namespace FarmOu.Web.Models;

public class ToolInfoViewModel
{
    public required string Name { get; set; }

    public required int LevelNeeded { get; set; }

    public required string UsedForCropIcon { get; set; }

    public required string Rarity { get; set; }

    public required int SpecificSavingTimeInMiliSeconds { get; set; }

    public required int GeneralSavingTimeInMiliSeconds { get; set; }

    public required int SpecificBonusQuantityPerHarvest { get; set; }

    public required int GeneralBonusQuantityPerHarvest { get; set; }

    public required string Icon { get; set; }
}
