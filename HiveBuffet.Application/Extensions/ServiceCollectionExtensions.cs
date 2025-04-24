using HiveBuffet.Application.Interfaces;
using HiveBuffet.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiveBuffet.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMealService, MealService>();
    }
}