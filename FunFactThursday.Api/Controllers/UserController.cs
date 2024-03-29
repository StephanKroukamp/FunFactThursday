using FunFactThursday.Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    public async Task<List<UserDto>> Get() =>
        await _userService.GetAllAsync(default);
    
    [HttpGet("GetUser/{userId}")]
    public async Task<UserDto> Get([FromRoute] Guid userId) =>
        await _userService.GetByIdAsync(userId, default);
    
    [HttpPost("CreateUser")]
    public async Task<UserDto> Create([FromBody] CreateUserDto createUserDto) =>
        await _userService.CreateAsync(createUserDto, default);

    [HttpPut("UpdateUser")]
    public async Task<UserDto> Update([FromBody] UserDto userDto) =>
        await _userService.UpdateAsync(userDto, default);

    [HttpDelete("DeleteUser/{userId}")]
    public async Task<bool> Delete([FromRoute] Guid userId) =>
        await _userService.DeleteAsync(userId, default);
}