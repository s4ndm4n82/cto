using CsvHelper.Configuration.Attributes;

namespace cto.DTOs;

public class InvoiceDto
{
	[Name("Line ID")]
	public string LineID { get; set; } = string.Empty;

	[Name("eInvoiceNumber")]
	public string EInvoiceNumber { get; set; } = string.Empty;

	[Name("Buyer.Name")]
	public string BuyerName { get; set; } = string.Empty;

	[Name("Classification")]
	public int Classification { get; set; }

	[Name("CurrencyCode")]
	public string CurrencyCode { get; set; } = string.Empty;

	[Name("CurrencyExchangeRate")]
	public string CurrencyExchangeRate { get; set; } = string.Empty;

	[Name("Supplier.Name")]
	public string SupplierName { get; set; } = string.Empty;

	[Name("Supplier.TIN")]
	public string SupplierTIN { get; set; } = string.Empty;

	[Name("Supplier.IDType")]
	public string SupplierIDType { get; set; } = string.Empty;

	[Name("Supplier.IDNo")]
	public string SupplierIDNo { get; set; } = string.Empty;

	[Name("Supplier.Address.AddressLine0")]
	public string SupplierAddressAddressLine0 { get; set; } = string.Empty;

	[Name("Supplier.Address.CityName")]
	public string SupplierAddressCityName { get; set; } = string.Empty;

	[Name("Supplier.Address.State")]
	public int SupplierAddressState { get; set; }

	[Name("Supplier.Address.CountryCode")]
	public string SupplierAddressCountryCode { get; set; } = string.Empty;

	[Name("Supplier.SST.No")]
	public string SupplierSSTNo { get; set; } = string.Empty;

	[Name("Supplier.MSIC.Code")]
	public int SupplierMSICCode { get; set; }

	[Name("Supplier.BusinessActivityDescription")]
	public string SupplierBusinessActivityDescription { get; set; } = string.Empty;

	[Name("Supplier.ContactNumber")]
	public string SupplierContactNumber { get; set; } = string.Empty;

	[Name("TotalExcludingTax")]
	public string TotalExcludingTax { get; set; } = string.Empty;

	[Name("TotalIncludingTax")]
	public string TotalIncludingTax { get; set; } = string.Empty;

	[Name("TotalPayableAmount")]
	public string TotalPayableAmount { get; set; } = string.Empty;

	[Name("TotalTaxAmount")]
	public string TotalTaxAmount { get; set; } = string.Empty;

	[Name("UIN")]
	public string UIN { get; set; } = string.Empty;

	[Name("Date & Timestamp")]
	public string DateTimestamp { get; set; } = string.Empty;

	[Name("Validation Link")]
	public string ValidationLink { get; set; } = string.Empty;
}
