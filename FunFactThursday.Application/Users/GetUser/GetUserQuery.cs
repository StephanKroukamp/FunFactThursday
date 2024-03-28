using FunFactThursday.Domain.Users;
using MediatR;

namespace FunFactThursday.Application.Users.GetUser;

public class GetUserQuery : IRequest<UserDto>
{
    public GetUserQuery(UserId userId)
    {
        UserId = userId;
    }

    public UserId UserId { get; set; }
}