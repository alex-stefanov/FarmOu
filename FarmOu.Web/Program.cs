using FarmOu.Data;
using FarmOu.Data.Models;
using FarmOu.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

builder.Configuration
    .AddEnvironmentSpecificJsonFiles(environment, out string connectionString);

builder.Services
    .AddDbContext<FarmOuDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

builder.Services
   .AddIdentity<Farmer, IdentityRole<string>>()
   .AddEntityFrameworkStores<FarmOuDbContext>()
   .AddRoles<IdentityRole<string>>()
   .AddSignInManager<SignInManager<Farmer>>()
   .AddUserManager<UserManager<Farmer>>();

builder.Services
    .RegisterRepositories()
    .RegisterUserDefinedServices();

builder.Services
    .AddControllersWithViews(cfg =>
    {
        cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
    });

builder.Services
    .AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/User/Login";
    cfg.LogoutPath = "/User/Logout";
});

builder.Services.AddSession(cfg =>
{
    cfg.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error500");

    app.UseStatusCodePagesWithRedirects("/Home/Error{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();