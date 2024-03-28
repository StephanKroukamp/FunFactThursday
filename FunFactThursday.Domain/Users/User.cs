using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Users.DomainEvents;

namespace FunFactThursday.Domain.Users;

public sealed class User : Entity<UserId>, IAuditable
{
    private User(UserId id, string email, string firstName, string lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTimeOffset CreatedOn { get; private set; }

    public DateTimeOffset? ModifiedOn { get; private set; }

    public static User Create(UserId id, string email, string firstName, string lastName)
    {
        var user = new User(id, email, firstName, lastName);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(id, email, firstName, lastName));

        return user;
    }
}