using cto.SupportClasses;

namespace cto.ProgramClasses;

public class CheckFolders
{
	public static bool StartCheckFolders()
	{
		var loopCount = 0;
		FolderPaths.Instance.InitializePaths();

		var inputFolderName1 = FolderPaths.Instance.InvoiceCsvFolderName;
		var inputFolderName2 = FolderPaths.Instance.LineItemsCsvFolderName;
		var outputFolderName = FolderPaths.Instance.OutputFolderName;
		var holdFolderPath = FolderPaths.Instance.HoldFolderPath;

		if (!Directory.Exists(holdFolderPath))
		{
			Directory.CreateDirectory(holdFolderPath);
		}

		var constDirectoryList = new[]
		{
			inputFolderName1,
			inputFolderName2,
			outputFolderName
		};


		foreach (var constDirectory in constDirectoryList)
		{
			loopCount++;
			var constDirectoryPath = Path.Combine(holdFolderPath, constDirectory);
			if (!Directory.Exists(constDirectoryPath))
			{
				Directory.CreateDirectory(constDirectoryPath);
			}
		}

		if (constDirectoryList.Length == loopCount)
		{
			return true;
		}

		return false;
	}
}
