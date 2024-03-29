using System.Net;

namespace FunFactThursday.Domain.common.Errors;

public class Error
{
    protected Error(HttpStatusCode httpStatusCode, string message)
    {
        HttpStatusCode = httpStatusCode;
        Message = message;
    }

    public HttpStatusCode HttpStatusCode { get; }

    public string Message { get; }

    public static implicit operator string(Error error) => error.Message;

    public override string ToString() => Message;
}