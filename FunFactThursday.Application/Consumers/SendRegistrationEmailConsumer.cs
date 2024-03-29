using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Consumers;

public class SendRegistrationEmailConsumer :
    IConsumer<SendRegistrationEmail>
{
    private readonly ILogger<SendRegistrationEmailConsumer> _logger;

    public SendRegistrationEmailConsumer(ILogger<SendRegistrationEmailConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<SendRegistrationEmail> context)
    {
        _logger.LogInformation(
            "Notifying User {UserId} that they registered for event {EventId} on {RegistrationDate} Registration {RegistrationId}",
            context.Message.UserId,
            context.Message.EventId,
            context.Message.RegistrationDate,
            context.Message.RegistrationId);

        return Task.CompletedTask;
    }
}