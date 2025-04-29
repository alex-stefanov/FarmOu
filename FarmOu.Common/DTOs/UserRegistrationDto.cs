namespace FarmOu.Common.DTOs;

/// <summary>
/// Contains the data transfer object for user registration.
/// </summary>
public class UserRegistrationDto
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string UserName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; } = null!;
}