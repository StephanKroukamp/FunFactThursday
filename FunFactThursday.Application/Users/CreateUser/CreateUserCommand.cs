using MediatR;

namespace FunFactThursday.Application.Users.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public CreateUserCommand(CreateUserDto createUserDto)
    {
        CreateUserDto = createUserDto;
    }

    public CreateUserDto CreateUserDto { get; set; }
}