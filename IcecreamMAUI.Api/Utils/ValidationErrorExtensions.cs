using FluentValidation.Results;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Utils;

public static class ValidationErrorExtensions
{
    public static List<ValidationError> ToValidationErrors(this IList<ValidationFailure> failures)
        => failures.Select(failure
            => new ValidationError(
                Code: failure.ErrorCode,
                Field: failure.PropertyName,
                Message: failure.ErrorMessage)).ToList();
}
