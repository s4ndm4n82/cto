using System;

namespace cto.DTOs;

public class CombinedDto
{
	// Fields from invoice csv
	public string LineID { get; set; } = string.Empty;
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string BuyerName { get; set; } = string.Empty;
	public int Classification { get; set; }
	public string CurrencyCode { get; set; } = string.Empty;
	public string CurrencyExchangeRate { get; set; } = string.Empty;
	public string SupplierName { get; set; } = string.Empty;
	public string SupplierTIN { get; set; } = string.Empty;
	public string SupplierIDType { get; set; } = string.Empty;
	public string SupplierIDNo { get; set; } = string.Empty;
	public string SupplierAddressLine0 { get; set; } = string.Empty;
	public string SupplierCityName { get; set; } = string.Empty;
	public int SupplierState { get; set; }
	public string SupplierCountryCode { get; set; } = string.Empty;
	public string SupplierSSTNo { get; set; } = string.Empty;
	public int SupplierMSICCode { get; set; }
	public string SupplierBusinessActivityDescription { get; set; } = string.Empty;
	public string SupplierContactNumber { get; set; } = string.Empty;
	public string TotalExcludingTax { get; set; } = string.Empty;
	public string TotalIncludingTax { get; set; } = string.Empty;
	public string TotalPayableAmount { get; set; } = string.Empty;
	public string TotalTaxAmount { get; set; } = string.Empty;
	public string UIN { get; set; } = string.Empty;
	public string DateTimestamp { get; set; } = string.Empty;
	public string ValidationLink { get; set; } = string.Empty;

	// Fields from line items (except EInvoiceNumber)
	public int ID { get; set; }
	public string DescriptionProductService { get; set; } = string.Empty;
	public string LiUnitPrice { get; set; } = string.Empty;
	public string LiSubtotal { get; set; } = string.Empty;
	public string LiTotalTaxAmount { get; set; } = string.Empty;       // Renamed to avoid conflict
	public string LiTotalExcludingTax { get; set; } = string.Empty;    // Renamed to avoid conflict
	public string LiDiscountRate { get; set; } = string.Empty;
	public string LiDiscountAmount { get; set; } = string.Empty;
	public string LiDiscountDescription { get; set; } = string.Empty;
}
