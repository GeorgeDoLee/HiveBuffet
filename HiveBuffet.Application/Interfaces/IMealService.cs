using HiveBuffet.Domain.Dtos;

namespace HiveBuffet.Application.Interfaces;

public interface IMealService : IService<MealDto>
{
    Task SetImageUrlAsync(int id, string imageUrl);

    Task ClearImageUrlAsync(int id);
}
