using System;

namespace cto.DTOs;

public class CombinedDto
{
	// Fields from invoice csv
	public long LineID { get; set; }
	public string EInvoiceNumber { get; set; } = string.Empty;
	public string BuyerName { get; set; } = string.Empty;
	public int Classification { get; set; }
	public string CurrencyCode { get; set; } = string.Empty;
	public decimal CurrencyExchangeRate { get; set; }
	public string SupplierName { get; set; } = string.Empty;
	public string SupplierTIN { get; set; } = string.Empty;
	public string SupplierIDType { get; set; } = string.Empty;
	public long SupplierIDNo { get; set; }
	public string SupplierAddressLine0 { get; set; } = string.Empty;
	public string SupplierCityName { get; set; } = string.Empty;
	public int SupplierState { get; set; }
	public string SupplierCountryCode { get; set; } = string.Empty;
	public string SupplierSSTNo { get; set; } = string.Empty;
	public int SupplierMSICCode { get; set; }
	public string SupplierBusinessActivityDescription { get; set; } = string.Empty;
	public string SupplierContactNumber { get; set; } = string.Empty;
	public decimal TotalExcludingTax { get; set; }
	public decimal TotalIncludingTax { get; set; }
	public decimal TotalPayableAmount { get; set; }
	public decimal TotalTaxAmount { get; set; }
	public string UIN { get; set; } = string.Empty;
	public string DateTimestamp { get; set; } = string.Empty;
	public string ValidationLink { get; set; } = string.Empty;

	// Fields from line items (except EInvoiceNumber)
	public int ID { get; set; }
	public string DescriptionProductService { get; set; } = string.Empty;
	public decimal LiUnitPrice { get; set; }
	public decimal LiSubtotal { get; set; }
	public decimal LiTotalTaxAmount { get; set; }       // Renamed to avoid conflict
	public decimal LiTotalExcludingTax { get; set; }    // Renamed to avoid conflict
	public decimal LiDiscountRate { get; set; }
	public decimal LiDiscountAmount { get; set; }
	public string LiDiscountDescription { get; set; } = string.Empty;
}
