using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Users;

public sealed class User : Entity
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}