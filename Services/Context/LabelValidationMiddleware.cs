using Microsoft.AspNetCore.Http.Extensions;

namespace Ktt.ScopeTest.Services.Context;

public class LabelValidationMiddleware
{
    private readonly RequestDelegate _next;

    public LabelValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public static string? GetLabelFromHttpContext(HttpContext httpContext)
    {
        if (httpContext.Request.RouteValues.TryGetValue("label", out var label))
        {
            return label?.ToString();
        }

        var url = httpContext.Request.GetDisplayUrl()!;
        var uri = new Uri(url);
        return uri.Host;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var label = GetLabelFromHttpContext(httpContext);

        if (!LabelContext.Validate(label?.ToString()))
        {
            await WriteErrorResponse(httpContext);
            return;
        }

        await _next(httpContext);
    }

    private static async Task WriteErrorResponse(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(new { error = "Invalid label" });
    }
}