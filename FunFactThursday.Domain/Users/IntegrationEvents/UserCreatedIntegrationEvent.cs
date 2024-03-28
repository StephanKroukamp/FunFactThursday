namespace FunFactThursday.Domain.Users.IntegrationEvents;

public sealed record UserCreatedIntegrationEvent(
    UserId Id,
    string Email,
    string FirstName,
    string LastName);