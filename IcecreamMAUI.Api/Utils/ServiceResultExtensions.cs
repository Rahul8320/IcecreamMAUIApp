using System.Net;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Utils;

public static class ServiceResultExtensions
{
    public static IResult ToHttpResponse<T>(this ServiceResult<T> serviceResult) where T : class
    {
        return serviceResult.StatusCode switch
        {
            HttpStatusCode.OK => Results.Ok(serviceResult.Data),
            HttpStatusCode.NoContent => Results.NoContent(),
            HttpStatusCode.NotFound => Results.NotFound(serviceResult.ErrorMessage),
            HttpStatusCode.BadRequest => Results.BadRequest(serviceResult.ErrorMessages ?? [serviceResult.ErrorMessage]),
            HttpStatusCode.InternalServerError => Results.Problem(
                detail: serviceResult.ErrorMessage,
                null,
                statusCode: 500,
                type: "Internal Server Error"),
            _ => Results.Problem(
                detail: "An unexpected error occur",
                null,
                statusCode: 500,
                type: "Internal Server Error"),
        };
    }
}
