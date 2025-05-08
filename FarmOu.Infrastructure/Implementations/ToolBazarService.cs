using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Infrastructure.Implementations;

/// <summary>
/// Implements operations for retrieving available tools and handling tool purchases
/// within the Tool Bazaar.
/// </summary>
/// <param name="toolRepository">Repository for managing <see cref="Tool"/> entities.</param>
/// <param name="ftRepository">Repository for managing farmer-tool associations (<see cref="FarmerTool"/>).</param>
/// <param name="toolBRepository">Repository for managing tool purchase transactions (<see cref="ToolBuying"/>).</param>
/// <param name="farmerRepository">Repository for managing farmers (<see cref="Farmer"/>).</param>
public class ToolBazarService(
    IRepository<Tool, string> toolRepository,
    IRepository<FarmerTool, object> ftRepository,
    IRepository<ToolBuying, object> toolBRepository,
    IRepository<Farmer, string> farmerRepository)
    : IToolBazarService
{
    #region IToolBazarService Members

    /// <inheritdoc/>
    public async Task BuyTool(
        string farmerId,
        string toolId)
    {
        var farmer = await farmerRepository.GetByIdAsync(farmerId)
           ?? throw new ArgumentException($"Farmer with id {farmerId} not found.");

        var tool = await toolRepository.GetByIdAsync(toolId)
            ?? throw new ArgumentException($"Tool with id {toolId} not found.");

        var toolB = new ToolBuying
        {
            FarmerId = farmer.Id,
            ToolId = tool.Id,
            BoughtAt = DateTime.UtcNow,
            BuyPrice = await GetToolBuyPrice(tool.Id),
        };

        if (farmer.XpLevelId < tool.LevelNeeded)
        {
            throw new ArgumentException($"Farmer with id {farmerId} does not have enough level to buy this tool.");
        }

        if (farmer.Coins < toolB.BuyPrice)
        {
            throw new ArgumentException($"Farmer with id {farmerId} does not have enough coins.");
        }

        var farmerTool = await ftRepository
            .GetAllAttached()
            .Where(x => x.FarmerId == farmer.Id && x.ToolId == tool.Id)
            .FirstOrDefaultAsync();

        if (farmerTool is not null)
        {
            throw new ArgumentException($"Farmer with id {farmerId} already has this tool.");
        }

        farmerTool = new FarmerTool
        {
            FarmerId = farmer.Id,
            ToolId = tool.Id,
        };

        farmer.Coins -= toolB.BuyPrice;

        await ftRepository.AddAsync(farmerTool);

        await farmerRepository.UpdateAsync(farmer);

        await toolBRepository.AddAsync(toolB);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Tool>> GetAllLeftTools(
        string farmerId)
    {
        var allToolIds = await toolRepository
            .GetAllAttached()
            .Select(x => x.Id)
            .ToArrayAsync();

        var farmerToolIds = await ftRepository
            .GetAllAttached()
            .Where(x => x.FarmerId == farmerId)
            .Select(x => x.ToolId)
            .ToHashSetAsync();

        var leftToolIds = allToolIds
            .Where(x => !farmerToolIds.Contains(x));

        var leftTools = await toolRepository
            .GetAllAttached()
            .Where(x => leftToolIds.Contains(x.Id))
            .ToArrayAsync();

        return leftTools
            .OrderBy(x => x.Rarity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ToolBuying>> GetAllToolBuyings(
        string farmerId)
        => await toolBRepository
            .GetAllAttached()
            .Where(x => x.FarmerId == farmerId)
            .ToArrayAsync();

    /// <inheritdoc/>
    public async Task<decimal> GetToolBuyPrice(
        string toolId)
    {
        var tool = await toolRepository
            .GetByIdAsync(toolId)
            ?? throw new ArgumentException($"Tool with id {toolId} not found.");

        return tool.Name switch
        {
            "Wheatwind Scythe" => 100m,
            "Pepper Pruner" => 100m,
            "Carrot Crescendo" => 100m,
            "Fungus Forger" => 100m,
            "Tater Tamer" => 100m,
            "Corncob Clarifier" => 500m,
            "Tomato Twister" => 500m,
            "Rice Reaper" => 500m,
            "Berry Brawler" => 500m,
            "Cotton Cutter" => 500m,
            "Blueberry Blitz" => 2000m,
            "Pumpkin Pulverizer" => 2000m,
            "Dragonfruit Dicer" => 2000m,
            "Grape Grappler" => 2000m,
            "Mythic Wheatwind Scythe" => 10000m,
            "Mythic Corncob Clarifier" => 10000m,
            "Mythic Berry Brawler" => 10000m,
            "Mythic Cotton Cutter" => 10000m,
            "Mythic Grape Grappler" => 10000m,
            "Godlike Pepper Pruner" => 50000m,
            "Godlike Tater Tamer" => 50000m,
            "Godlike Blueberry Blitz" => 50000m,
            "Godlike Pumpkin Pulverizer" => 50000m,
            _ => throw new ArgumentException($"Tool with name {tool.Name} not found.")
        };
    }

    #endregion
}
