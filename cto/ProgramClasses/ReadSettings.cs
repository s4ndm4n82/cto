using cto.Classes;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace cto.ProgramClasses;

public static class ReadSettings
{
    private static readonly string ConfigFilePath = Path
        .Combine(
            Directory.GetCurrentDirectory(), "ConfigFiles"
        );
    
    public static async Task<AppSettingsClass?> ReadAppSettings(string configFileName)
    {
        try
        {
            var configBuilder = await ReadConfigs(configFileName);
            
            if (configBuilder == null)
            {
                Log.Error("Config file is empty ....");
                return null;
            }
            var appSettings = configBuilder.Get<AppSettingsClass>();
            
            if (appSettings == null)
            {
                Log.Error("AppSettings is empty ....");
                return null;
            }
            
            GlobalAppSettings.Instance.UpdateSettings(appSettings);
            return appSettings;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error reading the AppSettings ....");
            return null;
        }
    }
    private static async Task<IConfigurationRoot?> ReadConfigs(string configFileName)
    {
        try
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(ConfigFilePath)
                .AddJsonFile(configFileName)
                .Build();

            await Task.CompletedTask;
            return configBuilder;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error reading the Config file ....");
            return null;
        }
    }
}