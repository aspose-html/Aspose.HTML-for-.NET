using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class MDtoPDFExample : BaseExample
    {
        public MDtoPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-pdf");
        }

        // Convert Markdown to PDF
        public void ConvertMarkdownToPdf()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "[visit applications](https://products.aspose.app/html/applications)";

            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Prepare a path for converted PDF file saving
            string savePath = Path.Combine(OutputDir, "document-output.pdf");

            // Convert the HTML document to PDF file format
            Converter.ConvertHTML(document, new PdfSaveOptions(), savePath);
        }

        // Convert Markdown to PDF with custom PdfSaveOptions
        public void ConvertMarkdownToPdfWithOptions()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Initialize PdfSaveOptions with custom settings
            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 100
            };

            // Prepare a path for converted PDF file saving
            string savePath = Path.Combine(OutputDir, "nature-output.pdf");

            // Convert the HTML document to PDF file format
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}