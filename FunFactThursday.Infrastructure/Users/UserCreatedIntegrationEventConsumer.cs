using System.Text.Json;
using FunFactThursday.Domain.Users.IntegrationEvents;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Infrastructure.Users;

public class UserCreatedIntegrationEventConsumer : IConsumer<UserCreatedIntegrationEvent>
{
    private readonly ILogger<UserCreatedIntegrationEventConsumer> _logger;

    public UserCreatedIntegrationEventConsumer(ILogger<UserCreatedIntegrationEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserCreatedIntegrationEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("A new User has been created!, look at other logs this is bad. no time for this now");

        return Task.CompletedTask;
    }
}