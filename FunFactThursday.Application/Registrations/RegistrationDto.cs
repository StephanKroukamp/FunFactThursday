namespace FunFactThursday.Application.Registrations;

public record RegistrationDto(
    Guid Id,
    DateTime RegistrationDate,
    Guid UserId,
    Guid EventId,
    decimal Payment);