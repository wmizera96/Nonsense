using Microsoft.EntityFrameworkCore;

namespace Nonsense.Data.MigrationRunner;

public static class MigrationRunner
{
    public static async Task MigrateAsync(DbContext context)
    {
        await context.Database.MigrateAsync();
    }
}