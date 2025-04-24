namespace HiveBuffet.Domain.Dtos;

public class MealDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public required decimal Price { get; set; }

    public string? ImageUrl { get; set; }
}
