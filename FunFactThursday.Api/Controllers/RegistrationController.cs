using FunFactThursday.Application.Registrations;
using FunFactThursday.Application.Registrations.CreateRegistration;
using FunFactThursday.Application.Users;
using FunFactThursday.Application.Users.CreateUser;
using FunFactThursday.Application.Users.DeleteUser;
using FunFactThursday.Application.Users.GetUser;
using FunFactThursday.Application.Users.GetUsers;
using FunFactThursday.Application.Users.UpdateUser;
using FunFactThursday.Domain.Users;
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