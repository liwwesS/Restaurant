using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces.Services;
using Restaurant.Application.Services.Authentication;
using Restaurant.Application.Services.Persistence;

namespace Restaurant.Application;

public static class ServiceContainer
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddScoped<IMenuItemsService, MenuItemsService>();
    }
}