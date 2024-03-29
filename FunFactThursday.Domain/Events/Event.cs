using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Registrations;

namespace FunFactThursday.Domain.Events;

public class Event : Entity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal TotalDonations { get; set; }

    public List<Registration> Registrations = new();
}