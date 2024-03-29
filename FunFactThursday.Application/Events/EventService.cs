using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Events;

namespace FunFactThursday.Application.Events;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<EventDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var events = await _eventRepository.GetAllAsync(cancellationToken);
        
        return events
            .Select(x => x.MapToEventDto())
            .ToList();
    }

    public async Task<EventDto> GetByIdAsync(Guid eventId, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(eventId, cancellationToken)
                     ?? throw new Exception("Event Not Found");

        return @event.MapToEventDto();
    }

    public async Task<EventDto> CreateAsync(CreateEventDto createEventDto, CancellationToken cancellationToken)
    {
        if (!await _eventRepository.IsNameUniqueAsync(@createEventDto.Name, cancellationToken))
        {
            throw new Exception("User is already attending the event");
        }

        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Name = createEventDto.Name
        };

        _eventRepository.Add(@event);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.MapToEventDto();
    }
}