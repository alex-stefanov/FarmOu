using FarmOu.Common.Constants;
using FarmOu.Data.Models;
using FarmOu.Data.Models.Enums;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.UI.Menus;

public static class FarmSessionMenu
{
    public static async Task<Crop?> CropSelectionMenu(
        ICropService cropService,
        Farmer farmer)
    {
        var cropsWithQuantity = await cropService
            .GetAllCropsWithQuantity(farmer.Id);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(MenuConstants.Logo);
            Console.ResetColor();

            Console.WriteLine("Select a Crop to Harvest:");
            for (int i = 0; i < cropsWithQuantity.Count(); i++)
            {
                var crop = cropsWithQuantity.ElementAt(i).Item1;
                var qty = cropsWithQuantity.ElementAt(i).Item2;
                bool selected = (i == selectedIndex);

                var icon = GetCropIcon(crop.Name);

                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("> ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("  ");
                }

                Console.WriteLine($"{icon} {crop.Name} (x{qty})");
                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % cropsWithQuantity.Count();
            }

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + cropsWithQuantity.Count()) % cropsWithQuantity.Count();
            }

            if (key == ConsoleKey.Escape)
            {
                return null;
            }

        } while (key != ConsoleKey.Enter);

        return cropsWithQuantity.ElementAt(selectedIndex).Item1;
    }

    public static async Task<Tool?> ToolSelectionMenu(
        IToolService toolService,
        Crop crop,
        Farmer farmer)
    {
        var farmerTools = await toolService
            .GetAllFarmerTools(farmer.Id);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(MenuConstants.Logo);
            Console.ResetColor();

            Console.WriteLine($"Select a Tool for {GetCropIcon(crop.Name)} {crop.Name}:\n");
            for (int i = 0; i < farmerTools.Count(); i++)
            {
                var tool = farmerTools.ElementAt(i);
                bool selected = (i == selectedIndex);

                var icon = GetToolIcon(tool.Name);
                var (bg, fg) = GetColorsByRarity(tool.Rarity, selected);
                var rarityEmoji = GetRarityEmoji(tool.Rarity);

                Console.BackgroundColor = bg;
                Console.ForegroundColor = fg;
                Console.Write(selected ? "> " : "  ");
                Console.WriteLine($"{icon} {tool.Name} {rarityEmoji}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress S for suggested tool");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % farmerTools.Count();
            }

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex - 1 + farmerTools.Count()) % farmerTools.Count();
            }

            if (key == ConsoleKey.S)
            {
                return await SuggestBestTool(toolService, crop, farmer);
            }

            if(key == ConsoleKey.Escape)
            {
                return null;
            }

        } while (key != ConsoleKey.Enter);

        return farmerTools.ElementAt(selectedIndex);
    }

    private static async Task<Tool> SuggestBestTool(
        IToolService toolService,
        Crop crop,
        Farmer farmer)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Suggesting best tool...\n");
        Console.ResetColor();
        await Task.Delay(500);

        var tool = await toolService.SuggestBestTool(farmer.Id, crop.Id);
        var icon = GetToolIcon(tool.Name);
        var rarityEmoji = GetRarityEmoji(tool.Rarity);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Recommended Tool: {icon} {tool.Name} {rarityEmoji}");
        Console.ResetColor();
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);

        return tool;
    }

    public static async Task<long> TimeSelectionMenu()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();

        Console.WriteLine("Enter desired time interval:");
        Console.Write("Minutes: ");
        string? minInput = Console.ReadLine()!;

        Console.Write("Seconds (optional): ");
        string? secInput = Console.ReadLine()!;

        int seconds = 0;
        if (!int.TryParse(minInput, out int minutes))
        {
            minutes = 0;
        }

        if (!string.IsNullOrWhiteSpace(secInput))
        {
            if (!int.TryParse(secInput, out seconds))
            {
                seconds = 0;
            }
        }

        long totalSeconds = minutes * 60L + seconds;

        if (totalSeconds <= 0)
        {
            totalSeconds = 5 * 60;
        }

        Console.WriteLine($"\nSelected Time: {minutes}m {seconds}s");
        await Task.Delay(5000);

        return totalSeconds * 1000L;
    }

    public static async Task FarmAnimation(
        IFarmSessionService fsService,
        Crop crop,
        Tool tool,
        Farmer farmer,
        long timeInMilliseconds)
    {
        var timePerHarvest = crop.HarvestingTimeInMiliSeconds
            - (crop.Id == tool.CropId
                ? tool.SpecificSavingTimeInMiliSeconds
                : tool.GeneralBonusQuantityPerHarvest);

        const int slots = 20;
        string cropIcon = GetCropIcon(crop.Name);
        string seedIcon = "🌱";
        string toolIcon = GetToolIcon(tool.Name);
        bool[] harvested = new bool[slots];

        string[] actionFrames = { "👩‍🌾🔨", "👩‍🌾💥" };

        int currentPos = 0;
        var start = DateTime.UtcNow;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();
        Console.WriteLine();

        while (true)
        {
            var elapsed = DateTime.UtcNow - start;
            if (elapsed.TotalMilliseconds >= timeInMilliseconds)
                break;

            foreach (var frame in actionFrames)
            {
                Console.SetCursorPosition(0, 9);
                for (int i = 0; i < slots; i++)
                {
                    if (i == currentPos)
                        Console.Write(frame + " ");
                    else
                        Console.Write((harvested[i] ? seedIcon : cropIcon) + " ");
                }

                var remaining = TimeSpan.FromMilliseconds(timeInMilliseconds) - elapsed;
                if (remaining.TotalMilliseconds < 0) remaining = TimeSpan.Zero;
                Console.SetCursorPosition(0, 12);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 12);

                Console.Write($"Tool: ");
                var (bg, fg) = GetColorsByRarity(tool.Rarity, true);
                Console.BackgroundColor = bg;
                Console.ForegroundColor = fg;
                Console.WriteLine($"{toolIcon} {tool.Name}");
                Console.ResetColor();

                Console.WriteLine($"Time Left: {remaining.Minutes}m {remaining.Seconds}s");

                await Task.Delay(timePerHarvest);
            }

            harvested[currentPos] = true;
            currentPos = (currentPos + 1) % slots;

            if (currentPos == 0)
            {
                for (int i = 0; i < slots; i++)
                    harvested[i] = false;
            }

            await Task.Delay(timePerHarvest);
        }

        int expectedQuantity = await fsService.CreateSession(
            farmer.Id,
            crop.Id,
            tool.Id,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMilliseconds(timeInMilliseconds));

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Harvest complete! ✨");
        Console.WriteLine($"Harvested Quantity: {expectedQuantity}");

        Console.Write($"Used Tool: ");
        var (bg1, fg1) = GetColorsByRarity(tool.Rarity, true);
        Console.BackgroundColor = bg1;
        Console.ForegroundColor = fg1;
        Console.WriteLine($"{toolIcon} {tool.Name}");
        Console.ResetColor();

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    private static string GetCropIcon(
        string name)
        => name switch
        {
            "Wheat" => "🌾",
            "Bell Pepper" => "🌶️",
            "Carrot" => "🥕",
            "Mushroom" => "🍄",
            "Potato" => "🥔",
            "Corn" => "🌽",
            "Tomato" => "🍅",
            "Rice" => "🍚",
            "Strawberry" => "🍓",
            "Cotton" => "🌱",
            "Dragonfruit" => "🐉",
            "Blueberry" => "🟣",
            "Grapes" => "🍇",
            "Pumpkin" => "🎃",
            _ => "?",
        };

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
