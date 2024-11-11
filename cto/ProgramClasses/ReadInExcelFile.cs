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
			var inputFolderName = FolderPaths.Instance.InputFolderName;
			var inputFilePath = Path.Combine(FolderPaths.Instance.HoldFolderPath,
			inputFolderName, inputFileName);

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using var excelFileData = new ExcelPackage(new FileInfo(inputFilePath));
			var fieldValues = excelFileData.Workbook.Worksheets[invoiceWsName];
			var lineValues = excelFileData.Workbook.Worksheets[lineItemsWsName];
			var matchingColumnIndex = GetColumnIndex(matchingColumn, fieldValues);

			CreateDto(fieldValues, lineValues, matchingColumnIndex);
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

	private static void CreateDto(ExcelWorksheet invoice,
	 ExcelWorksheet line,
	 int matchingColumnIndex)
	{
		try
		{
			// Looping through the invoice level worksheet
			for (var row = 2; row <= invoice.Dimension.End.Row; row++)
			{
				var invoiceLevelRow = invoice
				.Cells[
					row, 1, row, invoice.Dimension.End.Column
					];

				var cell = invoiceLevelRow[row, matchingColumnIndex];

				if (cell == null
				|| cell.Value == null
				|| string.IsNullOrEmpty(cell.Value.ToString()))
				{
					break;
				}

				var matchingInvoiceNumber = cell.Value.ToString();

				var matchingRows = line.Cells
				.Where(
					cell => cell != null
					&& cell.Value != null
					&& cell.Value.ToString() == matchingInvoiceNumber
					)
				.Select(cell => cell.Start.Row)
				.ToList();

				var invoiceDataDto = AddDataToDto.AddDataToInvoiceDto(invoiceLevelRow, row);

				var lineItemsDto = matchingRows
				.Select(rowValue => AddDataToDto.AddDataToLineItemsDto
				(line.Cells[rowValue, 1, rowValue, line.Dimension.End.Column], rowValue))
				.ToList();

				invoiceDataDto.LineItems.AddRange(lineItemsDto);
				CreateApiJsonRequest.MakeJsonRequest(invoiceDataDto);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
