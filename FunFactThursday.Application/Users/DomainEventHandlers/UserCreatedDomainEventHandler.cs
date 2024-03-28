using FunFactThursday.Domain.Users.DomainEvents;
using MediatR;

namespace FunFactThursday.Application.Users.DomainEventHandlers;

public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var hello = "hi!";
    }
}