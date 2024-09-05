using System.Net;

namespace IcecreamMAUI.Shared.Models;

public record ServiceResult(HttpStatusCode StatusCode, string? ErrorMessage, List<string>? ErrorMessages)
{
    public static ServiceResult Success()
        => new(HttpStatusCode.OK, null, null);
    public static ServiceResult BadRequest(string? errorMessage = null, List<string>? errorMessages = null)
        => new(HttpStatusCode.BadRequest, errorMessage, errorMessages);

    public static ServiceResult NotFound(string errorMessage)
        => new(HttpStatusCode.NotFound, errorMessage, null);

    public static ServiceResult ServerError(string errorMessage)
        => new(HttpStatusCode.InternalServerError, errorMessage, null);

    public static ServiceResult NoContent()
        => new(HttpStatusCode.NoContent, null, null);
}

public record ServiceResult<T>(HttpStatusCode StatusCode, T? Data, string? ErrorMessage, List<string>? ErrorMessages)
{
    public static ServiceResult<T> Success(T data)
        => new(HttpStatusCode.OK, data, null, null);

    public static ServiceResult<T> BadRequest(string? errorMessage = null, List<string>? errorMessages = null)
        => new(HttpStatusCode.BadRequest, default, errorMessage, errorMessages);

    public static ServiceResult<T> NotFound(string errorMessage)
        => new(HttpStatusCode.NotFound, default, errorMessage, null);

    public static ServiceResult<T> ServerError(string errorMessage)
        => new(HttpStatusCode.InternalServerError, default, errorMessage, null);

    public static ServiceResult<T> NoContent()
        => new(HttpStatusCode.NoContent, default, null, null);
}