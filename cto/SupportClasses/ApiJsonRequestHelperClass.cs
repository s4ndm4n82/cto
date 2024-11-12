using System.Reflection;
using cto.Classes;
using cto.DTOs;
using cto.ProgramClasses;

namespace cto.SupportClasses;

public class ApiJsonRequestHelperClass
{
	private static readonly Dictionary<string, string> FieldNameMap = new()
	{
		{ "Invoice Number", "EInvoiceNumber" },
		{ "Invoice Currency Code", "CurrencyCode" },
		{ "Currency Exchange Rate", "CurrencyExchangeRate" },
		{ "Supplier Identification Number", "SupplierIDNo" },
		{ "Supplier TIN", "SupplierTIN" },
		{ "Supplier Name", "SupplierName" },
		{ "Supplier Address", "SupplierAddressAddressLine0" },
		{ "Supplier City Name", "SupplierAddressCityName" },
		{ "Supplier Country", "SupplierAddressCountryCode" },
		{ "Supplier Country Subentity Code", "SupplierAddressState" },
		{ "Supplier Contact Number", "SupplierContactNumber" },
		{ "Total Excluding Tax", "TotalExcludingTax" },
		{ "Total Tax Amount", "TotalTaxAmount" },
		{ "Total Including Tax", "TotalIncludingTax" },
		{ "Total Payable Amount", "TotalPayableAmount" },
		{ "Tax Type", "TaxType" }
	};

	private static readonly Dictionary<string, string> LineFieldNameMap = new()
	{
		{ "LI Description of Product or Service", "DescriptionProductService" },
		{ "LI Unit Price", "UnitPrice" },
		{ "LI Subtotal", "Subtotal" },
		{ "LI Total Tax Amount", "TotalTaxAmount" },
		{ "LI Total Excluding Tax", "TotalExcludingTax" },
		{ "LI Discount Rate", "DiscountRate" },
		{ "LI Discount Amount", "DiscountAmount" },
		{ "LI Discount Description", "DiscountDescription" }
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
				var propertyName = string.Empty;

				if (FieldNameMap.TryGetValue(field, out propertyName))
				{
					var property = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

					if (property == null)
					{
						break;
					}

					var value = property.GetValue(invoiceDtoData)?.ToString();

					if (string.IsNullOrEmpty(value))
					{
						break;
					}

					fieldsList.Add(new JsonStringClass.Fields { Name = field, Value = value });
				}
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
		var value = string.Empty;

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
					var propertyName = string.Empty;

					if (LineFieldNameMap.TryGetValue(lineField, out propertyName))
					{
						var property = lineItem.GetType().GetProperty(propertyName);

						if (property == null)
						{
							break;
						}

						value = property.GetValue(lineItem)?.ToString();
					}
					else
					{
						value = lineDefaultValue
						.Where(x => x.FieldName.Equals(lineField, StringComparison.OrdinalIgnoreCase))
						.Select(y => y.FieldValue)
						.FirstOrDefault();
					}

					if (string.IsNullOrEmpty(value))
					{
						break;
					}

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
