using FarmOu.Data.Models;

namespace FarmOu.Infrastructure.Interfaces;

/// <summary>
/// Interface for managing user-related operations such as registration, login, and logout.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="firstName">The firstName of the user to register.</param>
    /// <param name="lastName">The lastName of the user to register.</param>
    /// <param name="username">The username of the user to register.</param>
    /// <param name="email">The email of the user to register.</param>
    /// <param name="password">The password for the user.</param>
    /// <returns>The registered user (Farmer) or null if registration fails.</returns>
    Task<Farmer?> RegisterUserAsync(
        string firstName,
        string lastName,
        string username,
        string email,
        string password);

    /// <summary>
    /// Logs in a user with the provided username and password.
    /// </summary>
    /// <param name="userName">The username of the user to log in.</param>
    /// <param name="password">The password for the user.</param>
    /// <returns>The logged-in user (Farmer) if successful, or null if login fails.</returns>
    Task<Farmer?> LoginUserAsync(
        string userName,
        string password);
}