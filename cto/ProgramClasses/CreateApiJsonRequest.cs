using cto.DTOs;
using cto.SupportClasses;

namespace cto.ProgramClasses;

public class CreateApiJsonRequest
{
	public static bool MakeJsonRequest(InvoiceDto invoiceDtoData)
	{
		try
		{
			var fieldsList = ApiJsonRequestHelperClass.CreateFieldsList(invoiceDtoData);
			var lineFieldList =
			return true;
		}
		catch (Exception ex)

		{
			Console.WriteLine(ex.Message);
			return false;
		}
	}
}
