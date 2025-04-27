using FarmOu.Data.Models;
using FarmOu.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmOu.Data.Configurations;

public class ToolConfiguration
    : IEntityTypeConfiguration<Tool>
{
    public void Configure(
        EntityTypeBuilder<Tool> builder)
    {
        builder
            .HasData(CreateTools());
    }

    private static IEnumerable<Tool> CreateTools()
        =>
        [
            new Tool { Id = "0794a9c9-f6d4-4c11-a1c0-f77ee2cac235", Name = "Wheatwind Scythe", LevelNeeded = 5, CropId = "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", Rarity = Rarity.Common, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 500 },
            new Tool { Id = "7e6e5f03-0f1f-43e8-a3d0-9cab05a9a117", Name = "Pepper Pruner", LevelNeeded = 5, CropId = "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", Rarity = Rarity.Common, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 500 },
            new Tool { Id = "b63467bf-8dc6-472a-88f1-af869eefac8a", Name = "Carrot Crescendo", LevelNeeded = 5, CropId = "c5f309e4-6d7f-4g34-1b29-3d4e5f6a7b80", Rarity = Rarity.Common, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 500 },
            new Tool { Id = "7d6cbabc-cbfb-42eb-bd93-590ed5f6f3da", Name = "Fungus Forger", LevelNeeded = 5, CropId = "d6g410f5-7e80-4h45-2c30-4e5f6a7b8c90", Rarity = Rarity.Common, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 500 },
            new Tool { Id = "a4ccf8be-ec77-434c-b454-1d250716547c", Name = "Tater Tamer", LevelNeeded = 5, CropId = "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", Rarity = Rarity.Common, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 500 },
                    
            new Tool { Id = "27f51def-481c-4cf1-b7e9-07aadfe73d60", Name = "Corncob Clarifier", LevelNeeded = 15, CropId = "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", Rarity = Rarity.Epic, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 1000 },
            new Tool { Id = "a2cc6a9a-26a4-4dcf-a2ae-f9527b126fcd", Name = "Tomato Twister", LevelNeeded = 15, CropId = "g9j743i8-0h13-4k78-5f63-7b8c9d0e1f23", Rarity = Rarity.Epic, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 1000 },
            new Tool { Id = "a4f46365-6d04-4780-969e-6ead81d7faca", Name = "Rice Reaper", LevelNeeded = 15, CropId = "h0k854j9-1i24-4l89-6g74-8c9d0e1f2g34", Rarity = Rarity.Epic, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 1000 },
            new Tool { Id = "dcad4c4b-3f28-4e25-b5dd-6a224eb684b3", Name = "Berry Brawler", LevelNeeded = 15, CropId = "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", Rarity = Rarity.Epic, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 1000 },
            new Tool { Id = "16559923-bf70-4f24-846d-4711303ec9b4", Name = "Cotton Cutter", LevelNeeded = 15, CropId = "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", Rarity = Rarity.Epic, GeneralBonusQuantityPerHarvest = 0, GeneralSavingTimeInMiliSeconds = 0, SpecificBonusQuantityPerHarvest = 1, SpecificSavingTimeInMiliSeconds = 1000 },
              
            new Tool { Id = "1e6c2c50-1e05-4a5a-b990-32813b97823c", Name = "Blueberry Blitz", LevelNeeded = 25, CropId = "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", Rarity = Rarity.Legendary, GeneralBonusQuantityPerHarvest = 1, GeneralSavingTimeInMiliSeconds = 1000, SpecificBonusQuantityPerHarvest = 2, SpecificSavingTimeInMiliSeconds = 1500 },
            new Tool { Id = "950d94f9-8487-4380-b3c7-fc533e8d8c89", Name = "Pumpkin Pulverizer", LevelNeeded = 25, CropId = "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", Rarity = Rarity.Legendary, GeneralBonusQuantityPerHarvest = 1, GeneralSavingTimeInMiliSeconds = 1000, SpecificBonusQuantityPerHarvest = 2, SpecificSavingTimeInMiliSeconds = 1500 },
            new Tool { Id = "3566e129-a898-4f81-b1af-1ba89bb1c901", Name = "Dragonfruit Dicer", LevelNeeded = 25, CropId = "k3n187m2-4l57-4o12-9j07-1f2g3h4i5j67", Rarity = Rarity.Legendary, GeneralBonusQuantityPerHarvest = 1, GeneralSavingTimeInMiliSeconds = 1000, SpecificBonusQuantityPerHarvest = 2, SpecificSavingTimeInMiliSeconds = 1500 },
            new Tool { Id = "ac633fba-5c14-4a42-b616-0bd729e5841a", Name = "Grape Grappler", LevelNeeded = 25, CropId = "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", Rarity = Rarity.Legendary, GeneralBonusQuantityPerHarvest = 1, GeneralSavingTimeInMiliSeconds = 1000, SpecificBonusQuantityPerHarvest = 2, SpecificSavingTimeInMiliSeconds = 1500 },
                      
            new Tool { Id = "ad5f3d9f-86cb-4e96-b959-6ef30528e5e1", Name = "Mythic Wheatwind Scythe", LevelNeeded = 35, CropId = "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", Rarity = Rarity.Unique, GeneralBonusQuantityPerHarvest = 2, GeneralSavingTimeInMiliSeconds = 1500, SpecificBonusQuantityPerHarvest = 3, SpecificSavingTimeInMiliSeconds = 2000 },
            new Tool { Id = "76a6c530-ac39-4029-85c2-e67caccdb192", Name = "Mythic Corncob Clarifier", LevelNeeded = 35, CropId = "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", Rarity = Rarity.Unique, GeneralBonusQuantityPerHarvest = 2, GeneralSavingTimeInMiliSeconds = 1500, SpecificBonusQuantityPerHarvest = 3, SpecificSavingTimeInMiliSeconds = 2000 },
            new Tool { Id = "bcba2bf4-969f-4f7d-813c-4810a5f377b7", Name = "Mythic Berry Brawler", LevelNeeded = 35, CropId = "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", Rarity = Rarity.Unique, GeneralBonusQuantityPerHarvest = 2, GeneralSavingTimeInMiliSeconds = 1500, SpecificBonusQuantityPerHarvest = 3, SpecificSavingTimeInMiliSeconds = 2000 },
            new Tool { Id = "8ccd5537-ccd7-4007-88c6-8a1be39127b2", Name = "Mythic Cotton Cutter", LevelNeeded = 35, CropId = "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", Rarity = Rarity.Unique, GeneralBonusQuantityPerHarvest = 2, GeneralSavingTimeInMiliSeconds = 1500, SpecificBonusQuantityPerHarvest = 3, SpecificSavingTimeInMiliSeconds = 2000 },
            new Tool { Id = "34a2d676-241b-43e8-a3dd-67c425570920", Name = "Mythic Grape Grappler", LevelNeeded = 35, CropId = "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", Rarity = Rarity.Unique, GeneralBonusQuantityPerHarvest = 2, GeneralSavingTimeInMiliSeconds = 1500, SpecificBonusQuantityPerHarvest = 3, SpecificSavingTimeInMiliSeconds = 2000 },

            new Tool { Id = "7f22cd92-14b2-4122-8444-d6e4d5ececde", Name = "Godlike Pepper Pruner", LevelNeeded = 50, CropId = "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", Rarity = Rarity.Godlike, GeneralBonusQuantityPerHarvest = 3, GeneralSavingTimeInMiliSeconds = 2000, SpecificBonusQuantityPerHarvest = 4, SpecificSavingTimeInMiliSeconds = 2500 },
            new Tool { Id = "d3adc72a-1d09-454c-a45b-5b3f80f41987", Name = "Godlike Tater Tamer", LevelNeeded = 50, CropId = "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", Rarity = Rarity.Godlike, GeneralBonusQuantityPerHarvest = 3, GeneralSavingTimeInMiliSeconds = 2000, SpecificBonusQuantityPerHarvest = 4, SpecificSavingTimeInMiliSeconds = 2500 },
            new Tool { Id = "3307ec62-9b30-4134-9b99-742d49803994", Name = "Godlike Blueberry Blitz", LevelNeeded = 50, CropId = "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", Rarity = Rarity.Godlike, GeneralBonusQuantityPerHarvest = 3, GeneralSavingTimeInMiliSeconds = 2000, SpecificBonusQuantityPerHarvest = 4, SpecificSavingTimeInMiliSeconds = 2500 },
            new Tool { Id = "9431273a-2df2-466b-94f0-da13e7735b66", Name = "Godlike Pumpkin Pulverizer", LevelNeeded = 50, CropId = "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", Rarity = Rarity.Godlike, GeneralBonusQuantityPerHarvest = 3, GeneralSavingTimeInMiliSeconds = 2000, SpecificBonusQuantityPerHarvest = 4, SpecificSavingTimeInMiliSeconds = 2500 }
        ];
}
