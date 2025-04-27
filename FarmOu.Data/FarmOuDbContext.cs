using System.Reflection;
using FarmOu.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Data;

/// <summary>
/// Database context for the FarmOu application.
/// </summary>
public class FarmOuDbContext
    : IdentityDbContext<Farmer>
{
    /// <summary>
    /// Db set for farmers.
    /// </summary>
    public override DbSet<Farmer> Users { get; set; }

    /// <summary>
    /// Db set for crops.
    /// </summary>
    public virtual DbSet<Crop> Crops { get; set; } = null!;

    /// <summary>
    /// Db set for xp levels.
    /// </summary>
    public virtual DbSet<XpLevel> XpLevels { get; set; } = null!;

    /// <summary>
    /// Db set for tools.
    /// </summary>
    public virtual DbSet<Tool> Tools { get; set; } = null!;

    /// <summary>
    /// Db set for the crops selling history.
    /// </summary>
    public virtual DbSet<CropSell> CropSells { get; set; } = null!;

    /// <summary>
    /// Db set for the crops buying history.
    /// </summary>
    public virtual DbSet<CropBuying> CropBuyings { get; set; } = null!;

    /// <summary>
    /// Db set for the tools buying history.
    /// </summary>
    public virtual DbSet<ToolBuying> ToolsBuyings { get; set; } = null!;

    /// <summary>
    /// Db set for the many-to-many relationship between farmers and tools.
    /// </summary>
    public virtual DbSet<FarmerTool> FarmersTools { get; set; } = null!;

    /// <summary>
    /// Db set for the many-to-many relationship between farmers and crops.
    /// </summary>
    public virtual DbSet<FarmerCrop> FarmersCrops { get; set; } = null!;

    /// <summary>
    /// Db set for thefmany-to-many relationship between farmers, crops and tools.
    /// </summary>
    public virtual DbSet<FarmingSession> FarmingsSessions { get; set; } = null!;

    /// <summary>
    /// Default constructor for the database context.
    /// </summary>
    public FarmOuDbContext() { }

    /// <summary>
    /// Database Application Context Constructor
    /// </summary>
    /// <param name="options">Options for the DbContext</param>
    public FarmOuDbContext(
        DbContextOptions<FarmOuDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=FarmOu;User Id=sa;Password=Str0ngPa$$w0rd;TrustServerCertificate=True");
        }
    }

    /// <summary>
    /// Method to configure the model creating process.
    /// </summary>
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
