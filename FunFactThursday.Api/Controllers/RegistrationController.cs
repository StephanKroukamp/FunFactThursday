using FunFactThursday.Application.Registrations;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet("GetRegistrations")]
    public async Task<List<RegistrationDto>> Get() =>
        await _registrationService.GetAllAsync(default);
    
    [HttpGet("GetRegistration/{registrationId}")]
    public async Task<RegistrationDto> Get([FromRoute] Guid registrationId) =>
        await _registrationService.GetByIdAsync(registrationId, default);
    
    [HttpPost("CreateRegistration")]
    public async Task<RegistrationDto> Create([FromBody] CreateRegistrationDto createRegistrationDto) => 
        await _registrationService.CreateAsync(createRegistrationDto, default);
}