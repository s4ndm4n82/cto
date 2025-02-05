using cto.SupportClasses;
using Serilog;

namespace cto.ProgramClasses;

public class CheckFolders
{
    public static bool StartCheckFolders()
    {
        try
        {
            Log.Information("Checking Folders ....");
            var mainLoopCount = 0;
            var subLoopCount = 0;
            FolderPaths.Instance.InitializePaths();

            var logFolderPath = FolderPaths.Instance.LogFolderPath;
            var configFolderPath = FolderPaths.Instance.ConfigFolderPath;
            var holdFolderPath = FolderPaths.Instance.HoldFolderPath;
            var inputFolderName = FolderPaths.Instance.InputFolderName;
            var outputFolderName = FolderPaths.Instance.OutputFolderName;

            if (!Directory.Exists(holdFolderPath))
            {
                Directory.CreateDirectory(holdFolderPath);
            }
            var mainDirectoryList = new[]
            {
                logFolderPath,
                configFolderPath,
                holdFolderPath
            };
            
            foreach (var mainDirectory in mainDirectoryList)
            {
                mainLoopCount++;
                if (!Directory.Exists(mainDirectory))
                {
                    Directory.CreateDirectory(mainDirectory);
                }
            }
            
            if (mainDirectoryList.Length != mainLoopCount)
            {
                Log.Information("Main Folder Check Failed ....");
                return false;
            }
            
            var subDirectoryList = new[]
            {
                inputFolderName,
                outputFolderName
            };

            foreach (var constDirectory in subDirectoryList)
            {
                subLoopCount++;
                var constDirectoryPath = Path.Combine(holdFolderPath, constDirectory);
                if (!Directory.Exists(constDirectoryPath))
                {
                    Directory.CreateDirectory(constDirectoryPath);
                }
            }

            if (subDirectoryList.Length == subLoopCount)
            {
                Log.Information("Folder Check Completed Successfully ....");
                return true;
            }
            
            Log.Information("Folder Check Failed ....");
            return false;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "CheckFolders.StartCheckFolders() Failed");
            return false;
        }
    }
}