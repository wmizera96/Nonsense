
using dotenv.net;
using Microsoft.Extensions.Configuration;

namespace Nonsense.Common;

public static class ConfigurationManagerExtensions
{
    private const string DotEnvFileName = ".env";
    
    public static IConfigurationManager AddDotEnvFile(this IConfigurationManager configuration)
    {
        var dotEnvFilePath = ResolveDotEnvFilePath();
        DotEnv.Load(new DotEnvOptions(envFilePaths: [dotEnvFilePath]));
        configuration.AddEnvironmentVariables();

        return configuration;
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