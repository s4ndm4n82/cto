using System;
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

	public static List<JsonStringClass.LineFields> CreateLineFieldsList(InvoiceDto invoiceDtoData)
	{
		var settings = ReadSettings.ReadAppSettings();
		var lineFields = settings.AppConfigs.FieldSettings.LineItemsFieldsList;
	}
}
