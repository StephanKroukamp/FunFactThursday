using System.Net;
using FunFactThursday.Domain.common.Errors;

namespace FunFactThursday.Domain.Events;

public static class EventErrors
{
    public static Error NameIsNotUnique => new ConflictError(HttpStatusCode.BadRequest, "The specified name is already in use.");

    public static Func<Guid, Error> NotFound => eventId => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The event with the id '{eventId}' was not found.");
    
    public static Func<string, Error> NotFoundByName => name => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The user with the email '{name}' was not found.");
}