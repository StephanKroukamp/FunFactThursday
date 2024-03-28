using FunFactThursday.Domain.Users;

namespace FunFactThursday.Application.Users;

public static class UserDtoExtensions
{
    public static UserDto MapToUserDto(this User user) => 
        new(user.Id, user.Email, user.FirstName, user.LastName);
}