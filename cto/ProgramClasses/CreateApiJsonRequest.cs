using System.Xml;
using cto.Classes;
using cto.DTOs;
using cto.SupportClasses;
using Newtonsoft.Json;
using Serilog;
using Formatting = Newtonsoft.Json.Formatting;

namespace cto.ProgramClasses;

public class CreateApiJsonRequest
{
    public static bool MakeJsonRequest(InvoiceDto invoiceDtoData)
    {
        var settings = ReadSettings.ReadAppSettings().Item1;
        var fileList = ApiJsonRequestHelperClass.CreateFilesList(invoiceDtoData);
        var fieldsList = ApiJsonRequestHelperClass.CreateFieldsList(invoiceDtoData);
        var lineFieldList = ApiJsonRequestHelperClass.CreateLineFieldsList(invoiceDtoData);
        try
        {
            Log.Information("Creating the Json Request ....");
            
            if (settings == null)
            {
                Log.Error("AppSettings is empty ....");
                Environment.Exit(0);
            }
            
            JsonStringClass.JsonClassRoot jsonRequest = new()
            {
                
                Token = settings.AppConfigs.ProjectSettings.ImportToken,
                UserName = settings.AppConfigs.ProjectSettings.ImportUser,
                ProjectId = settings.AppConfigs.ProjectSettings.ImportProjectId,
                Queue = settings.AppConfigs.ProjectSettings.ImportQueue,
                TemplateKey = settings.AppConfigs.ProjectSettings.ImportTemplateKey,
                Fields = fieldsList,
                Tables = lineFieldList,
                Files = fileList
            };

            var jsonRequestString = JsonConvert.SerializeObject(jsonRequest, Formatting.Indented);

            return SendToTps.SendToTpsFn(jsonRequestString, invoiceDtoData.EInvoiceNumber, invoiceDtoData.FileName);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error creating the Json Request ....");
            return false;
        }
    }
}