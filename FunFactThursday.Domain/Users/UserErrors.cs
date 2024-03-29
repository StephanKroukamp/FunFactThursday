using System.Net;
using FunFactThursday.Domain.common.Errors;

namespace FunFactThursday.Domain.Users;

public static class UserErrors
{
    public static Error EmailIsNotUnique => new ConflictError(HttpStatusCode.BadRequest, "The specified email is already in use.");

    public static Func<Guid, Error> NotFound => userId => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The user with the id '{userId}' was not found.");
    
    public static Func<string, Error> NotFoundByEmail => email => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The user with the email '{email}' was not found.");
}