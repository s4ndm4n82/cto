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
			var matchingColumn = settings.AppConfigs.FileSettings.MatchColumn;
			var mainColumnHeaders = settings.AppConfigs.FieldSettings.MainFieldHeaders;
			var lineColumnHeaders = settings.AppConfigs.FieldSettings.LineItemHeaders;
			var invoiceWsName = settings.AppConfigs.FileSettings.MainFieldWorksheet;
			var lineItemsWsName = settings.AppConfigs.FileSettings.LineItemsFieldWorksheet;

			var inputFolderName = FolderPaths.Instance.InputFolderName;
			var inputFolderPath = Path.Combine(FolderPaths.Instance.HoldFolderPath, inputFolderName);
			var inputFilePath = Directory.GetFiles(inputFolderPath).FirstOrDefault();

			if (string.IsNullOrEmpty(inputFilePath))
			{
				Console.WriteLine("Input folder is empty ...");
				Console.WriteLine("Press any key to exit ...");
				Console.Read();
				Environment.Exit(0);
			}
			
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using var excelFileData = new ExcelPackage(new FileInfo(inputFilePath));
			var fieldValues = excelFileData.Workbook.Worksheets[invoiceWsName];
			var lineValues = excelFileData.Workbook.Worksheets[lineItemsWsName];
			var matchingColumnIndex = GetMatchingColumnIndex(matchingColumn, fieldValues);
			var mainColumnIndex = GetColumnIndexes(fieldValues, mainColumnHeaders);
			var lineItemColumnIndex = GetColumnIndexes(lineValues, lineColumnHeaders);

			CreateDto(fieldValues,
				lineValues,
				mainColumnIndex,
				lineItemColumnIndex,
				matchingColumnIndex);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	private static int GetMatchingColumnIndex(string columnName, ExcelWorksheet sheet)
	{
		var columnIndex = 0;

		try
		{
			for (var i = 1; i <= sheet.Dimension.End.Column; i++)
			{
				var sheetValue = sheet.Cells[1, i].Value?.ToString();
				if (string.IsNullOrEmpty(sheetValue) || sheetValue != columnName) continue;
				columnIndex = i;
				break;
			}
			return columnIndex;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	private static Dictionary<string, int> GetColumnIndexes(ExcelWorksheet sheet,
	List<string> headerList)
	{
		var columnIndex = new Dictionary<string, int>();

		try
		{
			foreach (var header in headerList)
			{
				var matchingColumnIndex = GetMatchingColumnIndex(header.Trim(), sheet);

				if (matchingColumnIndex > 0)
				{
					columnIndex.Add(header.Trim(), matchingColumnIndex);
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
	 Dictionary<string, int> columnIndexes,
	 Dictionary<string, int> lineItemColumnIndex,
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

				if (cell?.Value == null
				    || string.IsNullOrEmpty(cell.Value.ToString()))
				{
					break;
				}

				var matchingInvoiceNumber = cell.Value.ToString();

				var matchingRows = line.Cells
				.Where(
					x => x is { Value: not null }
					        && x.Value.ToString() == matchingInvoiceNumber
					)
				.Select(y => y.Start.Row)
				.ToList();

				var invoiceDataDto = AddDataToInvoiceDto.AddDataToInvoiceDtoFn(invoiceLevelRow, row, columnIndexes);

				var lineItemsDto = matchingRows
				.Select(rowValue => AddDataToLineItemsDto.AddDataToLineItemsDtoFn
				(invoiceDataDto,
					line.Cells[rowValue, 1, rowValue, line.Dimension.End.Column],
					rowValue,
					lineItemColumnIndex))
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
