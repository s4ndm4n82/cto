using System;

namespace cto.DTOs;

public class LineItemsDto
{
	public string EInvoiceNumber { get; set; } = string.Empty;         // Mapped "eInvoiceNumber"
	public int ID { get; set; }
	public string DescriptionProductService { get; set; } = string.Empty;   // Mapped "DescriptionProductService"
	public decimal UnitPrice { get; set; }
	public decimal Subtotal { get; set; }
	public decimal TotalTaxAmount { get; set; }
	public decimal TotalExcludingTax { get; set; }
	public decimal DiscountRate { get; set; }
	public decimal DiscountAmount { get; set; }
	public string DiscountDescription { get; set; } = string.Empty;
}
