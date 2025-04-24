using HiveBuffet.API.Extensions;
using HiveBuffet.Domain.Entities;
using HiveBuffet.Infrastructure.Extensions;
using HiveBuffet.Infrastructure.Persistance;
using HiveBuffet.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.AddPresentation();
builder.Services.AddIdentityApiEndpoints<User>()
        .AddRoles<IdentityRole<int>>()
        .AddEntityFrameworkStores<UserDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
    await seeder.SeedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
