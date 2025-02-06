using cto.Classes;
using cto.Interfaces;
using cto.SupportClasses;
using Serilog;

namespace cto.ProgramClasses;

public class StartFtpProcess(IFileTransferClient ftpTransferClient)
{
    public async Task StartFtpAsync()
    {
        try
        {
            FolderPaths.Instance.InitializePaths();
            var settings = GlobalAppSettings.Instance.Settings;

            if (settings == null)
            {
                Log.Error("AppSettings is empty ....");
                return;
            }

            var remotePath = settings.AppConfigs.FtpDeliverSettings.RemoteFolderPath;
            var clientName = settings.AppConfigs.ProjectSettings.ClientName;

            var localPath = Path.Combine(FolderPaths.Instance.DownloadFolderPath, clientName);

            if (!Directory.Exists(localPath))
            {
                Directory.CreateDirectory(localPath);
            }

            await ftpTransferClient.ConnectAsync();
            var result = await ftpTransferClient.DownloadFilesAsync(remotePath, localPath);

            if (result)
            {
                //ReadInExcelFile.ReadExcelFile();
            }
        }
        catch (Exception e)
        {
            Log.Error(e, "Error reading from the FTP server ....");
        }
        finally
        {
            await ftpTransferClient.DisconnectAsync();
        }
    }
}