using cto.Interfaces;
using cto.ProgramClasses;
using Renci.SshNet;
using Serilog;

namespace cto.SupportClasses;

public class SftpClientWrapper : IFileTransferClient
{
    private readonly SftpClient _sftpClient;

    public SftpClientWrapper()
    {
        var settings = ReadSettings.ReadAppSettings().Item1;
        
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
            _sftpClient.Connect();
            await Task.CompletedTask;
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
    
    public async Task DownloadFilesAsync(string remotePath, string localPath)
    {
        try
        {
            var fileList = _sftpClient.ListDirectory(remotePath);
            
            
            Log.Information("Downloaded file from the SFTP server ....");
        }
        catch (Exception e)
        {
            Log.Error(e, "Error downloading file from the SFTP server ....");
            throw;
        }
    }
}