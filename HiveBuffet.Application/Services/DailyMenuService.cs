using HiveBuffet.Application.Common;
using HiveBuffet.Application.Interfaces;
using HiveBuffet.Domain.Dtos;
using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Interfaces;
using Mapster;

namespace HiveBuffet.Application.Services;

internal class DailyMenuService : IDailyMenuService
{
    private readonly IUnitOfWork _unitOfWork;

    public DailyMenuService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MealDto>> GetDailyMenuMealsByDayAsync(DayOfWeek dayOfWeek)
    {
        var dailyMenu = await FindDailyMenuByDay(dayOfWeek);

        var dailyMenuMeals = await _unitOfWork.DailyMenus
            .GetDailyMenuMealsByDayAsync(dailyMenu!.Id);

        return dailyMenuMeals.Adapt<List<MealDto>>();
    }

    public async Task AddMealToDailyMenuAsync(DayOfWeek dayOfWeek, int mealId)
    {
        var dailyMenu = await FindDailyMenuByDay(dayOfWeek);

        var dailyMenuMeal = new DailyMenuMeal
        {
            MealId = mealId,
            DailyMenuId = dailyMenu!.Id
        };

        await _unitOfWork.DailyMenuMeals.AddAsync(dailyMenuMeal);
        await _unitOfWork.Complete();
    }


    public async Task RemoveMealFromDailyMenuAsync(DayOfWeek dayOfWeek, int mealId)
    {
        var dailyMenu = await FindDailyMenuByDay(dayOfWeek);

        var dailyMenuMeal = await _unitOfWork.DailyMenuMeals
            .FindFirstAsync(dmm => dmm.DailyMenuId == dailyMenu!.Id && dmm.MealId == mealId);

        Guard.ThrowIfNull(dailyMenuMeal, "daily menu meal");

        _unitOfWork.DailyMenuMeals.Remove(dailyMenuMeal!);
    }

    private async Task<DailyMenu> FindDailyMenuByDay(DayOfWeek dayOfWeek)
    {
        var dailyMenu = await _unitOfWork.DailyMenus
            .FindFirstAsync(dm => dm.DayOfWeek == dayOfWeek);

        Guard.ThrowIfNull(dailyMenu, dayOfWeek.ToString(), "daily menu");

        return dailyMenu!;
    }
}
