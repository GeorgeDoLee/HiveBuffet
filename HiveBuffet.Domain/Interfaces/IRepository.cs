using System.Linq.Expressions;

namespace HiveBuffet.Domain.Interfaces;

public interface IRepository<T>
    where T : class
{
    Task<T?> GetAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    void Remove(T entity);
}
