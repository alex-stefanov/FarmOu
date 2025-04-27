using FarmOu.Data.Models;
using FarmOu.Infrastructure.Interfaces;
using FarmOu.UI.Menus;

namespace FarmOu;

public static class Application
{
    private static Farmer? currentFarmer;

    public async static Task RunAsync(IUserService userService)
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
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        currentFarmer = null;
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        break;
                    }
                case 8:
                    {
                        break;
                    }
                case 9:
                    {
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