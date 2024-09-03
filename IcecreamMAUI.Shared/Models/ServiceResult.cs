namespace IcecreamMAUI.Shared.Models;

public record ServiceResult(bool IsSuccess, string? ErrorMessage)
{
    public static ServiceResult Success() => new(true, null);
    public static ServiceResult Failure(string? errorMessage) => new(false, errorMessage);
}

public record ServiceResult<T>(bool IsSuccess, T Data, string? ErrorMessage) : ServiceResult(IsSuccess, ErrorMessage) where T : class
{
    public static ServiceResult<T> Success(T data) => new(true, data, null);
    public static new ServiceResult<T> Failure(string? errorMessage) => new(false, default!, errorMessage);
}