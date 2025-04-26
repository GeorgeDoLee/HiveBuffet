using HiveBuffet.Domain.Constants;
using HiveBuffet.Domain.Entities;
using HiveBuffet.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace HiveBuffet.Infrastructure.Seeders;

internal class Seeder : ISeeder
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly HiveBuffetDbContext _context;

    public Seeder(
        UserManager<User> userManager,
        RoleManager<IdentityRole<int>> roleManager,
        HiveBuffetDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task SeedAsync()
    {
        await SeedUser();
        await Seed<Meal>(DummyData.Meals);
        await Seed<DailyMenu>(DummyData.DailyMenus);
        await Seed<DailyMenuMeal>(DummyData.DailyMenuMeals);
    }

    private async Task SeedUser()
    {
        const string defaultUsername = "admin";
        const string defaultPassword = "Password1@";

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));
        }

        var user = await _userManager.FindByNameAsync(defaultUsername);
        if (user == null)
        {
            user = new User
            {
                UserName = defaultUsername
            };

            var result = await _userManager.CreateAsync(user, defaultPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create default admin user: " +
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }

        if (!await _userManager.IsInRoleAsync(user, UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
    }

    private async Task Seed<T>(IEnumerable<T> dummyData) 
        where T : class
    {
        if (!_context.Set<T>().Any())
        {
            await _context.Set<T>().AddRangeAsync(dummyData);
            await _context.SaveChangesAsync();
        }
    }
}