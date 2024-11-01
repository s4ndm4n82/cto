using System;

namespace cto.DTOs;

public class CustomerConfigsDto
{
	public List<ClientConfigs> ClientConfigs { get; set; } = [];
}

public class ClientConfigs
{
	public int id { get; set; }
	public bool SettingsOn { get; set; } = false;
	public required ProjectSettings ProjectSettings { get; set; }
	public required FileDeliverSettings FileDeliverSettings { get; set; }
	public required FolderDeliverSettings FolderDeliverSettings { get; set; }
	public required FtpDeliverSettings FtpDeliverSettings { get; set; }
	public required FileSettings FileSettings { get; set; }
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

public class FileDeliverSettings
{
	public string DeliveryExtension { get; set; } = string.Empty;
	public string DeliveryMethod { get; set; } = string.Empty;
}

public class FolderDeliverSettings
{
	public string BaseFolderPath { get; set; } = string.Empty;
	public string FileHoldFolder { get; set; } = string.Empty;
	public required InputFolderNames InputFolderNames { get; set; }
	public required OutputFolderName OutputFolderName { get; set; }
}

public class InputFolderNames
{
	public string InvoiceCsvFolderName { get; set; } = "Invoice";
	public string LineItemsCsvFolderName { get; set; } = "Lines";
}

public class OutputFolderName
{
	public string OutputCsvFolderName { get; set; } = "Output";
}

public class FtpDeliverSettings
{
	public string Type { get; set; } = string.Empty;
	public string Host { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public int Port { get; set; } = 21;
	public string RemoteFolderPath { get; set; } = string.Empty;
	public string RemoteInvoiceFolderName { get; set; } = string.Empty;
	public string RemoteLineItemsFolderName { get; set; } = string.Empty;
}

public class FileSettings
{
	public bool RemoveRootFiles { get; set; } = false;
}

public class FieldSettings
{
	public string[] MainFieldsList { get; set; } = [];
	public string[] MainFieldsList2 { get; set; } = [];
}