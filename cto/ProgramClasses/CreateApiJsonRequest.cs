using System.Xml;
using cto.Classes;
using cto.DTOs;
using cto.SupportClasses;
using Newtonsoft.Json;
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
            if (settings == null)
            {
                Console.WriteLine("AppSettings is empty ...");
                Console.WriteLine("Press any key to exit ...");
                Console.Read();
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
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}