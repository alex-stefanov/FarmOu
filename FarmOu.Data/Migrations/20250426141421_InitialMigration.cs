using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    HarvestingTimeInSeconds = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CurrentFarmerXp = table.Column<int>(type: "int", nullable: false),
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
                    SpecificSavingTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    GeneralSavingTimeInSeconds = table.Column<int>(type: "int", nullable: false),
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
                    XpLevelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_FarmingsSessions", x => new { x.CropId, x.FarmerId, x.ToolId });
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
