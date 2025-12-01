using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.IO;
using Aspose.Html.Drawing;

namespace Aspose.Html.Examples
{
    public class MDtoJPGExample : BaseExample
    {
        public MDtoJPGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-jpg");
        }

        // Convert Markdown to JPG
        public void ConvertMarkdownToJpg()
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

            // Prepare a path for the converted JPG file
            string savePath = Path.Combine(OutputDir, "document-output.jpg");

            // Convert the HTML document to JPG image format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), savePath);
        }

        // Convert Markdown to JPG with custom ImageSaveOptions
        public void ConvertMarkdownToJpgWithOptions()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 950), new Margin(30, 20, 10, 10));

            // Prepare a path for the converted JPG file
            string savePath = Path.Combine(OutputDir, "nature-options.jpg");

            // Convert the HTML document to JPG image format
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}