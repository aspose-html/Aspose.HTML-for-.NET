using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class MDtoPNGExample : BaseExample
    {
        public MDtoPNGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-png");
        }

        // Convert Markdown to PNG
        public void ConvertMarkdownToPng()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "[visit applications](https://products.aspose.app/html/family)";

            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Prepare a path for the converted PNG file
            string savePath = Path.Combine(OutputDir, "document-output.png");

            // Convert the HTML document to PNG image format
            Converter.ConvertHTML(document, new ImageSaveOptions(), savePath);
        }
    }
}