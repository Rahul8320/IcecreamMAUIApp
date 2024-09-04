using CommunityToolkit.Maui;
using IcecreamMAUI.Services;
using Microsoft.Extensions.Logging;
using Refit;
using System.Net.Security;
using Xamarin.Android.Net;

namespace IcecreamMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        ConfigureRefit(builder.Services);

        return builder.Build();
    }

    private static void ConfigureRefit(IServiceCollection services)
    {
        var refitSetting = new RefitSettings
        {
            HttpMessageHandlerFactory = () =>
            {
                return new AndroidMessageHandler
                {
                    ServerCertificateCustomValidationCallback = (HttpRequestMessage, ClientCertificateOption, HandlerChangingEventArgs, sslPolicyErrors) =>
                    {
                        return ClientCertificateOption?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                    }
                };
            }
        };

        services.AddRefitClient<IAuthApi>(refitSetting)
            .ConfigureHttpClient(httpClient =>
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7213" : "https://localhost:7213";

                httpClient.BaseAddress = new Uri(baseUrl);
            });
    }
}
