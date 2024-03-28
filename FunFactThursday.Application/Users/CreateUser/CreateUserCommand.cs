using MediatR;

namespace FunFactThursday.Application.Users.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}