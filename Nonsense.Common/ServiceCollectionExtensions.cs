using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nonsense.Common;

public static class ServiceCollectionExtensions
{
    private const string DotEnvFileName = ".env";
    
    public static IServiceCollection AddAppSettings<T>(this IServiceCollection services, ConfigurationManager configuration)
        where T : class
    {
        var dotEnvFilePath = ResolveDotEnvFilePath();
        DotEnv.Load(new DotEnvOptions(envFilePaths: [dotEnvFilePath]));
        configuration.AddEnvironmentVariables();

        services.AddOptions<T>()
            .Bind(configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }

    private static string ResolveDotEnvFilePath()
    {
        var currentDirectory = Environment.CurrentDirectory;
        var dotEnvFilePath = "";
        
        while(string.IsNullOrEmpty(currentDirectory) == false)
        {
            dotEnvFilePath = Path.Combine(currentDirectory, DotEnvFileName);

            if (File.Exists(dotEnvFilePath))
            {
                break;
            }

            currentDirectory = Path.GetDirectoryName(currentDirectory);
        }
        
        return dotEnvFilePath;
    }
}