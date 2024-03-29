using FunFactThursday.Domain.Registrations;

namespace FunFactThursday.Application.Registrations;

public interface IRegistrationService
{
    Task<List<Registration>> GetAlLAsync(CancellationToken cancellationToken);
    Task<RegistrationDto> CreateAsync(CreateRegistrationDto createRegistrationDto, CancellationToken cancellationToken);
}