using FunFactThursday.Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace FunFactThursday.Api.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user", async ([FromServices] IUserService userService, CancellationToken cancellationToken) =>
        await userService.GetAllAsync(cancellationToken))
        .WithTags("Users");

        app.MapGet("/users",
            async ([FromQuery] Guid userId, [FromServices] IUserService userService, CancellationToken cancellationToken)
                => await userService.GetByIdAsync(userId, cancellationToken))
            .WithTags("Users");

        app.MapPost("/user",
            async ([FromBody] CreateUserDto createUserDto, [FromServices] IUserService userService,
                    CancellationToken cancellationToken) =>
                await userService.CreateAsync(createUserDto, cancellationToken))
            .WithTags("Users");

        app.MapPut("/user",
            async ([FromBody] UserDto userDto, [FromServices] IUserService userService,
                    CancellationToken cancellationToken) =>
                await userService.UpdateAsync(userDto, cancellationToken))
            .WithTags("Users");

        app.MapDelete("/user",
            async ([FromQuery] Guid userId, [FromServices] IUserService userService, CancellationToken cancellationToken)
                => await userService.DeleteAsync(userId, cancellationToken))
            .WithTags("Users");
    }
}