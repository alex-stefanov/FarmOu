using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace FarmOu.Tests;

[TestFixture]
public class UserServiceTests
{
    private Mock<UserManager<Farmer>> _mockUserManager;
    private Mock<IRepository<FarmerTool, object>> _mockFtRepository;

    [SetUp]
    public void SetUp()
    {
        var userStore = new Mock<IUserStore<Farmer>>();
        _mockUserManager = new Mock<UserManager<Farmer>>(
            userStore.Object,
            null, null, null, null, null, null, null, null);

        _mockFtRepository = new Mock<IRepository<FarmerTool, object>>();
    }

    [Test]
    public void Constructor_NullUserManager_ThrowsArgumentNullException()
    {
        Assert.That(
            () => new UserService(null!, _mockFtRepository.Object),
            Throws.ArgumentNullException);
    }

    [Test]
    public void Constructor_NullRepository_ThrowsArgumentNullException()
    {
        Assert.That(
            () => new UserService(_mockUserManager.Object, null!),
            Throws.ArgumentNullException);
    }

    [Test]
    public async Task RegisterUserAsync_OnSuccess_ReturnsFarmerAndAddsTool()
    {
        var service = new UserService(_mockUserManager.Object, _mockFtRepository.Object);
        var password = "Secret123!";
        Farmer? createdFarmer = null;

        _mockUserManager
            .Setup(um => um.CreateAsync(It.IsAny<Farmer>(), password))
            .ReturnsAsync(IdentityResult.Success)
            .Callback<Farmer, string>((f, _) => createdFarmer = f);

        _mockFtRepository
            .Setup(r => r.AddAsync(It.IsAny<FarmerTool>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        var result = await service.RegisterUserAsync(
            firstName: "Alice",
            lastName: "Smith",
            username: "asmith",
            email: "alice@example.com",
            password: password);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.SameAs(createdFarmer));
        Assert.That(result!.FirstName, Is.EqualTo("Alice"));
        Assert.That(result.LastName, Is.EqualTo("Smith"));
        Assert.That(result.UserName, Is.EqualTo("asmith"));
        Assert.That(result.Email, Is.EqualTo("alice@example.com"));
        Assert.That(result.XpLevelId, Is.EqualTo(1));
        Assert.That(result.Coins, Is.EqualTo(0));

        _mockFtRepository.Verify(r => r.AddAsync(
            It.Is<FarmerTool>(ft =>
                ft.FarmerId == result.Id &&
                ft.ToolId == "0794a9c9-f6d4-4c11-a1c0-f77ee2cac235"
            )), Times.Once);
    }

    [Test]
    public async Task RegisterUserAsync_OnFailure_ReturnsNullAndDoesNotAddTool()
    {
        var service = new UserService(_mockUserManager.Object, _mockFtRepository.Object);

        _mockUserManager
            .Setup(um => um.CreateAsync(It.IsAny<Farmer>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed());

        var result = await service.RegisterUserAsync(
            firstName: "Bob",
            lastName: "Jones",
            username: "bjones",
            email: "bob@example.com",
            password: "badpass");

        Assert.That(result, Is.Null);
        _mockFtRepository.Verify(r => r.AddAsync(It.IsAny<FarmerTool>()), Times.Never);
    }

    [Test]
    public async Task LoginUserAsync_WhenUserExistsAndPasswordIsCorrect_ReturnsFarmer()
    {
        var service = new UserService(_mockUserManager.Object, _mockFtRepository.Object);
        var farmer = new Farmer { UserName = "user1" };

        _mockUserManager
            .Setup(um => um.FindByNameAsync("user1"))
            .ReturnsAsync(farmer);

        _mockUserManager
            .Setup(um => um.CheckPasswordAsync(farmer, "pass1"))
            .ReturnsAsync(true);

        var result = await service.LoginUserAsync("user1", "pass1");

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.SameAs(farmer));
    }

    [Test]
    public async Task LoginUserAsync_WhenUserNotFound_ReturnsNull()
    {
        var service = new UserService(_mockUserManager.Object, _mockFtRepository.Object);
        _mockUserManager
            .Setup(um => um.FindByNameAsync("missing"))
            .ReturnsAsync((Farmer?)null);

        var result = await service.LoginUserAsync("missing", "irrelevant");

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoginUserAsync_WhenPasswordIncorrect_ReturnsNull()
    {
        var service = new UserService(_mockUserManager.Object, _mockFtRepository.Object);
        var farmer = new Farmer { UserName = "user2" };

        _mockUserManager
            .Setup(um => um.FindByNameAsync("user2"))
            .ReturnsAsync(farmer);
        _mockUserManager
            .Setup(um => um.CheckPasswordAsync(farmer, "wrong"))
            .ReturnsAsync(false);

        var result = await service.LoginUserAsync("user2", "wrong");

        Assert.That(result, Is.Null);
    }
}