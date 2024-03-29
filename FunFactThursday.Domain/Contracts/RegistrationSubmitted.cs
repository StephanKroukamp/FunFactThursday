namespace FunFactThursday.Domain.Contracts;

public record RegistrationSubmitted
{
    public Guid RegistrationId { get; init; }
    public DateTime RegistrationDate { get; init; }
    public decimal Payment { get; init; }
    public Guid UserId { get; init; }
    public Guid EventId { get; init; }
}