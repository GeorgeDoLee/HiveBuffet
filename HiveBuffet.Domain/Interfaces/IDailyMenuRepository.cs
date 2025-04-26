using HiveBuffet.Domain.Entities;

namespace HiveBuffet.Domain.Interfaces;

public interface IDailyMenuRepository
{
    Task AddMealToDailyMenuAsync(DayOfWeek dayOfWeek, Meal meal);

    Task<List<DailyMenuMeal>> GetDailyMenuMealsByDayAsync(DayOfWeek dayOfWeek);

    Task RemoveMealFromDailyMenuAsync(DayOfWeek dayOfWeek, Meal meal);
}