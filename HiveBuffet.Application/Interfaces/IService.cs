namespace HiveBuffet.Application.Interfaces;

public interface IService<T>
    where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> AddAsync(T dto);

    Task UpdateAsync(T dto);

    Task DeleteAsync(int id);
}
