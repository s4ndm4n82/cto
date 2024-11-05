using cto.SupportClasses;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace cto.ProgramClasses;

public class ReadInExcelFile
{
	public static void ReadExcelFile()
	{
		try
		{
			FolderPaths.Instance.InitializePaths();
			var settings = ReadSettings.ReadAppSettings();
			var inputFileName = settings.AppConfigs.FileSettings.FileName;
			var matchingColumn = settings.AppConfigs.FileSettings.MatchColumn;
			var invoiceWsName = settings.AppConfigs.FileSettings.MainFieldWorksheet;
			var lineItemsWsName = settings.AppConfigs.FileSettings.LineItemsFieldWorksheet;
			var inputFolderName = FolderPaths.Instance.InvoiceCsvFolderName;
			var inputFilePath = Path.Combine(FolderPaths.Instance.HoldFolderPath,
			inputFolderName, inputFileName);

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using var excelFileData = new ExcelPackage(new FileInfo(inputFilePath));
			var fieldValues = excelFileData.Workbook.Worksheets[invoiceWsName];
			var lineValues = excelFileData.Workbook.Worksheets[lineItemsWsName];
			var matchingColumnIndex = GetColumnIndex(matchingColumn, fieldValues);

			// Looping through the invoice level worksheet
			for (var row = 1; row <= fieldValues.Dimension.End.Row; row++)
			{
				var invoiceLevelRow = fieldValues.Cells[row, 1, row, fieldValues.Dimension.End.Column];

				var matchingInvoiceNumber = invoiceLevelRow[row, matchingColumnIndex].Value.ToString();

				/*foreach (var line in lineValues.Cells)
				{
					if (line != null && line.Value != null)
					{
						if (line.Value.ToString() == matchingInvoiceNumber)
						{
							var matchingRow = line.Start.Row;
							var rowValues = lineValues.Cells[matchingRow, 1, matchingRow, lineValues.Dimension.End.Column];
							Console.WriteLine(string.Join(", ", rowValues.Select(c => c.Value?.ToString())));
							break;
						}
					}
				}*/

				var matchingRows = lineValues.Cells
				.Where(cell => cell != null && cell.Value != null && cell.Value.ToString() == matchingInvoiceNumber)
				.Select(cell => cell.Start.Row)
				.FirstOrDefault();

				if (matchingRows != 0)
				{
					var rowValues = lineValues.Cells[matchingRows, 1, matchingRows, lineValues.Dimension.End.Column];
					Console.WriteLine(string.Join(", ", rowValues.Select(c => c.Value?.ToString())));
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	private static int GetColumnIndex(string columnName, ExcelWorksheet sheet)
	{
		var columnIndex = 0;

		try
		{
			for (var i = 1; i <= sheet.Dimension.End.Column; i++)
			{
				if (sheet.Cells[1, i].Value.ToString() == columnName)
				{
					columnIndex = i;
					break;
				}
			}
			return columnIndex;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
