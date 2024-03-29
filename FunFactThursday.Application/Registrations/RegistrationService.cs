using FunFactThursday.Domain.common;
using FunFactThursday.Domain.common.Errors;
using FunFactThursday.Domain.Events;
using FunFactThursday.Domain.Registrations;
using FunFactThursday.Domain.Users;
using MassTransit;

namespace FunFactThursday.Application.Registrations;

public class RegistrationService : IRegistrationService
{
    private readonly IEventRepository _eventRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public RegistrationService(
        IRegistrationRepository registrationRepository,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IUserRepository userRepository,
        IEventRepository eventRepository)
    {
        _registrationRepository = registrationRepository;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _userRepository = userRepository;
        _eventRepository = eventRepository;
    }

    public async Task<List<RegistrationDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var registrations = await _registrationRepository
            .GetAllAsync(cancellationToken);

        return registrations
            .Select(x => x.MapToRegistrationDto())
            .ToList();
    }

    public async Task<RegistrationDto> GetByIdAsync(Guid registrationId, CancellationToken cancellationToken)
    {
        var registration = await _registrationRepository
                               .GetByIdAsync(registrationId, cancellationToken)
                           ?? throw new CustomException(RegistrationErrors.NotFound(registrationId));

        return registration.MapToRegistrationDto();
    }

    public async Task<RegistrationDto> CreateAsync(CreateRegistrationDto createRegistrationDto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository
                       .GetByEmailAsync(createRegistrationDto.UserEmailAddress, cancellationToken)
                   ?? throw new CustomException(UserErrors.NotFoundByEmail(createRegistrationDto.UserEmailAddress));

        var @event = await _eventRepository
                         .GetByNameAsync(createRegistrationDto.EventName, cancellationToken)
                     ?? throw new CustomException(EventErrors.NotFoundByName(createRegistrationDto.EventName));

        if (await _registrationRepository.IsUserAlreadyAttendingEvent(user.Id, @event.Id, cancellationToken))
        {
            throw new CustomException(RegistrationErrors.UserAlreadyAttendingEvent);
        }

        var registration = new Registration
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.UtcNow,
            UserId = user.Id,
            EventId = @event.Id,
            Payment = createRegistrationDto.Payment
        };

        _registrationRepository.Add(registration);

        await _publishEndpoint.Publish(registration.MapToRegistrationSubmitted(), cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return registration.MapToRegistrationDto();
    }
}