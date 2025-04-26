using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiveBuffet.Domain.Entities;

public class DailyMenuMeal
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("DailyMenu")]
    public required int DailyMenuId { get; set; }

    public DailyMenu DailyMenu { get; set; } = null!;

    [Required]
    [ForeignKey("Meal")]
    public required int MealId { get; set; }

    public Meal Meal { get; set; } = null!;
}
