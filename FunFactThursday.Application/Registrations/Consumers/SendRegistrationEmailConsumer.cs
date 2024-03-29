using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Registrations.Consumers;

public class SendRegistrationEmailConsumer :
    IConsumer<SendRegistrationEmail>
{
    readonly ILogger<SendRegistrationEmailConsumer> _logger;

    public SendRegistrationEmailConsumer(ILogger<SendRegistrationEmailConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<SendRegistrationEmail> context)
    {
        _logger.LogInformation("Notifying Member {MemberId} that they registered for event {EventId} on {RegistrationDate}", context.Message.UserId,
            context.Message.EventId, context.Message.RegistrationDate);

        return Task.CompletedTask;
    }
}