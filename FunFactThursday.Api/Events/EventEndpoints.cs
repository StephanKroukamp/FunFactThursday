using FunFactThursday.Application.Events;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Events;

public static class EventEndpoints
{
    public static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/events", async ([FromServices] IEventService eventService, CancellationToken cancellationToken) =>
        await eventService.GetAllAsync(cancellationToken))
        .WithTags("Events");

        app.MapGet("/event",
            async ([FromQuery] Guid eventId, [FromServices] IEventService eventService, CancellationToken cancellationToken)
                => await eventService.GetByIdAsync(eventId, cancellationToken))
            .WithTags("Events");

        app.MapPost("/event",
            async ([FromBody] CreateEventDto createEventDto, [FromServices] IEventService eventService,
                    CancellationToken cancellationToken) =>
                await eventService.CreateAsync(createEventDto, cancellationToken))
            .WithTags("Events");
    }
}