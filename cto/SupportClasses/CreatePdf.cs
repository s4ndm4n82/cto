using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.Layout.Properties;

namespace cto.SupportClasses;

internal class CreatePdf
{
    public static string CreatDummyPdfFile(string clientName, string docType)
    {
        try
        {
            // Create a watermark text
            var watermarkText = $"{clientName} {docType}";
        
            // Create a new PDF document
            using var memoryStream = new MemoryStream();
            var writer = new PdfWriter(memoryStream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
        
            // Adding a watermark to the PDF
            AddWatermark(pdf, watermarkText);
            document.Close();
        
            // Convert the PDF to a base64 string
            var pdfBytes = memoryStream.ToArray();
            return Convert.ToBase64String(pdfBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    
    private static void AddWatermark(PdfDocument pdf, string watermarkText)
    {
        try
        {
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            var pdfCanvas = new Canvas(pdf.AddNewPage(), pdf.GetDefaultPageSize());
            pdfCanvas.SetFont(font);
            pdfCanvas.SetFontSize(100);
            pdfCanvas.SetFontColor(ColorConstants.LIGHT_GRAY);
            pdfCanvas.ShowTextAligned(watermarkText,
                pdf.GetDefaultPageSize().GetWidth() / 2,
                pdf.GetDefaultPageSize().GetHeight() / 2,
                TextAlignment.CENTER,
                VerticalAlignment.MIDDLE,
                45);
            pdfCanvas.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}