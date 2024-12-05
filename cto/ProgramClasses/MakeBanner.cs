using System.Reflection;

namespace cto.ProgramClasses;

public class MakeBanner
{
    public static void AppName()
    {
        var assembly = Assembly.GetExecutingAssembly().GetName();
        var appVersion = assembly.Version;
        var appName = assembly.Name;

        if (appName != null)
        {
            var padding = (Console.WindowWidth - appName.Length) / 2;
            var title = new string(' ', padding) + appName + " v" + appVersion;

            HorizontalLine();
            Console.WriteLine(title);
        }

        HorizontalLine();
    }

    private static void HorizontalLine()
    {
        const char ch = '-';

        while (true)
        {
            for (var x = 0; x < Console.WindowWidth; x++)
            {
                Console.Write(ch);
            }

            Console.WriteLine();

            break;
        }
    }
}