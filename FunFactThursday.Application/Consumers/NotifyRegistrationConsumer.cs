using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Consumers;

public class NotifyRegistrationConsumer : IConsumer<RegistrationSubmitted>
{
    private readonly ILogger<NotifyRegistrationConsumer> _logger;

    public NotifyRegistrationConsumer(ILogger<NotifyRegistrationConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RegistrationSubmitted> context)
    {
        _logger.LogInformation(
            "User {UserId} registered for Event {EventId} on {RegistrationDate} Registration {RegistrationId}",
            context.Message.UserId,
            context.Message.EventId,
            context.Message.RegistrationDate,
            context.Message.RegistrationId);

        return Task.CompletedTask;
    }
}