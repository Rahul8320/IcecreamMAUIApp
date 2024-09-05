using FluentValidation;
using IcecreamMAUI.Api.Users.Services;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Users.UseCases;

public static class RegisterUser
{
    public static async Task<ServiceResult<AuthResult>> Handler(
        SignUpRequest request, 
        IAuthService authService,
        IValidator<SignUpRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResults = await validator.ValidateAsync(request, cancellationToken);

        if(validationResults.IsValid == false)
        {
            return ServiceResult<AuthResult>.BadRequest(errorMessages: validationResults.Errors.Select(error => error.ErrorMessage).ToList());
        }

        return await authService.SignUpAsync(request, cancellationToken);
    }
}
