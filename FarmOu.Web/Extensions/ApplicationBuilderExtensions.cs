using FarmOu.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmOu.Web.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder ApplyMigrations(
        this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        FarmOuDbContext dbContext = serviceScope
            .ServiceProvider
            .GetRequiredService<FarmOuDbContext>()!;

        dbContext.Database.Migrate();

        return app;
    }
}