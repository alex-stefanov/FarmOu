using FarmOu.Infrastructure.Interfaces;
using FarmOu.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmOu.Web.Controllers;

public class DocumentationController(
    ICropService cropService,
    IToolService toolService)
    : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> CropsInfo()
    {
        var crops = await cropService.GetAllCrops();

        var cropViewModels = crops
            .Select(x => new CropInfoViewModel
            {
                Name = x.Name,
                OverallBought = x.OverallBought,
                OverallSold = x.OverallSold,
                HarvestingTimeInMiliseconds = x.HarvestingTimeInMiliSeconds,
                QuantityPerHarvest = x.QuantityPerHarvest,
                XpPerHarvest = x.XpPerHarvest,
                Icon = GetCropIcon(x.Name),
            });

        return View(cropViewModels);
    }

    public async Task<IActionResult> ToolsInfo()
    {
        var tools = await toolService.GetAllTools();

        var toolViewModels = tools
            .Select(x => new ToolInfoViewModel
            {
                Name = x.Name,
                GeneralBonusQuantityPerHarvest = x.GeneralBonusQuantityPerHarvest,
                GeneralSavingTimeInMiliSeconds = x.GeneralSavingTimeInMiliSeconds,
                SpecificBonusQuantityPerHarvest = x.SpecificBonusQuantityPerHarvest,
                SpecificSavingTimeInMiliSeconds = x.SpecificSavingTimeInMiliSeconds,
                LevelNeeded = x.LevelNeeded,
                Rarity = x.Rarity.ToString(),
                Icon = GetToolIcon(x.Name),
                UsedForCropIcon = GetCropIcon(x.Crop.Name),
            });

        return View(toolViewModels);
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

    private static string GetToolIcon(
        string name)
        => name switch
        {
            "Wheatwind Scythe" => "𓌜",
            "Pepper Pruner" => "✂️",
            "Carrot Crescendo" => "🎶",
            "Fungus Forger" => "🛠️",
            "Tater Tamer" => "🤏",
            "Corncob Clarifier" => "🔍",
            "Tomato Twister" => "🌪️",
            "Rice Reaper" => "⚔️",
            "Berry Brawler" => "🥊",
            "Cotton Cutter" => "✂️",
            "Blueberry Blitz" => "💥",
            "Pumpkin Pulverizer" => "🔨",
            "Dragonfruit Dicer" => "🔪",
            "Grape Grappler" => "🤼",
            "Mythic Wheatwind Scythe" => "𓌜",
            "Mythic Corncob Clarifier" => "🔍",
            "Mythic Berry Brawler" => "🥊",
            "Mythic Cotton Cutter" => "✂️",
            "Mythic Grape Grappler" => "🤼",
            "Godlike Pepper Pruner" => "✂️",
            "Godlike Tater Tamer" => "🤏",
            "Godlike Blueberry Blitz" => "💥",
            "Godlike Pumpkin Pulverizer" => "🔨",
            _ => "🛠️"
        };
}
