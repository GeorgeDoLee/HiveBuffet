using HiveBuffet.Application.Interfaces;
using HiveBuffet.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HiveBuffet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyMenuController : ControllerBase
{
    private readonly IDailyMenuService _dailyMenuService;

    public DailyMenuController(IDailyMenuService dailyMenuService)
    {
        _dailyMenuService = dailyMenuService;
    }

    [HttpGet("{dayOfWeek}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDailyMenu([FromRoute]DayOfWeek dayOfWeek)
    {
        var dailyMenu = await _dailyMenuService
            .GetDailyMenuMealsByDayAsync(dayOfWeek);

        return Ok(dailyMenu);
    }

    [HttpPost("{dayOfWeek}/{mealId}")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddMealToDailyMenuAsync(
        [FromRoute]DayOfWeek dayOfWeek, [FromRoute]int mealId)
    {
        await _dailyMenuService.AddMealToDailyMenuAsync(dayOfWeek, mealId);

        return NoContent();
    }

    [HttpDelete("{dayOfWeek}/{mealId}")]
    [Authorize(Roles = UserRoles.Admin)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveMealFromDailyMenuAsync(
        [FromRoute]DayOfWeek dayOfWeek, [FromRoute]int mealId)
    {
        await _dailyMenuService.RemoveMealFromDailyMenuAsync(dayOfWeek, mealId);

        return NoContent();
    }
}
