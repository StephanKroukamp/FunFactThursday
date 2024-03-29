using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Registrations.Consumers;

public class AddEventAttendeeConsumer :
    IConsumer<AddEventAttendee>
{
    readonly ILogger<AddEventAttendeeConsumer> _logger;

    public AddEventAttendeeConsumer(ILogger<AddEventAttendeeConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<AddEventAttendee> context)
    {
        _logger.LogInformation("Adding Member {MemberId} as an attendee for event {EventId}", context.Message.MemberId, context.Message.EventId);

        return Task.CompletedTask;
    }
}