using cto.DTOs;
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
        var totalTaxAmountColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TotalTaxAmount];
        var totalExcludingTaxColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.TotalExcludingTax];
        var discountRateColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountRate];
        var discountAmountColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountAmount];
        var discountDescriptionColumnIndex = lineItemColumnIndexes[ExcelLineHeaderNames.DiscountDescription];
            
        var lineItemDto = new LineItemsDto
        {
            DescriptionProductService = descriptionColumnIndex > 0
                ? lineItemData[currentRow, 3]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            UnitPrice = unitPriceColumnIndex > 0
                ? lineItemData[currentRow, 4]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            Subtotal = subtotalColumnIndex > 0
                ? lineItemData[currentRow, 5]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TotalTaxAmount = totalTaxAmountColumnIndex > 0
                ? lineItemData[currentRow, 6]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            TotalExcludingTax = totalExcludingTaxColumnIndex > 0
                ? lineItemData[currentRow, 7]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountRate = discountRateColumnIndex > 0
                ? lineItemData[currentRow, 8]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountAmount = discountAmountColumnIndex > 0
                ? lineItemData[currentRow, 9]?.Value?.ToString() ?? string.Empty
                : string.Empty,
            
            DiscountDescription = discountDescriptionColumnIndex > 0
                ? lineItemData[currentRow, 10]?.Value?.ToString() ?? string.Empty
                : string.Empty
        };

        return lineItemDto;
    }
}