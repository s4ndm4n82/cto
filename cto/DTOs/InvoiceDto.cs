namespace cto.DTOs;

public class InvoiceDto
{
	public string LineID { get; set; } = string.Empty;
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string Classification { get; set; } = string.Empty;
	public string CurrencyCode { get; set; } = string.Empty;
	public string CurrencyExchangeRate { get; set; } = string.Empty;
	public string CustomsDeclaration { get; set; } = string.Empty;
	public string CustomsDeclarationNoFormNumber { get; set; } = string.Empty;
	public string BuyerName { get; set; } = string.Empty;
	public string BuyerTIN { get; set; } = string.Empty;
	public string BuyerIDType { get; set; } = string.Empty;
	public string BuyerIDNo { get; set; } = string.Empty;
	public string BuyerAddressAddressLine0 { get; set; } = string.Empty;
	public string BuyerAddressCityName { get; set; } = string.Empty;
	public string BuyerAddressState { get; set; } = string.Empty;
	public string BuyerAddressCountryCode { get; set; } = string.Empty;
	public string BuyerSSTNo { get; set; } = string.Empty;
	public string BuyerMSICCode { get; set; } = string.Empty;
	public string BuyerBusinessActivityDescription { get; set; } = string.Empty;
	public string BuyerContactNumber { get; set; } = string.Empty;
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
	public string OriginalInvoiceUin { get; set; } = string.Empty;
	public List<LineItemsDto> LineItems { get; set; } = [];
}
