using FunFactThursday.Application.Registrations;
using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Registrations;

public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/registration", async ([FromBody] CreateRegistrationDto createRegistrationDto, [FromServices] IPublishEndpoint publishEndpoint, CancellationToken cancellationToken) =>
                    await publishEndpoint.Publish(new CreateRegistration
                    {
                        EventName = createRegistrationDto.EventName,
                        UserEmailAddress = createRegistrationDto.UserEmailAddress,
                        Payment = createRegistrationDto.Payment
                    }, cancellationToken))
            .WithTags("Registrations");

        app.MapGet("/registrations",
                async ([FromServices] IRegistrationService registrationService, CancellationToken cancellationToken) =>
                await registrationService.GetAllAsync(cancellationToken))
            .WithTags("Registrations");

        app.MapGet("/registration",
                async ([FromQuery] Guid registrationId, [FromServices] IRegistrationService registrationService,
                        CancellationToken cancellationToken)
                    => await registrationService.GetByIdAsync(registrationId, cancellationToken))
            .WithTags("Registrations");
    }
}