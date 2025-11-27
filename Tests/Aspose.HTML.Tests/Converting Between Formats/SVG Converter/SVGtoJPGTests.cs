using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoJPGTests : TestsBase
    {
        public SVGtoJPGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-jpg");
        }


        [Fact(DisplayName = "Convert SVG to JPG With a Single Line")]
        public void ConvertSVGtoJPGWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToJpgInOneLine.cs
            // Convert SVG to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-jpg/

            // Invoke the ConvertSVG() method for SVG to JPG conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-with-single-line.jpg"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.jpg")));
        }


        [Fact(DisplayName = "Convert SVG to JPG")]
        public void ConvertSVGtoJPGTest()
        {
            // @START_SNIPPET ConvertSvgToJpg.cs
            // Convert SVG to JPG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-jpg/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='55' fill='green' stroke='red' stroke-width='10' />" +
                          "</svg>";

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "circle.jpg");

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert SVG to JPG
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.jpg")));
        }


        [Fact(DisplayName = "SVG to JPG With ImageSaveOptions")]
        public void SVGtoJPGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToJpgWithImageSaveOptions.cs
            // Convert SVG to JPG in C# with custom background, resolution, and antialiasing settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-jpg/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower.svg");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "flower-options.jpg");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Create an instance of the ImageSaveOptions class. Set up the resolutions, SmoothingMode and change the background color to AliceBlue
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Convert SVG to JPG
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "flower-options.jpg")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void SVGtoJPGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertSvgToJpgWithCustomStreamProvider.cs
            // Convert SVG to JPG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-jpg/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                          "</svg>";

            // Convert SVG to JPG using the MemoryStreamProvider
            Converter.ConvertSVG(code, ".", new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

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
