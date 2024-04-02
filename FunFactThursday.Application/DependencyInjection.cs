using FunFactThursday.Application.Events;
using FunFactThursday.Application.Registrations;
using FunFactThursday.Application.Registrations.Consumers;
using FunFactThursday.Application.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRegistrationService, RegistrationService>();
        services.AddScoped<IEventService, EventService>();
        
        services.ConfigureMassTransit();
    }

    private static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            
            x.AddConsumer<CreateRegistrationConsumer>();
            x.AddConsumer<RegistrationCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
        });
    }
}