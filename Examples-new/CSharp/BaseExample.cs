using System;
using System.IO;
using System.Reflection;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Base helper class for examples. Provides clear path handling for data, output and URL folders
    /// </summary>
    public class BaseExample
    {
        // Fields – resolved once at startup (based on the executable location)
        private readonly string dataDir;
        private readonly string outDir;
        private readonly string outUrl;
        private readonly string svgNS = "http://www.w3.org/2000/svg";

        private string exampleDir = string.Empty;

        // Constructor – runs once when the class is instantiated
        public BaseExample()
        {
            // Executable location: ...\Examples-new\CSharp\bin\Debug\net48\Aspose.Html.Examples.exe
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // Go up four levels to reach the Examples‑new folder (project root for examples)
            var baseDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", "..", ".."));
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
        protected void SetOutputDir(string dir = "")
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
        public string DataDir => dataDir;

        /// <summary>
        /// Absolute path to the output directory (including any example sub‑folder)
        /// </summary>
        public string OutputDir => Path.Combine(outDir, exampleDir);

        /// <summary>
        /// Absolute URL path to the output directory (including any example sub‑folder)
        /// </summary>
        public string OutputUrl => Path.Combine(outUrl, exampleDir);

        /// <summary>
        /// SVG namespace used by the examples
        /// </summary>
        public string SvgNamespace => svgNS;
    }
}