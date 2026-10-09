namespace HomeServices.API.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Processing request {Method} {Path}", context.Request.Method, context.Request.Path);
        
        await _next(context);
        
        _logger.LogInformation("Completed request {Method} {Path} with status code {StatusCode}", 
            context.Request.Method, context.Request.Path, context.Response.StatusCode);
    }
}
