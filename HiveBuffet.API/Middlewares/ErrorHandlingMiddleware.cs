using HiveBuffet.Domain.Exceptions;
using System.Net;

namespace HiveBuffet.API.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "HttpContext cannot be null.");
        }

        if (next == null)
        {
            throw new ArgumentNullException(nameof(next), "RequestDelegate cannot be null.");
        }

        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(notFound.Message);
        }
        catch (Exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("Something went wrong.");
            throw;
        }
    }
}
