using System.Net;
using cto.SupportClasses;
using RestSharp;
using Serilog;

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
                Log.Error("AppSettings is empty ....");
                Environment.Exit(0);
            }
            
            Log.Information($"Sending {clientName}_{docType}_{invoiceNumber}.pdf to TPS ....");
            
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
                Log.Error($"Server Error: {response.StatusCode} - {response.Content} ....");
                return false;
            }
            Log.Information($"{clientName}_{docType}_{invoiceNumber}.pdf uploaded successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error sending to TPS ....");
            throw;
        }
    }
}