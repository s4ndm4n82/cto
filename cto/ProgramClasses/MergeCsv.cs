using System.Text.RegularExpressions;
using cto.DTOs;
using cto.SupportClasses;

namespace cto.ProgramClasses;

public partial class MergeCsv
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

			MergeCsvFiles(invoiceCsvData, lineItemsCsvData);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Thread.Sleep(3000);
			return false;
		}

		return false;
	}

	private static bool MergeCsvFiles(Dictionary<string, InvoiceDto> invoiceData,
	IEnumerable<LineItemsDto> lineItemsData)
	{
		FolderPaths.Instance.InitializePaths();

		var outPutFolderPath = FolderPaths.Instance.OutputFolderPath;

		foreach (var invoice in invoiceData)
		{
			if (lineItemsData.Any(x => x.EInvoiceNumber == invoice.Key))
			{
				var lineItems = lineItemsData.FirstOrDefault(x => x.EInvoiceNumber == invoice.Key);
				if (lineItems == null)
				{
					Console.WriteLine("Line Items data not found for invoice number: " + invoice.Key);
					return false;
				}

				var combinedFileName = string.Concat(
				invoice.Value.SupplierTIN, "_", invoice.Value.EInvoiceNumber, ".csv"
				);

				var combinedFilePath = Path.Combine(outPutFolderPath, combinedFileName);

				using var writer = new StreamWriter(combinedFilePath);
				writer.WriteLine(
				"eInvoiceNumber," +
				"Buyer.Name," +
				"Classification," +
				"CurrencyCode," +
				"CurrencyExchangeRate," +
				"Supplier.Name," +
				"Supplier.TIN," +
				"Supplier.IDType," +
				"Supplier.IDNo," +
				"Supplier.Address.AddressLine0," +
				"Supplier.Address.CityName," +
				"Supplier.Address.State," +
				"Supplier.Address.CountryCode," +
				"Supplier.SST.No,Supplier.MSIC.Code," +
				"Supplier.BusinessActivityDescription," +
				"Supplier.ContactNumber," +
				"TotalExcludingTax," +
				"TotalIncludingTax," +
				"TotalPayableAmount," +
				"TotalTaxAmount," +
				"UIN," +
				"Date & Timestamp," +
				"Validation Link," +
				"DescriptionProductService," +
				"UnitPrice,Subtotal," +
				"TotalTaxAmount," +
				"TotalExcludingTax," +
				"DiscountRate," +
				"DiscountAmount," +
				"DiscountDescription");

				foreach (var lineItem in lineItemsData)
				{
					if (lineItem.EInvoiceNumber != invoice.Key)
					{
						continue;
					}

					var combinedDataRecord = new CombinedDto
					{
						EInvoiceNumber = invoice.Value.EInvoiceNumber,
						BuyerName = invoice.Value.BuyerName,
						Classification = invoice.Value.Classification,
						CurrencyCode = invoice.Value.CurrencyCode,
						CurrencyExchangeRate = invoice.Value.CurrencyExchangeRate,
						SupplierName = invoice.Value.SupplierName,
						SupplierTIN = invoice.Value.SupplierTIN,
						SupplierIDType = invoice.Value.SupplierIDType,
						SupplierIDNo = invoice.Value.SupplierIDNo,
						SupplierAddressLine0 = invoice.Value.SupplierAddressAddressLine0,
						SupplierCityName = invoice.Value.SupplierAddressCityName,
						SupplierState = invoice.Value.SupplierAddressState,
						SupplierCountryCode = invoice.Value.SupplierAddressCountryCode,
						SupplierSSTNo = invoice.Value.SupplierSSTNo,
						SupplierBusinessActivityDescription = invoice.Value.SupplierBusinessActivityDescription,
						SupplierContactNumber = invoice.Value.SupplierContactNumber,
						TotalExcludingTax = invoice.Value.TotalExcludingTax,
						TotalIncludingTax = invoice.Value.TotalIncludingTax,
						TotalPayableAmount = invoice.Value.TotalPayableAmount,
						TotalTaxAmount = invoice.Value.TotalTaxAmount,
						UIN = invoice.Value.UIN,
						DateTimestamp = invoice.Value.DateTimestamp,
						ValidationLink = invoice.Value.ValidationLink,
						DescriptionProductService = lineItems.DescriptionProductService,
						LiUnitPrice = lineItems.UnitPrice,
						LiSubtotal = lineItems.Subtotal,
						LiTotalTaxAmount = lineItems.TotalTaxAmount,
						LiTotalExcludingTax = lineItems.TotalExcludingTax,
						LiDiscountRate = lineItems.DiscountRate,
						LiDiscountAmount = lineItems.DiscountAmount,
						LiDiscountDescription = lineItems.DiscountDescription
					};
					// TODO: Complete the below list.
					writer.WriteLine(
						$"{combinedDataRecord.EInvoiceNumber}," +
						$"{combinedDataRecord.BuyerName}," +
						$"{combinedDataRecord.LiTotalExcludingTax},"
					);
				}
			}
		}
		return true;
	}
}