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

    internal static List<DailyMenu> DailyMenus = new List<DailyMenu>
    {
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Monday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Tuesday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Wednesday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Thursday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Friday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Saturday
        },
        new DailyMenu
        {
            DayOfWeek = DayOfWeek.Sunday
        }
    };

    internal static List<DailyMenuMeal> DailyMenuMeals = new List<DailyMenuMeal>
    {
        new DailyMenuMeal { DailyMenuId = 1, MealId = 1 },
        new DailyMenuMeal { DailyMenuId = 1, MealId = 2 },
        new DailyMenuMeal { DailyMenuId = 1, MealId = 6 },

        new DailyMenuMeal { DailyMenuId = 2, MealId = 3 },
        new DailyMenuMeal { DailyMenuId = 2, MealId = 4 },
        new DailyMenuMeal { DailyMenuId = 2, MealId = 7 },

        new DailyMenuMeal { DailyMenuId = 3, MealId = 5 },
        new DailyMenuMeal { DailyMenuId = 3, MealId = 8 },
        new DailyMenuMeal { DailyMenuId = 3, MealId = 9 },

        new DailyMenuMeal { DailyMenuId = 4, MealId = 1 },
        new DailyMenuMeal { DailyMenuId = 4, MealId = 5 },
        new DailyMenuMeal { DailyMenuId = 4, MealId = 10 },

        new DailyMenuMeal { DailyMenuId = 5, MealId = 2 },
        new DailyMenuMeal { DailyMenuId = 5, MealId = 3 },
        new DailyMenuMeal { DailyMenuId = 5, MealId = 7 },

        new DailyMenuMeal { DailyMenuId = 6, MealId = 4 },
        new DailyMenuMeal { DailyMenuId = 6, MealId = 8 },
        new DailyMenuMeal { DailyMenuId = 6, MealId = 9 },

        new DailyMenuMeal { DailyMenuId = 7, MealId = 6 },
        new DailyMenuMeal { DailyMenuId = 7, MealId = 7 },
        new DailyMenuMeal { DailyMenuId = 7, MealId = 10 }
    };
}
