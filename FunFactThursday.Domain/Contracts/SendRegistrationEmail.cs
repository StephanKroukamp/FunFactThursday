namespace FunFactThursday.Domain.Contracts;

public record SendRegistrationEmail
{
    public Guid RegistrationId { get; init; }
    public DateTime RegistrationDate { get; init; }
    public Guid UserId { get; init; }
    public Guid EventId { get; init; }
}