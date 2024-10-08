﻿using CommunityToolkit.Maui;
using IcecreamMAUI.Pages;
using IcecreamMAUI.Services;
using IcecreamMAUI.ViewModels;
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

        builder.Services.AddTransient<AuthViewModel>()
                        .AddTransient<SigninPage>()
                        .AddTransient<SignupPage>();

        builder.Services.AddSingleton<AuthService>();

        builder.Services.AddTransient<OnboardingPage>();

        builder.Services.AddSingleton<HomeViewModel>().AddSingleton<HomePage>();

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
                    ServerCertificateCustomValidationCallback = (
                    httpRequestMessage,
                    certificate,
                    chain,
                    sslPolicyErrors) =>
                    {
                        return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                    }
                };
            }
        };

        services.AddRefitClient<IAuthApi>(refitSetting).ConfigureHttpClient(SetHttpClient);
        services.AddRefitClient<IIceCreamsApi>(refitSetting).ConfigureHttpClient(SetHttpClient);
    }

    private static void SetHttpClient(HttpClient httpClient) 
    {
        var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7213" : "https://localhost:7213";

        httpClient.BaseAddress = new Uri(baseUrl);
    }
}
