namespace cto.Interfaces;

public interface IFileTransferClient
{
    Task ConnectAsync();
    Task DisconnectAsync();
    Task DownloadFilesAsync(string remotePath, string localPath);
    Task DeleteFilesAsync(string remotePath);
}