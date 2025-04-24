using HiveBuffet.Domain.Constants;
using HiveBuffet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace HiveBuffet.Infrastructure.Seeders;

internal class Seeder : ISeeder
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public Seeder(
        UserManager<User> userManager,
        RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
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
}