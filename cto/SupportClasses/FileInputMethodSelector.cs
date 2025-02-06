using cto.Classes;
using cto.ProgramClasses;
using Serilog;

namespace cto.SupportClasses;

public static class FileInputMethodSelector
{
    public static async Task SelectInputMethodAsync()
    {
        try
        {
            var settings = GlobalAppSettings.Instance.Settings;
            
            if (settings == null)
            {
                Log.Error("AppSettings is empty ....");
                return;
            }
            
            var fileDelivery = settings.AppConfigs.FileSettings.FileDeliveryMethod.ToLower();
            var ftpProtocol = settings.AppConfigs.FtpDeliverSettings.Protocol.ToLower();

            switch (fileDelivery)
            {
                case MagicWords.Ftp:
                    switch (ftpProtocol)
                    {
                        case MagicWords.Ftp:
                            Log.Information("Start reading from the FTP server ....");
                            var ftpClient = new FtpClientWrapper();
                            var ftpStart = new StartFtpProcess(ftpClient);
                            await ftpStart.StartFtpAsync();
                            break;
                        case MagicWords.Sftp:
                            Log.Information("Start reading from the SFTP server ....");
                            break;
                        default:
                            Log.Error("FTP protocol not supported ....");
                            break;
                    }
                    break;
                case MagicWords.Sftp:
                    Log.Information("Start reading from the SFTP server ....");
                    break;
                case MagicWords.Email:
                    Log.Information("Email delivery method not supported ....");
                    break;
                case MagicWords.Local:
                    Log.Information("Start reading from the local folder ....");
                    // ReadInExcelFile.ReadExcelFile();
                    break;
                default:
                    Log.Error("File delivery method not supported ....");
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Error(e, "Error selecting the Input Method ....");
        }
    }
}