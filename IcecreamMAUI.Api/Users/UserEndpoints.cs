using IcecreamMAUI.Api.Users.Services;
using IcecreamMAUI.Api.Utils;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Users;

public static class UserEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/signup",
            async (RequestHandler handler, SignUpRequest request, IAuthService service, CancellationToken cancellationToken)
                => await handler.HandleRequest(request, async request => await service.SignUpAsync(request, cancellationToken))
            ).WithTags("Users");

        app.MapPost(
            "/api/signin",
            async (RequestHandler handler, SignInRequest request, IAuthService service, CancellationToken cancellationToken)
                => await handler.HandleRequest(request, async request => await service.SignInAsync(request, cancellationToken))
            ).WithTags("Users");
    }
}
