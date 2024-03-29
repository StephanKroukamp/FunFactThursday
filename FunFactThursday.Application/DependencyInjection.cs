using FunFactThursday.Application.Registrations;
using FunFactThursday.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
    }
}