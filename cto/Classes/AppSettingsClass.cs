namespace cto.Classes;

public class AppSettingsClass
{
	public required AppConfigs AppConfigs { get; set; }
}

public class AppConfigs
{
	public required ProjectSettings ProjectSettings { get; set; }
	public required FileSettings FileSettings { get; set; }
	public required FtpDeliverSettings FtpDeliverSettings { get; set; }
	public required UploadSettings UploadSettings { get; set; }
	public required FieldSettings FieldSettings { get; set; }
}

public class ProjectSettings
{
	public string ImportUser { get; set; } = string.Empty;
	public string ImportToken { get; set; } = string.Empty;
	public string ImportProjectId { get; set; } = string.Empty;
	public string ImportQueue { get; set; } = string.Empty;
	public string ImportTemplateKey { get; set; } = string.Empty;
}

public class FileSettings
{
	public string FileDeliveryMethod { get; set; } = string.Empty;
	public bool RemoveRootFiles { get; set; }
	public string MatchColumn { get; set; } = string.Empty;
	public string MainFieldWorksheet { get; set; } = string.Empty;
	public string LineItemsFieldWorksheet { get; set; } = string.Empty;
}

public class FtpDeliverSettings
{
	public string Protocol { get; set; } = string.Empty;
	public string Host { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public int Port { get; set; }
	public string RemoteFolderPath { get; set; } = string.Empty;
}

public class FieldSettings
{
	public List<string> MainFieldsList { get; set; } = [];
	public List<string> LineItemsFieldsList { get; set; } = [];
	public List<string> MainFieldHeaders { get; set; } = [];
	public List<string> LineItemHeaders { get; set; } = [];
}

public class UploadSettings
{
	public string UploadDomain { get; set; } = string.Empty;
}