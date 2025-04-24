namespace HiveBuffet.Domain.Entities;

public class Meal
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}
