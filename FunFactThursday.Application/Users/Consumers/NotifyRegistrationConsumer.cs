using FunFactThursday.Application.Users.CreateUser;
using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using MediatR;

namespace FunFactThursday.Application.Users.Consumers;

public class NotifyRegistrationConsumer : IConsumer<RegistrationSubmitted>
{
    private readonly ILogger<NotifyRegistrationConsumer> _logger;
    
    public NotifyRegistrationConsumer(ILogger<NotifyRegistrationConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RegistrationSubmitted> context)
    {
        _logger.LogInformation("Member {MemberId} registered for event {EventId} on {RegistrationDate}", context.Message.MemberId, context.Message.EventId,
            context.Message.RegistrationDate);

        return Task.CompletedTask;
    }
}