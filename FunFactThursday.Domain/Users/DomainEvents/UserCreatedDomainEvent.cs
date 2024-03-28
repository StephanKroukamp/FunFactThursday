using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Users.DomainEvents;

public sealed record UserCreatedDomainEvent(
    UserId Id,
    string Email,
    string FirstName,
    string LastName) : IDomainEvent;