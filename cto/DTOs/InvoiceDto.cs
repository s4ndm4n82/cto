namespace cto.DTOs;

public class InvoiceDto
{
	public string LineId { get; set; } = string.Empty;
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string Classification { get; set; } = string.Empty;
	public string CurrencyCode { get; set; } = string.Empty;
	public string CurrencyExchangeRate { get; set; } = string.Empty;
	public string KFormType { get; set; } = "K1";
	public string KFormNumber { get; set; } = "12345";
	public string BuyerName { get; set; } = string.Empty;
	public string BuyerTin { get; set; } = string.Empty;
	public string BuyerIdType { get; set; } = string.Empty;
	public string BuyerIdNo { get; set; } = string.Empty;
	public string BuyerAddressAddressLine0 { get; set; } = string.Empty;
	public string BuyerAddressCityName { get; set; } = string.Empty;
	public string BuyerAddressState { get; set; } = string.Empty;
	public string BuyerAddressCountryCode { get; set; } = string.Empty;
	public string BuyerSstNo { get; set; } = string.Empty;
	public string BuyerMsicCode { get; set; } = string.Empty;
	public string BuyerBusinessActivityDescription { get; set; } = string.Empty;
	public string BuyerContactNumber { get; set; } = string.Empty;
	public string SupplierName { get; set; } = string.Empty;
	public string SupplierTin { get; set; } = string.Empty;
	public string SupplierIdType { get; set; } = string.Empty;
	public string SupplierIdNo { get; set; } = string.Empty;
	public string SupplierAddressAddressLine0 { get; set; } = string.Empty;
	public string SupplierAddressCityName { get; set; } = string.Empty;
	public string SupplierAddressState { get; set; } = string.Empty;
	public string SupplierAddressCountryCode { get; set; } = string.Empty;
	public string SupplierSstNo { get; set; } = string.Empty;
	public string SupplierMsicCode { get; set; } = string.Empty;
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
