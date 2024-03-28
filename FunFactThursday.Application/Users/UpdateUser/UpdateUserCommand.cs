using MediatR;

namespace FunFactThursday.Application.Users.UpdateUser;

public class UpdateUserCommand : IRequest<UserDto>
{
    public UpdateUserCommand(UserDto userDto)
    {
        UserDto = userDto;
    }

    public UserDto UserDto { get; set; }
}