using System.Net;
using RestSharp;

namespace cto.ProgramClasses;

public class SendToTps
{
	public static bool SendToTpsFn(string jsonRequestString, string invoiceNumber)
	{
		try
		{
			var settings = ReadSettings.ReadAppSettings();
			var apiUrl = settings.AppConfigs.UploadSettings.UploadDomain;
			var lastIndex = apiUrl.LastIndexOf('/');
			var baseUri = apiUrl[..lastIndex];
			var query = apiUrl[(lastIndex + 1)..];

			var client = new RestClient(baseUri);
			var request = new RestRequest(query)
			{
				Method = Method.Post,
				RequestFormat = DataFormat.Json
			};
			request.AddBody(jsonRequestString);
			var response = client.Execute(request);

			if (response.StatusCode != HttpStatusCode.OK)
			{
				return false;
			}
			Console.WriteLine($"{invoiceNumber}.pdf uploaded successfully.");
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
