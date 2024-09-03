using FluentValidation;

namespace IcecreamMAUI.Shared.Models;

public record SignUpRequest(string Name, string Email, string Password, string Address);

public sealed class SignUpValidator : AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(30)
            .WithMessage("Name can't be more than 30 character long.");

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .MaximumLength(100)
            .WithMessage("Email can't be more than 100 character long.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
           .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
           .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
           .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
           .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(r => r.Address)
            .NotEmpty()
            .WithMessage("Address is required")
            .MaximumLength(150)
            .WithMessage("Address can't be more than 150 character long.");
    }
}