using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.Infrastructure.Implementations;

public class CropService(
    IRepository<Crop, string> cropRepository,
    IRepository<FarmerCrop, object> fcRepository)
    : ICropService
{
    #region ICropService Members

    public async Task<IEnumerable<(Crop, int)>> GetAllCropsWithQuantity(
        string farmerId)
    {
        var crops = await cropRepository
            .GetAllAsync();

        List<(Crop, int)> cropsWithQuantities = [];

        foreach (var crop in crops)
        {
            var farmerCrop = await fcRepository
                .FirstOrDefaultAsync(x => x.FarmerId == farmerId 
                    && x.CropId == crop.Id);

            cropsWithQuantities.Add((
                crop,
                farmerCrop is null 
                    ? 0 
                    : farmerCrop.Quantity));
        }

        return cropsWithQuantities;
    }

    #endregion
}
