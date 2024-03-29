using FunFactThursday.Domain.Contracts;

namespace FunFactThursday.Domain.Registrations;

public static class RegistrationEventMappings
{
    public static RegistrationSubmitted MapToRegistrationSubmitted(this Registration registration)
    {
        return new RegistrationSubmitted
        {
            RegistrationId = registration.Id,
            RegistrationDate = registration.RegistrationDate,
            UserId = registration.UserId,
            EventId = registration.EventId,
            Payment = registration.Payment
        };
    }
}