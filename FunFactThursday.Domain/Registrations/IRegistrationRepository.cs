namespace FunFactThursday.Domain.Registrations;

public interface IRegistrationRepository
{
    Task<List<Registration>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Registration?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsUserAlreadyAttendingEvent(Guid userId, Guid eventId, CancellationToken cancellationToken = default);
    
    void Add(Registration registration);

    void Remove(Registration registration);
}