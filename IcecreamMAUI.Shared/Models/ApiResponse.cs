namespace IcecreamMAUI.Shared.Models;

public record ApiResponse(bool IsSuccess, string? ErrorMessage)
{
    public static ApiResponse Success() => new(true, null);
    public static ApiResponse Error(string? errorMessage) => new(false, errorMessage);
}


public record ApiResponse<T>(bool IsSuccess, T Data, string? ErrorMessage) : ApiResponse(IsSuccess, ErrorMessage);