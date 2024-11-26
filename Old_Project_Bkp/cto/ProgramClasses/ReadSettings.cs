using cto.Classes;
using Microsoft.Extensions.Configuration;

namespace cto.ProgramClasses;

public class ReadSettings
{
	private static readonly string configFilePath = Path
	.Combine(
		Directory.GetCurrentDirectory(), "ConfigFiles"
		);

	public static AppSettingsClass ReadAppSettings()
	{
		try
		{
			var configBuilder = ReadConfigs("appsettings.json").Get<AppSettingsClass>();

			return configBuilder ??
			throw new InvalidOperationException("AppSettings not found in configuration");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
	private static IConfigurationRoot ReadConfigs(string configFileName)
	{
		try
		{
			var configBuilder = new ConfigurationBuilder()
			.SetBasePath(configFilePath)
			.AddJsonFile(configFileName)
			.Build();

			return configBuilder;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}
}