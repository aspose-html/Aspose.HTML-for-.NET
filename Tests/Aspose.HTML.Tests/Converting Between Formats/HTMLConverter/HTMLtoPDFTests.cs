using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.HTMLConverter
{
    public class HTMLtoPDFTests : TestsBase
    {
        public HTMLtoPDFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-pdf");
        }


        [Fact(DisplayName = "Convert HTML to PDF With a Single Line")]
        public void ConvertHTMLtoPDFWithASingleLineTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfInOneLine.cs
            // Convert HTML to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Invoke the ConvertHTML() method to convert HTML to PDF
            Converter.ConvertHTML(@"<h1>Convert HTML to PDF!</h1>", ".", new PdfSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.pdf"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.pdf")));
        }


        [Fact(DisplayName = "Convert HTML to PDF In One Line")]
        public void ConvertHTMLtoPdfInOneLineTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfInOneLineOfCode.cs
            // Convert HTML to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/
            
            Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello, World!!</span>", ".", new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");

            // @END_SNIPPET
            Assert.True(File.Exists("output.pdf"));
        }


        [Fact(DisplayName = "Convert HTML to PDF")]
        public void ConvertHTMLtoPDFTest()
        {
            // @START_SNIPPET ConvertHtmlToPdf.cs
            // Convert HTML to PDF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "spring-output.pdf");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize PdfSaveOptions
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "spring-output.pdf")));
        }


        [Fact(DisplayName = "Convert HTML From URL to PDF")]
        public void ConvertHtmlFromUrlToPdfTest()
        {
            // @START_SNIPPET ConvertHtmlFromUrlToPdf.cs
            // Convert HTML from URL to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");

            // Initialize PdfSaveOptions
            PdfSaveOptions options = new PdfSaveOptions();

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "document.pdf");

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "document.pdf")));
        }


        [Fact(DisplayName = "Convert HTML to PDF Using Encryption Property")]
        public void ConvertHtmlToPdfWithEncryptionTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfUsingEncryptionPropery.cs
            // Convert HTML to PDF in C# with password protection and custom permissions
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");

            // Initialize PdfSaveOptions 
            PdfSaveOptions options = new PdfSaveOptions();

            // Configure PDF encryption settings
            options.Encryption = new PdfEncryptionInfo(
                ownerPassword: "owner123",
                userPassword: "user123",
                permissions: PdfPermissions.PrintDocument | PdfPermissions.ExtractContent,
                encryptionAlgorithm: PdfEncryptionAlgorithm.RC4_128
            );

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "document-with-password.pdf");

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, savePath);
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "document-with-password.pdf")));
        }


        [Fact(DisplayName = "Convert HTML to PDF Using Save Options")]
        public void ConvertHtmlToPdfWithSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithSaveOptions.cs
            // Convert HTML to PDF with custom metadata using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Load an HTML document from file or string
            using (HTMLDocument document = new HTMLDocument("<h1>Hello, PDF!</h1>", "."))
            {
                // Initialize PDF rendering options
                PdfSaveOptions options = new PdfSaveOptions();

                // Set PDF document information (metadata)
                options.DocumentInfo.Title = "Sample PDF Title";
                options.DocumentInfo.Author = "Aspose.HTML for .NET";
                options.DocumentInfo.Subject = "HTML to PDF Example";
                options.DocumentInfo.Keywords = "Aspose, HTML, PDF, conversion";

                // Set output file path
                string outputPath = Path.Combine(OutputDir, "document.pdf");

                // Convert HTML to PDF
                Converter.ConvertHTML(document, options, outputPath);
            }

            Output.WriteLine("PDF created successfully.");
            Assert.True(File.Exists(Path.Combine(OutputDir, "document.pdf")));
            // @END_SNIPPET
        }


        [Fact(DisplayName = "HTML to PDF With PdfSaveOptions")]
        public void HTMLtoPDFWithPdfSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithCustomSettings.cs
            // Convert HTML to PDF in C# with custom page settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "drawing.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "drawing-options.pdf");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize PdfSaveOptions. Set up the page-size 600x300 pixels, margins, resolutions and change the background color to AliceBlue 
            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 100
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 300), new Margin(20, 10, 10, 10));

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "drawing-options.pdf")));
        }


        [Fact(DisplayName = "Specify PdfSaveOptions")]
        public void SpecifyPdfSaveOptionsTest()
        {
            // @START_SNIPPET SpecifyPdfSaveOptions.cs
            // Convert HTML to PDF with custom settings using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.pdf");

            // Prepare HTML code and save it to a file
            string code = "<h1>  PdfSaveOptions Class</h1>\r\n" +
                          "<p>Using PdfSaveOptions Class, you can programmatically apply a wide range of conversion parameters such as BackgroundColor, HorizontalResolution, VerticalResolution, PageSetup, etc.</p>\r\n";

            File.WriteAllText(documentPath, code);

            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);
            
            // Set up the page-size, margins and change the background color to AntiqueWhite
            PdfSaveOptions options = new PdfSaveOptions()
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(4.9f), Length.FromInches(3.5f)), new Margin(30, 20, 10, 10));

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void HTMLtoPDFCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithCustomStreamProvider.cs
            // Convert HTML to PDF in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to PDF File Format!</h1>", ".");
            
            // Convert HTML to PDF using the MemoryStreamProvider
            Converter.ConvertHTML(document, new PdfSaveOptions(), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.pdf")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.pdf")));
        }


        // @START_SNIPPET MemoryStreamProvider.cs
        // Implement a custom MemoryStream provider for advanced control over HTML rendering output streams
        // Learn more: https://docs.aspose.com/html/net/convert-html-to-pdf/

        class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            // List of MemoryStream objects created during the document rendering
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                // This method is called when only one output stream is required, for instance for XPS, PDF or TIFF formats
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of image files (JPG, PNG, etc.)
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream)
            {
                // Here you can release the stream filled with data and, for instance, flush it to the hard-drive
            }

            public void Dispose()
            {
                // Releasing resources
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
        // @END_SNIPPET
    }
}
