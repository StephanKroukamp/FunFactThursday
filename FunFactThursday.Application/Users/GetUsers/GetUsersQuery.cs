using MediatR;

namespace FunFactThursday.Application.Users.GetUsers;

public class GetUsersQuery : IRequest<List<UserDto>>
{
}