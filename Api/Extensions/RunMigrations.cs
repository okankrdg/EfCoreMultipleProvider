using Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class RunMigrations
{
    public static void ExecuteMigrations(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var userContext = scope.ServiceProvider.GetRequiredService<UserContext>();
        if (userContext.Database.GetPendingMigrations().Any())
            userContext.Database.Migrate();
        var bookContext = scope.ServiceProvider.GetRequiredService<BookContext>();
        if (bookContext.Database.GetPendingMigrations().Any())
            bookContext.Database.Migrate();
    }
}

