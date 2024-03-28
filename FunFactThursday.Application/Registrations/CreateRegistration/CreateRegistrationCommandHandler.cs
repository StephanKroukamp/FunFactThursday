using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Contracts;
using FunFactThursday.Domain.Registrations;
using MassTransit;
using MediatR;

namespace FunFactThursday.Application.Registrations.CreateRegistration;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, RegistrationDto>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegistrationCommandHandler(IPublishEndpoint publishEndpoint, IRegistrationRepository registrationRepository, IUnitOfWork unitOfWork)
    {
        _publishEndpoint = publishEndpoint;
        _registrationRepository = registrationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegistrationDto> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
    {
        //TODO: check unique of event and member id, and 2 helpers in repo. quick ez
        
        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.UtcNow,
            MemberId = StringGenerator.Generate(),
            EventId = StringGenerator.Generate(),
            Payment = 10000
        };

        _registrationRepository.Add(registration);

        await _publishEndpoint.Publish(new RegistrationSubmitted
        {
            RegistrationId = registration.Id,
            RegistrationDate = DateTime.Now,
            MemberId = "random",
            EventId = "random",
            Payment = 1000
        }, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return registration.MapToRegistrationDto();
    }
}