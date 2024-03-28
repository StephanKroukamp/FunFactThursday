using FunFactThursday.Domain.Users;
using MediatR;

namespace FunFactThursday.Application.Users.GetUser;

public class GetUserQuery : IRequest<UserDto>
{
    public GetUserQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}