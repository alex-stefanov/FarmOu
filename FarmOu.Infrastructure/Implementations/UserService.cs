using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FarmOu.Infrastructure.Implementations;

/// <summary>
/// Service for handling user-related operations such as registration, login, and logout.
/// </summary>
public class UserService
    : IUserService
{
    private readonly UserManager<Farmer> userManager;
    private readonly IRepository<FarmerTool, object> ftRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="userManager">The user manager for managing user-related tasks.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserService(
        UserManager<Farmer> userManager,
        IRepository<FarmerTool, object> ftRepository)
    {
        this.userManager = userManager 
            ?? throw new ArgumentNullException(nameof(userManager));

        this.ftRepository = ftRepository 
            ?? throw new ArgumentNullException(nameof(ftRepository));
    }

    #region IUserService Members

    ///<inheritdoc/>
    public async Task<Farmer?> RegisterUserAsync(
        string firstName,
        string lastName,
        string username,
        string email,
        string password)
    {
        var farmer = new Farmer
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = username,
            Email = email,
            XpLevelId = 1,
            Coins = 0,
        };

        var result = await userManager
            .CreateAsync(farmer, password);

        if (result.Succeeded)
        {
            var farmerTool = new FarmerTool
            {
                FarmerId = farmer.Id,
                ToolId = "0794a9c9-f6d4-4c11-a1c0-f77ee2cac235",
            };

            await ftRepository.AddAsync(farmerTool);

            return farmer;
        }

        return null;
    }

    ///<inheritdoc/>
    public async Task<Farmer?> LoginUserAsync(
        string userName,
        string password)
    {
        var user = await userManager
            .FindByNameAsync(userName);

        if (user is not null
            && await userManager.CheckPasswordAsync(user, password))
        {
            return user;
        }

        return null;
    }

    #endregion
}