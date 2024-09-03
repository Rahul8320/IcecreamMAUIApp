using IcecreamMAUI.Api.Data;
using IcecreamMAUI.Api.Users.Entities;
using IcecreamMAUI.Api.Users.Models;
using IcecreamMAUI.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.Api.Users.Services;

public class AuthService(
    AppDbContext context,
    ITokenService tokenService,
    IPasswordService passwordService) : IAuthService
{
    public async Task<ServiceResult<AuthResult>> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await GetUserByEmail(request.Email, cancellationToken);

            if (user is null)
            {
                return ServiceResult<AuthResult>.NotFound("User not found");
            }

            bool isVerified = VerifyPassword(request.Password, user);

            if (isVerified == false)
            {
                return ServiceResult<AuthResult>.BadRequest("Invalid Credentials");
            }

            return GenerateAuthResult(user);
        }
        catch (Exception ex)
        {
            return ServiceResult<AuthResult>.ServerError(ex.Message);
        }
    }

    public async Task<ServiceResult<AuthResult>> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            bool isEmailExists = await IsEmailExists(request.Email, cancellationToken);

            if (isEmailExists)
            {
                return ServiceResult<AuthResult>.BadRequest("Email already exists");
            }

            PasswordDto passwordDto = passwordService.GenerateSaltAndHash(request.Password);

            User user = await CreateNewUser(request, passwordDto, cancellationToken);

            return GenerateAuthResult(user);
        }
        catch (Exception ex)
        {
            return ServiceResult<AuthResult>.ServerError(ex.Message);
        }
    }

    private async Task<User> CreateNewUser(SignUpRequest request, PasswordDto passwordDto, CancellationToken cancellationToken)
    {
        User user = new()
        {
            Email = request.Email,
            Name = request.Name,
            Address = request.Address,
            Salt = passwordDto.Salt,
            Hash = passwordDto.HashPassword
        };

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user;
    }

    private ServiceResult<AuthResult> GenerateAuthResult(User user)
    {
        UserDto userDto = user.ToDto();

        string token = tokenService.GenerateJWT(userDto);

        AuthResult authResult = new(userDto, token);

        return ServiceResult<AuthResult>.Success(authResult);
    }

    private bool VerifyPassword(string password, User user)
    {
        PasswordDto passwordDto = new()
        {
            PlainPassword = password,
            HashPassword = user.Hash,
            Salt = user.Salt,
        };

        return passwordService.Verify(passwordDto);
    }

    private async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    private async Task<bool> IsEmailExists(string email, CancellationToken cancellationToken)
    {
        return await context.Users.AsNoTracking().AnyAsync(u => u.Email == email, cancellationToken);
    }
}

public interface IAuthService
{
    Task<ServiceResult<AuthResult>> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);
    Task<ServiceResult<AuthResult>> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
}