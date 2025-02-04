using System.Net;
using cto.SupportClasses;
using RestSharp;

namespace cto.ProgramClasses;

public class SendToTps
{
    public static bool SendToTpsFn(string jsonRequestString, string invoiceNumber, string fileName)
    {
        try
        {
            var settings = ReadSettings.ReadAppSettings().Item1;
            var (docType, clientName) = ApiJsonRequestHelperClass.GetClientNameAndDocType(fileName);
            if (settings == null)
            {
                Console.WriteLine("AppSettings is empty ...");
                Console.WriteLine("Press any key to exit ...");
                Console.Read();
                Environment.Exit(0);
            }
            
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
                Console.WriteLine($"Server Error: {response.StatusCode} - {response.Content}");
                return false;
            }
            Console.WriteLine($"{clientName}_{docType}_{invoiceNumber}.pdf uploaded successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}