using System;

namespace cto.DTOs;

using CsvHelper.Configuration.Attributes;

public class LineItemsDto
{
	[Name("eInvoiceNumber")]
	public string EInvoiceNumber { get; set; } = string.Empty;  // Mapped to "eInvoiceNumber"

	/*[Name("ID")]
	public int ID { get; set; }*/

	[Name("DescriptionProductService")]
	public string DescriptionProductService { get; set; } = string.Empty;  // Mapped to "DescriptionProductService"

	[Name("UnitPrice")]
	public string UnitPrice { get; set; } = string.Empty;

	[Name("Subtotal")]
	public string Subtotal { get; set; } = string.Empty;

	[Name("TotalTaxAmount")]
	public string TotalTaxAmount { get; set; } = string.Empty;

	[Name("TotalExcludingTax")]
	public string TotalExcludingTax { get; set; } = string.Empty;

	[Name("DiscountRate")]
	public string DiscountRate { get; set; } = string.Empty;

	[Name("DiscountAmount")]
	public string DiscountAmount { get; set; } = string.Empty;

	[Name("DiscountDescription")]
	public string DiscountDescription { get; set; } = string.Empty;
}
