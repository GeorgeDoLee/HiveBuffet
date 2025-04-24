namespace HiveBuffet.Domain.Entities;

public class Meal
{
    public int Id { get; set; }

    public required String Name { get; set; }

    public String? Description { get; set; }
}
