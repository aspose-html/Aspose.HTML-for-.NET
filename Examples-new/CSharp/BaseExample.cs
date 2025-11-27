using System;
using System.IO;
using System.Reflection;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Provides common helper methods for example projects
    /// </summary>
    public static class BaseExample
    {
        /// <summary>
        /// Returns the path to the output directory (Examples-new/CSharp/output)
        /// </summary>
        public static string GetOutputDir()
        {
            // Executable path: ...\Examples-new\CSharp\bin\Debug\net48\Aspose.Html.Examples.exe
            // Go up three levels to reach the Examples-new\CSharp folder, then append "output"
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", "..", "output"));
            return outputDir;
        }

        /// <summary>
        /// Returns the path to the data directory (Examples-new/CSharp/data)
        /// </summary>
        public static string GetDataDir()
        {
            // Executable path: ...\Examples-new\CSharp\bin\Debug\net48\Aspose.Html.Examples.exe
            // Go up three levels to reach the Examples-new\CSharp folder, then append "data"
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dataDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", "..", "data"));
            return dataDir;
        }
    }
}