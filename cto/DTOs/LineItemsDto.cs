namespace cto.DTOs;

public class LineItemsDto
{
    public string Classification { get; set; } = string.Empty;
    public string DescriptionProductService { get; set; } = string.Empty;
    public string UnitPrice { get; set; } = string.Empty;
    public string Subtotal { get; set; } = string.Empty;
    public string TaxRate { get; set; } = string.Empty;
    public string TaxType { get; set; } = string.Empty;
    public string TotalTaxAmount { get; set; } = string.Empty;
    public string TotalExcludingTax { get; set; } = string.Empty;
    public string DiscountRate { get; set; } = string.Empty;
    public string DiscountAmount { get; set; } = string.Empty;
    public string DiscountDescription { get; set; } = string.Empty;
}