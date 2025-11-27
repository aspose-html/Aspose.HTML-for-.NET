using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using System.Drawing.Drawing2D;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoPNGTests : TestsBase
    {
        public SVGtoPNGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-png");
        }


        [Fact(DisplayName = "Convert SVG to PNG With a Single Line")]
        public void ConvertSVGtoPNGWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToPngInOneLine.cs
            // Convert SVG to PNG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-png/

            // Invoke the ConvertSVG() method for SVG to PNG conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.png")));
        }


        [Fact(DisplayName = "Convert SVG to PNG")]
        public void ConvertSVGtoPNGTest()
        {
            // @START_SNIPPET ConvertSvgToPng.cs
            // Convert SVG to PNG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-png/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='60' fill='none' stroke='red' stroke-width='10' />" +
                          "</svg>";

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.png");

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions();

            // Convert SVG to PNG
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.png")));
        }


        [Fact(DisplayName = "SVG to PNG With ImageSaveOptions")]
        public void SVGtoPNGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToPngWithCustomSettings.cs
            // Convert SVG to PNG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-png/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower1.svg");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "flower-options.png");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Create an instance of the ImageSaveOptions class. Set up the SmoothingMode, resolutions, and change the background color to AliceBlue 
            ImageSaveOptions options = new ImageSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                UseAntialiasing = true,
            };

            // Convert SVG to PNG
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "flower-options.png")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void SVGtoPNGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertSvgToPngWithCustomStreamProvider.cs
            // Convert SVG to PNG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-png/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                          "</svg>";

            // Convert SVG to PNG using the MemoryStreamProvider
            Converter.ConvertSVG(code, ".", new ImageSaveOptions(), streamProvider);

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
