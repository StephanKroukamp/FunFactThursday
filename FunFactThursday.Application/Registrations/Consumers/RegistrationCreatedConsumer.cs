using FunFactThursday.Domain.Contracts;
using MassTransit;

namespace FunFactThursday.Application.Registrations.Consumers;

public class RegistrationCreatedConsumer : IConsumer<RegistrationCreated>
{
    public Task Consume(ConsumeContext<RegistrationCreated> context)
    {
        var message = context.Message;
        
        return Task.CompletedTask;
    }
}