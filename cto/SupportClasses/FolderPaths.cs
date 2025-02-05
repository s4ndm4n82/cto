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
	public string BackUpFolderName { get; set; } = string.Empty;
	private string HoldFolderName { get; set; } = string.Empty;

	// Folder path elements
	private string WorkingDirectory { get; set; } = string.Empty;
	public string ConfigFolderPath { get; private set; } = string.Empty;
	public string LogFolderPath { get; private set; } = string.Empty;
	public string InputFolderPath { get; private set; } = string.Empty;
	public string OutputFolderPath { get; private set; } = string.Empty;
	public string BackUpFolderPath { get; set; } = string.Empty;
	public string HoldFolderPath { get; private set; } = string.Empty;

	public void InitializePaths()
	{
		var settings = ReadSettings.ReadAppSettings().Item1;
		
		if (settings == null)
		{
			Log.Error("AppSettings is empty ...");
			Environment.Exit(0);
		}

		try
		{
			ConfigFolderName = FolderNames.ConfigFolder;
			
			LogFolderName = FolderNames.LogFolder;
			
			InputFolderName = FolderNames.InputFolder;

			OutputFolderName = FolderNames.OutputFolder;

			BackUpFolderName = FolderNames.BackUpFolder;

			HoldFolderName = FolderNames.HoldFolder;

			// Directory paths
			WorkingDirectory = Directory.GetCurrentDirectory();
		
			ConfigFolderPath = Path.Combine(WorkingDirectory, ConfigFolderName);
			
			LogFolderPath = Path.Combine(WorkingDirectory, LogFolderName);
		
			HoldFolderPath = Path.Combine(WorkingDirectory, HoldFolderName);
			
			InputFolderPath = Path.Combine(HoldFolderPath, InputFolderName);

			BackUpFolderPath = Path.Combine(HoldFolderPath, BackUpFolderName);

			OutputFolderPath = Path.Combine(HoldFolderPath, OutputFolderName);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
