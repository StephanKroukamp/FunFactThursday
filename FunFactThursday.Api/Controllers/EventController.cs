using FunFactThursday.Application.Events;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;
    
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet("GetEvents")]
    public async Task<List<EventDto>> Get() =>
        await _eventService.GetAllAsync(default);
    
    [HttpGet("GetEvent/{eventId}")]
    public async Task<EventDto> Get([FromRoute] Guid eventId) =>
        await _eventService.GetByIdAsync(eventId, default);
    
    [HttpPost("CreateRegistration")]
    public async Task<EventDto> Create([FromBody] CreateEventDto createEventDto) => 
        await _eventService.CreateAsync(createEventDto, default);
    
    
}