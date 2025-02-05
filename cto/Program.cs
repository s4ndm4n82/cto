using cto.ProgramClasses;
using cto.SupportClasses;
using cto.Versioning;
using Serilog;

LoggingConfig.ConfigureLogging();

try
{
    VersionUpdater.IncrementVersion();
    MakeBanner.AppName();
    Log.Information("Application Started ....");
    if (!CheckFolders.StartCheckFolders())
    {
        Console.WriteLine("Folder Check Failed .... Press any key to exit ....");
        Console.Read();
        Environment.Exit(0);
    }

    ReadInExcelFile.ReadExcelFile();   
}
catch (Exception ex)
{
    Log.Error(ex, "Application Failed ....");
    Console.WriteLine("Application Failed .... Press any key to exit ....");
    Console.Read();
    Environment.Exit(0);
}
finally
{
    Log.Information("Application Ended ....\n");
    Log.CloseAndFlush();
}