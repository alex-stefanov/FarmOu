using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FarmOu;

/// <summary>
/// Startup class for the application.
/// </summary>
public class StartUp
{
    /// <summary>
    /// Main method to initialize and run the application.
    /// </summary>
    public async static Task Main(
        string[] args)
    {
        var context = new FarmOuDbContext();

        #region User Manager

        var userStore = new UserStore<Farmer>(context);
        var options = new OptionsWrapper<IdentityOptions>(new IdentityOptions());
        var passwordHasher = new PasswordHasher<Farmer>();
        var userValidator = new UserValidator<Farmer>();
        var passwordValidator = new PasswordValidator<Farmer>();
        var keyNormalizer = new UpperInvariantLookupNormalizer();
        var errors = new IdentityErrorDescriber();

        var userManager = new UserManager<Farmer>(
            userStore,
            options,
            passwordHasher,
            [userValidator],
            [passwordValidator],
            keyNormalizer,
            errors,
            null!,
            null!
        );

        #endregion

        #region Register Repositories

        var cropRepository = new Repository<Crop, string>(context);
        var cropBuyingRepository = new Repository<CropBuying, string>(context);
        var cropSellRepository = new Repository<CropSell, string>(context);

        var farmerRepository = new Repository<Farmer, string>(context);
        var farmerCropRepository = new Repository<FarmerCrop, string>(context);
        var farmerToolRepository = new Repository<FarmerTool, string>(context);
        var farmingSessionRepository = new Repository<FarmingSession, string>(context);

        var toolRepository = new Repository<Tool, string>(context);
        var toolBuyingRepository = new Repository<ToolBuying, string>(context);
        var xpLevelRepository = new Repository<XpLevel, int>(context);

        #endregion

        #region Register Services

        var userService = new UserService(userManager);

        #endregion

        await Application.RunAsync(userService);
    }
}