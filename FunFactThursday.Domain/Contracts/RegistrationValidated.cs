namespace FunFactThursday.Domain.Contracts;

public record RegistrationValidated
{
    public Guid RegistrationId { get; init; }
}