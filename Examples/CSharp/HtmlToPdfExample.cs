using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples
{
    public class HtmlToPdfExample : BaseExample
    {
        public HtmlToPdfExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-to-pdf");
        }

        /// <summary>
        /// Convert a simple HTML string to a PDF file
        /// </summary>
        public void ConvertHtmlStringToPdf()
        {
            string outputPath = Path.Combine(OutputDir, "simple-html.pdf");
            // Single-line HTML to PDF conversion
            Converter.ConvertHTML("<h1>Hello, PDF!</h1>", ".", new PdfSaveOptions(), outputPath);
            Console.WriteLine($"PDF created: {outputPath}");
        }

        /// <summary>
        /// Convert an HTML document from a file to PDF
        /// </summary>
        public void ConvertHtmlFileToPdf()
        {
            string htmlPath = Path.Combine(DataDir, "sample.html");
            File.WriteAllText(htmlPath, "<p>Sample HTML content</p>");
            string pdfPath = Path.Combine(OutputDir, "sample.pdf");
            using (HTMLDocument doc = new HTMLDocument(htmlPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertHTML(doc, options, pdfPath);
            }
            Console.WriteLine($"PDF from HTML file created: {pdfPath}");
        }
    }
}