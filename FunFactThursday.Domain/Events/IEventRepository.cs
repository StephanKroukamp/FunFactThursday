namespace FunFactThursday.Domain.Events;

public interface IEventRepository
{
    Task<List<Event>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Event?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    void Add(Event @event);

    void Remove(Event @event);
}