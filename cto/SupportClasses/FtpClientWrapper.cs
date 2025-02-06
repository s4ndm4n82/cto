using cto.Classes;
using cto.Interfaces;
using cto.ProgramClasses;
using FluentFTP;
using Serilog;

namespace cto.SupportClasses;

public class FtpClientWrapper : IFileTransferClient
{
    private readonly AsyncFtpClient _ftpClient;
    private readonly CancellationToken _cancellationToken = new CancellationToken();
    
    public FtpClientWrapper()
    {
        var settings = GlobalAppSettings.Instance.Settings;
        
        if (settings == null)
        {
            Log.Error("AppSettings is empty ....");
            Environment.Exit(0);
        }
        
        var ftpHost = settings.AppConfigs.FtpDeliverSettings.Host;
        var ftpUserName = settings.AppConfigs.FtpDeliverSettings.UserName;
        var ftpPass = settings.AppConfigs.FtpDeliverSettings.Password;
        var ftpPort = settings.AppConfigs.FtpDeliverSettings.Port;
        
        _ftpClient = new AsyncFtpClient(ftpHost, ftpUserName, ftpPass, ftpPort);
    }
    
    public async Task ConnectAsync()
    {
        try
        {
            await _ftpClient.Connect(_cancellationToken);
            Log.Information("Connected to the FTP server ....");
        }
        catch (Exception e)
        {
            Log.Error(e, "Error connecting to the FTP server ....");
            throw;
        }
    }
    
    public async Task DisconnectAsync()
    {
        try
        {
            await _ftpClient.Disconnect(_cancellationToken);
            Log.Information("Disconnected from the FTP server ....");
        }
        catch (Exception e)
        {
            Log.Error(e, "Error disconnecting from the FTP server ....");
            throw;
        }
    }
    
    public async Task<bool> DownloadFilesAsync(string localPath, string remotePath)
    {
        try
        {
            await _ftpClient.Connect();
            Log.Information("Downloading files from the FTP server ....");
            
            // Get the list of files in the remote directory
            var ftpFileList = await _ftpClient.GetListing(remotePath, _cancellationToken);
            // Filter the list to only include files
            var listToDownload = ftpFileList
                .Where(x => x.Type == FtpObjectType.File)
                .Select(f => f.FullName);
            
            // Download the files
            var remoteFiles = listToDownload as string[] ?? listToDownload.ToArray();
            
            var downloadedFiles = await _ftpClient.DownloadFiles(localPath,
                remoteFiles,
                FtpLocalExists.Resume,
                FtpVerify.None,
                FtpError.None,
                _cancellationToken);
            
            if (remoteFiles.Length == downloadedFiles.ToArray().Length)
            {
                Log.Information("Files downloaded successfully ....");
                return true;
            };
            Log.Error("Error downloading files from the FTP server ....");
            return false;

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error downloading files from the FTP server ....");
            return false;
        }
        finally
        {
            await _ftpClient.Disconnect(_cancellationToken);
        }
    }
    
    public async Task DeleteFilesAsync(string remotePath)
    {
        try
        {
            await _ftpClient.Connect(_cancellationToken);
            Log.Information("Deleting files from the FTP server ....");
            var fileList = await _ftpClient.GetListing(remotePath, _cancellationToken);
            
            foreach (var file in fileList)
            {
                await _ftpClient.DeleteFile(file.FullName, _cancellationToken);
                Log.Information($"Deleted file from FTP: {file.Name} ....");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error deleting files from the FTP server ....");
            throw;
        }
        finally
        {
            await _ftpClient.Disconnect(_cancellationToken);
        }
    }
}