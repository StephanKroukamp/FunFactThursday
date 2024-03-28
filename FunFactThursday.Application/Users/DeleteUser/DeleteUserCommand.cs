using FunFactThursday.Domain.Users;
using MediatR;

namespace FunFactThursday.Application.Users.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(UserId userId)
    {
        UserId = userId;
    }

    public UserId UserId { get; set; }
}