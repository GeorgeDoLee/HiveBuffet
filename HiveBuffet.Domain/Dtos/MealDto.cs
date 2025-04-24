namespace HiveBuffet.Domain.Dtos;

public class MealDto
{
    public int Id { get; set; }

    public required String Name { get; set; }

    public String? Description { get; set; }
}
