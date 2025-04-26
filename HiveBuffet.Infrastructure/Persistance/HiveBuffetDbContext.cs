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
}
