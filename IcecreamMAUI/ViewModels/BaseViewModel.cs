using CommunityToolkit.Mvvm.ComponentModel;

namespace IcecreamMAUI.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    protected async Task RedirectToPage(string url, bool animate = false)
        => await Shell.Current.GoToAsync(url, animate);

    protected async Task ShowErrorAlert(string errorMessage)
        => await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
}