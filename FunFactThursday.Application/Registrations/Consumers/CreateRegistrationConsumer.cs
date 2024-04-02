using FunFactThursday.Domain.Contracts;
using MassTransit;

namespace FunFactThursday.Application.Registrations.Consumers;

public class CreateRegistrationConsumer : IConsumer<CreateRegistration>
{
    private readonly IRegistrationService _registrationService;
    
    public CreateRegistrationConsumer(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    public async Task Consume(ConsumeContext<CreateRegistration> context)
    {
        var message = context.Message;

        var registrationDto = await _registrationService.CreateAsync(new CreateRegistrationDto
        {
            EventName = message.EventName,
            UserEmailAddress = message.UserEmailAddress,
            Payment = message.Payment
        }, default);

        await context.Publish(new RegistrationCreated
        {
            RegistrationId = registrationDto.Id,
            RegistrationDate = registrationDto.RegistrationDate,
            Payment = registrationDto.Payment,
            UserId = registrationDto.UserId,
            EventId = registrationDto.EventId
        });
    }
}