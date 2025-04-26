using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Exceptions;
using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HiveBuffet.Infrastructure.Repositories;

public class DailyMenuRepository : IDailyMenuRepository
{
    private readonly HiveBuffetDbContext _context;

    public DailyMenuRepository(HiveBuffetDbContext context)
    {
        _context = context;
    }

    private async Task<DailyMenu?> GetDailyMenuByDayAsync(DayOfWeek dayOfWeek)
    {
        return await _context.DailyMenus
            .FirstOrDefaultAsync(dm => dm.DayOfWeek == dayOfWeek);
    }

    public async Task<List<DailyMenuMeal>> GetDailyMenuMealsByDayAsync(DayOfWeek dayOfWeek)
    {
        var dailyMenu = await GetDailyMenuByDayAsync(dayOfWeek);

        if (dailyMenu == null)
        {
            return new List<DailyMenuMeal>();
        }

        return await _context.DailyMenuMeals
            .Where(dmm => dmm.DailyMenuId == dailyMenu.Id)
            .Include(dmm => dmm.Meal)
            .ToListAsync();
    }

    public async Task AddMealToDailyMenuAsync(DayOfWeek dayOfWeek, Meal meal)
    {
        var dailyMenu = await GetDailyMenuByDayAsync(dayOfWeek);

        if (dailyMenu == null)
        {
            throw new NotFoundException("Daily menu not found for the specified day.");
        }

        var dailyMenuMeal = new DailyMenuMeal
        {
            DailyMenuId = dailyMenu.Id,
            MealId = meal.Id
        };

        await _context.DailyMenuMeals.AddAsync(dailyMenuMeal);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveMealFromDailyMenuAsync(DayOfWeek dayOfWeek, Meal meal)
    {
        var dailyMenu = await GetDailyMenuByDayAsync(dayOfWeek);

        if (dailyMenu == null)
        {
            throw new NotFoundException("Daily menu not found for the specified day.");
        }

        var dailyMenuMeal = await _context.DailyMenuMeals
            .FirstOrDefaultAsync(dmm => dmm.DailyMenuId == dailyMenu.Id && dmm.MealId == meal.Id);

        if (dailyMenuMeal != null)
        {
            _context.DailyMenuMeals.Remove(dailyMenuMeal);
            await _context.SaveChangesAsync();
        }
    }
}
