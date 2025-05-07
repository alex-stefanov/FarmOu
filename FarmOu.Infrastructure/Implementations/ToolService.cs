using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Infrastructure.Implementations;

public class ToolService(
    IRepository<FarmerTool, object> ftRepository)
    : IToolService
{
    #region IToolService Members

    public async Task<IEnumerable<Tool>> GetAllFarmerTools(
        string farmerId)
        => await ftRepository
            .GetAllAttached()
            .Include(x => x.Tool)
            .Where(x => x.FarmerId == farmerId)
            .Select(x => x.Tool)
            .ToArrayAsync();

    public async Task<Tool?> SuggestBestTool(
        string farmerId,
        string cropId)
    {
        var tools = ftRepository
            .GetAllAttached()
            .Include(x => x.Tool)
            .Where(x => x.FarmerId == farmerId)
            .Select(x => x.Tool);

        tools = await tools.AnyAsync(x => x.CropId == cropId)
            ? tools.Where(x => x.CropId == cropId).OrderByDescending(x => x.SpecificBonusQuantityPerHarvest).ThenByDescending(x => x.SpecificSavingTimeInMiliSeconds)
            : tools.OrderByDescending(x => x.GeneralBonusQuantityPerHarvest).ThenByDescending(x => x.GeneralSavingTimeInMiliSeconds);

        return await tools.FirstOrDefaultAsync();
    }

    #endregion
}
