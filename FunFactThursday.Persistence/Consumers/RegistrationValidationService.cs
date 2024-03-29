using FunFactThursday.Domain.Contracts;
using MassTransit;

namespace FunFactThursday.Persistence.Consumers;

public class RegistrationValidationService :
    IRegistrationValidationService
{
    readonly IPublishEndpoint _publishEndpoint;

    public RegistrationValidationService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task ValidateRegistration(Guid eventId, Guid userId, Guid registrationId)
    {
        await _publishEndpoint.Publish(new RegistrationValidated { RegistrationId = registrationId });
    }
}