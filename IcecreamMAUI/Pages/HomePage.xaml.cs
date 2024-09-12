using IcecreamMAUI.ViewModels;

namespace IcecreamMAUI.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;

    public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        _homeViewModel = homeViewModel;
        BindingContext = _homeViewModel;
    }

    protected async override void OnAppearing()
	{
		await _homeViewModel.InitializeAsync();
	}
}