using System.Net;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IcecreamMAUI.Pages;
using IcecreamMAUI.Services;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.ViewModels;

public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
{
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignUp))]
    private string? _name;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignUp)), NotifyPropertyChangedFor(nameof(CanSignIn))]
    private string? _email;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignUp)), NotifyPropertyChangedFor(nameof(CanSignIn))]
    private string? _password;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignUp))]
    private string? _address;

    public bool CanSignIn => string.IsNullOrEmpty(Email) == false && string.IsNullOrEmpty(Password) == false;

    public bool CanSignUp => CanSignIn && string.IsNullOrEmpty(Name) == false && string.IsNullOrEmpty(Address) == false;

    [RelayCommand]
    private async Task SignupAsync()
    {
        IsBusy = true;

        try
        {
            if (CanSignUp == false)
            {
                return;
            }

            var signupRequest = new SignUpRequest(Name: Name!, Email: Email!, Password: Password!, Address: Address!);

            // Make Api Call
            var result = await authApi.SignUpAsync(signupRequest, new CancellationToken());

            if (result.StatusCode == HttpStatusCode.OK)
            {
                authService.SignIn(result.Data!);

                await RedirectToPage($"//{nameof(HomePage)}", animate: true);
                return;
            }

            await ShowErrorAlert(result.ErrorMessage ?? result.ErrorMessages?[0] ?? "Something wrong happened!");
        }
        catch (Exception ex)
        {
            await ShowErrorAlert(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SigninAsync()
    {
        IsBusy = true;

        try
        {
            if (CanSignIn == false)
            {
                return;
            }

            var signinRequest = new SignInRequest(Email: Email!, Password: Password!);

            // Make Api Call
            var result = await authApi.SignInAsync(signinRequest, new CancellationToken());

            if (result.StatusCode == HttpStatusCode.OK)
            {
                authService.SignIn(result.Data!);

                await RedirectToPage($"//{nameof(HomePage)}", animate: true);
                return;
            }

            await ShowErrorAlert(result.ErrorMessage ?? result.ErrorMessages?[0] ?? "Something wrong happened!");
        }
        catch (Exception ex)
        {
            await ShowErrorAlert(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}