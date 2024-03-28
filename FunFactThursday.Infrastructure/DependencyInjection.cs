using FunFactThursday.Infrastructure.Users;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddMassTransit();
    }
    
    private static IServiceCollection AddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
             x.AddConsumer<UserCreatedIntegrationEventConsumer>();

            x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
        });

        return services;
    }
}