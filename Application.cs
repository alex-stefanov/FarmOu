using FarmOu.UI.Menus;

namespace FarmOu.UI;

public static class Application
{
    public static void Run()
    {
        WelcomeMenu.LoadingMenu();
        WelcomeMenu.OptionsMenu();
    }
}
