using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IcecreamMAUI.Shared.Models;
using Microsoft.IdentityModel.Tokens;

namespace IcecreamMAUI.Api.Users.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        => new()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"]!,
            IssuerSigningKey = GetSymmetricSecurityKey(configuration),
        };

    public string GenerateJWT(UserDto user)
    {
        SymmetricSecurityKey securityKey = GetSymmetricSecurityKey(configuration);

        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = CreateJwtSecurityToken(credentials, user);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken CreateJwtSecurityToken(SigningCredentials credentials, UserDto user)
    {
        string audience = configuration["JWT:Audience"]!;
        string issuer = configuration["JWT:Issuer"]!;
        int expiryInMinutes = Convert.ToInt32(configuration["JWT:ExpiryInMinutes"]!);

        Claim[] claims = CreateClaims(user);

        return new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiryInMinutes),
            signingCredentials: credentials
        );
    }

    private static Claim[] CreateClaims(UserDto user)
    {
        return [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.StreetAddress, user.Address),
        ];
    }

    private static SymmetricSecurityKey GetSymmetricSecurityKey(IConfiguration configuration)
    {
        string secretKey = configuration["JWT:SecretKey"]!;
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }
}

public interface ITokenService
{
    string GenerateJWT(UserDto user);
}
