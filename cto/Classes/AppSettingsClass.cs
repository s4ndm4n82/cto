namespace cto.Classes;

public class AppSettingsClass
{
	public required AppConfigs AppConfigs { get; set; }
}

public class AppConfigs
{
	public required ProjectSettings ProjectSettings { get; set; }
	public required FolderDeliverSettings FolderDeliverSettings { get; set; }
	public required FtpDeliverSettings FtpDeliverSettings { get; set; }
	public required FileSettings FileSettings { get; set; }
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

public class FolderDeliverSettings
{
	public string BaseFolderPath { get; set; } = string.Empty;
	public string FileHoldFolder { get; set; } = string.Empty;
	public string InputFolderName { get; set; } = string.Empty;
	public string OutputFolderName { get; set; } = string.Empty;
	public string BackUpFolderName { get; set; } = string.Empty;
}

public class FtpDeliverSettings
{
	public string Token { get; set; } = string.Empty;
	public string Host { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public int Port { get; set; }
	public string RemoteFolderPath { get; set; } = string.Empty;
	public string RemoteInvoiceFolderName { get; set; } = string.Empty;
	public string RemoteLineItemsFolderName { get; set; } = string.Empty;
}

public class FileSettings
{
	public bool RemoveRootFiles { get; set; }
	public string MatchColumn { get; set; } = string.Empty;
	public string MainFieldWorksheet { get; set; } = string.Empty;
	public string LineItemsFieldWorksheet { get; set; } = string.Empty;
}

public class FieldSettings
{
	public List<string> MainFieldsList { get; set; } = [];
	public List<string> LineItemsFieldsList { get; set; } = [];
	public List<string> MainFieldHeaders { get; set; } = [];
	public List<string> LineItemHeaders { get; set; } = [];
	public List<LineDefaultValues> LineDefaultValues { get; set; } = [];
}

public class LineDefaultValues
{
	public string FieldName { get; set; } = string.Empty;
	public string FieldValue { get; set; } = string.Empty;
}

public class UploadSettings
{
	public string UploadDomain { get; set; } = string.Empty;
}