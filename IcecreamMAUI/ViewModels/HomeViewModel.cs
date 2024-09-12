using CommunityToolkit.Mvvm.ComponentModel;
using IcecreamMAUI.Services;
using IcecreamMAUI.Shared.Models;
using System.Net;

namespace IcecreamMAUI.ViewModels;

public partial class HomeViewModel(IIceCreamsApi iceCreamsApi, AuthService authService) : BaseViewModel
{
    [ObservableProperty]
    private IceCreamDto[] _iceCreams = [];

    [ObservableProperty]
    private string _userName = string.Empty;

    private bool _isInitialized;

    public async Task InitializeAsync()
    {
        UserName = authService.User!.Name;

        if (_isInitialized)
        {
            return;
        }

        try
        {
            IsBusy = true;
            _isInitialized = true;

            // make api call to fetch IceCreams
            var result =  await iceCreamsApi.GetAllIceCreamAsync();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                await ShowErrorAlert(result.ErrorMessage ?? "Something went wrong!");
                return;
            }

            IceCreams = result.Data!;
        }
        catch (Exception ex)
        {
            _isInitialized = false;
            await ShowErrorAlert(ex.Message);
        }
        finally 
        {
            IsBusy = false;
        }
    }
}
