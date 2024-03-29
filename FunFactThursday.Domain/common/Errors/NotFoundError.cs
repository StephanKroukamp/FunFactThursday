using System.Net;

namespace FunFactThursday.Domain.common.Errors;

public sealed class NotFoundError : Error
{
    public NotFoundError(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message)
    {
    }
}