namespace cto.DTOs;

public class AppSettingsClass
{
	public required AppConfigs AppConfigs { get; set; }
}
public class AppConfigs
{
	public required AppSettings AppSettings { get; set; }
	public required UploadSettings UploadSettings { get; set; }
}
public class AppSettings
{
	public string AppName { get; set; } = string.Empty;
}

public class UploadSettings
{
	public string UploadDomain { get; set; } = string.Empty;
}