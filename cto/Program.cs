﻿using cto.ProgramClasses;
using cto.Versioning;

VersionUpdater.IncrementVersion();
MakeBanner.AppName();
if (!CheckFolders.StartCheckFolders())
{
    Console.WriteLine("Folder Check Failed .... Press any key to exit ....");
    Console.Read();
    Environment.Exit(0);
}

ReadInExcelFile.ReadExcelFile();