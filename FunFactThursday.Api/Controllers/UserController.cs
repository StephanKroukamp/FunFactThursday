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
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateUser")]
    public async Task<UserDto> Create([FromBody] CreateUserDto createUserDto) => await _mediator.Send(new CreateUserCommand(createUserDto));
    
    [HttpPut("UpdateUser")]
    public async Task<UserDto> Update([FromBody] UserDto userDto) => await _mediator.Send(new UpdateUserCommand(userDto));
    
    [HttpDelete("DeleteUser/{userId}")]
    public async Task<Unit> Delete([FromRoute] Guid userId) => await _mediator.Send(new DeleteUserCommand(new UserId(userId)));
    
    [HttpGet("GetUser/{userId}")]
    
    public async Task<UserDto> Get([FromRoute] Guid userId) => await _mediator.Send(new GetUserQuery(new UserId(userId)));
    
    [HttpGet("GetUsers")]
    public async Task<List<UserDto>> Get() => await _mediator.Send(new GetUsersQuery());
}