using System.Net;
using System.Text.Json;
using HiveBuffet.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HiveBuffet.API.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        if (next == null) throw new ArgumentNullException(nameof(next));

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        ProblemDetails problem;
        HttpStatusCode status;

        switch (exception)
        {
            case NotFoundException notFound:
                status = HttpStatusCode.NotFound;
                problem = new ProblemDetails
                {
                    Title = "Resource Not Found",
                    Status = (int)status,
                    Detail = notFound.Message,
                    Instance = context.Request.Path
                };
                break;

            default:
                status = HttpStatusCode.InternalServerError;
                problem = new ProblemDetails
                {
                    Title = "An unexpected error occurred.",
                    Status = (int)status,
                    Detail = exception.Message,
                    Instance = context.Request.Path
                };
                break;
        }

        problem.Extensions["traceId"] = context.TraceIdentifier;

        context.Response.Clear();
        context.Response.StatusCode = (int)status;
        context.Response.ContentType = "application/problem+json";

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(problem, options);
        await context.Response.WriteAsync(json);
    }
}
