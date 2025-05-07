using System.Text;
using FarmOu.Common.Constants;
using FarmOu.Common.DTOs;
using FarmOu.Data.Models;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.UI.Menus;

/// <summary>
/// Menu for user authentication, including registration and login.
/// </summary>
public static class UserMenu
{
    /// <summary>
    /// Displays the authentication menu for the user.
    /// </summary>
    /// <param name="userService">the user service needed for the logic</param>
    public static async Task<Farmer?> ShowAuthMenu(
        IUserService userService)
    {
        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MenuConstants.Logo);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n  [R] Register ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  [L] Login ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  [ESC] Back");
            Console.ResetColor();

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.R:
                    var registerDto = await RegisterUser();

                    if (registerDto is not null)
                    {
                        var newfarmer = await userService.RegisterUserAsync(
                            registerDto.FirstName,
                            registerDto.LastName,
                            registerDto.UserName,
                            registerDto.Email,
                            registerDto.Password);

                        if (newfarmer is null)
                        {
                            ShowError("Registration failed. Please try again.");
                            return null;
                        }

                        return newfarmer!;
                    }

                    break;

                case ConsoleKey.L:
                    var loginDto = await Login();

                    if (loginDto is not null)
                    {
                        var farmer = await userService.LoginUserAsync(
                            loginDto.Username,
                            loginDto.Password);

                        if (farmer is null)
                        {
                            ShowError("Login failed. Please try again.");
                            return null;
                        }

                        return farmer!;
                    }
                    break;

                case ConsoleKey.Escape:
                    return null;
            }
        }
    }

    private static async Task<UserRegistrationDto?> RegisterUser()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();
        Console.WriteLine("\n  REGISTER (ESC to cancel)\n");

        var user = new UserRegistrationDto();

        try
        {
            user.FirstName = GetValidatedInput(
                prompt: "First Name: ",
                minLength: UserConstants.FirstNameMinLength,
                maxLength: UserConstants.FirstNameMaxLength);

            user.LastName = GetValidatedInput(
                prompt: "Last Name: ",
                minLength: UserConstants.LastNameMinLength,
                maxLength: UserConstants.LastNameMaxLength);

            user.UserName = GetValidatedInput(
                prompt: "User Name: ",
                minLength: UserConstants.UsernameMinLength,
                maxLength: UserConstants.UsernameMaxLength);

            user.Email = GetEmailInput();

            user.Password = GetPasswordInput("Password: ");
            string confirmPassword = GetPasswordInput("Confirm Password: ");

            if (user.Password != confirmPassword)
            {
                ShowError("Passwords don't match!");
                return null;
            }

            await ShowRegistrationProgress();

            return user;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
    }

    public static async Task<LoginDto?> Login()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();
        Console.WriteLine("\n  LOGIN (ESC to cancel)\n");

        try
        {
            var loginDto = new LoginDto
            {
                Username = GetValidatedInput(
                    prompt: "UserName: ",
                    minLength: UserConstants.UsernameMinLength,
                    maxLength: UserConstants.UsernameMaxLength),
                Password = GetPasswordInput("Password: "),
            };

            await ShowLoginProgress();

            return loginDto;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
    }

    #region Helper Methods

    private static string GetValidatedInput(
        string prompt,
        int minLength,
        int maxLength)
    {
        while (true)
        {
            Console.Write(prompt);

            string input = "";
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input[0..^1];
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }

            Console.WriteLine();

            if (input.Length < minLength)
            {
                ShowError($"Minimum {minLength} characters required");
            }
            else if (input.Length > maxLength)
            {
                ShowError($"Maximum {maxLength} characters allowed");
            }
            else
            {
                return input;
            }
        }
    }

    private static string GetEmailInput()
    {
        while (true)
        {
            Console.Write("Email: ");

            string email = "";
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    throw new OperationCanceledException();
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (email.Length > 0)
                    {
                        email = email[0..^1];
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    email += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }

            Console.WriteLine();

            if (!email.Contains('@')
                || !email.Contains('.'))
                ShowError("Invalid email format");
            else
                return email;
        }
    }

    private static string GetPasswordInput(
        string prompt)
    {
        Console.Write(prompt);
        var password = new StringBuilder();

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter) break;
            if (key.Key == ConsoleKey.Escape) throw new OperationCanceledException();

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                password.Append(key.KeyChar);
                Console.Write("*");
            }
        }
        Console.WriteLine();
        return password.ToString();
    }

    #endregion

    #region Show Methods

    private static void ShowError(string message)
    {
        int originalLine = Console.CursorTop;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Error: {message}");
        Console.ResetColor();

        Thread.Sleep(1500);

        Console.SetCursorPosition(0, originalLine);
        Console.Write(new string(' ', Console.WindowWidth));

        Console.SetCursorPosition(0, originalLine - 1);
        Console.Write(new string(' ', Console.WindowWidth));

        Console.SetCursorPosition(0, originalLine - 1);
    }

    private static async Task ShowRegistrationProgress()
    {
        Console.CursorVisible = false;
        Console.Write("\nRegistering account...");

        await ShowProgressAnimation();

        Console.CursorVisible = true;
    }

    private static async Task ShowLoginProgress()
    {
        Console.CursorVisible = false;
        Console.Write("\nValidating credentials...");

        await ShowProgressAnimation();

        Console.CursorVisible = true;
    }

    private static async Task ShowProgressAnimation()
    {
        int width = 30;
        int left = (Console.WindowWidth - width) / 2;
        int top = Console.CursorTop;

        Console.SetCursorPosition(left, top);
        Console.Write("[" + new string(' ', width) + "]");

        var rnd = new Random();
        int baseSpeed = rnd.Next(30, 60);

        for (int p = 0; p < width; p++)
        {
            Console.SetCursorPosition(left + 1 + p, top);

            char progressChar = p switch
            {
                < 10 => '░',
                < 20 => '▒',
                _ => '▓'
            };

            Console.ForegroundColor = p switch
            {
                < 8 => ConsoleColor.DarkYellow,
                < 16 => ConsoleColor.Yellow,
                < 24 => ConsoleColor.Green,
                _ => ConsoleColor.DarkGreen
            };

            Console.Write(progressChar);
            await Task.Delay(baseSpeed + (int)(p * 1.5f));
        }

        Console.SetCursorPosition(left + width + 2, top);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("✓");

        await Task.Delay(300);
        Console.ResetColor();
    }

    #endregion
}