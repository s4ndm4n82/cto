using cto.DTOs;
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
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			return false;
		}

		return false;
	}

	private static bool MergeCsvFiles(List<InvoiceDto> invoiceData,
	Dictionary<string, LineItemsDto> lineItemsData)
	{
		var combinedDataRecords = new List<CombinedDto>();
		var combinedFileName = string.Empty;

		foreach (var invoice in invoiceData)
		{
			combinedFileName = string.Concat(
				invoice.SupplierTIN, "_", invoice.EInvoiceNumber, ".csv"
				);

			if (lineItemsData.TryGetValue(invoice.EInvoiceNumber, out var lineItems))
			{
				var combinedDataRecord = new CombinedDto
				{
					EInvoiceNumber = invoice.EInvoiceNumber,
					BuyerName = invoice.BuyerName,
					Classification = invoice.Classification,
					CurrencyCode = invoice.CurrencyCode,
					CurrencyExchangeRate = invoice.CurrencyExchangeRate,
					SupplierName = invoice.SupplierName,
					SupplierTIN = invoice.SupplierTIN,
					SupplierIDType = invoice.SupplierIDType,
					SupplierIDNo = invoice.SupplierIDNo,
					SupplierAddressLine0 = invoice.SupplierAddressAddressLine0,
					SupplierCityName = invoice.SupplierAddressCityName,
					SupplierState = invoice.SupplierAddressState,
					SupplierCountryCode = invoice.SupplierAddressCountryCode,
					SupplierSSTNo = invoice.SupplierSSTNo,
					SupplierBusinessActivityDescription = invoice.SupplierBusinessActivityDescription,
					SupplierContactNumber = invoice.SupplierContactNumber,
					TotalExcludingTax = invoice.TotalExcludingTax,
					TotalIncludingTax = invoice.TotalIncludingTax,
					TotalPayableAmount = invoice.TotalPayableAmount,
					TotalTaxAmount = invoice.TotalTaxAmount,
					UIN = invoice.UIN,
					DateTimestamp = invoice.DateTimestamp,
					ValidationLink = invoice.ValidationLink,
					DescriptionProductService = lineItems.DescriptionProductService,
					LiUnitPrice = lineItems.UnitPrice,
					LiSubtotal = lineItems.Subtotal,
					LiTotalTaxAmount = lineItems.TotalTaxAmount,
					LiTotalExcludingTax = lineItems.TotalExcludingTax,
					LiDiscountRate = lineItems.DiscountRate,
					LiDiscountAmount = lineItems.DiscountAmount,
					LiDiscountDescription = lineItems.DiscountDescription
				};
				combinedDataRecords.Add(combinedDataRecord);
			}
		}
		return WriteCombinedCsvFile.WriteCombinedCsvFileFn(combinedFileName, combinedDataRecords);
	}
}