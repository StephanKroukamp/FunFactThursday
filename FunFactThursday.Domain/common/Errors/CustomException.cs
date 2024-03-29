using System.Net;

namespace FunFactThursday.Domain.common.Errors;

public class CustomException : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    private CustomException()
    {
    }

    public CustomException(Error error) : base(error.Message)
    {
        HttpStatusCode = error.HttpStatusCode;
    }
}