using HiveBuffet.Domain.Interfaces;
using HiveBuffet.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HiveBuffet.Infrastructure.Repositories;

internal class Repository<T> : IRepository<T>
    where T : class
{
    protected readonly HiveBuffetDbContext _context;

    public Repository(HiveBuffetDbContext hiveBuffetDbContext)
    {
        _context = hiveBuffetDbContext;
    }

    public virtual async Task AddAsync(T entity)
    {
        _ = await _context.Set<T>()
            .AddAsync(entity);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>()
            .Where(predicate)
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .ToListAsync();
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        return await _context.Set<T>()
            .FindAsync(id);
    }

    public virtual void Remove(T entity)
    {
        _ = this._context.Set<T>()
            .Remove(entity);
    }
}
