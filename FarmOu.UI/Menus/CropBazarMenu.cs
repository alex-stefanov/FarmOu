using FarmOu.Common.Constants;
using FarmOu.Data.Models;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.UI.Menus;

public static class CropBazarMenu
{
    public async static Task ShowCropBazar(
        ICropBazarService cbService,
        Farmer farmer)
    {
        while (true)
        {
            Console.Clear();
            DrawHeader();

            var crops = await cbService
                .ShowAllCrops();

            var cropList = crops
                .ToList();

            int selected = 0;
            bool confirmed = false;

            while (!confirmed)
            {
                Console.Clear();

                DrawHeader();
                DrawCropList(
                    cropList,
                    selected);

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            selected = (selected <= 0)
                                ? cropList.Count - 1
                                : selected - 1;

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            selected = (selected >= cropList.Count - 1)
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

            await ShowCrop(
                cbService,
                farmer,
                cropList[selected]);

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey(true);
        }
    }

    private static void DrawHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(MenuConstants.Logo);
        Console.ResetColor();
        Console.WriteLine("========== Welcome to the Crop Bazar! ==========".PadLeft(50));
        Console.WriteLine();
    }

    private static void DrawCropList(
        List<Crop> crops,
        int selected)
    {
        for (int i = 0; i < crops.Count; i++)
        {
            var crop = crops[i];
            var icon = GetCropIcon(crop.Name);
            if (i == selected)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"> {icon} {crop.Name}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {icon} {crop.Name}");
            }
        }

        Console.CursorVisible = false;
    }

    private async static Task ShowCrop(
        ICropBazarService cbService,
        Farmer farmer,
        Crop crop)
    {
        Console.Clear();
        DrawHeader();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your Coins: {farmer.Coins} ⛃\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"--- {crop.Name} {GetCropIcon(crop.Name)} ---\n");
        Console.ResetColor();

        decimal buyPrice = await cbService.GetBuyPricePerCrop(crop.Id);
        decimal sellPrice = await cbService.GetSellPricePerCrop(crop.Id);

        Console.WriteLine($"[B] Buy : {buyPrice} ⛃");
        Console.WriteLine($"[S] Sell: {sellPrice} ⛃");

        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.B:
                {
                    await BuyCrops(
                        cbService,
                        farmer,
                        crop);

                    break;
                }
            case ConsoleKey.S:
                {
                    await SellCrops(
                        cbService,
                        farmer,
                        crop);

                    break;
                }
            default:
                {
                    return;
                }
        }
    }

    private async static Task BuyCrops(
        ICropBazarService cbService,
        Farmer farmer,
        Crop crop)
    {
        Console.Clear();
        DrawHeader();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your Coins: {farmer.Coins} ⛃\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($">> Enter amount to BUY {crop.Name}:  ");
        Console.ResetColor();

        Console.CursorVisible = true;
        if (!int.TryParse(Console.ReadLine(), out int qty) 
            || qty <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number. Try again.");
            Console.ResetColor();

            return;
        }

        try
        {
            await cbService.BuyCrops(
                farmer.Id,
                crop.Id,
                qty);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"+{qty} {crop.Name} bought! Coins -{qty * await cbService.GetBuyPricePerCrop(crop.Id)}⛃");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    private async static Task SellCrops(
        ICropBazarService cbService,
        Farmer farmer,
        Crop crop)
    {
        Console.Clear();
        DrawHeader();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your Coins: {farmer.Coins} ⛃\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($">> Enter amount to SELL {crop.Name}:  ");
        Console.ResetColor();

        Console.CursorVisible = true;
        if (!int.TryParse(Console.ReadLine(), out int qty) 
            || qty <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number. Try again.");
            Console.ResetColor();
            return;
        }

        try
        {
            await cbService.SellCrops(
                farmer.Id,
                crop.Id,
                qty);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"+{qty * await cbService.GetSellPricePerCrop(crop.Id)}⛃ earned! -{qty} {crop.Name} sold.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
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
}