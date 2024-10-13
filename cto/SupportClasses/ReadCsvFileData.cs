using System.Globalization;
using CsvHelper;
using cto.DTOs;

namespace cto.SupportClasses;

public class ReadCsvFileData
{
	public static Dictionary<string, InvoiceDto> ReadInvoiceCsvFileData(string fileName)
	{
		using var reader = new StreamReader(fileName);
		using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		return csv.GetRecords<InvoiceDto>().ToDictionary(x => x.EInvoiceNumber);
	}

	public static List<LineItemsDto> ReadLineItemsCsvFileData(string fileName)
	{
		using var reader = new StreamReader(fileName);
		using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
		return csv.GetRecords<LineItemsDto>().ToList();
	}
}
