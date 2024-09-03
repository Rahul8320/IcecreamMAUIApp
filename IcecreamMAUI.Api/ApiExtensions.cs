using IcecreamMAUI.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace IcecreamMAUI.Api;

public static class ApiExtensions
{
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
}
