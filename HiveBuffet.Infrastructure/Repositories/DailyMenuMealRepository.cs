using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Persistance;

namespace HiveBuffet.Infrastructure.Repositories;

internal class DailyMenuMealRepository
    : Repository<DailyMenuMeal>, IRepository<DailyMenuMeal>, IDailyMenuMealRepository
{
    public DailyMenuMealRepository(HiveBuffetDbContext context)
        : base(context)
    {
    }
}
