using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories;

namespace StoreApp.Infrastructure.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
    {
        RepositoryContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RepositoryContext>();

        if(context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }

    public static void ConfigureLocalization(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(options =>
        {
            options.AddSupportedCultures("tr-TR")
            .AddSupportedUICultures("tr-TR")
            .SetDefaultCulture("tr-TR");
        });
    }

    public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
    {
        const string adminName = "Admin";
        const string adminPassword = "asd123*";

        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var user = await userManager.FindByNameAsync(adminName);
        if (user is null)
        {
            user = new IdentityUser(){
                UserName = adminName,
                Email = "meliksahmertcakir@hotmail.com",
                PhoneNumber = "05516208340"
            };

            var result = await userManager.CreateAsync(user,adminPassword);
            if (!result.Succeeded)
                throw new Exception("Admin could not created");

            var roleResult = await userManager.AddToRolesAsync(user,roleManager.Roles.Select(r => r.Name).ToList());
            if(!roleResult.Succeeded)
                throw new Exception("Roles could not found.");
        }
    }
}