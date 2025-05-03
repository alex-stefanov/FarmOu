using FarmOu.Data.Models;
using FarmOu.Infrastructure.Interfaces;
using FarmOu.UI.Menus;

namespace FarmOu;

/// <summary>
/// Class for the main application flow.
/// </summary>
public static class Application
{
    private static Farmer? currentFarmer;

    /// <summary>
    /// Main method to run the application.
    /// </summary>
    /// <param name="userService">the user service</param>
    /// <param name="cropBazarService">the crop bazar service</param>
    /// <param name="toolBazarService">the tool bazar service</param>
    /// <param name="farmingSessionService">the farming session service</param>
    public async static Task RunAsync(
        IUserService userService,
        ICropBazarService cropBazarService,
        IToolBazarService toolBazarService,
        IFarmSessionService farmingSessionService)
    {
        WelcomeMenu.LoadingMenu();

        while (true)
        {
            WelcomeMenu.OptionsMenu();

            if (currentFarmer is null)
            {
                Console.WriteLine("Not logged in.");
            }
            else
            {
                Console.WriteLine($"Hi {currentFarmer.FirstName} {currentFarmer.LastName}!");
            }

            Console.Write("Select an option: ");
            Console.CursorVisible = true;

            int option = int.Parse(Console.ReadLine() ?? "0");
            switch (option)
            {
                case 0:
                    {
                        return;
                    }
                case 1:
                    {
                        currentFarmer = await UserMenu
                            .ShowAuthMenu(userService);

                        break;
                    }
                case 2:
                    {
                        await CropBazarMenu
                            .ShowCropBazar(cropBazarService, currentFarmer!);

                        break;
                    }
                case 3:
                    {
                        await ToolBazarMenu
                            .ShowToolBazar(toolBazarService, currentFarmer!);

                        break;
                    }
                case 4:
                    {
                        FarmSessionMenu.CropSelectionMenu();

                        FarmSessionMenu.ToolSelectionMenu();

                        FarmSessionMenu.TimeSelectioneMenu();

                        FarmSessionMenu.FarmAnimation();

                        break;
                    }
                case 5:
                    {
                        currentFarmer = null;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            Console.Clear();
        }
    }
}