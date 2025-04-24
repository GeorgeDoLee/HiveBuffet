using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Persistance;

namespace HiveBuffet.Infrastructure.Repositories;

internal class MealRepository : Repository<Meal>, IMealRepository
{
    public MealRepository(HiveBuffetDbContext context)
        : base(context)
    {
    }
}
