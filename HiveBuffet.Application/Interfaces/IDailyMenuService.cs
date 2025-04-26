using HiveBuffet.Domain.Dtos;

namespace HiveBuffet.Application.Interfaces;

public interface IDailyMenuService
{
    Task<IEnumerable<MealDto>> GetDailyMenuMealsByDayAsync(DayOfWeek dayOfWeek);

    Task AddMealToDailyMenuAsync(DayOfWeek dayOfWeek, int mealId);

    Task RemoveMealFromDailyMenuAsync(DayOfWeek dayOfWeek, int mealId);
}
