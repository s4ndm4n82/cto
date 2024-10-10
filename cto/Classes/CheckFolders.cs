namespace cto.Classes;

public class CheckFolders
{
	public static void StartCheckFolders()
	{
		var workingDirectory = Directory.GetCurrentDirectory();
		var constDirectoryList = new string[]
		{
			FolderNames.InputFolder1,
			FolderNames.InputFolder2,
			FolderNames.OutputFolder
		};

		foreach (var constDirectory in constDirectoryList)
		{
			var constDirectoryPath = Path.Combine(workingDirectory, constDirectory);
			if (!Directory.Exists(constDirectoryPath))
			{
				Directory.CreateDirectory(constDirectoryPath);
			}
		}
	}

	static class FolderNames
	{
		public const string InputFolder1 = "InputFolder1";
		public const string InputFolder2 = "InputFolder2";
		public const string OutputFolder = "OutputFolder";
	}
}
