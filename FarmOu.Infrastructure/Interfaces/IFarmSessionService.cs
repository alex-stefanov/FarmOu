namespace FarmOu.Infrastructure.Interfaces;

/// <summary>
/// Defines operations for managing a farmer's session activities,
/// including the tools and crops used within a specific time frame.
/// </summary>
public interface IFarmSessionService
{
    /// <summary>
    /// Creates a new farming session record linking a farmer,
    /// a crop, and a tool over a specified time period.
    /// </summary>
    /// <param name="farmerId">
    /// The unique identifier of the farmer starting the session.
    /// </param>
    /// <param name="cropId">
    /// The unique identifier of the crop involved in the session.
    /// </param>
    /// <param name="toolId">
    /// The unique identifier of the tool used during the session.
    /// </param>
    /// <param name="startTime">
    /// The <see cref="DateTime"/> when the session begins.
    /// </param>
    /// <param name="endTime">
    /// The <see cref="DateTime"/> when the session ends.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous creation operation.
    /// </returns>
    Task<int> CreateSession(
        string farmerId,
        string cropId,
        string toolId,
        DateTime startTime,
        DateTime endTime);
}