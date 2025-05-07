using FarmOu.Data.Models;

namespace FarmOu.Infrastructure.Interfaces;

public interface IToolService
{
    Task<IEnumerable<Tool>> GetAllFarmerTools(
        string farmerId);

    Task<Tool?> SuggestBestTool(
        string farmerId,
        string cropId);
}
