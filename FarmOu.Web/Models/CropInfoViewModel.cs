namespace FarmOu.Web.Models;

public class CropInfoViewModel
{
    public required string Name { get; set; }

    public required string Icon { get; set; }

    public required int HarvestingTimeInMiliseconds { get; set; }

    public required float XpPerHarvest { get; set; }

    public required int QuantityPerHarvest { get; set; }

    public required int OverallSold { get; set; }

    public required int OverallBought { get; set; }
}
