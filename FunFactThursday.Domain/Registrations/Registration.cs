using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Registrations;

public class Registration : Entity
{
    public Guid Id { get; set; }
    
    public decimal Payment { get; set; }
    
    public DateTime RegistrationDate { get; set; }

    public Guid UserId { get; set; }
    
    public Guid EventId { get; set; }
}