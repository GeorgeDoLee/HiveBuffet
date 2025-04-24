using HiveBuffet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HiveBuffet.Infrastructure.Persistance;

public class UserDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }
}
