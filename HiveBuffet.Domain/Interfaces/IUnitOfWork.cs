namespace HiveBuffet.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMealRepository Meals { get; }

    Task Complete();
}
