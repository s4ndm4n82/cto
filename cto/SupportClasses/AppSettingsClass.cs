namespace cto.SupportClasses;

public class AppSettingsClass
{
    public required AppConfigs AppConfigs { get; set; }
}
public class AppConfigs
{
    public required AppSettings AppSettings { get; set; }
    public required FolderPathSetting FolderPathSetting { get; set; }
    public required FolderNameSettings FolderNameSettings { get; set; }
}
public class AppSettings
{
    public string AppName { get; set; } = string.Empty;
}
public class FolderPathSetting
{
    public string BaseFolderPath { get; set; } = string.Empty;
}
public class FolderNameSettings
{
    public string InputFolderName1 { get; set; } = string.Empty;
    public string InputFolderName2 { get; set; } = string.Empty;
    public string OutputFolderName { get; set; } = string.Empty;
}