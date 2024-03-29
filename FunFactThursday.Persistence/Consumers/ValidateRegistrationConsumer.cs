using FunFactThursday.Domain.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FunFactThursday.Persistence.Consumers;

public class ValidateRegistrationConsumer :
    IConsumer<AddEventAttendee>
{
    private readonly ILogger<ValidateRegistrationConsumer> _logger;
    private readonly IRegistrationValidationService _validationService;

    public ValidateRegistrationConsumer(ILogger<ValidateRegistrationConsumer> logger,
        IRegistrationValidationService validationService)
    {
        _logger = logger;
        _validationService = validationService;
    }

    public async Task Consume(ConsumeContext<AddEventAttendee> context)
    {
        await _validationService.ValidateRegistration(context.Message.EventId, context.Message.UserId,
            context.Message.RegistrationId);
    }
}