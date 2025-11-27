using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.HTMLConverter
{
    public class HTMLtoXPSTests : TestsBase
    {
        public HTMLtoXPSTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-xps");
        }


        [Fact(DisplayName = "Convert HTML to XPS With a Single Line")]
        public void ConvertHTMLtoXPSWithASingleLineTest()
        {
            // @START_SNIPPET ConvertHtmlToXpsInOneLine.cs
            // Convert HTML to XPS using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-xps/

            // Invoke the ConvertHTML() method to convert the HTML code to XPS
            Converter.ConvertHTML(@"<h1>Convert HTML to XPS!</h1>", ".", new XpsSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.xps"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.xps")));
        }


        [Fact(DisplayName = "Convert HTML to XPS")]
        public void ConvertHTMLtoXPSTest()
        {
            // @START_SNIPPET ConvertHtmlToXps.cs
            // Convert HTML to XPS in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-xps/

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

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify XpsSaveOptions")]
        public void SpecifyXpsSaveOptionsTest()
        {
            // @START_SNIPPET SpecifyXpsSaveOptions.cs
            // Convert HTML to XPS with custom settings using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-xps/

            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.xps");

            // Prepare HTML code and save it to a file
            string code = "<h1>  XpsSaveOptions Class</h1>\r\n" +
                          "<p>Using XpsSaveOptions Class, you can programmatically apply a wide range of conversion parameters such as BackgroundColor, PageSetup, etc.</p>\r\n";

            File.WriteAllText(documentPath, code);

            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);
            
            // Set up the page-size, margins and change the background color to AntiqueWhite
            XpsSaveOptions options = new XpsSaveOptions()
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(4.9f), Length.FromInches(3.5f)), new Margin(30, 20, 10, 10));

            // Convert HTML to XPS
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void HTMLtoXPSCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertHtmlToXpsWithCustomStreamProvider.cs
            // Convert HTML to XPS in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-xps/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to XPS File Format!</h1>", ".");
            
            // Convert HTML to XPS using MemoryStreamProvider
            Converter.ConvertHTML(document, new XpsSaveOptions(), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.xps")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.xps")));
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
