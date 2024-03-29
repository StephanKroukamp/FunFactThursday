using FunFactThursday.Application.Registrations;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Registrations;

public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/registration",
                async ([FromBody] CreateRegistrationDto createRegistrationDto, [FromServices] IRegistrationService registrationService,
                        CancellationToken cancellationToken) =>
                    await registrationService.CreateAsync(createRegistrationDto, cancellationToken))
            .WithTags("Registrations");
        
        app.MapGet("/registrations", async ([FromServices] IRegistrationService registrationService, CancellationToken cancellationToken) =>
        await registrationService.GetAllAsync(cancellationToken))
        .WithTags("Registrations");

        app.MapGet("/registration",
            async ([FromQuery] Guid registrationId, [FromServices] IRegistrationService registrationService, CancellationToken cancellationToken)
                => await registrationService.GetByIdAsync(registrationId, cancellationToken))
            .WithTags("Registrations");
    }
}