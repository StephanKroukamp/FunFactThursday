using FunFactThursday.Domain.Contracts;
using MassTransit;

namespace FunFactThursday.Application.Registrations.Consumers;

public class CreateRegistrationConsumer : IConsumer<CreateRegistration>
{
    private readonly IRegistrationService _registrationService;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public CreateRegistrationConsumer(IRegistrationService registrationService, IPublishEndpoint publishEndpoint)
    {
        _registrationService = registrationService;
        _publishEndpoint = publishEndpoint;
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

        await _publishEndpoint.Publish(new RegistrationCreated
        {
            RegistrationId = registrationDto.Id,
            RegistrationDate = registrationDto.RegistrationDate,
            Payment = registrationDto.Payment,
            UserId = registrationDto.UserId,
            EventId = registrationDto.EventId
        });
    }
}