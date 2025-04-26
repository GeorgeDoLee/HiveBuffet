using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HiveBuffet.Domain.Entities;

public class Meal
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [Precision(5, 2)]
    public required decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
