using cto.DTOs;
using cto.MagicWordClasses.InvoiceLevel;
using cto.MagicWordClasses.LineItemLevel;
using cto.SupportClasses;
using OfficeOpenXml;

namespace cto.ProgramClasses;

public class AddDataToLineItemsDto
{
    public static LineItemsDto AddDataToLineItemsDtoFn(ExcelRange lineItemData,
        int currentRow,
        Dictionary<string, int> columnIndexes)
    {
        var lineItemColumnIndexes = AddDataToDtoHelper.GetLineColumnIndexes(columnIndexes);
        
        var descriptionColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DescriptionProductService];
        var unitPriceColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.UnitPrice];
        var subtotalColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.Subtotal];
        var taxRateColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TaxRate];
        var taxTypeColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TaxType];
        var totalTaxAmountColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TotalTaxAmount];
        var totalExcludingTaxColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TotalExcludingTax];
        var discountRateColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountRate];
        var discountAmountColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountAmount];
        var discountDescriptionColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountDescription];
            
        var lineItemDto = new LineItemsDto
        {   
            DescriptionProductService = descriptionColumnIndex > 0
                ? lineItemData[currentRow, descriptionColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            UnitPrice = unitPriceColumnIndex > 0
                ? lineItemData[currentRow, unitPriceColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            Subtotal = subtotalColumnIndex > 0
                ? lineItemData[currentRow, subtotalColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TaxRate = taxRateColumnIndex > 0
                ? lineItemData[currentRow, taxRateColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TaxType = taxTypeColumnIndex > 0
                ? lineItemData[currentRow, taxTypeColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TotalTaxAmount = totalTaxAmountColumnIndex > 0
                ? lineItemData[currentRow, totalTaxAmountColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TotalExcludingTax = totalExcludingTaxColumnIndex > 0
                ? lineItemData[currentRow, totalExcludingTaxColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountRate = discountRateColumnIndex > 0
                ? lineItemData[currentRow, discountRateColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountAmount = discountAmountColumnIndex > 0
                ? lineItemData[currentRow, discountAmountColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountDescription = discountDescriptionColumnIndex > 0
                ? lineItemData[currentRow, discountDescriptionColumnIndex]?.Value?.ToString() ?? string.Empty
                : string.Empty
        };

        return lineItemDto;
    }
}