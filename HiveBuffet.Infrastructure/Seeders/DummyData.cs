using HiveBuffet.Domain.Entities;

namespace HiveBuffet.Infrastructure.Seeders;

internal static class DummyData
{
    internal static List<Meal> Meals = new List<Meal>
    {
        new Meal
        {
            Name = "Fried Chicken",
            Description = "Stir-fry chicken with soy sauce, garlic, and ginger.",
            Price = 12.99m
        },
        new Meal
        {
            Name = "Spaghetti Bolognese",
            Description = "Classic Italian pasta with rich tomato and beef sauce.",
            Price = 14.50m
        },
        new Meal
        {
            Name = "Vegetable Curry",
            Description = "Mixed vegetables simmered in a creamy coconut curry sauce.",
            Price = 11.75m
        },
        new Meal
        {
            Name = "Grilled Salmon",
            Description = "Fresh salmon fillet grilled with herbs and lemon.",
            Price = 18.25m
        },
        new Meal
        {
            Name = "Beef Stroganoff",
            Description = "Tender beef in a creamy mushroom sauce served over noodles.",
            Price = 16.00m
        },
        new Meal
        {
            Name = "Caesar Salad",
            Description = "Romaine lettuce with croutons, parmesan, and Caesar dressing.",
            Price = 8.50m
        },
        new Meal
        {
            Name = "Mushroom Risotto",
            Description = "Creamy arborio rice with mushrooms and white wine.",
            Price = 14.00m
        },
        new Meal
        {
            Name = "Chicken Tikka Masala",
            Description = "Marinated chicken chunks in a spiced tomato cream sauce.",
            Price = 13.50m
        },
        new Meal
        {
            Name = "Sushi Platter",
            Description = "Assortment of sushi rolls and nigiri with soy sauce and wasabi.",
            Price = 22.00m
        },
        new Meal
        {
            Name = "Vegan Burrito",
            Description = "Whole wheat wrap with black beans, rice, guacamole, and veggies.",
            Price = 9.99m
        }
    };
}
