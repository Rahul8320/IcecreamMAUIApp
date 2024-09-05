using IcecreamMAUI.Api.Users.UseCases;

namespace IcecreamMAUI.Api.Users;

public static class UserEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost( "/api/signup", RegisterUser.Handler ).WithTags("Users");

        app.MapPost( "/api/signin", LoginUser.Handler ).WithTags("Users");
    }
}
