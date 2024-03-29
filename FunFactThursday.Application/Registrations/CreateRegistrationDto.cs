namespace FunFactThursday.Application.Registrations;

public class CreateRegistrationDto
{
    public string EventName { get; set; } = null!;
    public string UserEmailAddress { get; set; } = null!;
    public decimal Payment { get; set; }
}