using FunFactThursday.Domain.Events;

namespace FunFactThursday.Application.Events;

public static class EventDtoExtensions
{
    public static EventDto MapToEventDto(this Event @event) =>
        new(@event.Id, @event.Name);
}