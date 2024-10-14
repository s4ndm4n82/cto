using cto.DTOs;
using cto.SupportClasses;
using System.Text.RegularExpressions;

namespace cto.ProgramClasses;

public partial class WriteCsvFile
{
	public static bool WriteFile(Dictionary<string, InvoiceDto> invoiceData,
	IEnumerable<LineItemsDto> lineItemsData)
	{
		FolderPaths.Instance.InitializePaths();
		var outPutFolderPath = FolderPaths.Instance.OutputFolderPath;

		var settings = ReadSettings.ReadAppSettings();
		var csvDelimiter = settings.AppConfigs.FileSettings.Delimiter == ""
		? ";"
		: settings.AppConfigs.FileSettings.Delimiter;

		foreach (var invoice in invoiceData)
		{
			if (lineItemsData.Any(x => x.EInvoiceNumber == invoice.Key))
			{
				var lineItems = lineItemsData.Where(x => x.EInvoiceNumber == invoice.Key);
				if (lineItems == null)
				{
					Console.WriteLine("Line Items data not found for invoice number: " + invoice.Key);
					return false;
				}

				var cleanInvoiceNumber = CleanInvoiceNo().Replace(invoice.Value.EInvoiceNumber, "-");

				var combinedFileName = string.Concat(
				invoice.Value.SupplierTIN, "_", cleanInvoiceNumber, ".csv"
				);

				var combinedFilePath = Path.Combine(outPutFolderPath, combinedFileName);

				using var writer = new StreamWriter(combinedFilePath);
				writer.WriteLine(
				"eInvoiceNumber" + csvDelimiter +
				"Buyer.Name" + csvDelimiter +
				"Classification" + csvDelimiter +
				"CurrencyCode" + csvDelimiter +
				"CurrencyExchangeRate" + csvDelimiter +
				"Supplier.Name" + csvDelimiter +
				"Supplier.TIN" + csvDelimiter +
				"Supplier.IDType" + csvDelimiter +
				"Supplier.IDNo" + csvDelimiter +
				"Supplier.Address.AddressLine0" + csvDelimiter +
				"Supplier.Address.CityName" + csvDelimiter +
				"Supplier.Address.State" + csvDelimiter +
				"Supplier.Address.CountryCode" + csvDelimiter +
				"Supplier.SST.No,Supplier.MSIC.Code" + csvDelimiter +
				"Supplier.BusinessActivityDescription" + csvDelimiter +
				"Supplier.ContactNumber" + csvDelimiter +
				"TotalExcludingTax" + csvDelimiter +
				"TotalIncludingTax" + csvDelimiter +
				"TotalPayableAmount" + csvDelimiter +
				"TotalTaxAmount" + csvDelimiter +
				"UIN" + csvDelimiter +
				"Date & Timestamp" + csvDelimiter +
				"Validation Link" + csvDelimiter +
				"DescriptionProductService" + csvDelimiter +
				"UnitPrice,Subtotal" + csvDelimiter +
				"TotalTaxAmount" + csvDelimiter +
				"TotalExcludingTax" + csvDelimiter +
				"DiscountRate" + csvDelimiter +
				"DiscountAmount" + csvDelimiter +
				"DiscountDescription");

				foreach (var lineItem in lineItems)
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
						DescriptionProductService = lineItem.DescriptionProductService,
						LiUnitPrice = lineItem.UnitPrice,
						LiSubtotal = lineItem.Subtotal,
						LiTotalTaxAmount = lineItem.TotalTaxAmount,
						LiTotalExcludingTax = lineItem.TotalExcludingTax,
						LiDiscountRate = lineItem.DiscountRate,
						LiDiscountAmount = lineItem.DiscountAmount,
						LiDiscountDescription = lineItem.DiscountDescription
					};

					writer.WriteLine(
						$"{combinedDataRecord.EInvoiceNumber}".Trim() + csvDelimiter +
						$"{combinedDataRecord.BuyerName}".Trim() + csvDelimiter +
						$"{combinedDataRecord.Classification}".Trim() + csvDelimiter +
						$"{combinedDataRecord.CurrencyCode}".Trim() + csvDelimiter +
						$"{combinedDataRecord.CurrencyExchangeRate}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierName}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierTIN}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierIDType}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierIDNo}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierAddressLine0}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierCityName}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierState}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierCountryCode}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierSSTNo}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierBusinessActivityDescription}".Trim() + csvDelimiter +
						$"{combinedDataRecord.SupplierContactNumber}".Trim() + csvDelimiter +
						$"{combinedDataRecord.TotalExcludingTax}".Trim() + csvDelimiter +
						$"{combinedDataRecord.TotalIncludingTax}".Trim() + csvDelimiter +
						$"{combinedDataRecord.TotalPayableAmount}".Trim() + csvDelimiter +
						$"{combinedDataRecord.TotalTaxAmount}".Trim() + csvDelimiter +
						$"{combinedDataRecord.UIN}".Trim() + csvDelimiter +
						$"{combinedDataRecord.DateTimestamp}".Trim() + csvDelimiter +
						$"{combinedDataRecord.ValidationLink}".Trim() + csvDelimiter +
						$"{combinedDataRecord.DescriptionProductService}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiUnitPrice}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiSubtotal}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiTotalTaxAmount}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiTotalExcludingTax}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiDiscountRate}".Trim() + csvDelimiter +
						$"{combinedDataRecord.LiDiscountAmount}"
					);
				}
			}
		}
		return true;
	}

	[GeneratedRegex(@"[^0-9a-zA-Z_\-]")]
	private static partial Regex CleanInvoiceNo();
}
