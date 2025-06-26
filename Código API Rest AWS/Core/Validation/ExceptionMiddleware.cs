using System.Net;
using System.Text.Json;

namespace BXTecnologia.API.Validation;

/// <summary>
/// Middleware to handle exceptions and return standardized error responses
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException ex)
        {
            await HandleApiExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleApiExceptionAsync(HttpContext context, ApiException exception)
    {
        _logger.LogError(exception, "API Exception: {Message}", exception.Message);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exception.StatusCode;

        var response = new ErrorResponse
        {
            StatusCode = (int)exception.StatusCode,
            Message = exception.Message,
            Details = exception.ErrorDetails
        };

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        
        await context.Response.WriteAsync(json);
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Unhandled Exception: {Message}", exception.Message);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorResponse
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = _environment.IsDevelopment() 
                ? exception.Message 
                : "Um erro interno ocorreu. Por favor, tente novamente mais tarde."
        };

        if (_environment.IsDevelopment())
        {
            response.Details = new
            {
                exception.StackTrace,
                InnerException = exception.InnerException?.Message
            };
        }

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        
        await context.Response.WriteAsync(json);
    }
}

/// <summary>
/// Standard error response format
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// HTTP status code
    /// </summary>
    public int StatusCode { get; set; }
    
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Additional error details (optional)
    /// </summary>
    public object? Details { get; set; }
    
    /// <summary>
    /// Timestamp of when the error occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
