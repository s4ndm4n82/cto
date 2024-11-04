namespace cto.DTOs;

public class AppSettingsClass
{
	public required AppConfigs AppConfigs { get; set; }
}

public class AppConfigs
{
	public required AppSettings AppSettings { get; set; }
	public required ProjectSettings ProjectSettings { get; set; }
	public required FileDeliverSettings FileDeliverSettings { get; set; }
	public required FolderDeliverSettings FolderDeliverSettings { get; set; }
	public required FtpDeliverSettings FtpDeliverSettings { get; set; }
	public required FileSettings FileSettings { get; set; }
	public required UploadSettings UploadSettings { get; set; }
	public required FieldSettings FieldSettings { get; set; }
}

public class AppSettings
{
	public string AppName { get; set; } = string.Empty;
}

public class ProjectSettings
{
	public string ImportUser { get; set; } = string.Empty;
	public string ImportToken { get; set; } = string.Empty;
	public string ImportProjectId { get; set; } = string.Empty;
	public string ImportQueue { get; set; } = string.Empty;
	public string ImportTemplateKey { get; set; } = string.Empty;
}

public class FileDeliverSettings
{
	public string DeliveryExtension { get; set; } = string.Empty;
	public string DeliveryMethod { get; set; } = string.Empty;
}

public class FolderDeliverSettings
{
	public string BaseFolderPath { get; set; } = string.Empty;
	public string FileHoldFolder { get; set; } = string.Empty;
	public InputFolderNames InputFolderNames { get; set; } = new();
	public OutputFolderName OutputFolderName { get; set; } = new();
}

public class InputFolderNames
{
	public string InvoiceCsvFolderName { get; set; } = string.Empty;
	public string LineItemsCsvFolderName { get; set; } = string.Empty;
}

public class OutputFolderName
{
	public string OutputCsvFolderName { get; set; } = string.Empty;
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
	public string FileName { get; set; } = string.Empty;
	public string MatchColumn { get; set; } = string.Empty;
	public string MainFieldWorksheet { get; set; } = string.Empty;
	public string LineItemsFieldWorksheet { get; set; } = string.Empty;
	public string CustomsDeclarationWorksheet { get; set; } = string.Empty;
}

public class FieldSettings
{
	public string[] MainFieldsList { get; set; } = [];
	public string[] LineItemsFieldsList { get; set; } = [];
}

public class UploadSettings
{
	public string UploadDomain { get; set; } = string.Empty;
}