using cto.SupportClasses;
using cto.Versioning;
using Serilog;

namespace cto.ProgramClasses;

public class FileDetails
{
    public required string FilePath { get; set; }
    public required string FileName { get; set; }
}

public static class StartReadingProcess
{
    private static readonly string ConfigFilePath = Path
        .Combine(
            Directory.GetCurrentDirectory(), "ConfigFiles"
        );
    
    public static async Task StartReading()
    {
        
        MakeBanner.AppName();
        LoggingConfig.ConfigureLogging();
        try
        {
            Log.Information("Application Started ....");

            var configFiles = Directory.GetFiles(ConfigFilePath)
                .Select(file => new FileDetails
                {
                    FilePath = file,
                    FileName = Path.GetFileName(file)
                })
                .ToArray();
            
            if (configFiles.Length == 0)
            {
                Log.Error("Config folder is empty ....");
                return;
            }

            foreach (var configFile in configFiles)
            {
                if (configFile.FileName.Contains("default")) continue;
                
                var settings = await ReadSettings.ReadAppSettings(configFile.FilePath);
                
                if (settings == null)
                {
                    Log.Error("AppSettings is empty ....");
                    return;
                }
                
                await FileInputMethodSelector.SelectInputMethodAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}