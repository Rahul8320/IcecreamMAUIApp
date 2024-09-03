using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

    public string GenerateJWT(Guid userId, string userName, string email, string address)
    {
        string audience = configuration["JWT:Audience"]!;
        string issuer = configuration["JWT:Issuer"]!;
        int expiryInMinutes = Convert.ToInt32(configuration["JWT:ExpiryInMinutes"]!);

        var securityKey = GetSymmetricSecurityKey(configuration);

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.StreetAddress, address),
        ];

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(expiryInMinutes),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private static SymmetricSecurityKey GetSymmetricSecurityKey(IConfiguration configuration)
    {
        string secretKey = configuration["JWT:SecretKey"]!;
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }
}

public interface ITokenService
{
    string GenerateJWT(Guid userId, string userName, string email, string address);
}
