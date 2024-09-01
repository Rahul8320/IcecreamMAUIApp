namespace IcecreamMAUI.Pages;

public partial class SigninPage : ContentPage
{
	public SigninPage()
	{
		InitializeComponent();
	}

	private async void GoToApp(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
	}
}