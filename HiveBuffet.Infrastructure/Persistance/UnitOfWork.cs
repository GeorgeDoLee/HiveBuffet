using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Repositories;

namespace HiveBuffet.Infrastructure.Persistance;

internal class UnitOfWork : IUnitOfWork
{
    private readonly HiveBuffetDbContext _context;

    public UnitOfWork(HiveBuffetDbContext todoListDbContext)
    {
        _context = todoListDbContext;
        Meals = new MealRepository(_context);
    }

    public IMealRepository Meals { get; }

    public async Task Complete()
    {
        _ = await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
