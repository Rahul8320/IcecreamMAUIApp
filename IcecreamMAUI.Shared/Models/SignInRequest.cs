using FluentValidation;

namespace IcecreamMAUI.Shared.Models;

public record SignInRequest(string Email, string Password);

public sealed class SignInValidator : AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
    }
}