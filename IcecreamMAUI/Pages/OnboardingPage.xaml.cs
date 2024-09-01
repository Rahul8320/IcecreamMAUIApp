namespace IcecreamMAUI.Pages;

public partial class OnboardingPage : ContentPage
{
    public OnboardingPage()
    {
        InitializeComponent();
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