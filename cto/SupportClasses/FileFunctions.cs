namespace cto.SupportClasses;

public class FileFunctions
{
    public static (string,string) GetMatchingConfigFile(string configFilePath, string dataFilePath)
    {
        try
        {
            var dataFiles = Directory.GetFiles(dataFilePath);
            var configFiles = Directory.GetFiles(configFilePath);

            if (dataFiles.Length == 0 || configFiles.Length == 0)
            {
                Console.WriteLine("Input or Config folder is empty ...");
                Console.WriteLine("Press any key to exit ...");
                Console.Read();
                Environment.Exit(0);
            }

            foreach (var dataFile in dataFiles)
            {
                var dataFileName = Path.GetFileName(dataFile);
                var clientName = GetClientNameFromFileName(Path.GetFileNameWithoutExtension(dataFile));

                foreach (var configFile in configFiles)
                {
                    var configFileName = Path.GetFileName(configFile);
                    var configClientName = GetFileNameFromConfigFileName(Path.GetFileNameWithoutExtension(configFile));

                    if (clientName.Equals(configClientName, StringComparison.OrdinalIgnoreCase))
                    {
                        return (configFileName, dataFileName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

        return (string.Empty, string.Empty);
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