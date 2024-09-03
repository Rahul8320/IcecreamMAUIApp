using FluentValidation;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Utils;

public class RequestHandler(IServiceProvider serviceProvider)
{
    public async Task<IResult> HandleRequest<TRequest, TResponse>(
       TRequest requestModel,
       Func<TRequest, Task<ServiceResult<TResponse>>> serviceCall) where TResponse : class
    {
        var validator = serviceProvider.GetRequiredService<IValidator<TRequest>>();
        var validationResult = await validator.ValidateAsync(requestModel);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors.ToValidationErrors());
        }

        var result = await serviceCall(requestModel);
        return result.ToHttpResponse();
    }
}
