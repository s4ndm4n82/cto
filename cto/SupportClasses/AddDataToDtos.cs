using cto.DTOs;
using OfficeOpenXml;

namespace cto.SupportClasses;

public class AddDataToDto
{
	public static InvoiceDto AddDataToInvoiceDto(ExcelRange invoiceData,
	int currentRow,
	Dictionary<string, int> columnIndex)
	{
		var test = columnIndex.Where(x => x.Key.Equals("line ID", StringComparison.OrdinalIgnoreCase)).Select(y => y.Value).FirstOrDefault();
		var test2 = columnIndex.Where(x => x.Key.Equals("eInvoiceNumber", StringComparison.OrdinalIgnoreCase)).Select(y => y.Value).FirstOrDefault();
		var invoiceDto = new InvoiceDto
		{
			LineID = invoiceData[currentRow, 1]?.Value?.ToString() ?? string.Empty,
			EInvoiceNumber = invoiceData[currentRow, 2]?.Value?.ToString() ?? string.Empty,
			BuyerName = invoiceData[currentRow, 3]?.Value?.ToString() ?? string.Empty,
			Classification = invoiceData[currentRow, 4]?.Value?.ToString() ?? string.Empty,
			CurrencyCode = invoiceData[currentRow, 5]?.Value?.ToString() ?? string.Empty,
			CurrencyExchangeRate = invoiceData[currentRow, 6]?.Value?.ToString() ?? string.Empty,
			KFormType = invoiceData[currentRow, 7]?.Value?.ToString() ?? string.Empty,
			KFormNumber = invoiceData[currentRow, 8]?.Value?.ToString() ?? string.Empty,
			SupplierName = invoiceData[currentRow, 9]?.Value?.ToString() ?? string.Empty,
			SupplierTIN = invoiceData[currentRow, 10]?.Value?.ToString() ?? string.Empty,
			SupplierIDType = invoiceData[currentRow, 11]?.Value?.ToString() ?? string.Empty,
			SupplierIDNo = invoiceData[currentRow, 12]?.Value?.ToString() ?? string.Empty,
			SupplierAddressAddressLine0 = invoiceData[currentRow, 13]?.Value?.ToString() ?? string.Empty,
			SupplierAddressCityName = invoiceData[currentRow, 14]?.Value?.ToString() ?? string.Empty,
			SupplierAddressState = invoiceData[currentRow, 15]?.Value?.ToString() ?? string.Empty,
			SupplierAddressCountryCode = invoiceData[currentRow, 16]?.Value?.ToString() ?? string.Empty,
			SupplierSSTNo = invoiceData[currentRow, 17]?.Value?.ToString() ?? string.Empty,
			SupplierMSICCode = invoiceData[currentRow, 18]?.Value?.ToString() ?? string.Empty,
			SupplierBusinessActivityDescription = invoiceData[currentRow, 19]?.Value?.ToString() ?? string.Empty,
			SupplierContactNumber = invoiceData[currentRow, 20]?.Value?.ToString() ?? string.Empty,
			TotalExcludingTax = invoiceData[currentRow, 21]?.Value?.ToString() ?? string.Empty,
			TotalIncludingTax = invoiceData[currentRow, 22]?.Value?.ToString() ?? string.Empty,
			TotalPayableAmount = invoiceData[currentRow, 23]?.Value?.ToString() ?? string.Empty,
			TotalTaxAmount = invoiceData[currentRow, 24]?.Value?.ToString() ?? string.Empty,
			OriginalInvoiceNumber = invoiceData[currentRow, 28]?.Value?.ToString() ?? string.Empty,
			InvoiceReferenceUin = invoiceData[currentRow, 29]?.Value?.ToString() ?? string.Empty
		};

		return invoiceDto;
	}

	public static LineItemsDto AddDataToLineItemsDto(ExcelRange lineItemData, int currentRow)
	{
		var lineItemDto = new LineItemsDto
		{
			EInvoiceNumber = lineItemData[currentRow, 1]?.Value?.ToString() ?? string.Empty,
			ID = lineItemData[currentRow, 2]?.Value?.ToString() ?? string.Empty,
			DescriptionProductService = lineItemData[currentRow, 3]?.Value?.ToString() ?? string.Empty,
			UnitPrice = lineItemData[currentRow, 4]?.Value?.ToString() ?? string.Empty,
			Subtotal = lineItemData[currentRow, 5]?.Value?.ToString() ?? string.Empty,
			TotalTaxAmount = lineItemData[currentRow, 6]?.Value?.ToString() ?? string.Empty,
			TotalExcludingTax = lineItemData[currentRow, 7]?.Value?.ToString() ?? string.Empty,
			DiscountRate = lineItemData[currentRow, 8]?.Value?.ToString() ?? string.Empty,
			DiscountAmount = lineItemData[currentRow, 9]?.Value?.ToString() ?? string.Empty,
			DiscountDescription = lineItemData[currentRow, 10]?.Value?.ToString() ?? string.Empty
		};

		return lineItemDto;
	}
}
