using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.IO;

namespace Aspose.Html.Examples
{
    public class MDtoXPSExample : BaseExample
    {
        public MDtoXPSExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-xps");
        }

        // Convert Markdown to XPS
        public void ConvertMarkdownToXps()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "[visit applications](https://products.aspose.app/html/applications)";

            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Prepare a path to save the converted XPS file
            string savePath = Path.Combine(OutputDir, "document-output.xps");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert the HTML document to XPS file format
            Converter.ConvertHTML(document, new XpsSaveOptions(), savePath);
        }

        // Convert Markdown to XPS with custom XpsSaveOptions
        public void ConvertMarkdownToXpsWithOptions()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Prepare a path to save the converted XPS file
            string savePath = Path.Combine(OutputDir, "nature-output.xps");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Initialize XpsSaveOptions with custom settings
            XpsSaveOptions options = new XpsSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(5.0f), Length.FromInches(10.0f)), new Margin(30, 20, 10, 10));

            // Convert the HTML document to XPS file format with options
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}