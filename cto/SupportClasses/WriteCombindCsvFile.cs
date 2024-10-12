using CsvHelper;
using System.Globalization;
using cto.DTOs;

namespace cto.SupportClasses;

public class WriteCombinedCsvFile
{
	public static bool WriteCombinedCsvFileFn(string filePath, List<CombinedDto> combinedDto)
	{
		using var writer = new StreamWriter(filePath);
		using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
		csv.WriteRecords(combinedDto);

		if (File.Exists(filePath))
		{
			Console.Write($"{Path.GetFileName(filePath)} combined CSV file created successfully ....");
			Thread.Sleep(3000);
			return true;
		}

		Console.WriteLine($"Failed to create {Path.GetFileName(filePath)} combined CSV file ....");
		Thread.Sleep(3000);
		return false;
	}
}
