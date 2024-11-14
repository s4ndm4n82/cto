namespace cto.DTOs;

public class InvoiceDto
{
	public string LineID { get; set; } = string.Empty;
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string BuyerName { get; set; } = string.Empty;
	public string Classification { get; set; } = string.Empty;
	public string CurrencyCode { get; set; } = string.Empty;
	public string CurrencyExchangeRate { get; set; } = string.Empty;
	public string KFormType { get; set; } = "K1";
	public string KFormNumber { get; set; } = "12345";
	public string SupplierName { get; set; } = string.Empty;
	public string SupplierTIN { get; set; } = string.Empty;
	public string SupplierIDType { get; set; } = string.Empty;
	public string SupplierIDNo { get; set; } = string.Empty;
	public string SupplierAddressAddressLine0 { get; set; } = string.Empty;
	public string SupplierAddressCityName { get; set; } = string.Empty;
	public string SupplierAddressState { get; set; } = string.Empty;
	public string SupplierAddressCountryCode { get; set; } = string.Empty;
	public string SupplierSSTNo { get; set; } = string.Empty;
	public string SupplierMSICCode { get; set; } = string.Empty;
	public string SupplierBusinessActivityDescription { get; set; } = string.Empty;
	public string SupplierContactNumber { get; set; } = string.Empty;
	public string TotalExcludingTax { get; set; } = string.Empty;
	public string TotalIncludingTax { get; set; } = string.Empty;
	public string TotalPayableAmount { get; set; } = string.Empty;
	public string TotalTaxAmount { get; set; } = string.Empty;
	public string OriginalInvoiceNumber { get; set; } = string.Empty;
	public string InvoiceReferenceUin { get; set; } = string.Empty;
	public List<LineItemsDto> LineItems { get; set; } = [];
}
