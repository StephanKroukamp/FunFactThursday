using FunFactThursday.Domain.Registrations;

namespace FunFactThursday.Application.Registrations;

public static class RegistrationDtoExtensions
{
    public static RegistrationDto MapToRegistrationDto(this Registration registration) =>
        new(
            registration.Id,
            registration.RegistrationDate,
            registration.UserId,
            registration.EventId,
            registration.Payment);
}