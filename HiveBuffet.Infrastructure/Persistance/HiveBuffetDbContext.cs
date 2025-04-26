using HiveBuffet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiveBuffet.Infrastructure.Persistance;

public class HiveBuffetDbContext : DbContext
{
    public HiveBuffetDbContext(DbContextOptions<HiveBuffetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Meal> Meals { get; set; }

    public DbSet<DailyMenu> DailyMenus { get; set; }

    public DbSet<DailyMenuMeal> DailyMenuMeals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DailyMenuMeal>(entity =>
        {
            entity.HasOne(dmm => dmm.DailyMenu)
                  .WithMany(dm => dm.DailyMenuMeals)
                  .HasForeignKey(dmm => dmm.DailyMenuId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(dmm => dmm.Meal)
                  .WithMany()
                  .HasForeignKey(dmm => dmm.MealId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
