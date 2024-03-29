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

    [HttpPost("CreateRegistration")]
    public async Task<RegistrationDto> Create([FromBody] CreateRegistrationDto createRegistrationDto) => 
        await _registrationService.CreateAsync(createRegistrationDto, default);
}