using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nonsense.Common;

namespace Nonsense.Data.MigrationRunner;

public class DataContextFactory
{
    public NonsenseDataContext CreateDataContext()
    {
        var configuration = new ConfigurationManager()
            .AddDotEnvFile();

        var connectionString = configuration.GetValue<string>("Database:ConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<NonsenseDataContext>()
            .UseSqlServer(connectionString);
        
        return new NonsenseDataContext(optionsBuilder.Options);
    }
}