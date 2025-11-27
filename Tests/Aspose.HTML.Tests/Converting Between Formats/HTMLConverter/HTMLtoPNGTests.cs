using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
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
    public class HTMLtoPNGTests : TestsBase
    {
        public HTMLtoPNGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-png");
        }


        [Fact(DisplayName = "Convert HTML to PNG With a Single Line")]
        public void ConvertHTMLtoPNGwithASingleLineTest()
        {
            // @START_SNIPPET ConvertHtmlToPngInOneLine.cs
            // Convert HTML to PNG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-png/

            // Invoke the ConvertHTML() method to convert HTML to PNG
            Converter.ConvertHTML(@"<h1>Convert HTML to PNG!</h1>", ".", new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.png")));
        }

        [Fact(DisplayName = "Convert HTML to PNG")]
        public void ConvertHTMLtoPNGTest()
        {
            // @START_SNIPPET ConvertHtmlToPng.cs
            // Convert HTML to PNG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-png/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-output.png");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Convert HTML to PNG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "nature-output.png")));
        }


        [Fact(DisplayName = "Convert HTML to PNG with ImageSaveOptions")]
        public void ConvertHTMLtoPNGWithImageSavaOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToPngWithImageSavaOptions.cs
            // Convert HTML to PNG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-png/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-output-options.png");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions()
            {
                UseAntialiasing = false,
                HorizontalResolution = 100,
                VerticalResolution = 100,
                BackgroundColor = System.Drawing.Color.Beige
            };

            // Convert HTML to PNG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "nature-output-options.png")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void HTMLtoPNGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertHtmlToPngWithCustomStreamProvider.cs
            // Convert HTML to PNG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-png/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to PNG File Format!</h1>", ".");
            
            // Convert HTML to JPG using the MemoryStreamProvider
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Png), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.png")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.png")));
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
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of the image files (JPG, PNG, etc.)
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
