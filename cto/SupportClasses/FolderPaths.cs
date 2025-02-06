using cto.Classes;
using cto.ProgramClasses;
using Serilog;

namespace cto.SupportClasses;

public sealed class FolderPaths
{
	private static class FolderNames
	{
		// Default folder names
		public const string ConfigFolder = "ConfigFiles";
		public const string LogFolder = "Logs";
		public const string InputFolder = "Input";
		public const string OutputFolder = "Output";
		public const string DownloadFolder = "Download";
		public const string BackUpFolder = "Backup";
		public const string HoldFolder = "HoldFolder";
	}

	private FolderPaths() { }

	public static FolderPaths Instance { get; } = new();

	// Folder name elements
	private string ConfigFolderName { get; set; } = string.Empty;
	private string LogFolderName { get; set; } = string.Empty;
	public string InputFolderName { get; private set; } = string.Empty;
	public string OutputFolderName { get; private set; } = string.Empty;
	public string DownloadFolderName { get; private set; } = string.Empty;
	public string BackUpFolderName { get; set; } = string.Empty;
	private string HoldFolderName { get; set; } = string.Empty;

	// Folder path elements
	private string WorkingDirectory { get; set; } = string.Empty;
	public string ConfigFolderPath { get; private set; } = string.Empty;
	public string LogFolderPath { get; private set; } = string.Empty;
	public string InputFolderPath { get; private set; } = string.Empty;
	public string OutputFolderPath { get; private set; } = string.Empty;
	public string DownloadFolderPath { get; private set; } = string.Empty;
	public string BackUpFolderPath { get; set; } = string.Empty;
	public string HoldFolderPath { get; private set; } = string.Empty;

	public void InitializePaths()
	{
		try
		{
			ConfigFolderName = FolderNames.ConfigFolder;
			
			LogFolderName = FolderNames.LogFolder;
			
			InputFolderName = FolderNames.InputFolder;

			OutputFolderName = FolderNames.OutputFolder;
			
			DownloadFolderName = FolderNames.DownloadFolder;

			BackUpFolderName = FolderNames.BackUpFolder;

			HoldFolderName = FolderNames.HoldFolder;

			// Directory paths
			WorkingDirectory = Directory.GetCurrentDirectory();
		
			ConfigFolderPath = Path.Combine(WorkingDirectory, ConfigFolderName);
			
			LogFolderPath = Path.Combine(WorkingDirectory, LogFolderName);
		
			HoldFolderPath = Path.Combine(WorkingDirectory, HoldFolderName);
			
			InputFolderPath = Path.Combine(HoldFolderPath, InputFolderName);
			
			DownloadFolderPath = Path.Combine(HoldFolderPath, DownloadFolderName);

			BackUpFolderPath = Path.Combine(HoldFolderPath, BackUpFolderName);

			OutputFolderPath = Path.Combine(HoldFolderPath, OutputFolderName);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error initializing the folder paths ....");
			throw;
		}
	}
}
