using HiveBuffet.Application.Common;
using HiveBuffet.Application.Interfaces;
using HiveBuffet.Domain.Dtos;
using HiveBuffet.Domain.Entities;
using HiveBuffet.Domain.Interfaces;
using Mapster;

namespace HiveBuffet.Application.Services;

internal class MealService : IMealService
{
    private readonly IUnitOfWork _unitOfWork;

    public MealService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<MealDto> GetByIdAsync(int id)
    {
        var meal = await _unitOfWork.Meals.GetAsync(id);

        Guard.ThrowIfNull(meal, id.ToString(), "meal");

        return meal.Adapt<MealDto>();
    }

    public async Task<IEnumerable<MealDto>> GetAllAsync()
    {
        var meals = await _unitOfWork.Meals.GetAllAsync();

        return meals.Adapt<List<MealDto>>();
    }

    public async Task<MealDto> AddAsync(MealDto dto)
    {
        var meal = dto.Adapt<Meal>();

        await _unitOfWork.Meals.AddAsync(meal);
        await _unitOfWork.Complete();

        return meal.Adapt<MealDto>();
    }

    public async Task UpdateAsync(MealDto dto)
    {
        var meal = await _unitOfWork.Meals.GetAsync(dto.Id);

        Guard.ThrowIfNull(meal, dto.Id.ToString(), "meal");

        dto.Adapt(meal);

        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var meal = await _unitOfWork.Meals.GetAsync(id);

        Guard.ThrowIfNull(meal, id.ToString(), "meal");

        _unitOfWork.Meals.Remove(meal!);
        await _unitOfWork.Complete();
    }
}
