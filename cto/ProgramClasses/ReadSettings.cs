using cto.Classes;
using cto.SupportClasses;
using Microsoft.Extensions.Configuration;

namespace cto.ProgramClasses;

public class ReadSettings
{
    private static readonly string ConfigFilePath = Path
        .Combine(
            Directory.GetCurrentDirectory(), "ConfigFiles"
        );
    
    private static readonly string DataFilePath = Path
        .Combine(
            Directory.GetCurrentDirectory(), "HoldFolder", "Input"
        );
    
    public static (AppSettingsClass?, string) ReadAppSettings()
    {
        try
        {
            var configFile = FileFunctions.GetMatchingConfigFile(ConfigFilePath, DataFilePath);
            var configBuilder = ReadConfigs(configFile.Item1).Get<AppSettingsClass>();

            return (configBuilder, configFile.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    private static IConfigurationRoot ReadConfigs(string configFileName)
    {
        try
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(ConfigFilePath)
                .AddJsonFile(configFileName)
                .Build();

            return configBuilder;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}