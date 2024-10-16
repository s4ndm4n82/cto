using cto.ProgramClasses;
using cto.SupportClasses;

var exHandler = new ExceptionHandler();
exHandler.GlobalExceptionHandler();

VersionIncrementer.IncrementVersion();
MakeBanner.AppName();
if (!CheckFolders.StartCheckFolders())
{
	Console.WriteLine("Folder Check Failed .... Press any key to exit ....");
	Console.Read();
	Environment.Exit(0);
}

MergeCsv.StartMergeCsv();
