using cto.SupportClasses;
using OfficeOpenXml;

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


			var invoiceFieldData = fieldValues.Cells[matchingColumn].Select(val => val.Value.ToString()).ToList();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
