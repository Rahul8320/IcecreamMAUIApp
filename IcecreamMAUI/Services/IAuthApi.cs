using IcecreamMAUI.Shared.Models;
using Refit;

namespace IcecreamMAUI.Services;

public interface IAuthApi
{
    [Post("/api/signup")]
    Task<ServiceResult<AuthResult>> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);

    [Post("/api/signin")]
    Task<ServiceResult<AuthResult>> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
}