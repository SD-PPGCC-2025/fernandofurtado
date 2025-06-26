using System.Net;

namespace BXTecnologia.API.Validation;

/// <summary>
/// Custom exception for API errors with HTTP status code
/// </summary>
public class ApiException : Exception
{
    /// <summary>
    /// HTTP Status code associated with this exception
    /// </summary>
    public HttpStatusCode StatusCode { get; }
    
    /// <summary>
    /// Additional error details (optional)
    /// </summary>
    public object? ErrorDetails { get; }

    /// <summary>
    /// Creates a new API exception with the specified message and status code
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="statusCode">HTTP status code</param>
    public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) 
        : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Creates a new API exception with the specified message, status code, and error details
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="statusCode">HTTP status code</param>
    /// <param name="errorDetails">Additional error details</param>
    public ApiException(string message, HttpStatusCode statusCode, object errorDetails) 
        : base(message)
    {
        StatusCode = statusCode;
        ErrorDetails = errorDetails;
    }

    /// <summary>
    /// Creates a new API exception with the specified message, inner exception, and status code
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    /// <param name="statusCode">HTTP status code</param>
    public ApiException(string message, Exception innerException, HttpStatusCode statusCode = HttpStatusCode.BadRequest) 
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}
