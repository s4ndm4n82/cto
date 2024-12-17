namespace cto.DTOs;

public class InvoiceDto
{
	public string LineId { get; set; } = string.Empty;
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string Classification { get; set; } = string.Empty;
	public string CurrencyCode { get; set; } = string.Empty;
	public string CurrencyExchangeRate { get; set; } = string.Empty;
	public string KFormType { get; set; } = string.Empty;
	public string KFormNumber { get; set; } = string.Empty;
	public string BuyerName { get; set; } = string.Empty;
	public string BuyerTin { get; set; } = string.Empty;
	public string BuyerIdType { get; set; } = string.Empty;
	public string BuyerIdNo { get; set; } = string.Empty;
	public string BuyerAddress { get; set; } = string.Empty;
	public string BuyerCity { get; set; } = string.Empty;
	public string BuyerState { get; set; } = string.Empty;
	public string BuyerCountry { get; set; } = string.Empty;
	public string BuyerSst { get; set; } = string.Empty;
	public string BuyerMsicCode { get; set; } = string.Empty;
	public string BuyerBusinessActivityDescription { get; set; } = string.Empty;
	public string BuyerContactNumber { get; set; } = string.Empty;
	public string SupplierName { get; set; } = string.Empty;
	public string SupplierTin { get; set; } = string.Empty;
	public string SupplierIdType { get; set; } = string.Empty;
	public string SupplierIdNo { get; set; } = string.Empty;
	public string SupplierAddress { get; set; } = string.Empty;
	public string SupplierCity { get; set; } = string.Empty;
	public string SupplierState { get; set; } = string.Empty;
	public string SupplierCountry { get; set; } = string.Empty;
	public string SupplierSst { get; set; } = string.Empty;
	public string SupplierMsic { get; set; } = string.Empty;
	public string SupplierBusinessActivityDescription { get; set; } = string.Empty;
	public string SupplierContactNumber { get; set; } = string.Empty;
	public string TaxRate { get; set; } = string.Empty;
	public string TaxType { get; set; } = string.Empty;
	public string TotalExcludingTax { get; set; } = string.Empty;
	public string TotalIncludingTax { get; set; } = string.Empty;
	public string TotalPayableAmount { get; set; } = string.Empty;
	public string TotalTaxAmount { get; set; } = string.Empty;
	public string OriginalInvoiceNumber { get; set; } = string.Empty;
	public string OriginalInvoiceUin { get; set; } = string.Empty;
	public List<LineItemsDto> LineItems { get; set; } = [];
}
