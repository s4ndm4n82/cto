using Serilog;

namespace cto.SupportClasses;

public class FileFunctions
{
    public static string GetMatchingDataFile(string configFileName, string dataFilePath)
    {
        try
        {
            var dataFiles = Directory.GetFiles(dataFilePath);

            if (dataFiles.Length == 0)
            {
                Log.Error("Input or Config folder is empty ...");
                return string.Empty;
            }

            foreach (var dataFile in dataFiles)
            {
                var dataFileName = Path.GetFileName(dataFile);
                var clientName = GetClientNameFromFileName(Path.GetFileNameWithoutExtension(dataFile));
                var configClientName = GetFileNameFromConfigFileName(Path.GetFileNameWithoutExtension(configFileName));
                
                if (clientName.Equals(configClientName, StringComparison.OrdinalIgnoreCase)) return dataFileName;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error getting the matching config file ....");
            return string.Empty;
        }

        return string.Empty;
    }
    
    private static string GetClientNameFromFileName(string fileName)
    {
        try
        {
            var clientName = fileName.Split("_");
            return clientName.Length > 2 ? clientName[2] : string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    } 
    
    private static string GetFileNameFromConfigFileName(string fileName)
    {
        try
        {
            var configFileName = fileName.Split("_");
            return configFileName.Length > 0 ? configFileName[1] : string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}