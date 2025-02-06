using cto.Classes;
using cto.SupportClasses;
using OfficeOpenXml;
using Serilog;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace cto.ProgramClasses;

public class ReadInExcelFile
{
	public static void ReadExcelFile(string inputFileName)
	{
		try
		{
			// Initialize the folder paths
			FolderPaths.Instance.InitializePaths();
			// Read the app settings
			var settings = GlobalAppSettings.Instance.Settings;

			if (settings == null)
			{
				Log.Error("AppSettings is empty ....");
				return;
			}
			
			// Loading config data from the app settings
			var matchingColumn = settings.AppConfigs.FileSettings.MatchColumn;
			var mainColumnHeaders = settings.AppConfigs.FieldSettings.MainFieldHeaders;
			var lineColumnHeaders = settings.AppConfigs.FieldSettings.LineItemHeaders;
			var invoiceWsName = settings.AppConfigs.FileSettings.MainFieldWorksheet;
			var lineItemsWsName = settings.AppConfigs.FileSettings.LineItemsFieldWorksheet;
			var inputFilePath = Path.Combine(FolderPaths.Instance.InputFolderPath, inputFileName);

			if (string.IsNullOrEmpty(inputFilePath))
			{
				Log.Error("Input folder is empty ....");
				return;
			}
			
			// Set the license context
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			
			// Read the Excel file
			Log.Information("Reading the Excel file ...");
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
				matchingColumnIndex,
				inputFileName);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error reading the Excel file ....");
			throw;
		}
	}
	
	private static void CreateDto(ExcelWorksheet invoice,
		ExcelWorksheet line,
		Dictionary<string, int> columnIndexes,
		Dictionary<string, int> lineItemColumnIndex,
		int matchingColumnIndex,
		string excelFileName)
	{
		try
		{
			Log.Information("Creating the DTO ....");
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

				// Adding data to invoice DTO
				var invoiceDataDto = AddDataToInvoiceDto
					.AddDataToInvoiceDtoFn(invoiceLevelRow, row, excelFileName, columnIndexes);

				// Adding data to line items DTO
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
			Log.Error(ex, "Error creating the DTO ....");
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
			Log.Error(ex, "Error getting the matching column index ....");
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
			Log.Error(ex, "Error getting the column indexes ....");
			throw;
		}
	}
}
