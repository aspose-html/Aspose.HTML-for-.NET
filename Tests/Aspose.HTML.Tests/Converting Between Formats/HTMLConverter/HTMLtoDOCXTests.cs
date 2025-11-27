using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;


namespace Aspose.HTML.Tests.Converting_Between_Formats.HTMLConverter
{
    public class HTMLtoDOCXTests : TestsBase
    {
        public HTMLtoDOCXTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-docx");
        }


        [Fact(DisplayName = "Convert HTML to DOCX With a Single Line")]
        public void ConvertHTMLWithASingleLineTest()
        {
            // @START_SNIPPET ConvertHtmlToDocxWithOneLineOfCode.cs
            // Convert HTML to DOCX in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-docx/

            // Invoke the ConvertHTML() method to convert HTML to DOCX
            Converter.ConvertHTML(@"<h1>Convert HTML to DOCX!</h1>", ".", new DocSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.docx"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.docx")));
        }


        [Fact(DisplayName = "Convert HTML to DOCX")]
        public void ConvertHTMLtoDOCXTest()
        {
            // @START_SNIPPET ConvertHtmlToDocx.cs
            // Convert HTML to DOCX using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-docx/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "canvas.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "canvas-output.docx");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize DocSaveOptions
            DocSaveOptions options = new DocSaveOptions();

            // Convert HTML to DOCX
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "HTML to DOCX With DocSaveOptions")]
        public void HTMLtoDOCXWithDocSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToDocxWithDocSaveOptions.cs
            // Convert HTML to DOCX in C# with custom page size and margins
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-docx/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "canvas.html");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "canvas-output-options.docx");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize DocSaveOptions. Set up the page-size 600x400 pixels and margins
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 400), new Margin(10, 10, 10, 10));

            // Convert HTML to DOCX
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify DocSaveOptions")]
        public void SpecifyDocSaveOptionsTest()
        {
            // @START_SNIPPET SpecifyDocSaveOptions.cs
            // Convert HTML to DOCX in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-docx/

            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.docx");

            // Prepare HTML code and save it to a file
            string code = "<h1>DocSaveOptions Class</h1>\r\n" +
                          "<p>Using DocSaveOptions Class, you can programmatically apply a wide range of conversion parameters.</p>\r\n";

            File.WriteAllText(documentPath, code);

            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize DocSaveOptions. Set A5 as a page-size 
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(8.3f), Length.FromInches(5.8f)));

            // Convert HTML to DOCX
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void HTMLtoDOCXCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertHtmlToDocxWithCustomStreamProvider.cs
            // Convert HTML to DOCX in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-docx/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to DOCX File Format!</h1>", ".");
            
            // Convert HTML to DOCX using the MemoryStreamProvider
            Converter.ConvertHTML(document, new DocSaveOptions(), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.docx")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.docx")));
        }


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
    }
}
