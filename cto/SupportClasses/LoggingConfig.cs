using Serilog;

namespace cto.SupportClasses;

public static class LoggingConfig
{
    public static void ConfigureLogging()
    {
        //FolderPaths.Instance.InitializePaths();
        var logFolderPath = FolderPaths.Instance.LogFolderPath;
        const string fileName = "cto_log"+ "_" + ".txt";
        var filePath = Path.Combine(logFolderPath, fileName);
            
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}