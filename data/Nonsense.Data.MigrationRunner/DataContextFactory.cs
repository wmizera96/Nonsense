using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Nonsense.Common;

namespace Nonsense.Data.MigrationRunner;

public class DataContextFactory : IDesignTimeDbContextFactory<NonsenseDataContext>
{
    public NonsenseDataContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationManager()
            .AddDotEnvFile();

        var connectionString = configuration.GetValue<string>("Database:ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<NonsenseDataContext>()
            .UseSqlServer(connectionString, 
                builder => builder.MigrationsAssembly(typeof(DataContextFactory).Assembly.FullName));
        
        return new NonsenseDataContext(optionsBuilder.Options);
    }
}