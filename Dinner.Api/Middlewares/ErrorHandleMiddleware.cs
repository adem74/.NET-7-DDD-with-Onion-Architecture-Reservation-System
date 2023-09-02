using System.Text.Json;

namespace Dinner.Api.Middlewares;

public class ErrorHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    public static Task HandleException(HttpContext context, Exception ex)
    {
        var result = JsonSerializer.Serialize(new { Error = ex?.Message, HasError = true });
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}
