using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services.Authentication;

namespace Restaurant.Application;

public static class ServiceContainer
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}