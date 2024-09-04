using IcecreamMAUI.ViewModels;

namespace IcecreamMAUI.Pages;

public partial class SigninPage : ContentPage
{
	public SigninPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
	}

	private async void GoToApp(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
	}
}