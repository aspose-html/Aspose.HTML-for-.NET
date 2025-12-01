using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using ImageFormat = Aspose.Html.Rendering.Image.ImageFormat;

namespace Aspose.Html.Examples
{
    public class MDtoTIFFExample : BaseExample
    {
        public MDtoTIFFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-tiff");
        }

        // Convert Markdown to TIFF
        public void ConvertMarkdownToTiff()
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

            // Prepare a path for the converted TIFF file
            string savePath = Path.Combine(OutputDir, "document-output.tiff");

            // Convert the HTML document to TIFF image format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Tiff), savePath);
        }
    }
}