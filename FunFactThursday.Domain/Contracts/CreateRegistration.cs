namespace FunFactThursday.Domain.Contracts;

public record CreateRegistration
{
    public string EventName { get; set; } = null!;
    public string UserEmailAddress { get; set; } = null!;
    public decimal Payment { get; set; }
}