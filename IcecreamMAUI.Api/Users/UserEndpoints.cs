using IcecreamMAUI.Api.Users.Services;
using IcecreamMAUI.Api.Users.UseCases;
using IcecreamMAUI.Api.Utils;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Users;

public static class UserEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost( "/api/signup", RegisterUser.Handler ).WithTags("Users");

        app.MapPost( "/api/signin", LoginUser.Handler ).WithTags("Users");
    }
}
