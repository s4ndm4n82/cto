using System.Globalization;
using CsvHelper;
using cto.DTOs;

namespace cto.SupportClasses;

public class ReadCsvFileData
{
	public static List<InvoiceDto> ReadInvoiceCsvFileData(string fileName)
	{
		using var reader = new StreamReader(fileName);
		using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		return csv.GetRecords<InvoiceDto>().ToList();
	}

	public static Dictionary<string, LineItemsDto> ReadLineItemsCsvFileData(string fileName)
	{
		using var reader = new StreamReader(fileName);
		using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		return csv.GetRecords<LineItemsDto>().ToDictionary(x => x.EInvoiceNumber);
	}
}
