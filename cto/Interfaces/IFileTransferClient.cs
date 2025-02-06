namespace cto.Interfaces;

public interface IFileTransferClient
{
    Task ConnectAsync();
    Task DisconnectAsync();
    Task<bool> DownloadFilesAsync(string remotePath, string localPath);
    Task DeleteFilesAsync(string remotePath);
}