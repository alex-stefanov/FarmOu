using FarmOu.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmOu.Data.Configurations;

/// <summary>
/// Configuration class for the Crop entity.
/// </summary>
public class CropConfiguration
    : IEntityTypeConfiguration<Crop>
{
    /// <summary>
    /// Method to configure the Crop entity.
    /// </summary>
    /// <param name="builder">the entity type builder</param>
    public void Configure(
        EntityTypeBuilder<Crop> builder)
    {
        builder
            .HasData(CreateCrops());
    }

    private static IEnumerable<Crop> CreateCrops()
        =>
        [
            new Crop { Id = "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", Name = "Wheat",       HarvestingTimeInMiliSeconds = 2500,  XpPerHarvest = 8,  QuantityPerHarvest = 4, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", Name = "Bell Pepper", HarvestingTimeInMiliSeconds = 3000,  XpPerHarvest = 5,  QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "c5f309e4-6d7f-4g34-1b29-3d4e5f6a7b80", Name = "Carrot",      HarvestingTimeInMiliSeconds = 3500,  XpPerHarvest = 9,  QuantityPerHarvest = 3, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "d6g410f5-7e80-4h45-2c30-4e5f6a7b8c90", Name = "Mushroom",    HarvestingTimeInMiliSeconds = 4000,  XpPerHarvest = 30, QuantityPerHarvest = 1, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", Name = "Potato",      HarvestingTimeInMiliSeconds = 4500,  XpPerHarvest = 10, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", Name = "Corn",        HarvestingTimeInMiliSeconds = 6000,  XpPerHarvest = 12, QuantityPerHarvest = 3, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "g9j743i8-0h13-4k78-5f63-7b8c9d0e1f23", Name = "Tomato",      HarvestingTimeInMiliSeconds = 7000,  XpPerHarvest = 15, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "h0k854j9-1i24-4l89-6g74-8c9d0e1f2g34", Name = "Rice",        HarvestingTimeInMiliSeconds = 9000,  XpPerHarvest = 16, QuantityPerHarvest = 3, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", Name = "Strawberry",  HarvestingTimeInMiliSeconds = 10000, XpPerHarvest = 18, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", Name = "Cotton",      HarvestingTimeInMiliSeconds = 12000, XpPerHarvest = 20, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "k3n187m2-4l57-4o12-9j07-1f2g3h4i5j67", Name = "Dragonfruit", HarvestingTimeInMiliSeconds = 12500, XpPerHarvest = 28, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", Name = "Blueberry",   HarvestingTimeInMiliSeconds = 13000, XpPerHarvest = 22, QuantityPerHarvest = 2, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", Name = "Grapes",      HarvestingTimeInMiliSeconds = 14000, XpPerHarvest = 18, QuantityPerHarvest = 3, OverallSold = 0, OverallBought = 0 },
            new Crop { Id = "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", Name = "Pumpkin",     HarvestingTimeInMiliSeconds = 15000, XpPerHarvest = 25, QuantityPerHarvest = 1, OverallSold = 0, OverallBought = 0 }
        ];
}
