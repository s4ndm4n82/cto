using System;
using cto.ProgramClasses;

namespace cto.SupportClasses;

public sealed class FolderPaths
{
	static class FolderNames
	{
		// Default folder names
		public const string InvoiceFolder = "Invoice";
		public const string LineItemsFolder = "LineItems";
		public const string OutputFolder = "Output";
		public const string HoldFolder = "HoldFolder";
	}

	private static readonly FolderPaths _instances = new();

	private FolderPaths() { }

	public static FolderPaths Instance
	{
		get { return _instances; }
	}

	// Folder name elements
	public string InvoiceCsvFolderName { get; private set; } = string.Empty;
	public string LineItemsCsvFolderName { get; private set; } = string.Empty;
	public string OutputFolderName { get; private set; } = string.Empty;
	public string HoldFolderName { get; private set; } = string.Empty;

	// Folder path elements
	public string WorkingDirectory { get; private set; } = string.Empty;
	public string HoldFolderPath { get; private set; } = string.Empty;
	public string OutputFolderPath { get; private set; } = string.Empty;


	public void InitializePaths()
	{
		var settings = ReadSettings.ReadAppSettings();

		// Folder names
		InvoiceCsvFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.InputFolderNames.InvoiceCsvFolderName
			)
		? settings.AppConfigs.FolderDeliverSettings.InputFolderNames.InvoiceCsvFolderName
		: FolderNames.InvoiceFolder;

		LineItemsCsvFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.InputFolderNames.LineItemsCsvFolderName
		)
		? settings.AppConfigs.FolderDeliverSettings.InputFolderNames.LineItemsCsvFolderName
		: FolderNames.LineItemsFolder;

		OutputFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.OutputFolderName.OutputCsvFolderName
		)
		? settings.AppConfigs.FolderDeliverSettings.OutputFolderName.OutputCsvFolderName
		: FolderNames.OutputFolder;

		HoldFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.FileHoldFolder
		)
		? settings.AppConfigs.FolderDeliverSettings.FileHoldFolder
		: FolderNames.HoldFolder;

		// Directory paths
		WorkingDirectory = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.BaseFolderPath
		)
		? settings.AppConfigs.FolderDeliverSettings.BaseFolderPath
		: Directory.GetCurrentDirectory();

		HoldFolderPath = Path.Combine(WorkingDirectory, HoldFolderName);

		OutputFolderPath = Path.Combine(HoldFolderPath, OutputFolderName);
	}
}
