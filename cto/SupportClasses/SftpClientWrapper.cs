using cto.Classes;
using cto.Interfaces;
using cto.ProgramClasses;
using Renci.SshNet;
using Renci.SshNet.Async;
using Renci.SshNet.Sftp;
using Serilog;

namespace cto.SupportClasses;

public class SftpClientWrapper : IFileTransferClient
{
    private readonly SftpClient _sftpClient;
    
    public SftpClientWrapper()
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
        
        _sftpClient = new SftpClient(ftpHost, ftpPort, ftpUserName, ftpPass);
    }
    
    public async Task ConnectAsync()
    {
        try
        {
            await _sftpClient.ConnectAsync(CancellationToken.None);
            Log.Information("Connected to the SFTP server ....");
        }
        catch (Exception e)
        {
            Log.Error(e, "Error connecting to the SFTP server ....");
            throw;
        }
    }
    
    public async Task DisconnectAsync()
    {
        try
        {
            _sftpClient.Disconnect();
            await Task.CompletedTask;
            Log.Information("Disconnected from the SFTP server ....");
        }
        catch (Exception e)
        {
            Log.Error(e, "Error disconnecting from the SFTP server ....");
            throw;
        }
    }
    
    public async Task<bool> DownloadFilesAsync(string remotePath, string localPath)
    {
        try
        {
            _sftpClient.Connect();
            var fileList = _sftpClient.ListDirectory(remotePath);
            var sftpFiles = fileList as ISftpFile[] ?? fileList.ToArray();
            var loopCount = 0;

            foreach (var file in sftpFiles)
            {
                var downloadPath = Path.Combine(localPath, file.Name);
                await using var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.ReadWrite);
                await _sftpClient.DownloadAsync(file.FullName, fileStream);

                Log.Information($"Downloaded {file.Name} file from the SFTP server ....");
                loopCount++;
            }
            
            if (loopCount == sftpFiles.Length) return true;

            Log.Error("Error downloading file from the SFTP server ....");
            return false;
        }
        catch (Exception e)
        {
            Log.Error(e, "Error downloading file from the SFTP server ....");
            return false;
        }
        finally
        {
            _sftpClient.Disconnect();
        }
    }
    
    public async Task DeleteFilesAsync(string remotePath)
    {
        try
        {
            _sftpClient.Connect();
            var fileList = _sftpClient.ListDirectory(remotePath);
            
            foreach (var file in fileList)
            {
                await _sftpClient.DeleteAsync(file.FullName, CancellationToken.None);
                Log.Information($"Deleted {file.Name} file from the SFTP server ....");
            }
        }
        catch (Exception e)
        {
            Log.Error(e, "Error deleting file from the SFTP server ....");
            throw;
        }
        finally
        {
            _sftpClient.Disconnect();
        }
    }
}