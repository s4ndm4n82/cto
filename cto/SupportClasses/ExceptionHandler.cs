namespace cto.SupportClasses;

public class ExceptionHandler
{
	public void GlobalExceptionHandler()
	{
		AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
	}

	private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		var ex = (Exception)e.ExceptionObject;
		Console.WriteLine($"Unhandled Exception Caught: {ex.Message}");
		Console.WriteLine($"Stack Trace: {ex.StackTrace}");
		Console.WriteLine("Press any key to exit ....");
		Console.Read();
	}
}
