using FunFactThursday.Domain.Users;

namespace FunFactThursday.Application.Users;

public record UserDto(UserId UserId, string Email, string FirstName, string LastName);