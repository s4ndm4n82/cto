using System.Reflection;
using cto.Classes;
using cto.DTOs;
using cto.MagicWordClasses.InvoiceLevel;
using cto.MagicWordClasses.LineItemLevel;
using cto.MagicWordClasses.TpsFields;
using cto.ProgramClasses;

namespace cto.SupportClasses;

public class ApiJsonRequestHelperClass
{
	private static readonly Dictionary<string, string> FieldNameMap = new()
	{
		{ TpsFieldsList.InvoiceNumber, HeaderNames.EInvoiceNumber },
		{ TpsFieldsList.InvoiceCurrencyCode, HeaderNames.CurrencyCode },
		{ TpsFieldsList.CurrencyExchangeRate, HeaderNames.CurrencyExchangeRate },
		{ TpsFieldsList.KFormType, HeaderNames.KFormType},
		{ TpsFieldsList.KFormNumber, HeaderNames.KFormNumber },
		{ TpsFieldsList.SupplierMsicCode, HeaderNames.SupplierMsic },
		{ TpsFieldsList.SupplierIdentificationNumber, HeaderNames.SupplierIdNo },
		{ TpsFieldsList.SupplierTin, HeaderNames.SupplierTin },
		{ TpsFieldsList.SupplierName, HeaderNames.SupplierName },
		{ TpsFieldsList.SupplierAddress, HeaderNames.SupplierAddress },
		{ TpsFieldsList.SupplierCityName, HeaderNames.SupplierCity },
		{ TpsFieldsList.SupplierCountry, HeaderNames.SupplierCountry },
		{ TpsFieldsList.SupplierCountrySubentityCode, HeaderNames.SupplierState },
		{ TpsFieldsList.SupplierContactNumber, HeaderNames.SupplierContactNumber },
		{ TpsFieldsList.BuyerName, HeaderNames.BuyerName },
		{ TpsFieldsList.BuyerRegistration, HeaderNames.BuyerIdNo },
		{ TpsFieldsList.BuyerTin, HeaderNames.BuyerTin },
		{ TpsFieldsList.BuyerAddress, HeaderNames.BuyerAddress },
		{ TpsFieldsList.BuyerSstNumber, HeaderNames.BuyerSst },
		{ TpsFieldsList.BuyerContactNumber, HeaderNames.BuyerContactNumber },
		{ TpsFieldsList.BuyerCityName, HeaderNames.BuyerCity},
		{ TpsFieldsList.BuyerState, HeaderNames.BuyerState },
		{ TpsFieldsList.BuyerCountry, HeaderNames.BuyerCountry },
		{ TpsFieldsList.MainTaxRate, HeaderNames.TaxRate },
		{ TpsFieldsList.MainTaxType, HeaderNames.TaxType },
		{ TpsFieldsList.TotalExcludingTax, HeaderNames.TotalExcludingTax },
		{ TpsFieldsList.TotalTaxAmount, HeaderNames.TotalTaxAmount },
		{ TpsFieldsList.TotalIncludingTax, HeaderNames.TotalIncludingTax },
		{ TpsFieldsList.TotalPayableAmount, HeaderNames.TotalPayableAmount },
		{ TpsFieldsList.OriginalInvoiceNumber, HeaderNames.OriginalInvoiceNumber },
		{ TpsFieldsList.InvoiceReferenceNumber, HeaderNames.OriginalInvoiceUin}
	};

	private static readonly Dictionary<string, string> LineFieldNameMap = new()
	{
		{ TpsFieldsList.LiClassification, HeaderNames.Classification },
		{ TpsFieldsList.LiDescriptionOfProductOrService, LineHeaderNames.LiDescription },
		{ TpsFieldsList.LiUnitPrice, LineHeaderNames.LiUnitPrice },
		{ TpsFieldsList.LiSubtotal, LineHeaderNames.LiSubtotal },
		{ TpsFieldsList.LiTaxRate, LineHeaderNames.LiTaxRate },
		{ TpsFieldsList.LiTaxType, LineHeaderNames.LiTaxType },
		{ TpsFieldsList.LiTaxAmount, LineHeaderNames.LiTotalTaxAmount },
		{ TpsFieldsList.LiTotalExcludingTax, LineHeaderNames.LiTotalExcludingTax },
		{ TpsFieldsList.LiDiscountRate, LineHeaderNames.LiDiscountRate },
		{ TpsFieldsList.LiDiscountAmount, LineHeaderNames.LiDiscountAmount },
		{ TpsFieldsList.LiDiscountDescription, LineHeaderNames.LiDiscountDescription },
	};

	public static List<JsonStringClass.Fields> CreateFieldsList(InvoiceDto invoiceDtoData)
	{
		var settings = ReadSettings.ReadAppSettings();
		var fields = settings.AppConfigs.FieldSettings.MainFieldsList;

		var fieldsList = new List<JsonStringClass.Fields>();
		var invoiceDtoType = invoiceDtoData.GetType();
		var properties = invoiceDtoType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

		try
		{
			foreach (var field in fields)
			{
				if (!FieldNameMap.TryGetValue(field, out var propertyName)) continue;
				var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

				if (property == null) continue;

				var value = property.GetValue(invoiceDtoData)?.ToString();

				if (string.IsNullOrEmpty(value)) continue;

				fieldsList.Add(new JsonStringClass.Fields { Name = field, Value = value });
			}

			return fieldsList;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	public static List<JsonStringClass.Tables> CreateLineFieldsList(InvoiceDto invoiceDtoData)
	{
		var settings = ReadSettings.ReadAppSettings();
		var lineFields = settings.AppConfigs.FieldSettings.LineItemsFieldsList;
		var lineDefaultValue = settings.AppConfigs.FieldSettings.LineDefaultValues;
		var tables = new List<JsonStringClass.Tables>();
		var table = new JsonStringClass.Tables();

		try
		{
			foreach (var lineItem in invoiceDtoData.LineItems)
			{
				var row = new JsonStringClass.Rows
				{
					Fields = []
				};

				foreach (var lineField in lineFields)
				{
					string? value;
					
					if (LineFieldNameMap.TryGetValue(lineField, out var propertyName))
					{
						var property = lineItem.GetType().GetProperty(propertyName);

						if (property == null) continue;
						
						value = property.GetValue(lineItem)?.ToString();
					}
					else
					{
						value = lineDefaultValue
						.Where(x => x.FieldName.Equals(lineField, StringComparison.OrdinalIgnoreCase))
						.Select(y => y.FieldValue)
						.FirstOrDefault();
					}

					if (string.IsNullOrEmpty(value)) break;

					row.Fields.Add(new JsonStringClass.LineFields { Name = lineField, Value = value });
				}
				table.Rows.Add(row);
			}
			tables.Add(table);

			return tables;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	public static List<JsonStringClass.Files> CreateFilesList(InvoiceDto invoiceDtoData)
	{
		var settings = ReadSettings.ReadAppSettings();
		var base64 = settings.AppConfigs.FileSettings.DummyBase64;
		var number = invoiceDtoData.EInvoiceNumber;
		try
		{
			var fileName = $"DummyInvoice_{number}.pdf";
			var files = new List<JsonStringClass.Files>();
			{
				files.Add(new JsonStringClass.Files() { Name = fileName, Data = base64 });
			}

			return files;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
