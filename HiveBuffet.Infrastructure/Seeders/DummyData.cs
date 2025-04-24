using HiveBuffet.Domain.Entities;

namespace HiveBuffet.Infrastructure.Seeders;

internal static class DummyData
{
    internal static List<Meal> Meals = new List<Meal>
    {
        new Meal
        {
            Name = "Fried Chicken",
            Description = "Stir-fry chicken with soy sauce, garlic, and ginger."
        },
        new Meal
        {
            Name = "Spaghetti Bolognese",
            Description = "Classic Italian pasta with rich tomato and beef sauce."
        },
        new Meal
        {
            Name = "Vegetable Curry",
            Description = "Mixed vegetables simmered in a creamy coconut curry sauce."
        },
        new Meal
        {
            Name = "Grilled Salmon",
            Description = "Fresh salmon fillet grilled with herbs and lemon."
        },
        new Meal
        {
            Name = "Beef Stroganoff",
            Description = "Tender beef in a creamy mushroom sauce served over noodles."
        },
        new Meal
        {
            Name = "Caesar Salad",
            Description = "Romaine lettuce with croutons, parmesan, and Caesar dressing."
        },
        new Meal
        {
            Name = "Mushroom Risotto",
            Description = "Creamy arborio rice with mushrooms and white wine."
        },
        new Meal
        {
            Name = "Chicken Tikka Masala",
            Description = "Marinated chicken chunks in a spiced tomato cream sauce."
        },
        new Meal
        {
            Name = "Sushi Platter",
            Description = "Assortment of sushi rolls and nigiri with soy sauce and wasabi."
        },
        new Meal
        {
            Name = "Vegan Burrito",
            Description = "Whole wheat wrap with black beans, rice, guacamole, and veggies."
        }
    };
}
