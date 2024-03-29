using FunFactThursday.Domain.Contracts;

namespace FunFactThursday.Domain.Registrations;

public static class RegistrationEventMappings
{
    public static RegistrationSubmitted MapToRegistrationSubmitted(this Registration registration)
        => new()
        {
            RegistrationId = registration.Id,
            RegistrationDate = registration.RegistrationDate,
            MemberId = registration.MemberId,
            EventId = registration.EventId,
            Payment = registration.Payment
        };
}