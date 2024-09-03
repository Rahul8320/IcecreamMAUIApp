namespace IcecreamMAUI.Api.Users.Services;

public interface ITokenService
{
    string GenerateJWT(Guid userId, string userName, string email, string address);
}
