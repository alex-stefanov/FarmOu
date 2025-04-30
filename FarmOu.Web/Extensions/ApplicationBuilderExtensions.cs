using FarmOu.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Web.Extensions;

public static class ApplicationBuilderExtensions
{
    public async static Task<IApplicationBuilder> ApplyMigrations(
        this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        FarmOuDbContext dbContext = serviceScope
            .ServiceProvider
            .GetRequiredService<FarmOuDbContext>()!;

        await dbContext.Database.EnsureCreatedAsync();

        return app;
    }
}