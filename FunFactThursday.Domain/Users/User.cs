using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Events;
using FunFactThursday.Domain.Registrations;

namespace FunFactThursday.Domain.Users;

public sealed class User : Entity
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Registration> Registrations = new();
}