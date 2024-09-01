using IcecreamMAUI.Pages;

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

    public AppShell()
    {
        InitializeComponent();

        RegisterRoutes();
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
        await Current.DisplayAlert("Alert", "You will be signout", "Ok");
    }

}
