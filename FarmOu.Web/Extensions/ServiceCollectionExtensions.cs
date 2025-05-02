using FarmOu.Data.Models;
using FarmOu.Data.Repositories;
using FarmOu.Infrastructure.Implementations;
using FarmOu.Infrastructure.Interfaces;

namespace FarmOu.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IRepository<Crop,string>, Repository<Crop,string>>();
        services.AddScoped<IRepository<CropBuying, object>, Repository<CropBuying, object>>();
        services.AddScoped<IRepository<CropSell, object>, Repository<CropSell, object>>();

        services.AddScoped<IRepository<Farmer, string>, Repository<Farmer, string>>();
        services.AddScoped<IRepository<FarmerCrop, object>, Repository<FarmerCrop, object>>();
        services.AddScoped<IRepository<FarmerTool, object>, Repository<FarmerTool, object>>();
        services.AddScoped<IRepository<FarmingSession, object>, Repository<FarmingSession, object>>();

        services.AddScoped<IRepository<Tool, string>, Repository<Tool, string>>();
        services.AddScoped<IRepository<ToolBuying, object>, Repository<ToolBuying, object>>();
        services.AddScoped<IRepository<XpLevel, int>, Repository<XpLevel, int>>();

        return services;
    }

    public static IServiceCollection RegisterUserDefinedServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICropBazarService, CropBazarService>();
        services.AddScoped<IToolBazarService, ToolBazarService>();

        return services;
    }
}