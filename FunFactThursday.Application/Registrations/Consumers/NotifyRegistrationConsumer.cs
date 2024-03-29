using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Registrations.Consumers;

public class NotifyRegistrationConsumer : IConsumer<RegistrationSubmitted>
{
    private readonly ILogger<NotifyRegistrationConsumer> _logger;
    
    public NotifyRegistrationConsumer(ILogger<NotifyRegistrationConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RegistrationSubmitted> context)
    {
        _logger.LogInformation("Member {MemberId} registered for event {EventId} on {RegistrationDate}", context.Message.UserId, context.Message.EventId,
            context.Message.RegistrationDate);

        return Task.CompletedTask;
    }
}