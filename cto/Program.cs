using cto.ProgramClasses;
using cto.Versioning;
using Serilog;

VersionUpdater.IncrementVersion();

try
{
    if (!CheckFolders.StartCheckFolders())
    {
        Log.Error("Folder Check Failed .... Press any key to exit ....");
        Console.Read();
        Environment.Exit(0);
    }
    
    await StartReadingProcess.StartReading();   
}
catch (Exception ex)
{
    Log.Error(ex, "Application Failed ....");
    Console.Read();
    Environment.Exit(0);
}
finally
{
    Log.Information("Application Ended ....\n");
    Log.CloseAndFlush();
}