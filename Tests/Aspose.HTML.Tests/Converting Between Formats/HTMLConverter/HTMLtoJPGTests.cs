using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
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
    public class HTMLtoJPGTests : TestsBase
    {
        public HTMLtoJPGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-jpg");
        }


        [Fact(DisplayName = "Convert HTML to JPG With a Single Line")]
        public void ConvertHTMLtoJPGWithASingleLineTest()
        {
            // @START_SNIPPET ConvertHtmlToJpgWithOneLineOfCode.cs
            // Convert HTML to JPG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-jpg/

            // Invoke the ConvertHTML() method to convert the HTML code to JPG image
            Converter.ConvertHTML(@"<h1>Convert HTML to JPG!</h1>", ".", new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-with-single-line.jpg"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.jpg")));
        }


        [Fact(DisplayName = "Convert HTML to JPG")]
        public void ConvertHTMLtoJPGTest()
        {
            // @START_SNIPPET ConvertHtmlToJpg.cs
            // Convert HTML to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-jpg/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "spring-output.jpg");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "spring-output.jpg")));
        }


        [Fact(DisplayName = "Convert HTML to JPG with ImageSaveOptions")]
        public void ConvertHTMLtoJPGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToJpgWithImageSaveOptions.cs
            // Convert HTML to JPG in C# with with custom background, resolution, and antialiasing settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-jpg/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "color.html");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "color-output-options.jpg");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 500), new Margin(30, 20, 10, 10));

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "color-output-options.jpg")));
        }


        [Fact(DisplayName = "Specify Image SaveOptions")]
        public void SpecifyImageSaveOptionsTest()
        {
            // @START_SNIPPET SpecifyImageSaveOptions.cs
            // Convert HTML to JPG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-jpg/

            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.jpg");

            // Prepare HTML code and save it to a file
            string code = "<h1> Image SaveOptions </h1>\r\n" +
                          "<p>Using ImageSaveOptions Class, you can programmatically apply a wide range of conversion parameters such as BackgroundColor, Format, Compression, PageSetup, etc.</p>\r\n";

            File.WriteAllText(documentPath, code);

            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);
            
            // Set up the page-size 500x250 pixels, margins and change the background color to AntiqueWhite
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 250), new Margin(40, 40, 20, 20));

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "save-options-output.jpg")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void HTMLtoJPGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertHtmlToJpgWithCustomStreamProvider.cs
            // Convert HTML to JPG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-jpg/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to JPG File Format!</h1>", ".");
            
            // Convert HTML to JPG using the MemoryStreamProvider
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.jpg")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.jpg")));
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
