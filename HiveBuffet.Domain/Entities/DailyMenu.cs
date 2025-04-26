using System.ComponentModel.DataAnnotations;

namespace HiveBuffet.Domain.Entities;

public class DailyMenu
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required DayOfWeek DayOfWeek { get; set; }

    public List<DailyMenuMeal> DailyMenuMeals { get; set; } = new List<DailyMenuMeal>();
}
