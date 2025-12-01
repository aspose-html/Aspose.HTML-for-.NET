using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using ImageFormat = Aspose.Html.Rendering.Image.ImageFormat;

namespace Aspose.Html.Examples
{
    public class MDtoGIFExample : BaseExample
    {
        public MDtoGIFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-gif");
        }

        // Convert Markdown to GIF
        public void ConvertMarkdownToGif()
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

            // Prepare a path for the converted GIF file
            string savePath = Path.Combine(OutputDir, "document-output.gif");
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert the HTML document to GIF image format
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}