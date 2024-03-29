using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Events;
using FunFactThursday.Domain.Users;

namespace FunFactThursday.Domain.Registrations;

public class Registration : Entity
{
    public Guid Id { get; set; }

    public decimal Payment { get; set; }

    public DateTime RegistrationDate { get; set; }

    public User User { get; set; } = null!;

    public Guid UserId { get; set; }

    public Event Event { get; set; } = null!;

    public Guid EventId { get; set; }
}