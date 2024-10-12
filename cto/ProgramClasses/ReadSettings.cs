using cto.DTOs;
using Microsoft.Extensions.Configuration;

namespace cto.ProgramClasses;

public class ReadSettings
{
	public static AppSettingsClass ReadAppSettings()
	{
		var configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ConfigFiles");

		try
		{
			var configBuilder = new ConfigurationBuilder()
				.SetBasePath(configFilePath)
				.AddJsonFile("appsettings.json")
				.Build();

			var config = configBuilder.Get<AppSettingsClass>();

			return config ?? throw new InvalidOperationException("AppSettings not found in configuration");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}
