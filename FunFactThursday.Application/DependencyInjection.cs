using Microsoft.Extensions.DependencyInjection;

namespace FunFactThursday.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
    }
}