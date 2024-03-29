using FunFactThursday.Application.Registrations;
using FunFactThursday.Application.Registrations.CreateRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateRegistration")]
    public async Task<RegistrationDto> Create([FromBody] CreateRegistrationCommand createRegistrationCommand) => await _mediator.Send(createRegistrationCommand);
}