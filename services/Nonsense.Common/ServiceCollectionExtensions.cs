using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nonsense.Common.Settings;

namespace Nonsense.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppSettings(this IServiceCollection services, ConfigurationManager configuration)
    {
        configuration.AddJsonFile("appsettings.json", optional: false);

        services.AddOptions<AppSettings>()
            .Bind(configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}