using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Registrations;
using MassTransit;

namespace FunFactThursday.Application.Registrations;

public class RegistrationService : IRegistrationService
{
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    
    public RegistrationService(IRegistrationRepository registrationRepository, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
    {
        _registrationRepository = registrationRepository;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
    }
    
    public async Task<List<Registration>> GetAlLAsync(CancellationToken cancellationToken) =>
        await _registrationRepository.GetAllAsync(cancellationToken);
    
    public async Task<RegistrationDto> CreateAsync(CreateRegistrationDto createRegistrationDto, CancellationToken cancellationToken)
    {
        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.UtcNow,
            MemberId = StringGenerator.Generate(),
            EventId = StringGenerator.Generate(),
            Payment = createRegistrationDto.Payment
        };

        _registrationRepository.Add(registration);
        
        await _publishEndpoint.Publish(registration.MapToRegistrationSubmitted(), cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return registration.MapToRegistrationDto();
    }
}