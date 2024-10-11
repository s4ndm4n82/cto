using cto.SupportClasses;

namespace cto.ProgramClasses;

public class MergeCsv
{
	public static void StartMergeCsv()
	{
		var result = CheckIfFolderEmpty.CheckIfFolderEmptyFn();

		while (!result)
		{
			Console.Write("Do you wish to try again? (y/n): ");
			var userInput = Console.ReadLine();

			switch (userInput?.Trim().ToLowerInvariant())
			{
				case "y":
					result = CheckIfFolderEmpty.CheckIfFolderEmptyFn();
					break;
				case "n":
					Environment.Exit(0);
					break;
			}
		}

		if (result)
		{

		}
	}

}