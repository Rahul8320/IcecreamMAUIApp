using IcecreamMAUI.Pages;
using IcecreamMAUI.Services;

namespace IcecreamMAUI;

public partial class AppShell : Shell
{
    private readonly static Type[] _routablePageType =
       [
           typeof(SigninPage),
            typeof(SignupPage),
            typeof(DetailsPage),
            typeof(MyOrderPage),
            typeof(OrderDetailsPage)
       ];

    private readonly AuthService _authService;

    public AppShell(AuthService authService)
    {
        InitializeComponent();

        RegisterRoutes();
        _authService = authService;
    }

    private static void RegisterRoutes()
    {
        foreach (var pageType in _routablePageType)
        {
            Routing.RegisterRoute(pageType.Name, pageType);
        }

        //Routing.RegisterRoute(nameof(SigninPage), typeof(SigninPage));
        //Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
    }

    private async void GoToGithubPage(object sender, TappedEventArgs e)
    {
        await Launcher.OpenAsync("https://www.github.com/rahul8320");
    }

    private async void Signout(object sender, EventArgs e)
    {
        _authService.SignOut();
        await Current.GoToAsync($"//{nameof(OnboardingPage)}");
    }
}
