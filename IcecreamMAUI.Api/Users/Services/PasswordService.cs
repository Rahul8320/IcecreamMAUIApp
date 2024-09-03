using System.Security.Cryptography;
using IcecreamMAUI.Api.Users.Models;

namespace IcecreamMAUI.Api.Users.Services;

public class PasswordService : IPasswordService
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    private readonly HashAlgorithmName _algorithmName = HashAlgorithmName.SHA256;

    public PasswordDto GenerateSaltAndHash(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException(nameof(password));
        }

        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _algorithmName, HashSize);

        string saltString = Convert.ToHexString(salt);

        string hashPassword = Convert.ToHexString(hash);

        return new PasswordDto
        {
            Salt = saltString,
            PlainPassword = password,
            HashPassword = hashPassword
        };
    }

    public bool Verify(PasswordDto passwordDto)
    {
        byte[] hash = Convert.FromHexString(passwordDto.HashPassword);
        byte[] salt = Convert.FromHexString(passwordDto.Salt);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(passwordDto.PlainPassword, salt, Iterations, _algorithmName, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}


public interface IPasswordService
{
    PasswordDto GenerateSaltAndHash(string password);

    bool Verify(PasswordDto passwordDto);
}