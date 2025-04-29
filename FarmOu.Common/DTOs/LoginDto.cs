namespace FarmOu.Common.DTOs;

/// <summary>
/// Contains the data transfer object for user login.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; } = null!;
}