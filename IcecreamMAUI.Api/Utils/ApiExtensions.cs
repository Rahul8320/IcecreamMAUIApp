using IcecreamMAUI.Api.Data;
using IcecreamMAUI.Api.IceCreams;
using IcecreamMAUI.Api.IceCreams.Services;
using IcecreamMAUI.Api.Users;
using IcecreamMAUI.Api.Users.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.Api.Utils;

public static class ApiExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(
            option => option.UseSqlite(databaseConnectionString));

        return services;
    }

    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IPasswordService, PasswordService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IIceCreamService, IceCreamService>();

        services.AddTransient<RequestHandler>();

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwtOptions =>
            jwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(configuration)
        );

        services.AddAuthorization();

        return services;
    }

    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var isPendingMigrations = appDbContext.Database.GetPendingMigrations().Any();

        if (isPendingMigrations)
        {
            appDbContext.Database.Migrate();
        }
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        UserEndpoints.MapEndpoints(builder);
        IceCreamEndpoints.MapEndpoints(builder);

        return builder;
    }
}
