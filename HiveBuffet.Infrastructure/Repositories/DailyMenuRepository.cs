using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Exceptions;
using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HiveBuffet.Infrastructure.Repositories;

internal class DailyMenuRepository
    : Repository<DailyMenu>, IRepository<DailyMenu>, IDailyMenuRepository
{
    public DailyMenuRepository(HiveBuffetDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Meal>> GetDailyMenuMealsByDayAsync(int dailyMenuId)
    {
        return await _context.DailyMenuMeals
                    .Where(dmm => dmm.DailyMenuId == dailyMenuId)
                    .Include(dmm => dmm.Meal)
                    .Select(dmm => dmm.Meal)
                    .ToListAsync();
    }
}