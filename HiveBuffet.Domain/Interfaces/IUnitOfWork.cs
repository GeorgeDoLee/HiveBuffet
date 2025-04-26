namespace HiveBuffet.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMealRepository Meals { get; }

    IDailyMenuRepository DailyMenus { get; }

    IDailyMenuMealRepository DailyMenuMeals { get; }

    Task Complete();
}
