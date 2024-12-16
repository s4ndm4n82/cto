namespace cto.Versioning;

public class VersionUpdater
{
    public static void IncrementVersion()
	{
		const int AssemblyVersionIndex = 27;
		const int AssemblyVersionLength = 29;
		const int BuildNumberIndex = 3;
		const int RevisionNumberIndex = 2;
		const int MinorNumberIndex = 1;
		const int MajorNumberIndex = 0;

		try
		{
			// Gets the working directory.
			var appRootDirectory = Directory.GetCurrentDirectory().Split("\\bin")[0];
			var assemblyInfoFilePath = Path.Combine(appRootDirectory, "Versioning", "AssemblyInfo.cs");
			
			if (!File.Exists(assemblyInfoFilePath)) return;

			var lines = File.ReadAllLines(assemblyInfoFilePath);
			for (var i = 0; i < lines.Length; i++)
			{
				if (!lines[i].StartsWith("[assembly: AssemblyVersion(")) continue;
				var version = lines[i]
					.Substring(AssemblyVersionIndex, lines[i].Length - AssemblyVersionLength)
					.Trim('"');
				var versionParts = ParseVersion(version);

				var buildNumber = versionParts[BuildNumberIndex] + 1;
				var revisionNumber = versionParts[RevisionNumberIndex];
				var minorNumber = versionParts[MinorNumberIndex];
				var majorNumber = versionParts[MajorNumberIndex];

				// Increments the revision number.
				if (buildNumber >= 1000)
				{
					revisionNumber++;
					buildNumber = 0;
				}

				// Increments the minor number.
				if (revisionNumber >= 100)
				{
					minorNumber++;
					revisionNumber = 0;
					buildNumber = 0;
				}

				// Increments the major number.
				if (minorNumber >= 10)
				{
					majorNumber++;
					minorNumber = 0;
					revisionNumber = 0;
					buildNumber = 0;
				}

				var versionNumber = $"{majorNumber}.{minorNumber}.{revisionNumber}.{buildNumber}";

				lines[i] = $"[assembly: AssemblyVersion(\"{versionNumber}\")]";
				lines[i + 1] = $"[assembly: AssemblyFileVersion(\"{versionNumber}\")]";
				lines[i + 2] = $"[assembly: AssemblyInformationalVersion(\"{versionNumber}\")]";

				break;
			}
			File.WriteAllLines(assemblyInfoFilePath, lines);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	private static int[] ParseVersion(string version)
	{
		return version.Split('.').Select(int.Parse).ToArray();
	}
}