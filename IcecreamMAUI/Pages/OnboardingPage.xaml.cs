using IcecreamMAUI.Services;

namespace IcecreamMAUI.Pages;

public partial class OnboardingPage : ContentPage
{
    private readonly AuthService _authService;

    public OnboardingPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected async override void OnAppearing()
    {
        bool isLoggedInUser = _authService.IsUserLoggedIn();

        if (isLoggedInUser) 
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

    private async void GotoSigninPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigninPage));
    }

    private async void GotoSignupPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}