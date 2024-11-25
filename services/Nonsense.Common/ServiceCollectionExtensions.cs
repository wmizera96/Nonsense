using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nonsense.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppSettings<T>(this IServiceCollection services, ConfigurationManager configuration)
        where T : class
    {
        DotEnv.Load();
        configuration.AddEnvironmentVariables();

        services.AddOptions<T>()
            .Bind(configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}