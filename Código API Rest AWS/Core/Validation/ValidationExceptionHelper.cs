using System.Net;

namespace BXTecnologia.API.Validation;

/// <summary>
/// Helper class for throwing validation exceptions
/// </summary>
public static class ValidationExceptionHelper
{
    /// <summary>
    /// Throws an ApiException if the condition is false
    /// </summary>
    /// <param name="condition">Condition to check</param>
    /// <param name="message">Error message if condition is false</param>
    /// <param name="statusCode">HTTP status code to return</param>
    /// <exception cref="ApiException">Thrown if condition is false</exception>
    public static void ThrowIf(bool condition, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (condition)
        {
            throw new ApiException(message, statusCode);
        }
    }

    /// <summary>
    /// Throws an ApiException if the object is null
    /// </summary>
    /// <param name="obj">Object to check</param>
    /// <param name="message">Error message if object is null</param>
    /// <param name="statusCode">HTTP status code to return</param>
    /// <exception cref="ApiException">Thrown if object is null</exception>
    public static void ThrowIfNull(object? obj, string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
    {
        if (obj == null)
        {
            throw new ApiException(message, statusCode);
        }
    }

    /// <summary>
    /// Throws an ApiException if the string is null or empty
    /// </summary>
    /// <param name="value">String to check</param>
    /// <param name="message">Error message if string is null or empty</param>
    /// <param name="statusCode">HTTP status code to return</param>
    /// <exception cref="ApiException">Thrown if string is null or empty</exception>
    public static void ThrowIfNullOrEmpty(string? value, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ApiException(message, statusCode);
        }
    }

    /// <summary>
    /// Throws an ApiException for resource not found
    /// </summary>
    /// <param name="resourceName">Name of the resource</param>
    /// <param name="id">ID of the resource</param>
    /// <exception cref="ApiException">Thrown with NotFound status code</exception>
    public static void ThrowNotFound(string resourceName, string id)
    {
        throw new ApiException($"{resourceName} com ID {id} não foi encontrado.", HttpStatusCode.NotFound);
    }

    /// <summary>
    /// Throws an ApiException for unauthorized access
    /// </summary>
    /// <param name="message">Error message</param>
    /// <exception cref="ApiException">Thrown with Unauthorized status code</exception>
    public static void ThrowUnauthorized(string message = "Acesso não autorizado.")
    {
        throw new ApiException(message, HttpStatusCode.Unauthorized);
    }

    /// <summary>
    /// Throws an ApiException for forbidden access
    /// </summary>
    /// <param name="message">Error message</param>
    /// <exception cref="ApiException">Thrown with Forbidden status code</exception>
    public static void ThrowForbidden(string message = "Você não tem permissão para acessar este recurso.")
    {
        throw new ApiException(message, HttpStatusCode.Forbidden);
    }

    /// <summary>
    /// Throws an ApiException for duplicate resource
    /// </summary>
    /// <param name="resourceName">Name of the resource</param>
    /// <param name="fieldName">Name of the field that is duplicate</param>
    /// <param name="value">Value that is duplicate</param>
    /// <exception cref="ApiException">Thrown with Conflict status code</exception>
    public static void ThrowDuplicate(string resourceName, string fieldName, string value)
    {
        throw new ApiException(
            $"Já existe um {resourceName} com {fieldName} '{value}'.", 
            HttpStatusCode.Conflict);
    }
}
