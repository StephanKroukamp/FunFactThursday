namespace FunFactThursday.Domain.Contracts;

public record AddEventAttendee
{
    public Guid RegistrationId { get; init; }
    public Guid UserId { get; init; }
    public Guid EventId { get; init; }
}