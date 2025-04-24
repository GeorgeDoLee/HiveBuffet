using HiveBuffet.Application.Interfaces;
using HiveBuffet.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HiveBuffet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;

    public MealController(IMealService mealService)
    {
        _mealService = mealService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MealDto>>> GetAllMeals()
    {
        var meals = await _mealService.GetAllAsync();
        return Ok(meals);
    }

    [HttpGet("{id}", Name = nameof(GetMealById))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MealDto>> GetMealById(int id)
    {
        var meal = await _mealService.GetByIdAsync(id);
        return Ok(meal);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MealDto>> AddMeal([FromBody] MealDto dto)
    {
        if (dto == null) return BadRequest();

        var created = await _mealService.AddAsync(dto);

        return CreatedAtAction(
            nameof(GetMealById),
            new { id = created.Id },
            created
        );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMeal(
        int id,
        [FromBody] MealDto dto)
    {
        if (dto == null || dto.Id != id) return BadRequest();

        await _mealService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveMeal(int id)
    {
        await _mealService.DeleteAsync(id);
        return NoContent();
    }
}
