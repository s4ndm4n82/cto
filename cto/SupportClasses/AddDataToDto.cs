using cto.DTOs;
using OfficeOpenXml;

namespace cto.SupportClasses;

public class AddDataToDto
{
	public static InvoiceDto AddDataToInvoiceDto(ExcelRange invoiceData,
		int currentRow,
		Dictionary<string, int> columnIndex)
	{
		try
		{
			var columnIndexes = AddDataToDtoHelper.GetInvoiceColumnIndexes(columnIndex);

			var lineIdIndex = columnIndexes[HeaderNames.LineId];
			var eInvoiceNumberIndex = columnIndexes[HeaderNames.EInvoiceNumber];
			var classificationIndex = columnIndexes[HeaderNames.Classification];
			var currencyCodeIndex = columnIndexes[HeaderNames.CurrencyCode];
			var currencyExchangeRateIndex = columnIndexes[HeaderNames.CurrencyExchangeRate];
			var kFormTypeIndex = columnIndexes[HeaderNames.KFormType];
			var kFormNumberIndex = columnIndexes[HeaderNames.KFormNumber];
			var buyerNameIndex = columnIndexes[HeaderNames.BuyerName];
			var buyerTinIndex = columnIndexes[HeaderNames.BuyerTin];
			var buyerIdTypeIndex = columnIndexes[HeaderNames.BuyerIdType];
			var buyerIdNoIndex = columnIndexes[HeaderNames.BuyerIdNo];
			var buyerAddressIndex = columnIndexes[HeaderNames.BuyerAddress];
			var buyerCityIndex = columnIndexes[HeaderNames.BuyerCity];
			var buyerStateIndex = columnIndexes[HeaderNames.BuyerState];
			var buyerCountryIndex = columnIndexes[HeaderNames.BuyerCountry];
			var buyerSstIndex = columnIndexes[HeaderNames.BuyerSst];
			var buyerMiscIndex = columnIndexes[HeaderNames.BuyerMisc];
			var buyerBusinessActivityDescriptionIndex = columnIndexes[HeaderNames.BuyerBusinessActivityDescription];
			var buyerContactNumberIndex = columnIndexes[HeaderNames.BuyerContactNumber];
			var supplierNameIndex = columnIndexes[HeaderNames.SupplierName];
			var supplierTinIndex = columnIndexes[HeaderNames.SupplierTin];
			var supplierIdTypeIndex = columnIndexes[HeaderNames.SupplierIdType];
			var supplierIdNoIndex = columnIndexes[HeaderNames.SupplierIdNo];
			var supplierAddressIndex = columnIndexes[HeaderNames.SupplierAddress];
			var supplierCityIndex = columnIndexes[HeaderNames.SupplierAddress];
			var supplierStateIndex = columnIndexes[HeaderNames.SupplierState];
			var supplierCountryIndex = columnIndexes[HeaderNames.SupplierCountry];
			var supplierSstIndex = columnIndexes[HeaderNames.SupplierSst];
			var supplierMiscIndex = columnIndexes[HeaderNames.SupplierMisc];
			var supplierBusinessActivityDescriptionIndex =
				columnIndexes[HeaderNames.SupplierBusinessActivityDescription];
			var supplierContactNumberIndex = columnIndexes[HeaderNames.SupplierContactNumber];
			var totalExcludingTaxIndex = columnIndexes[HeaderNames.TotalExcludingTax];
			var totalIncludingTaxIndex = columnIndexes[HeaderNames.TotalIncludingTax];
			var totalPayableAmountIndex = columnIndexes[HeaderNames.TotalPayableAmount];
			var totalTaxAmountIndex = columnIndexes[HeaderNames.TotalTaxAmount];
			var originalInvoiceNumberIndex = columnIndexes[HeaderNames.OriginalInvoiceNumber];
			var originalInvoiceUinIndex = columnIndexes[HeaderNames.OriginalInvoiceUin];

			var invoiceDto = new InvoiceDto
			{
				LineId = lineIdIndex > 0
					? invoiceData[currentRow, lineIdIndex].Value?.ToString() ?? string.Empty
					: string.Empty,

				EInvoiceNumber = eInvoiceNumberIndex > 0
					? invoiceData[currentRow, eInvoiceNumberIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				Classification = classificationIndex > 0
					? invoiceData[currentRow, classificationIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				CurrencyCode = currencyCodeIndex > 0
					? invoiceData[currentRow, currencyCodeIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				CurrencyExchangeRate = currencyExchangeRateIndex > 0
					? invoiceData[currentRow, currencyExchangeRateIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				KFormType = kFormTypeIndex > 0
					? invoiceData[currentRow, kFormTypeIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				KFormNumber = kFormNumberIndex > 0
					? invoiceData[currentRow, kFormNumberIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerName = buyerNameIndex > 0
					? invoiceData[currentRow, buyerNameIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerTin = buyerTinIndex > 0
					? invoiceData[currentRow, buyerTinIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerIdType = buyerIdTypeIndex > 0
					? invoiceData[currentRow, buyerIdTypeIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerIdNo = buyerIdNoIndex > 0
					? invoiceData[currentRow, buyerIdNoIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerAddressAddressLine0 = buyerAddressIndex > 0
					? invoiceData[currentRow, buyerAddressIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerAddressCityName = buyerCityIndex > 0
					? invoiceData[currentRow, buyerCityIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerAddressState = buyerStateIndex > 0
					? invoiceData[currentRow, buyerStateIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerAddressCountryCode = buyerCountryIndex > 0
					? invoiceData[currentRow, buyerCountryIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerSstNo = buyerSstIndex > 0
					? invoiceData[currentRow, buyerSstIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerMsicCode = buyerMiscIndex > 0
					? invoiceData[currentRow, buyerMiscIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerBusinessActivityDescription = buyerBusinessActivityDescriptionIndex > 0
					? invoiceData[currentRow, buyerBusinessActivityDescriptionIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerContactNumber = buyerContactNumberIndex > 0
					? invoiceData[currentRow, buyerContactNumberIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierName = supplierNameIndex > 0
					? invoiceData[currentRow, supplierNameIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierTin = supplierTinIndex > 0
					? invoiceData[currentRow, supplierTinIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierIdType = supplierIdTypeIndex > 0
					? invoiceData[currentRow, supplierIdTypeIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierIdNo = supplierIdNoIndex > 0
					? invoiceData[currentRow, supplierIdNoIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierAddressAddressLine0 = supplierAddressIndex > 0
					? invoiceData[currentRow, supplierAddressIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierAddressCityName = supplierCityIndex > 0
					? invoiceData[currentRow, supplierCityIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierAddressState = supplierStateIndex > 0
					? invoiceData[currentRow, supplierStateIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierAddressCountryCode = supplierCountryIndex > 0
					? invoiceData[currentRow, supplierCountryIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierSstNo = supplierSstIndex > 0
					? invoiceData[currentRow, supplierSstIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierMsicCode = supplierMiscIndex > 0
					? invoiceData[currentRow, supplierMiscIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierBusinessActivityDescription = supplierBusinessActivityDescriptionIndex > 0
					? invoiceData[currentRow, supplierBusinessActivityDescriptionIndex]?.Value?.ToString() ??
					  string.Empty
					: string.Empty,

				SupplierContactNumber = supplierContactNumberIndex > 0
					? invoiceData[currentRow, supplierContactNumberIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalExcludingTax = totalExcludingTaxIndex > 0
					? invoiceData[currentRow, totalExcludingTaxIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalIncludingTax = totalIncludingTaxIndex > 0
					? invoiceData[currentRow, totalIncludingTaxIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalPayableAmount = totalPayableAmountIndex > 0
					? invoiceData[currentRow, totalPayableAmountIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalTaxAmount = totalTaxAmountIndex > 0
					? invoiceData[currentRow, totalTaxAmountIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				OriginalInvoiceNumber = originalInvoiceNumberIndex > 0
					? invoiceData[currentRow, originalInvoiceNumberIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				OriginalInvoiceUin = originalInvoiceUinIndex > 0
					? invoiceData[currentRow, originalInvoiceUinIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty
			};

			return invoiceDto;
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			throw;
		}
	}

	public static LineItemsDto AddDataToLineItemsDto(ExcelRange lineItemData,
		int currentRow,
		Dictionary<string, int> columnIndexes)
	{
		var lineItemDto = new LineItemsDto
		{
			EInvoiceNumber = lineItemData[currentRow, 1]?.Value?.ToString() ?? string.Empty,
			Id = lineItemData[currentRow, 2]?.Value?.ToString() ?? string.Empty,
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
