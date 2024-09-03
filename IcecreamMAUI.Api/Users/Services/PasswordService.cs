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
        byte[] hash = GetHashPassword(password, salt);

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

        byte[] inputHash = GetHashPassword(passwordDto.PlainPassword, salt);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }

    private byte[] GetHashPassword(string password, byte[] salt)
    {
        return Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _algorithmName, HashSize);
    }
}


public interface IPasswordService
{
    PasswordDto GenerateSaltAndHash(string password);

    bool Verify(PasswordDto passwordDto);
}