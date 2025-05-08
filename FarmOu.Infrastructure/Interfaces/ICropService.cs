using FarmOu.Data.Models;

namespace FarmOu.Infrastructure.Interfaces;

public interface ICropService
{
    Task<IEnumerable<(Crop, int)>> GetAllCropsWithQuantity(
        string farmerId);

    Task<IEnumerable<Crop>> GetAllCrops();
}
