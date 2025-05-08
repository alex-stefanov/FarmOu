using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmOu.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    HarvestingTimeInMiliSeconds = table.Column<int>(type: "int", nullable: false),
                    XpPerHarvest = table.Column<float>(type: "real", nullable: false),
                    QuantityPerHarvest = table.Column<int>(type: "int", nullable: false),
                    OverallSold = table.Column<int>(type: "int", nullable: false),
                    OverallBought = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XpLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    NeededFarmerXp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XpLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LevelNeeded = table.Column<int>(type: "int", nullable: false),
                    CropId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    SpecificSavingTimeInMiliSeconds = table.Column<int>(type: "int", nullable: false),
                    GeneralSavingTimeInMiliSeconds = table.Column<int>(type: "int", nullable: false),
                    SpecificBonusQuantityPerHarvest = table.Column<int>(type: "int", nullable: false),
                    GeneralBonusQuantityPerHarvest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Coins = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    XpLevelId = table.Column<int>(type: "int", nullable: false),
                    CurrentFarmerXp = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_XpLevels_XpLevelId",
                        column: x => x.XpLevelId,
                        principalTable: "XpLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropBuyings",
                columns: table => new
                {
                    CropId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BuyPricePerCrop = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BoughtAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropBuyings", x => new { x.FarmerId, x.CropId });
                    table.ForeignKey(
                        name: "FK_CropBuyings_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropBuyings_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropSells",
                columns: table => new
                {
                    CropId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellPricePerCrop = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoldAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropSells", x => new { x.FarmerId, x.CropId });
                    table.ForeignKey(
                        name: "FK_CropSells_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropSells_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmersCrops",
                columns: table => new
                {
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CropId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmersCrops", x => new { x.FarmerId, x.CropId });
                    table.ForeignKey(
                        name: "FK_FarmersCrops_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmersCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmersTools",
                columns: table => new
                {
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToolId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmersTools", x => new { x.FarmerId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_FarmersTools_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmersTools_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmingsSessions",
                columns: table => new
                {
                    CropId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HarvestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FarmedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmingsSessions", x => new { x.HarvestedAt, x.CropId, x.FarmerId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_FarmingsSessions_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmingsSessions_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmingsSessions_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ToolsBuyings",
                columns: table => new
                {
                    ToolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BoughtAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolsBuyings", x => new { x.FarmerId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_ToolsBuyings_AspNetUsers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToolsBuyings_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crops",
                columns: new[] { "Id", "HarvestingTimeInMiliSeconds", "Name", "OverallBought", "OverallSold", "QuantityPerHarvest", "XpPerHarvest" },
                values: new object[,]
                {
                    { "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", 2500, "Wheat", 0, 0, 4, 8f },
                    { "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", 3000, "Bell Pepper", 0, 0, 2, 5f },
                    { "c5f309e4-6d7f-4g34-1b29-3d4e5f6a7b80", 3500, "Carrot", 0, 0, 3, 9f },
                    { "d6g410f5-7e80-4h45-2c30-4e5f6a7b8c90", 4000, "Mushroom", 0, 0, 1, 30f },
                    { "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", 4500, "Potato", 0, 0, 2, 10f },
                    { "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", 6000, "Corn", 0, 0, 3, 12f },
                    { "g9j743i8-0h13-4k78-5f63-7b8c9d0e1f23", 7000, "Tomato", 0, 0, 2, 15f },
                    { "h0k854j9-1i24-4l89-6g74-8c9d0e1f2g34", 9000, "Rice", 0, 0, 3, 16f },
                    { "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", 10000, "Strawberry", 0, 0, 2, 18f },
                    { "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", 12000, "Cotton", 0, 0, 2, 20f },
                    { "k3n187m2-4l57-4o12-9j07-1f2g3h4i5j67", 12500, "Dragonfruit", 0, 0, 2, 28f },
                    { "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", 13000, "Blueberry", 0, 0, 2, 22f },
                    { "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", 14000, "Grapes", 0, 0, 3, 18f },
                    { "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", 15000, "Pumpkin", 0, 0, 1, 25f }
                });

            migrationBuilder.InsertData(
                table: "XpLevels",
                columns: new[] { "Id", "Level", "NeededFarmerXp" },
                values: new object[,]
                {
                    { 1, 1, 100 },
                    { 2, 2, 120 },
                    { 3, 3, 140 },
                    { 4, 4, 160 },
                    { 5, 5, 180 },
                    { 6, 6, 200 },
                    { 7, 7, 220 },
                    { 8, 8, 240 },
                    { 9, 9, 260 },
                    { 10, 10, 280 },
                    { 11, 11, 300 },
                    { 12, 12, 320 },
                    { 13, 13, 340 },
                    { 14, 14, 360 },
                    { 15, 15, 380 },
                    { 16, 16, 400 },
                    { 17, 17, 420 },
                    { 18, 18, 440 },
                    { 19, 19, 460 },
                    { 20, 20, 480 },
                    { 21, 21, 500 },
                    { 22, 22, 520 },
                    { 23, 23, 540 },
                    { 24, 24, 560 },
                    { 25, 25, 580 },
                    { 26, 26, 600 },
                    { 27, 27, 620 },
                    { 28, 28, 640 },
                    { 29, 29, 660 },
                    { 30, 30, 680 },
                    { 31, 31, 700 },
                    { 32, 32, 720 },
                    { 33, 33, 740 },
                    { 34, 34, 760 },
                    { 35, 35, 780 },
                    { 36, 36, 800 },
                    { 37, 37, 820 },
                    { 38, 38, 840 },
                    { 39, 39, 860 },
                    { 40, 40, 880 },
                    { 41, 41, 900 },
                    { 42, 42, 920 },
                    { 43, 43, 940 },
                    { 44, 44, 960 },
                    { 45, 45, 980 },
                    { 46, 46, 1000 },
                    { 47, 47, 1020 },
                    { 48, 48, 1040 },
                    { 49, 49, 1060 },
                    { 50, 50, 1080 },
                    { 51, 51, 1100 },
                    { 52, 52, 1120 },
                    { 53, 53, 1140 },
                    { 54, 54, 1160 },
                    { 55, 55, 1180 },
                    { 56, 56, 1200 },
                    { 57, 57, 1220 },
                    { 58, 58, 1240 },
                    { 59, 59, 1260 },
                    { 60, 60, 0 }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CropId", "GeneralBonusQuantityPerHarvest", "GeneralSavingTimeInMiliSeconds", "LevelNeeded", "Name", "Rarity", "SpecificBonusQuantityPerHarvest", "SpecificSavingTimeInMiliSeconds" },
                values: new object[,]
                {
                    { "0794a9c9-f6d4-4c11-a1c0-f77ee2cac235", "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", 0, 0, 1, "Wheatwind Scythe", 0, 1, 500 },
                    { "16559923-bf70-4f24-846d-4711303ec9b4", "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", 0, 0, 15, "Cotton Cutter", 1, 1, 1000 },
                    { "1e6c2c50-1e05-4a5a-b990-32813b97823c", "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", 1, 1000, 25, "Blueberry Blitz", 2, 2, 1500 },
                    { "27f51def-481c-4cf1-b7e9-07aadfe73d60", "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", 0, 0, 15, "Corncob Clarifier", 1, 1, 1000 },
                    { "3307ec62-9b30-4134-9b99-742d49803994", "l4o298n3-5m68-4p23-0k18-2g3h4i5j6k78", 3, 2000, 50, "Godlike Blueberry Blitz", 5, 4, 2500 },
                    { "34a2d676-241b-43e8-a3dd-67c425570920", "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", 2, 1500, 35, "Mythic Grape Grappler", 4, 3, 2000 },
                    { "3566e129-a898-4f81-b1af-1ba89bb1c901", "k3n187m2-4l57-4o12-9j07-1f2g3h4i5j67", 1, 1000, 25, "Dragonfruit Dicer", 2, 2, 1500 },
                    { "76a6c530-ac39-4029-85c2-e67caccdb192", "f8i632h7-9g02-4j67-4e52-6a7b8c9d0e12", 2, 1500, 35, "Mythic Corncob Clarifier", 4, 3, 2000 },
                    { "7d6cbabc-cbfb-42eb-bd93-590ed5f6f3da", "d6g410f5-7e80-4h45-2c30-4e5f6a7b8c90", 0, 0, 5, "Fungus Forger", 0, 1, 500 },
                    { "7e6e5f03-0f1f-43e8-a3d0-9cab05a9a117", "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", 0, 0, 5, "Pepper Pruner", 0, 1, 500 },
                    { "7f22cd92-14b2-4122-8444-d6e4d5ececde", "b4e2f8d3-5c6e-4f23-8a18-2c3d4e5f6a70", 3, 2000, 50, "Godlike Pepper Pruner", 5, 4, 2500 },
                    { "8ccd5537-ccd7-4007-88c6-8a1be39127b2", "j2m076l1-3k46-4n01-8i96-0e1f2g3h4i56", 2, 1500, 35, "Mythic Cotton Cutter", 4, 3, 2000 },
                    { "9431273a-2df2-466b-94f0-da13e7735b66", "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", 3, 2000, 50, "Godlike Pumpkin Pulverizer", 5, 4, 2500 },
                    { "950d94f9-8487-4380-b3c7-fc533e8d8c89", "n6q410p5-7o80-4r45-2m30-4i5j6k7l8m90", 1, 1000, 25, "Pumpkin Pulverizer", 2, 2, 1500 },
                    { "a2cc6a9a-26a4-4dcf-a2ae-f9527b126fcd", "g9j743i8-0h13-4k78-5f63-7b8c9d0e1f23", 0, 0, 15, "Tomato Twister", 1, 1, 1000 },
                    { "a4ccf8be-ec77-434c-b454-1d250716547c", "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", 0, 0, 5, "Tater Tamer", 0, 1, 500 },
                    { "a4f46365-6d04-4780-969e-6ead81d7faca", "h0k854j9-1i24-4l89-6g74-8c9d0e1f2g34", 0, 0, 15, "Rice Reaper", 1, 1, 1000 },
                    { "ac633fba-5c14-4a42-b616-0bd729e5841a", "m5p309o4-6n79-4q34-1l29-3h4i5j6k7l89", 1, 1000, 25, "Grape Grappler", 2, 2, 1500 },
                    { "ad5f3d9f-86cb-4e96-b959-6ef30528e5e1", "a3f1e7c2-4b5d-4e12-9f07-1b2c3d4e5f60", 2, 1500, 35, "Mythic Wheatwind Scythe", 4, 3, 2000 },
                    { "b63467bf-8dc6-472a-88f1-af869eefac8a", "c5f309e4-6d7f-4g34-1b29-3d4e5f6a7b80", 0, 0, 5, "Carrot Crescendo", 0, 1, 500 },
                    { "bcba2bf4-969f-4f7d-813c-4810a5f377b7", "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", 2, 1500, 35, "Mythic Berry Brawler", 4, 3, 2000 },
                    { "d3adc72a-1d09-454c-a45b-5b3f80f41987", "e7h521g6-8f91-4i56-3d41-5f6a7b8c9d01", 3, 2000, 50, "Godlike Tater Tamer", 5, 4, 2500 },
                    { "dcad4c4b-3f28-4e25-b5dd-6a224eb684b3", "i1l965k0-2j35-4m90-7h85-9d0e1f2g3h45", 0, 0, 15, "Berry Brawler", 1, 1, 1000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_XpLevelId",
                table: "AspNetUsers",
                column: "XpLevelId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CropBuyings_CropId",
                table: "CropBuyings",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_CropSells_CropId",
                table: "CropSells",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmersCrops_CropId",
                table: "FarmersCrops",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmersTools_ToolId",
                table: "FarmersTools",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmingsSessions_CropId",
                table: "FarmingsSessions",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmingsSessions_FarmerId",
                table: "FarmingsSessions",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmingsSessions_ToolId",
                table: "FarmingsSessions",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_CropId",
                table: "Tools",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolsBuyings_ToolId",
                table: "ToolsBuyings",
                column: "ToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CropBuyings");

            migrationBuilder.DropTable(
                name: "CropSells");

            migrationBuilder.DropTable(
                name: "FarmersCrops");

            migrationBuilder.DropTable(
                name: "FarmersTools");

            migrationBuilder.DropTable(
                name: "FarmingsSessions");

            migrationBuilder.DropTable(
                name: "ToolsBuyings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "XpLevels");

            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
