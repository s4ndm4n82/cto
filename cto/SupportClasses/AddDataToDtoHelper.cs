using cto.MagicWordClasses.InvoiceLevel;
using cto.MagicWordClasses.LineItemLevel;

namespace cto.SupportClasses;

public class AddDataToDtoHelper
{
    public static Dictionary<string, int> GetInvoiceColumnIndexes(Dictionary<string, int> columnIndex)
    {
        try
        {
            return new Dictionary<string, int>
            {
                { HeaderNames.LineId, columnIndex.GetValueOrDefault(ExcelHeaderNames.LineId, 0) },
                { HeaderNames.EInvoiceNumber, columnIndex.GetValueOrDefault(ExcelHeaderNames.EInvoiceNumber, 0) },
                { HeaderNames.Classification, columnIndex.GetValueOrDefault(ExcelHeaderNames.Classification, 0) },
                { HeaderNames.CurrencyCode, columnIndex.GetValueOrDefault(ExcelHeaderNames.CurrencyCode, 0) },
                {
                    HeaderNames.CurrencyExchangeRate,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.CurrencyExchangeRate, 0)
                },
                { HeaderNames.KFormType, columnIndex.GetValueOrDefault(ExcelHeaderNames.KFormType, 0) },
                { HeaderNames.KFormNumber, columnIndex.GetValueOrDefault(ExcelHeaderNames.KFormNumber, 0) },
                { HeaderNames.BuyerName, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerName, 0) },
                { HeaderNames.BuyerTin, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerTin, 0) },
                { HeaderNames.BuyerIdType, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerIdType, 0) },
                { HeaderNames.BuyerIdNo, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerIdNo, 0) },
                { HeaderNames.BuyerAddress, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerAddress, 0) },
                { HeaderNames.BuyerCity, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerCity, 0) },
                { HeaderNames.BuyerState, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerState, 0) },
                { HeaderNames.BuyerCountry, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerCountry, 0) },
                { HeaderNames.BuyerSst, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerSst, 0) },
                { HeaderNames.BuyerMsic, columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerMisc, 0) },
                {
                    HeaderNames.BuyerBusinessActivityDescription,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerBusinessActivityDescription, 0)
                },
                {
                    HeaderNames.BuyerContactNumber,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.BuyerContactNumber, 0)
                },
                { HeaderNames.SupplierName, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierName, 0) },
                { HeaderNames.SupplierTin, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierTin, 0) },
                { HeaderNames.SupplierIdType, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierIdType, 0) },
                { HeaderNames.SupplierIdNo, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierIdNo, 0) },
                { HeaderNames.SupplierAddress, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierAddress, 0) },
                { HeaderNames.SupplierCity, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierCity, 0) },
                { HeaderNames.SupplierState, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierState, 0) },
                { HeaderNames.SupplierCountry, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierCountry, 0) },
                { HeaderNames.SupplierSst, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierSst, 0) },
                { HeaderNames.SupplierMsic, columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierMisc, 0) },
                {
                    HeaderNames.SupplierBusinessActivityDescription,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierBusinessActivityDescription, 0)
                },
                {
                    HeaderNames.SupplierContactNumber,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.SupplierContactNumber, 0)
                },
                { HeaderNames.TaxRate, columnIndex.GetValueOrDefault(ExcelHeaderNames.TaxRate, 0) },
                { HeaderNames.TaxType, columnIndex.GetValueOrDefault(ExcelHeaderNames.TaxType, 0) },
                { HeaderNames.TotalExcludingTax, columnIndex.GetValueOrDefault(ExcelHeaderNames.TotalExcludingTax, 0) },
                { HeaderNames.TotalIncludingTax, columnIndex.GetValueOrDefault(ExcelHeaderNames.TotalIncludingTax, 0) },
                {
                    HeaderNames.TotalPayableAmount,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.TotalPayableAmount, 0)
                },
                { HeaderNames.TotalTaxAmount, columnIndex.GetValueOrDefault(ExcelHeaderNames.TotalTaxAmount, 0) },
                {
                    HeaderNames.OriginalInvoiceNumber,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.OriginalInvoiceNumber, 0)
                },
                {
                    HeaderNames.OriginalInvoiceUin,
                    columnIndex.GetValueOrDefault(ExcelHeaderNames.OriginalInvoiceUin, 0)
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public static Dictionary<string, int> GetLineColumnIndexes(Dictionary<string, int> columnIndex)
    {
        try
        {
            return new Dictionary<string, int>
            {
                
                {
                    LineHeaderNames.LiDescription,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.DescriptionProductService, 0)
                },
                { 
                    LineHeaderNames.LiUnitPrice,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.UnitPrice, 0)
                },
                {
                    LineHeaderNames.LiSubtotal,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.Subtotal, 0)
                },
                {
                    LineHeaderNames.LiTaxRate,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.TaxRate, 0)
                },
                {
                    LineHeaderNames.LiTaxType,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.TaxType, 0)
                },
                {
                    LineHeaderNames.LiTotalTaxAmount,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.TotalTaxAmount, 0)
                },
                {
                    LineHeaderNames.LiTotalExcludingTax,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.TotalExcludingTax, 0)
                },
                {
                    LineHeaderNames.LiDiscountRate,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.DiscountRate, 0)
                },
                {
                    LineHeaderNames.LiDiscountAmount,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.DiscountAmount, 0)
                },
                {
                    LineHeaderNames.LiDiscountDescription,
                    columnIndex.GetValueOrDefault(ExcelLineHeaderNames.DiscountDescription, 0)
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}