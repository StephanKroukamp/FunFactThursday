using FunFactThursday.Domain.Contracts;

namespace FunFactThursday.Domain.Registrations;

public static class RegistrationEventMappings
{
    public static RegistrationCreated MapToRegistrationSubmitted(this Registration registration)
    {
        return new RegistrationCreated
        {
            RegistrationId = registration.Id,
            RegistrationDate = registration.RegistrationDate,
            UserId = registration.UserId,
            EventId = registration.EventId,
            Payment = registration.Payment
        };
    }
}