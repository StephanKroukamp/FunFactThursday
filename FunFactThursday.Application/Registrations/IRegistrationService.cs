namespace FunFactThursday.Application.Registrations;

public interface IRegistrationService
{
    Task<List<RegistrationDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<RegistrationDto> GetByIdAsync(Guid registrationId, CancellationToken cancellationToken);

    Task<RegistrationDto> CreateAsync(CreateRegistrationDto createRegistrationDto, CancellationToken cancellationToken);
}