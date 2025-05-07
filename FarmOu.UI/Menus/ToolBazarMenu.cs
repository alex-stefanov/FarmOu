using FarmOu.Common.Constants;
using FarmOu.Data.Models.Enums;
using FarmOu.Data.Models;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.UI.Menus;

public static class ToolBazarMenu
{
    public async static Task ShowToolBazar(
        IToolBazarService tbService,
        Farmer farmer)
    {
        while (true)
        {
            Console.Clear();
            DrawToolHeader();

            var tools = await tbService
                .GetAllLeftTools(farmer.Id);

            var toolList = tools
                .ToList();

            int selected = 0;
            bool confirmed = false;

            while (!confirmed)
            {
                Console.Clear();

                DrawToolHeader();
                DrawToolList(
                    toolList,
                    selected);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            selected = (selected <= 0)
                                ? toolList.Count - 1
                                : selected - 1;

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            selected = (selected >= toolList.Count - 1)
                                ? 0
                                : selected + 1;

                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            confirmed = true;

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                } 
            }
            await ShowTool(
                tbService,
                toolList[selected],
                farmer);

            Console.WriteLine("Press any key to return ...");
            Console.ReadKey(true);
        }
    }

    private static void DrawToolHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();
        Console.WriteLine("======= Welcome to the Tool Bazar! =======".PadLeft(50));
        Console.WriteLine();
    }

    private static void DrawToolList(
        List<Tool> tools,
        int selected)
    {
        for (int i = 0; i < tools.Count; i++)
        {
            var tool = tools[i];
            var icon = GetToolIcon(tool.Name);
            var (bg, fg) = GetColorsByRarity(tool.Rarity, i == selected);

            if (i == selected)
            {
                Console.BackgroundColor = bg;
                Console.ForegroundColor = fg;
                Console.WriteLine($"> {icon} {tool.Name} {GetRarityEmoji(tool.Rarity)}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {icon} {tool.Name} {GetRarityEmoji(tool.Rarity)}");
            }
        }

        Console.CursorVisible = false;
    }

    private async static Task ShowTool(
        IToolBazarService tbService,
        Tool tool,
        Farmer farmer)
    {
        Console.Clear();
        DrawToolHeader();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your Coins: {farmer.Coins} ⛃");
        Console.WriteLine($"Your Level: {farmer.XpLevelId} ⭐");
        Console.ResetColor();

        var (bg, fg) = GetColorsByRarity(tool.Rarity, true);
        Console.BackgroundColor = bg;
        Console.ForegroundColor = fg;
        Console.WriteLine($"--- {tool.Name} {GetToolIcon(tool.Name)} {GetRarityEmoji(tool.Rarity)} ---");
        Console.ResetColor();

        bool levelOk = farmer.XpLevelId >= tool.LevelNeeded;
        Console.ForegroundColor = levelOk ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"Required Level: {tool.LevelNeeded} 🏅");
        Console.ResetColor();

        decimal price = await tbService.GetToolBuyPrice(tool.Id);
        Console.WriteLine($"[B] Buy : {price} ⛃");

        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.B:
                {
                    await BuyTool(
                        tbService,
                        farmer,
                        tool.Id);

                    break;
                }
            default:
                {
                    return;
                }
        }
    }

    private async static Task BuyTool(
        IToolBazarService tbService,
        Farmer farmer,
        string toolId)
    {
        Console.Clear();
        DrawToolHeader();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your Coins: {farmer.Coins} ⛃");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($">> Confirm? (Y/N)");
        Console.ResetColor();

        Console.CursorVisible = true;
        if (Console.ReadKey(true).Key != ConsoleKey.Y)
        {
            return;
        }

        try
        {
            await tbService.BuyTool(
                farmer.Id,
                toolId);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tool purchased successfully!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    private static (ConsoleColor bg, ConsoleColor fg) GetColorsByRarity(
        Rarity rarity,
        bool selected)
        => rarity switch
        {
            Rarity.Common => selected 
                ? (ConsoleColor.Gray, ConsoleColor.Black) 
                : (ConsoleColor.Black, ConsoleColor.Gray),
            Rarity.Epic => selected 
                ? (ConsoleColor.DarkMagenta, ConsoleColor.White) 
                : (ConsoleColor.Black, ConsoleColor.Magenta),
            Rarity.Legendary => selected 
                ? (ConsoleColor.DarkYellow, ConsoleColor.Black) 
                : (ConsoleColor.Black, ConsoleColor.Yellow),
            Rarity.Unique => selected 
                ? (ConsoleColor.DarkCyan, ConsoleColor.White) 
                : (ConsoleColor.Black, ConsoleColor.Cyan),
            Rarity.Godlike => selected 
                ? (ConsoleColor.DarkRed, ConsoleColor.White) 
                : (ConsoleColor.Black, ConsoleColor.Red),
            _ => (ConsoleColor.Black, ConsoleColor.White)
        };

    private static string GetRarityEmoji(
        Rarity rarity)
        => rarity switch
        {
            Rarity.Common => "⚙️",
            Rarity.Epic => "✨",
            Rarity.Legendary => "🏆",
            Rarity.Unique => "💎",
            Rarity.Godlike => "🔥",
            _ => string.Empty
        };

    private static string GetToolIcon(
        string name)
        => name switch
        {
            "Wheatwind Scythe" => "🌾𓌜",
            "Pepper Pruner" => "🌶️✂️",
            "Carrot Crescendo" => "🥕🎶",
            "Fungus Forger" => "🍄🛠️",
            "Tater Tamer" => "🥔🤏",
            "Corncob Clarifier" => "🌽🔍",
            "Tomato Twister" => "🍅🌪️",
            "Rice Reaper" => "🍚⚔️",
            "Berry Brawler" => "🍓🥊",
            "Cotton Cutter" => "🌱✂️",
            "Blueberry Blitz" => "🟣💥",
            "Pumpkin Pulverizer" => "🎃🔨",
            "Dragonfruit Dicer" => "🐉🔪",
            "Grape Grappler" => "🍇🤼",
            "Mythic Wheatwind Scythe" => "🌾𓌜✨",
            "Mythic Corncob Clarifier" => "🌽🔍✨",
            "Mythic Berry Brawler" => "🍓🥊✨",
            "Mythic Cotton Cutter" => "🌱✂️✨",
            "Mythic Grape Grappler" => "🍇🤼✨",
            "Godlike Pepper Pruner" => "🌶️✂️🔥",
            "Godlike Tater Tamer" => "🥔🤏🔥",
            "Godlike Blueberry Blitz" => "🟣💥🔥",
            "Godlike Pumpkin Pulverizer" => "🎃🔨🔥",
            _ => "🛠️"
        };
}