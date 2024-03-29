namespace FunFactThursday.Application.Events;

public interface IEventService
{
    Task<List<EventDto>> GetAllAsync(CancellationToken cancellationToken);

    Task<EventDto> GetByIdAsync(Guid eventId, CancellationToken cancellationToken);

    Task<EventDto> CreateAsync(CreateEventDto createEventDto, CancellationToken cancellationToken);
}