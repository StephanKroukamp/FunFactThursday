using FunFactThursday.Api.Events;
using FunFactThursday.Api.Registrations;
using FunFactThursday.Api.Users;

namespace FunFactThursday.Api;

public static class DependencyInjection
{
    public static void MapApiEndpoints(this WebApplication app)
    {
        app.MapUserEndpoints();
        app.MapEventEndpoints();
        app.MapRegistrationEndpoints();
    }
}