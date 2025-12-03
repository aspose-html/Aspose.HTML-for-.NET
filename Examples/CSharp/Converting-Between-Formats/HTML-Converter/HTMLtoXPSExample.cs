using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class HTMLtoXPSExample : BaseExample
    {
        public HTMLtoXPSExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-xps");
        }

        // Convert HTML to XPS with a single line
        public void ConvertHtmlToXpsWithSingleLine()
        {
            // Convert HTML to XPS using C#
            Converter.ConvertHTML(@"<h1>Convert HTML to XPS!</h1>", ".", new XpsSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.xps"));
        }

        // Convert HTML to XPS from a file
        public void ConvertHtmlToXps()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "canvas.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "canvas-output.xps");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize XpsSaveOptions
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert HTML to XPS
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to XPS with custom options
        public void ConvertHtmlToXpsWithCustomOptions()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "canvas.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "canvas-output-options.xps");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize XpsSaveOptions with custom background color
            XpsSaveOptions options = new XpsSaveOptions
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(4.9f), Length.FromInches(3.5f)), new Margin(30, 20, 10, 10));

            // Convert HTML to XPS
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}