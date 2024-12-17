using cto.DTOs;
using cto.MagicWordClasses.InvoiceLevel;
using cto.SupportClasses;
using OfficeOpenXml;

namespace cto.ProgramClasses;

public class AddDataToInvoiceDto
{
	public static InvoiceDto AddDataToInvoiceDtoFn(ExcelRange invoiceData,
		int currentRow,
		Dictionary<string, int> columnIndex)
	{
		try
		{
			var columnIndexes = AddDataToDtoHelper.GetInvoiceColumnIndexes(columnIndex);

			var lineIdColumnIndex = columnIndexes[HeaderNames.LineId];
			var eInvoiceNumberColumnIndex = columnIndexes[HeaderNames.EInvoiceNumber];
			var classificationColumnIndex = columnIndexes[HeaderNames.Classification];
			var currencyCodeColumnIndex = columnIndexes[HeaderNames.CurrencyCode];
			var currencyExchangeRateColumnIndex = columnIndexes[HeaderNames.CurrencyExchangeRate];
			var kFormTypeColumnIndex = columnIndexes[HeaderNames.KFormType];
			var kFormNumberColumnIndex = columnIndexes[HeaderNames.KFormNumber];
			var buyerNameColumnIndex = columnIndexes[HeaderNames.BuyerName];
			var buyerTinColumnIndex = columnIndexes[HeaderNames.BuyerTin];
			var buyerIdTypeColumnIndex = columnIndexes[HeaderNames.BuyerIdType];
			var buyerIdNoColumnIndex = columnIndexes[HeaderNames.BuyerIdNo];
			var buyerAddressColumnIndex = columnIndexes[HeaderNames.BuyerAddress];
			var buyerCityColumnIndex = columnIndexes[HeaderNames.BuyerCity];
			var buyerStateColumnIndex = columnIndexes[HeaderNames.BuyerState];
			var buyerCountryColumnIndex = columnIndexes[HeaderNames.BuyerCountry];
			var buyerSstColumnIndex = columnIndexes[HeaderNames.BuyerSst];
			var buyerMiscColumnIndex = columnIndexes[HeaderNames.BuyerMsic];
			var buyerBusinessActivityDescriptionColumnIndex = columnIndexes[HeaderNames.BuyerBusinessActivityDescription];
			var buyerContactNumberColumnIndex = columnIndexes[HeaderNames.BuyerContactNumber];
			var supplierNameColumnIndex = columnIndexes[HeaderNames.SupplierName];
			var supplierTinColumnIndex = columnIndexes[HeaderNames.SupplierTin];
			var supplierIdTypeColumnIndex = columnIndexes[HeaderNames.SupplierIdType];
			var supplierIdNoColumnIndex = columnIndexes[HeaderNames.SupplierIdNo];
			var supplierAddressColumnIndex = columnIndexes[HeaderNames.SupplierAddress];
			var supplierCityColumnIndex = columnIndexes[HeaderNames.SupplierCity];
			var supplierStateColumnIndex = columnIndexes[HeaderNames.SupplierState];
			var supplierCountryColumnIndex = columnIndexes[HeaderNames.SupplierCountry];
			var supplierSstColumnIndex = columnIndexes[HeaderNames.SupplierSst];
			var supplierMiscColumnIndex = columnIndexes[HeaderNames.SupplierMsic];
			var supplierBusinessActivityDescriptionColumnIndex =
				columnIndexes[HeaderNames.SupplierBusinessActivityDescription];
			var supplierContactNumberColumnIndex = columnIndexes[HeaderNames.SupplierContactNumber];
			var taxTypeColumnIndex = columnIndexes[HeaderNames.TaxType];
			var taxRateColumnIndex = columnIndexes[HeaderNames.TaxRate];
			var totalExcludingTaxColumnIndex = columnIndexes[HeaderNames.TotalExcludingTax];
			var totalIncludingTaxColumnIndex = columnIndexes[HeaderNames.TotalIncludingTax];
			var totalPayableAmountColumnIndex = columnIndexes[HeaderNames.TotalPayableAmount];
			var totalTaxAmountColumnIndex = columnIndexes[HeaderNames.TotalTaxAmount];
			var originalInvoiceNumberColumnIndex = columnIndexes[HeaderNames.OriginalInvoiceNumber];
			var originalInvoiceUinColumnIndex = columnIndexes[HeaderNames.OriginalInvoiceUin];

			var invoiceDto = new InvoiceDto
			{
				LineId = lineIdColumnIndex > 0
					? invoiceData[currentRow, lineIdColumnIndex].Value?.ToString() ?? string.Empty
					: string.Empty,

				EInvoiceNumber = eInvoiceNumberColumnIndex > 0
					? invoiceData[currentRow, eInvoiceNumberColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				Classification = classificationColumnIndex > 0
					? invoiceData[currentRow, classificationColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				CurrencyCode = currencyCodeColumnIndex > 0
					? invoiceData[currentRow, currencyCodeColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				CurrencyExchangeRate = currencyExchangeRateColumnIndex > 0
					? invoiceData[currentRow, currencyExchangeRateColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				KFormType = kFormTypeColumnIndex > 0
					? invoiceData[currentRow, kFormTypeColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				KFormNumber = kFormNumberColumnIndex > 0
					? invoiceData[currentRow, kFormNumberColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerName = buyerNameColumnIndex > 0
					? invoiceData[currentRow, buyerNameColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerTin = buyerTinColumnIndex > 0
					? invoiceData[currentRow, buyerTinColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerIdType = buyerIdTypeColumnIndex > 0
					? invoiceData[currentRow, buyerIdTypeColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerIdNo = buyerIdNoColumnIndex > 0
					? invoiceData[currentRow, buyerIdNoColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerAddress = buyerAddressColumnIndex > 0
					? invoiceData[currentRow, buyerAddressColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerCity = buyerCityColumnIndex > 0
					? invoiceData[currentRow, buyerCityColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerState = buyerStateColumnIndex > 0
					? invoiceData[currentRow, buyerStateColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerCountry = buyerCountryColumnIndex > 0
					? invoiceData[currentRow, buyerCountryColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerSst = buyerSstColumnIndex > 0
					? invoiceData[currentRow, buyerSstColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerMsicCode = buyerMiscColumnIndex > 0
					? invoiceData[currentRow, buyerMiscColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerBusinessActivityDescription = buyerBusinessActivityDescriptionColumnIndex > 0
					? invoiceData[currentRow, buyerBusinessActivityDescriptionColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				BuyerContactNumber = buyerContactNumberColumnIndex > 0
					? invoiceData[currentRow, buyerContactNumberColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierName = supplierNameColumnIndex > 0
					? invoiceData[currentRow, supplierNameColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierTin = supplierTinColumnIndex > 0
					? invoiceData[currentRow, supplierTinColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierIdType = supplierIdTypeColumnIndex > 0
					? invoiceData[currentRow, supplierIdTypeColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierIdNo = supplierIdNoColumnIndex > 0
					? invoiceData[currentRow, supplierIdNoColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierAddress = supplierAddressColumnIndex > 0
					? invoiceData[currentRow, supplierAddressColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierCity = supplierCityColumnIndex > 0
					? invoiceData[currentRow, supplierCityColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierState = supplierStateColumnIndex > 0
					? invoiceData[currentRow, supplierStateColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierCountry = supplierCountryColumnIndex > 0
					? invoiceData[currentRow, supplierCountryColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierSst = supplierSstColumnIndex > 0
					? invoiceData[currentRow, supplierSstColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierMsic = supplierMiscColumnIndex > 0
					? invoiceData[currentRow, supplierMiscColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				SupplierBusinessActivityDescription = supplierBusinessActivityDescriptionColumnIndex > 0
					? invoiceData[currentRow, supplierBusinessActivityDescriptionColumnIndex]?.Value?.ToString() ??
					  string.Empty
					: string.Empty,

				SupplierContactNumber = supplierContactNumberColumnIndex > 0
					? invoiceData[currentRow, supplierContactNumberColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,
				
				TaxRate = taxRateColumnIndex > 0
					? invoiceData[currentRow, taxRateColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,
				
				TaxType = taxTypeColumnIndex > 0
					? invoiceData[currentRow, taxTypeColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalExcludingTax = totalExcludingTaxColumnIndex > 0
					? invoiceData[currentRow, totalExcludingTaxColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalIncludingTax = totalIncludingTaxColumnIndex > 0
					? invoiceData[currentRow, totalIncludingTaxColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalPayableAmount = totalPayableAmountColumnIndex > 0
					? invoiceData[currentRow, totalPayableAmountColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				TotalTaxAmount = totalTaxAmountColumnIndex > 0
					? invoiceData[currentRow, totalTaxAmountColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				OriginalInvoiceNumber = originalInvoiceNumberColumnIndex > 0
					? invoiceData[currentRow, originalInvoiceNumberColumnIndex]?.Value?.ToString() ?? string.Empty
					: string.Empty,

				OriginalInvoiceUin = originalInvoiceUinColumnIndex > 0
					? invoiceData[currentRow, originalInvoiceUinColumnIndex]?.Value?.ToString() ?? string.Empty
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
}
