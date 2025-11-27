using System;
using System.IO;
using System.Reflection;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Base helper class. Provides clear path handling for data, output and URL folders
    /// </summary>
    public static class BaseExample
    {
        // Fields – resolved once at startup (based on the executable location)
        private static readonly string dataDir;
        private static readonly string outDir;
        private static readonly string outUrl;
        private static readonly string svgNS = "http://www.w3.org/2000/svg";

        private static string exampleDir = string.Empty;

        // Static constructor – runs once when the class is first used
        static BaseExample()
        {
            // Executable location: ...\Examples-new\CSharp\bin\Debug\net48\Aspose.Html.Examples.exe
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Go up three levels to reach the Examples-new\CSharp folder (project root for examples)
            var baseDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
            dataDir = Path.Combine(baseDir, "data");
            outDir = Path.Combine(baseDir, "output");
            outUrl = Path.Combine(baseDir, "output");

            // Ensure the base output folder exists
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }
        }

        /// <summary>
        /// Sets the sub‑directory for the current example
        /// </summary>
        /// <param name="dir">Optional sub‑folder name.</param>
        public static void SetOutputDir(string dir = "")
        {
            exampleDir = dir;

            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            var full = OutputDir;
            if (!Directory.Exists(full))
            {
                Directory.CreateDirectory(full);
            }
        }

        /// <summary>
        /// Absolute path to the data directory
        /// </summary>
        public static string DataDir => dataDir;

        /// <summary>
        /// Absolute path to the output directory (including any example sub‑folder)
        /// </summary>
        public static string OutputDir => Path.Combine(outDir, exampleDir);

        /// <summary>
        /// Absolute URL path to the output directory (including any example sub‑folder)
        /// </summary>
        public static string OutputUrl => Path.Combine(outUrl, exampleDir);

        /// <summary>
        /// SVG namespace used by the examples
        /// </summary>
        public static string SvgNamespace => svgNS;

        // Backward‑compatible helpers
        public static string GetDataDir() => DataDir;
        public static string GetOutputDir() => OutputDir;
        public static string GetOutputUrl() => OutputUrl;
    }
}