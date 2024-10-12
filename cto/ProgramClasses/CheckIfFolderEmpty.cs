using System;
using cto.SupportClasses;

namespace cto.ProgramClasses;

public class CheckIfFolderEmpty
{
	public static bool CheckIfFolderEmptyFn()
	{
		var loopCount = 0;

		FolderPaths.Instance.InitializePaths();
		var inputFolderName1 = FolderPaths.Instance.InvoiceCsvFolderName;
		var inputFolderName2 = FolderPaths.Instance.LineItemsCsvFolderName;
		var holdFolderPath = FolderPaths.Instance.HoldFolderPath;

		var folderList = new[]
		{
			Path.Combine(holdFolderPath, inputFolderName1),
			Path.Combine(holdFolderPath, inputFolderName2)
		};

		if (folderList == null)
		{
			throw new ArgumentNullException(nameof(folderList), "folderList is null.");
		}

		foreach (var folder in folderList)
		{
			if (folder == null)
			{
				throw new ArgumentNullException(nameof(folder), "folder is null.");
			}

			if (!Directory.Exists(folder))
			{
				throw new DirectoryNotFoundException($"Directory {folder} does not exist.");
			}

			if (!Directory.EnumerateFiles(folder).Any())
			{
				Console.WriteLine($"{Path.GetDirectoryName(folder)}"
				+ " is empty. Please add files to it .... ");
				break;
			}

			loopCount++;
		}

		if (folderList.Length == loopCount)
		{
			return true;
		}

		return false;
	}
}
