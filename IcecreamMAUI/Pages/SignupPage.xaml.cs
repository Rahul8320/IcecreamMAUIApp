using IcecreamMAUI.ViewModels;

namespace IcecreamMAUI.Pages;

public partial class SignupPage : ContentPage
{
	public SignupPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
		BindingContext = authViewModel;
	}

	private async void GotoSigninPage(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SigninPage));
	}
}