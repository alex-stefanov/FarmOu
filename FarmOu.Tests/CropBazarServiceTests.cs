using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using Moq;

namespace FarmOu.Tests;

[TestFixture]
public class CropBazarServiceTests
{
    private Mock<IRepository<Crop, string>> _mockCropRepo;
    private Mock<IRepository<CropBuying, object>> _mockCropBRepo;
    private Mock<IRepository<CropSell, object>> _mockCropSRepo;
    private Mock<IRepository<Farmer, string>> _mockFarmerRepo;
    private Mock<IRepository<FarmerCrop, object>> _mockFcRepo;
    private CropBazarService _service;

    [SetUp]
    public void Setup()
    {
        _mockCropRepo = new Mock<IRepository<Crop, string>>();
        _mockCropBRepo = new Mock<IRepository<CropBuying, object>>();
        _mockCropSRepo = new Mock<IRepository<CropSell, object>>();
        _mockFarmerRepo = new Mock<IRepository<Farmer, string>>();
        _mockFcRepo = new Mock<IRepository<FarmerCrop, object>>();
        _service = new CropBazarService(
            _mockCropRepo.Object,
            _mockCropBRepo.Object,
            _mockCropSRepo.Object,
            _mockFarmerRepo.Object,
            _mockFcRepo.Object);
    }

    [Test]
    public void BuyCrops_Throws_WhenNotEnoughCoins()
    {
        var farmer = new Farmer { Id = "f1", Coins = 10 };
        var crop = new Crop { Id = "c1", Name = "Wheat" };

        _mockFarmerRepo.Setup(x => x.GetByIdAsync("f1")).ReturnsAsync(farmer);
        _mockCropRepo.Setup(x => x.GetByIdAsync("c1")).ReturnsAsync(crop);
        _mockFcRepo.Setup(x => x.GetAllAttached())
            .Returns(new List<FarmerCrop>().AsQueryable());

        Assert.ThrowsAsync<ArgumentException>(() => _service.BuyCrops("f1", "c1", 10));
    }

    [Test]
    public async Task GetBuyPricePerCrop_ReturnsCorrectPrice()
    {
        var crop = new Crop { Id = "c1", Name = "Wheat", OverallBought = 100, OverallSold = 80 };
        _mockCropRepo.Setup(x => x.GetByIdAsync("c1")).ReturnsAsync(crop);

        var price = await _service.GetBuyPricePerCrop("c1");

        Assert.That(price, Is.InRange(20m, 70m)); 
    }

    [Test]
    public async Task ShowAllCrops_ReturnsAllCrops()
    {
        var crops = new List<Crop>
            {
                new Crop { Id = "c1", Name = "Wheat" },
                new Crop { Id = "c2", Name = "Corn" }
            };
        _mockCropRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(crops);

        var result = await _service.ShowAllCrops();

        Assert.That(result.Count(), Is.EqualTo(2));
    }
}