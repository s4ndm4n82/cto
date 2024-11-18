using cto.DTOs;
using OfficeOpenXml;

namespace cto.SupportClasses;

public class AddDataToDto
{
	public static InvoiceDto AddDataToInvoiceDto(ExcelRange invoiceData,
	Dictionary<string, int> invoiceHeaderIndexes,
	int currentRow)
	{
		var lineIdIndex = invoiceHeaderIndexes
		.FirstOrDefault(name => name.Key
		.Equals("line id", StringComparison.OrdinalIgnoreCase))
		.Value;

		var eInvoiceNumberIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("eInvoiceNumber", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var classificationIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("classification", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var currencyCodeIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("currencycode", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var currencyExchangeRateIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("currencyexchangeRate", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var customsDeclarationIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("customs.declaration", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var customsDeclarationNoFormNumberIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("customs.declaration.no.form.number", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerNameIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.name", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerTINIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.TIN", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerIDTypeIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.IDType", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerIDNoIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.IDNo", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerAddressAddressLine0Index = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key.Equals("buyer.Address.AddressLine0", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerAddressCityNameIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.Address.CityName", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerAddressStateIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.Address.State", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerAddressCountryCodeIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.Address.CountryCode", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerSSTNoIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.SST.No", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerMSICIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.MSIC.Code", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerBusinessActivityDescriptionIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.BusinessActivityDescription", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var buyerContactNumberIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("buyer.ContactNumber", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierNameIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.Name", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierTINIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.TIN", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierIDTypeIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.IDType", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierIDNoIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.IDNo", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierAddressAddressLine0Index = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.Address.AddressLine0", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierAddressCityNameIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.Address.CityName", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierAddressStateIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.Address.State", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierAddressCountryCodeIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.Address.CountryCode", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierSSTNoIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.SST.No", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierMSICIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.MSIC.Code", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierBusinessActivityDescriptionIndex = invoiceHeaderIndexes
		.FirstOrDefault(name => name.Key
		.Equals("supplier.BusinessActivityDescription", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var supplierContactNumberIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("supplier.ContactNumber", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var totalExcludingTax = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("totalExcludingTax", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var totalIncludingTax = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("totalIncludingTax", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var totalPayableAmount = invoiceHeaderIndexes
		.FirstOrDefault(name => name.Key
		.Equals("totalPayableAmount", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var totalTaxAmount = invoiceHeaderIndexes
		.FirstOrDefault(name => name.Key
		.Equals("totalTaxAmount", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var originalInvoiceNumberIndex = invoiceHeaderIndexes
		.FirstOrDefault(name => name.Key
		.Equals("Original.Invoice.Number", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var originalInvoiceUinIndex = invoiceHeaderIndexes.
		FirstOrDefault(name => name.Key
		.Equals("Original.Invoice.UIN", StringComparison.InvariantCultureIgnoreCase))
		.Value;

		var invoiceDto = new InvoiceDto
		{
			LineID = invoiceData[currentRow, lineIdIndex]?
			.Value?.ToString() ?? string.Empty,
			EInvoiceNumber = invoiceData[currentRow, eInvoiceNumberIndex]?
			.Value?.ToString() ?? string.Empty,
			Classification = invoiceData[currentRow, classificationIndex]?
			.Value?.ToString() ?? string.Empty,
			CurrencyCode = invoiceData[currentRow, currencyCodeIndex]?
			.Value?.ToString() ?? string.Empty,
			CurrencyExchangeRate = invoiceData[currentRow, currencyExchangeRateIndex]?
			.Value?.ToString() ?? string.Empty,
			CustomsDeclaration = invoiceData[currentRow, customsDeclarationIndex]?
			.Value?.ToString() ?? string.Empty,
			CustomsDeclarationNoFormNumber = invoiceData[currentRow, customsDeclarationNoFormNumberIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerName = invoiceData[currentRow, buyerNameIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerTIN = invoiceData[currentRow, buyerTINIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerIDType = invoiceData[currentRow, buyerIDTypeIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerIDNo = invoiceData[currentRow, buyerIDNoIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerAddressAddressLine0 = invoiceData[currentRow, buyerAddressAddressLine0Index]?
			.Value?.ToString() ?? string.Empty,
			BuyerAddressCityName = invoiceData[currentRow, buyerAddressCityNameIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerAddressState = invoiceData[currentRow, buyerAddressStateIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerAddressCountryCode = invoiceData[currentRow, buyerAddressCountryCodeIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerSSTNo = invoiceData[currentRow, buyerSSTNoIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerMSICCode = invoiceData[currentRow, buyerMSICIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerBusinessActivityDescription = invoiceData[currentRow, buyerBusinessActivityDescriptionIndex]?
			.Value?.ToString() ?? string.Empty,
			BuyerContactNumber = invoiceData[currentRow, buyerContactNumberIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierName = invoiceData[currentRow, supplierNameIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierTIN = invoiceData[currentRow, supplierTINIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierIDType = invoiceData[currentRow, supplierIDTypeIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierIDNo = invoiceData[currentRow, supplierIDNoIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierAddressAddressLine0 = invoiceData[currentRow, supplierAddressAddressLine0Index]?
			.Value?.ToString() ?? string.Empty,
			SupplierAddressCityName = invoiceData[currentRow, supplierAddressCityNameIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierAddressState = invoiceData[currentRow, supplierAddressStateIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierAddressCountryCode = invoiceData[currentRow, supplierAddressCountryCodeIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierSSTNo = invoiceData[currentRow, supplierSSTNoIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierMSICCode = invoiceData[currentRow, supplierMSICIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierBusinessActivityDescription = invoiceData[currentRow, supplierBusinessActivityDescriptionIndex]?
			.Value?.ToString() ?? string.Empty,
			SupplierContactNumber = invoiceData[currentRow, supplierContactNumberIndex]?
			.Value?.ToString() ?? string.Empty,
			TotalExcludingTax = invoiceData[currentRow, totalExcludingTax]?
			.Value?.ToString() ?? string.Empty,
			TotalIncludingTax = invoiceData[currentRow, totalIncludingTax]?
			.Value?.ToString() ?? string.Empty,
			TotalPayableAmount = invoiceData[currentRow, totalPayableAmount]?
			.Value?.ToString() ?? string.Empty,
			TotalTaxAmount = invoiceData[currentRow, totalTaxAmount]?
			.Value?.ToString() ?? string.Empty,
			OriginalInvoiceNumber = invoiceData[currentRow, originalInvoiceNumberIndex]?
			.Value?.ToString() ?? string.Empty,
			OriginalInvoiceUin = invoiceData[currentRow, originalInvoiceUinIndex]?
			.Value?.ToString() ?? string.Empty
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
