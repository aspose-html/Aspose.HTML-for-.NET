using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class HTMLtoPDFExample : BaseExample
    {
        public HTMLtoPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-pdf");
        }

        // Convert HTML to PDF with a single line
        public void ConvertHtmlToPdfWithSingleLine()
        {
            // Convert HTML to PDF using C#
            Converter.ConvertHTML(@"<h1>Convert HTML to PDF!</h1>", ".", new PdfSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.pdf"));
        }

        // Convert HTML to PDF in one line of code
        public void ConvertHtmlToPdfInOneLine()
        {
            // Convert HTML to PDF using C#
            Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello, World!!</span>", ".", new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
        }

        // Convert HTML to PDF from a file
        public void ConvertHtmlToPdfFromFile()
        {
            // Convert HTML to PDF in C#
            string documentPath = Path.Combine(DataDir, "spring.html");
            string savePath = Path.Combine(OutputDir, "spring-output.pdf");
            using HTMLDocument document = new HTMLDocument(documentPath);
            PdfSaveOptions options = new PdfSaveOptions();
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML from URL to PDF
        public void ConvertHtmlFromUrlToPdf()
        {
            // Convert HTML from URL to PDF using C#
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");
            PdfSaveOptions options = new PdfSaveOptions();
            string savePath = Path.Combine(OutputDir, "document.pdf");
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PDF using encryption
        public void ConvertHtmlToPdfWithEncryption()
        {
            // Convert HTML to PDF in C# with password protection and custom permissions
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");
            PdfSaveOptions options = new PdfSaveOptions
            {
                Encryption = new PdfEncryptionInfo(
                    ownerPassword: "owner123",
                    userPassword: "user123",
                    permissions: PdfPermissions.PrintDocument | PdfPermissions.ExtractContent,
                    encryptionAlgorithm: PdfEncryptionAlgorithm.RC4_128)
            };
            string savePath = Path.Combine(OutputDir, "document-with-password.pdf");
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PDF with custom document information
        public void ConvertHtmlToPdfWithSaveOptions()
        {
            // Convert HTML to PDF with custom metadata using C#
            using (HTMLDocument document = new HTMLDocument("<h1>Hello, PDF!</h1>", "."))
            {
                PdfSaveOptions options = new PdfSaveOptions
                {
                    DocumentInfo = {
                        Title = "Sample PDF Title",
                        Author = "Aspose.HTML for .NET",
                        Subject = "HTML to PDF Example",
                        Keywords = "Aspose, HTML, PDF, conversion"
                    }
                };
                string outputPath = Path.Combine(OutputDir, "document.pdf");
                Converter.ConvertHTML(document, options, outputPath);
            }
        }

        // Convert HTML to PDF with custom page settings
        public void ConvertHtmlToPdfWithCustomPageSettings()
        {
            // Convert HTML to PDF in C# with custom page settings
            string documentPath = Path.Combine(DataDir, "drawing.html");
            string savePath = Path.Combine(OutputDir, "drawing-options.pdf");
            using HTMLDocument document = new HTMLDocument(documentPath);
            PdfSaveOptions options = new PdfSaveOptions
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 100
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 300), new Margin(20, 10, 10, 10));
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PDF with simple save options
        public void SpecifyPdfSaveOptions()
        {
            // Convert HTML to PDF with custom settings using C#
            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.pdf");
            string code = "<h1>  PdfSaveOptions Class</h1>\r\n" +
                "<p>Using PdfSaveOptions Class, you can programmatically apply a wide range of conversion parameters such as BackgroundColor, HorizontalResolution, VerticalResolution, PageSetup, etc.</p>\r\n";
            File.WriteAllText(documentPath, code);
            using HTMLDocument document = new HTMLDocument(documentPath);
            PdfSaveOptions options = new PdfSaveOptions
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(4.9f), Length.FromInches(3.5f)), new Margin(30, 20, 10, 10));
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PDF using a custom memory‑stream provider
        public void ConvertHtmlToPdfWithCustomStreamProvider()
        {
            // Convert HTML to PDF in C# using memory stream
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to PDF File Format!</h1>", ".");
            Converter.ConvertHTML(document, new PdfSaveOptions(), streamProvider);
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.pdf")))
            {
                memory.CopyTo(fs);
            }
        }

        // Custom memory‑stream provider implementation
        private class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream) { }

            public void Dispose()
            {
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
    }
}