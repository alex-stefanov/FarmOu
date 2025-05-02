using FarmOu.Data.Models;

namespace FarmOu.Infrastructure.Interfaces;

/// <summary>
/// Defines operations for retrieving and purchasing tools in the Tool Bazaar.
/// </summary>
public interface IToolBazarService
{
    /// <summary>
    /// Retrieves all tools not yet purchased by the specified farmer.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer.</param>
    /// <returns>A collection of <see cref="Tool"/> entities that the farmer does not own.</returns>
    Task<IEnumerable<Tool>> GetAllLeftTools(
        string farmerId);

    /// <summary>
    /// Allows a farmer to purchase a specific tool.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer making the purchase.</param>
    /// <param name="toolId">The unique identifier of the tool to purchase.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task BuyTool(
        string farmerId,
        string toolId);

    /// <summary>
    /// Retrieves all tool purchase transactions for the specified farmer.
    /// </summary>
    /// <param name="farmerId">The unique identifier of the farmer.</param>
    /// <returns>A collection of <see cref="ToolBuying"/> representing the farmer's purchase history.</returns>
    Task<IEnumerable<ToolBuying>> GetAllToolBuyings(
        string farmerId);

    /// <summary>
    /// Gets the current purchase price for a specific tool.
    /// </summary>
    /// <param name="toolId">The unique identifier of the tool.</param>
    /// <returns>
    /// A <see cref="decimal"/> representing the price to buy one unit of the tool.
    /// </returns>
    Task<decimal> GetToolBuyPrice(
        string toolId);
}
