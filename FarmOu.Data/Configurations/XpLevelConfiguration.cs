using FarmOu.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmOu.Data.Configurations;

public class XpLevelConfiguration
    : IEntityTypeConfiguration<XpLevel>
{
    public void Configure(
        EntityTypeBuilder<XpLevel> builder)
    {
        builder
            .HasData(CreateXpLevels());
    }

    private static IEnumerable<XpLevel> CreateXpLevels()
        =>
        [
            new XpLevel { Id = 1, Level = 1, NeededFarmerXp = 100 },
            new XpLevel { Id = 2, Level = 2, NeededFarmerXp = 120 },
            new XpLevel { Id = 3, Level = 3, NeededFarmerXp = 140 },
            new XpLevel { Id = 4, Level = 4, NeededFarmerXp = 160 },
            new XpLevel { Id = 5, Level = 5, NeededFarmerXp = 180 },
            new XpLevel { Id = 6, Level = 6, NeededFarmerXp = 200 },
            new XpLevel { Id = 7, Level = 7, NeededFarmerXp = 220 },
            new XpLevel { Id = 8, Level = 8, NeededFarmerXp = 240 },
            new XpLevel { Id = 9, Level = 9, NeededFarmerXp = 260 },
            new XpLevel { Id = 10, Level = 10, NeededFarmerXp = 280 },
            new XpLevel { Id = 11, Level = 11, NeededFarmerXp = 300 },
            new XpLevel { Id = 12, Level = 12, NeededFarmerXp = 320 },
            new XpLevel { Id = 13, Level = 13, NeededFarmerXp = 340 },
            new XpLevel { Id = 14, Level = 14, NeededFarmerXp = 360 },
            new XpLevel { Id = 15, Level = 15, NeededFarmerXp = 380 },
            new XpLevel { Id = 16, Level = 16, NeededFarmerXp = 400 },
            new XpLevel { Id = 17, Level = 17, NeededFarmerXp = 420 },
            new XpLevel { Id = 18, Level = 18, NeededFarmerXp = 440 },
            new XpLevel { Id = 19, Level = 19, NeededFarmerXp = 460 },
            new XpLevel { Id = 20, Level = 20, NeededFarmerXp = 480 },
            new XpLevel { Id = 21, Level = 21, NeededFarmerXp = 500 },
            new XpLevel { Id = 22, Level = 22, NeededFarmerXp = 520 },
            new XpLevel { Id = 23, Level = 23, NeededFarmerXp = 540 },
            new XpLevel { Id = 24, Level = 24, NeededFarmerXp = 560 },
            new XpLevel { Id = 25, Level = 25, NeededFarmerXp = 580 },
            new XpLevel { Id = 26, Level = 26, NeededFarmerXp = 600 },
            new XpLevel { Id = 27, Level = 27, NeededFarmerXp = 620 },
            new XpLevel { Id = 28, Level = 28, NeededFarmerXp = 640 },
            new XpLevel { Id = 29, Level = 29, NeededFarmerXp = 660 },
            new XpLevel { Id = 30, Level = 30, NeededFarmerXp = 680 },
            new XpLevel { Id = 31, Level = 31, NeededFarmerXp = 700 },
            new XpLevel { Id = 32, Level = 32, NeededFarmerXp = 720 },
            new XpLevel { Id = 33, Level = 33, NeededFarmerXp = 740 },
            new XpLevel { Id = 34, Level = 34, NeededFarmerXp = 760 },
            new XpLevel { Id = 35, Level = 35, NeededFarmerXp = 780 },
            new XpLevel { Id = 36, Level = 36, NeededFarmerXp = 800 },
            new XpLevel { Id = 37, Level = 37, NeededFarmerXp = 820 },
            new XpLevel { Id = 38, Level = 38, NeededFarmerXp = 840 },
            new XpLevel { Id = 39, Level = 39, NeededFarmerXp = 860 },
            new XpLevel { Id = 40, Level = 40, NeededFarmerXp = 880 },
            new XpLevel { Id = 41, Level = 41, NeededFarmerXp = 900 },
            new XpLevel { Id = 42, Level = 42, NeededFarmerXp = 920 },
            new XpLevel { Id = 43, Level = 43, NeededFarmerXp = 940 },
            new XpLevel { Id = 44, Level = 44, NeededFarmerXp = 960 },
            new XpLevel { Id = 45, Level = 45, NeededFarmerXp = 980 },
            new XpLevel { Id = 46, Level = 46, NeededFarmerXp = 1000 },
            new XpLevel { Id = 47, Level = 47, NeededFarmerXp = 1020 },
            new XpLevel { Id = 48, Level = 48, NeededFarmerXp = 1040 },
            new XpLevel { Id = 49, Level = 49, NeededFarmerXp = 1060 },
            new XpLevel { Id = 50, Level = 50, NeededFarmerXp = 1080 },
            new XpLevel { Id = 51, Level = 51, NeededFarmerXp = 1100 },
            new XpLevel { Id = 52, Level = 52, NeededFarmerXp = 1120 },
            new XpLevel { Id = 53, Level = 53, NeededFarmerXp = 1140 },
            new XpLevel { Id = 54, Level = 54, NeededFarmerXp = 1160 },
            new XpLevel { Id = 55, Level = 55, NeededFarmerXp = 1180 },
            new XpLevel { Id = 56, Level = 56, NeededFarmerXp = 1200 },
            new XpLevel { Id = 57, Level = 57, NeededFarmerXp = 1220 },
            new XpLevel { Id = 58, Level = 58, NeededFarmerXp = 1240 },
            new XpLevel { Id = 59, Level = 59, NeededFarmerXp = 1260 },
            new XpLevel { Id = 60, Level = 60, NeededFarmerXp = 0    }
        ];
}