using IcecreamMAUI.Shared.Models;
using System.Text.Json;

namespace IcecreamMAUI.Services;

public class AuthService
{
    private const string AuthKey = "AuthKey";

    public UserDto? User { get; private set; }
    public string? Token { get; private set; }

    public void Initialize()
    {
        bool isAuthKeyPresent = Preferences.Default.ContainsKey(AuthKey);

        if (isAuthKeyPresent == false)
        {
            return;
        }

        var serializedString = Preferences.Default.Get<string?>(AuthKey, null);

        if (string.IsNullOrEmpty(serializedString))
        {
            Preferences.Default.Remove(AuthKey);
            return;
        }

        var authResult = JsonSerializer.Deserialize<AuthResult>(serializedString);
        User = authResult?.User;
        Token = authResult?.Token;
    }

    public bool IsUserLoggedIn()
    {
        return User != null && User?.Id != null && User.Id != Guid.Empty && string.IsNullOrEmpty(Token) == false;
    }

    public void SignIn(AuthResult result)
    {
        var serializedString = JsonSerializer.Serialize(result);
        Preferences.Default.Set(AuthKey, serializedString);

        User = result.User;
        Token = result.Token;
    }

    public void SignOut() 
    {
        Preferences.Default.Remove(AuthKey);

        User = null;
        Token = null;
    }

}
