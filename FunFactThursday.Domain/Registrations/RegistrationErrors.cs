using System.Net;
using FunFactThursday.Domain.common.Errors;

namespace FunFactThursday.Domain.Registrations;

public static class RegistrationErrors
{
    public static Error LessThan50 = new ConflictError(HttpStatusCode.InternalServerError, "Less than 500");
    
    public static Error UserAlreadyAttendingEvent = new ConflictError(HttpStatusCode.BadRequest, "THe user is already attending the event");
    
    public static Error NameIsNotUnique => new ConflictError(HttpStatusCode.BadRequest, "This event name is unavailable");

    public static Func<Guid, Error> NotFound => eventId => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The event with the id '{eventId}' was not found.");
    
    public static Func<string, Error> NotFoundByName => name => new NotFoundError(
        HttpStatusCode.NotFound,
        $"The user with the email '{name}' was not found.");
}