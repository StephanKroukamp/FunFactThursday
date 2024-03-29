using FunFactThursday.Domain.common;
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
        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.UtcNow,
            MemberId = StringGenerator.Generate(),
            EventId = StringGenerator.Generate(),
            Payment = request.Payment
        };

        _registrationRepository.Add(registration);
        
        await _publishEndpoint.Publish(registration.MapToRegistrationSubmitted(), cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return registration.MapToRegistrationDto();
    }
}