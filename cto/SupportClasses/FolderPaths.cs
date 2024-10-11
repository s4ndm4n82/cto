using System;
using cto.ProgramClasses;

namespace cto.SupportClasses;

public sealed class FolderPaths
{
	static class FolderNames
	{
		public const string InputFolder1 = "InputFolder1";
		public const string InputFolder2 = "InputFolder2";
		public const string OutputFolder = "OutputFolder";
	}

	private static readonly FolderPaths _instances = new();

	private FolderPaths() { }

	public static FolderPaths Instance
	{
		get { return _instances; }
	}

	public string InputFolderName1 { get; private set; } = string.Empty;
	public string InputFolderName2 { get; private set; } = string.Empty;
	public string OutputFolderName { get; private set; } = string.Empty;
	public string WorkingDirectory { get; private set; } = string.Empty;
	public string HoldFolderPath { get; private set; } = string.Empty;


	public void InitializePaths()
	{
		var settings = ReadSettings.ReadAppSettings();

		InputFolderName1 = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.InputFolderName1
			)
			? settings.AppConfigs.FolderNameSettings.InputFolderName1
			: FolderNames.InputFolder1;

		InputFolderName2 = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.InputFolderName2
			)
			? settings.AppConfigs.FolderNameSettings.InputFolderName2
			: FolderNames.InputFolder2;

		OutputFolderName = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderNameSettings.OutputFolderName
			)
			? settings.AppConfigs.FolderNameSettings.OutputFolderName
			: FolderNames.OutputFolder;

		WorkingDirectory = !string.IsNullOrEmpty(
			settings.AppConfigs.FolderPathSetting.BaseFolderPath
			)
			? settings.AppConfigs.FolderPathSetting.BaseFolderPath
			: Directory.GetCurrentDirectory();

		HoldFolderPath = Path.Combine(WorkingDirectory, "HoldFolder");
	}
}
