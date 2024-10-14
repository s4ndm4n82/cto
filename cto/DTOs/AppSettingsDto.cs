namespace cto.DTOs;

public class AppSettingsClass
{
	public required AppConfigs AppConfigs { get; set; }
}
public class AppConfigs
{
	public required AppSettings AppSettings { get; set; }
	public required FolderPathSetting FolderPathSetting { get; set; }
	public required FolderNameSettings FolderNameSettings { get; set; }
	public required FileSettings FileSettings { get; set; }
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
	public string InvoiceCsvFolderName { get; set; } = string.Empty;
	public string LineItemsCsvFolderName { get; set; } = string.Empty;
	public string OutputFolderName { get; set; } = string.Empty;
	public string HoldFolderName { get; set; } = string.Empty;
}

public class FileSettings
{
	public string Delimiter { get; set; } = ";";
}