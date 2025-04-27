namespace FarmOu.UI.Menus;

public static class WelcomeMenu
{
    public static void LoadingMenu()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        Console.WriteLine(@"
[38;2;150;200;80m
  ███████╗  █████╗ ██████╗  ███╗  ███╗ ██████╗ ██╗   ██╗
  ██╔════╝ ██╔══██╗██╔══██╗ ████╗ ████║██╔═══██╗██║   ██║
  █████╗   ███████║██████╔╝ ██╔████╔██║██║   ██║██║   ██║
  ██╔══╝   ██╔══██║██╔══██╗ ██║╚██╔╝██║██║   ██║██║   ██║
  ██║      ██║  ██║██║  ██║ ██║ ╚═╝ ██║╚██████╔╝╚██████╔╝
  ╚═╝      ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═╝     ╚═╝ ╚═════╝  ╚═════╝ 
[0m");

        string[] loadingMessages = {
            "Preparing soil",
            "Planting seeds",
            "Watering crops",
            "Applying nutrients",
            "Growing plants"
        };

        int maxLength = loadingMessages.Max(m => m.Length) + 4;
        foreach (string msg in loadingMessages)
        {
            Console.WriteLine($"  {msg.PadRight(maxLength)}");
        }
        int firstLine = Console.CursorTop - loadingMessages.Length;

        Console.CursorVisible = false;

        var rnd = new Random();
        foreach (int i in Enumerable.Range(0, loadingMessages.Length))
        {
            int currentLine = firstLine + i;
            string message = loadingMessages[i];

            int baseSpeed = rnd.Next(30, 60);
            int steps = 25;
            int progressBarLeft = message.Length + 4;

            Console.SetCursorPosition(progressBarLeft, currentLine);
            Console.Write($"[{new string(' ', steps)}]");

            for (int p = 0; p < steps; p++)
            {
                Console.SetCursorPosition(progressBarLeft + 1 + p, currentLine);

                char progressChar = (p < steps / 3) ? '░' :
                                   (p < steps * 2 / 3) ? '▒' : '▓';

                Console.ForegroundColor = (p < steps / 2) ? ConsoleColor.DarkYellow :
                                          (p < steps * 3 / 4) ? ConsoleColor.Yellow : ConsoleColor.Green;

                Console.Write(progressChar);

                Console.SetCursorPosition(progressBarLeft + steps + 3, currentLine);
                Console.Write($"{p * 100 / steps}%");

                Thread.Sleep(baseSpeed + (int)(p * 1.5f));
            }

            Console.SetCursorPosition(0, currentLine);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  {message}");
            Console.ResetColor();

            Console.SetCursorPosition(progressBarLeft + steps + 3, currentLine);
            Console.Write("100%");

            Thread.Sleep(500);

            Console.SetCursorPosition(progressBarLeft, currentLine);
            Console.Write(new string(' ', steps + 2));
            Console.SetCursorPosition(progressBarLeft + steps + 3, currentLine);
            Console.Write(new string(' ', 5));
        }

        Thread.Sleep(500);
        Console.CursorVisible = true;
        Console.Clear();
    }

    public static void OptionsMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
  ███████╗  █████╗ ██████╗  ███╗  ███╗ ██████╗ ██╗   ██╗
  ██╔════╝ ██╔══██╗██╔══██╗ ████╗ ████║██╔═══██╗██║   ██║
  █████╗   ███████║██████╔╝ ██╔████╔██║██║   ██║██║   ██║
  ██╔══╝   ██╔══██║██╔══██╗ ██║╚██╔╝██║██║   ██║██║   ██║
  ██║      ██║  ██║██║  ██║ ██║ ╚═╝ ██║╚██████╔╝╚██████╔╝
  ╚═╝      ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═╝     ╚═╝ ╚═════╝  ╚═════╝ 

[38;2;255;215;0m╔══════════════════════════╗
║       MAIN MENU          ║
╠══════════════════════════╣
║ 1. Register/Login        ║
║ 2.                       ║
║ 3.                       ║
║ 4. Logout                ║
║ 0. Exit                  ║
╚══════════════════════════╝
[0m");
    }
}
