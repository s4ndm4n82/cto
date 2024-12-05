using cto.ProgramClasses;

namespace cto.SupportClasses;

public sealed class FolderPaths
{
	private static class FolderNames
	{
		// Default folder names
		public const string InputFolder = "Input";
		public const string OutputFolder = "Output";
		public const string BackUpFolder = "Backup";
		public const string HoldFolder = "HoldFolder";
	}

	private static readonly FolderPaths _instances = new();

	private FolderPaths() { }

	public static FolderPaths Instance
	{
		get { return _instances; }
	}

	// Folder name elements
	public string InputFolderName { get; private set; } = string.Empty;
	public string OutputFolderName { get; private set; } = string.Empty;
	public string BackUpFolderName { get; set; } = string.Empty;
	public string HoldFolderName { get; private set; } = string.Empty;

	// Folder path elements
	public string WorkingDirectory { get; private set; } = string.Empty;
	public string OutputFolderPath { get; private set; } = string.Empty;
	public string BackUpFolderPath { get; set; } = string.Empty;
	public string HoldFolderPath { get; private set; } = string.Empty;

	public void InitializePaths()
	{
		var settings = ReadSettings.ReadAppSettings();

		// Folder names
		InputFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.InputFolderName
			)
		? settings.AppConfigs.FolderDeliverSettings.InputFolderName
		: FolderNames.InputFolder;

		OutputFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.OutputFolderName
		)
		? settings.AppConfigs.FolderDeliverSettings.OutputFolderName
		: FolderNames.OutputFolder;

		BackUpFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderDeliverSettings.BackUpFolderName
		)
		? settings.AppConfigs.FolderDeliverSettings.BackUpFolderName
		: FolderNames.BackUpFolder;

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

		BackUpFolderPath = Path.Combine(HoldFolderPath, BackUpFolderName);

		OutputFolderPath = Path.Combine(HoldFolderPath, OutputFolderName);
	}
}
