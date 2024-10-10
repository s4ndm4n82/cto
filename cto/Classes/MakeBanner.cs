using Microsoft.VisualBasic;

namespace cto.Classes;

public class MakeBanner
{
	public static void AppName()
	{
		var appName = "Csv To One";
		var padding = (Console.WindowWidth - appName.Length) / 2;
		var title = new string(' ', padding) + appName + new string(' ', padding);

		HorizontalLine();
		Console.WriteLine(title);
		HorizontalLine();
	}

	public static void HorizontalLine()
	{
		const char ch = '-';

		while (true)
		{
			for (int x = 0; x < Console.WindowWidth; x++)
			{
				Console.Write(ch);
			}

			Console.WriteLine();

			break;
		}
	}
}