using System.Net;
using System.Text.Json;
using FunFactThursday.Domain.common.Errors;

namespace FunFactThursday.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            await HandleCustomExceptionAsync(context, ex);
        }   
    }

    public class CustomExceptionResponse
    {
        public int HttpStatusCode { get; set; }
        
        public string Message { get; set; } = null!;
    }

    private async Task HandleCustomExceptionAsync(HttpContext context, CustomException exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var customExceptionResponse = new CustomExceptionResponse
        {
            Message = exception.Message
        };

        switch (exception.HttpStatusCode)
        {
            case HttpStatusCode.BadRequest:
                customExceptionResponse.HttpStatusCode = 400;
                response.StatusCode = 400;
                break;
            case HttpStatusCode.NotFound:
                customExceptionResponse.HttpStatusCode = 404;
                response.StatusCode = 404;
                break;
            case HttpStatusCode.InternalServerError:
                customExceptionResponse.HttpStatusCode = 500;
                response.StatusCode = 500;
                break;
            default:
                customExceptionResponse.HttpStatusCode = 500;
                response.StatusCode = 500;
                break;
        }

        await context.Response.WriteAsync(JsonSerializer.Serialize(customExceptionResponse));
    }
}