using FunFactThursday.Domain.Registrations;

namespace FunFactThursday.Application.Registrations;

public record RegistrationDto(
    Guid Id,
    DateTime RegistrationDate,
    string MemberId,
    string EventId,
    decimal Payment);

public static class RegistrationDtoExtensions
{
    public static RegistrationDto MapToRegistrationDto(this Registration registration) =>
        new(
            registration.Id,
            registration.RegistrationDate,
            registration.MemberId,
            registration.EventId,
            registration.Payment);
}