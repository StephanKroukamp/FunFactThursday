using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Registrations.Consumers;

public class AddEventAttendeeConsumer :
    IConsumer<AddEventAttendee>
{
    private readonly ILogger<AddEventAttendeeConsumer> _logger;

    public AddEventAttendeeConsumer(ILogger<AddEventAttendeeConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<AddEventAttendee> context)
    {
        _logger.LogInformation("Adding User {UserId} as an attendee for Event {EventId}", context.Message.UserId,
            context.Message.EventId);

        return Task.CompletedTask;
    }
}