using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Registrations;

public class Registration : Entity
{
    public Guid Id { get; set; }
    
    public DateTime RegistrationDate { get; set; }

    public string MemberId { get; set; } = null!;
    
    public string EventId { get; set; } = null!;

    public decimal Payment { get; set; }
}