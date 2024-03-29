using System.Net;

namespace FunFactThursday.Domain.common.Errors;

public sealed class ConflictError : Error
{
    public ConflictError(HttpStatusCode httpStatusCode, string message) : base(httpStatusCode, message)
    {
    }
}