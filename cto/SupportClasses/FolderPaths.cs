using System;
using cto.ProgramClasses;

namespace cto.SupportClasses;

public sealed class FolderPaths
{
	static class FolderNames
	{
		// Default folder names
		public const string InvoiceFolder = "InvoiceFolder";
		public const string LineItemsFolder = "LineItemsFolder";
		public const string OutputFolder = "OutputFolder";
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
			settings.AppConfigs.FolderNameSettings.InvoiceCsvFolderName
			)
		? settings.AppConfigs.FolderNameSettings.InvoiceCsvFolderName
		: FolderNames.InvoiceFolder;

		LineItemsCsvFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.LineItemsCsvFolderName
		)
		? settings.AppConfigs.FolderNameSettings.LineItemsCsvFolderName
		: FolderNames.LineItemsFolder;

		OutputFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.OutputFolderName
		)
		? settings.AppConfigs.FolderNameSettings.OutputFolderName
		: FolderNames.OutputFolder;

		HoldFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.HoldFolderName
		)
		? settings.AppConfigs.FolderNameSettings.HoldFolderName
		: FolderNames.HoldFolder;

		// Directory paths
		WorkingDirectory = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderPathSetting.BaseFolderPath
		)
		? settings.AppConfigs.FolderPathSetting.BaseFolderPath
		: Directory.GetCurrentDirectory();

		HoldFolderPath = Path.Combine(WorkingDirectory, HoldFolderName);

		OutputFolderPath = Path.Combine(WorkingDirectory, OutputFolderName);
	}
}
