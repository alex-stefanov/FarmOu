using FarmOu.Data.Models;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="userManager">The user manager for managing user-related tasks.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserService(
        UserManager<Farmer> userManager)
    {
        this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
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