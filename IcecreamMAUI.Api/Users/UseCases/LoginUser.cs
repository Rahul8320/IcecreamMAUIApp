using FluentValidation;
using IcecreamMAUI.Api.Users.Services;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Users.UseCases;

public static class LoginUser
{
    public static async Task<ServiceResult<AuthResult>> Handler(
       SignInRequest request,
       IAuthService authService,
       IValidator<SignInRequest> validator,
       CancellationToken cancellationToken)
    {
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if (validationResults.IsValid == false)
        {
            return ServiceResult<AuthResult>.BadRequest(errorMessages: validationResults.Errors.Select(error => error.ErrorMessage).ToList());
        }

        return await authService.SignInAsync(request, cancellationToken);
    }
}
