using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Application.Consumers;

public class RegistrationValidatedConsumer :
    IConsumer<RegistrationValidated>
{
    private readonly ILogger<RegistrationValidatedConsumer> _logger;

    public RegistrationValidatedConsumer(ILogger<RegistrationValidatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<RegistrationValidated> context)
    {
        _logger.LogInformation("Validated Registration {RegistrationId}", context.Message.RegistrationId);

        return Task.CompletedTask;
    }
}