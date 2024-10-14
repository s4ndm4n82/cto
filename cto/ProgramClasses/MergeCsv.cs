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
			StartReadingCsvFiles();
		}
	}

	private static bool StartReadingCsvFiles()
	{
		try
		{
			FolderPaths.Instance.InitializePaths();

			var invoiceCsvFilePath = Path.Combine(FolderPaths.Instance.HoldFolderPath,
			FolderPaths.Instance.InvoiceCsvFolderName);

			var lineItemsCsvFolderPath = Path.Combine(FolderPaths.Instance.HoldFolderPath,
			FolderPaths.Instance.LineItemsCsvFolderName);

			var invoiceCsvFileName = Directory.GetFiles(invoiceCsvFilePath).FirstOrDefault();
			var lineItemsCsvFileName = Directory.GetFiles(lineItemsCsvFolderPath).FirstOrDefault();

			if (invoiceCsvFileName == null || lineItemsCsvFileName == null)
			{
				Console.WriteLine("Invoice or Line Items CSV file not found. Press any key to exit ....");
				return false;
			}

			var invoiceCsvData = ReadCsvFileData.ReadInvoiceCsvFileData(invoiceCsvFileName);
			var lineItemsCsvData = ReadCsvFileData.ReadLineItemsCsvFileData(lineItemsCsvFileName);

			WriteCsvFile.WriteFile(invoiceCsvData, lineItemsCsvData);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			return false;
		}

		return false;
	}
}