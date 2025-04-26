using HiveBuffet.Domain.Entities;

namespace HiveBuffet.Domain.Interfaces;

public interface IDailyMenuRepository : IRepository<DailyMenu>
{
    Task<IEnumerable<Meal>> GetDailyMenuMealsByDayAsync(int dailyMenuId);
}