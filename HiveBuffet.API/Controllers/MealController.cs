using HiveBuffet.Application.Interfaces;
using HiveBuffet.Domain.Constants;
using HiveBuffet.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HiveBuffet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealController : ControllerBase
{
    private readonly IMealService _mealService;
    private readonly IFileService _fileService;

    public MealController(IMealService mealService, IFileService fileService)
    {
        _mealService = mealService;
        _fileService = fileService;
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
    public async Task<ActionResult<MealDto>> GetMealById([FromRoute]int id)
    {
        var meal = await _mealService.GetByIdAsync(id);
        return Ok(meal);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MealDto>> AddMeal([FromBody]MealDto dto)
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
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMeal(
        [FromRoute]int id,
        [FromBody] MealDto dto)
    {
        if (dto == null || dto.Id != id) return BadRequest();

        await _mealService.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveMeal([FromRoute]int id)
    {
        await _mealService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/image")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UploadMealImage(
            [FromRoute] int id,
            IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("no file uploaded.");
        }

        _ = await _mealService.GetByIdAsync(id);

        var imagePath = await _fileService.UploadImageAsync(file);

        await _mealService.SetImageUrlAsync(id, imagePath);

        return Ok(imagePath);
    }

    [HttpDelete("{id}/image")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMealImage([FromRoute]int id)
    {
        var meal = await _mealService.GetByIdAsync(id);

        if (!string.IsNullOrWhiteSpace(meal.ImageUrl))
        {
            var fileName = Path.GetFileName(meal.ImageUrl);

            _fileService.DeleteImage(fileName);
            await _mealService.ClearImageUrlAsync(id);
        }

        return NoContent();
    }
}
