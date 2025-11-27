using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Drawing;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using System.Drawing.Drawing2D;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoGIFTests : TestsBase
    {
        public SVGtoGIFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-gif");
        }


        [Fact(DisplayName = "Convert SVG to GIF With a Single Line")]
        public void ConvertSVGtoGIFWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToGifInOneLine.cs
            // Convert SVG to GIF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-gif/

            // Invoke the ConvertSVG() method for SVG to GIF conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Gif), Path.Combine(OutputDir, "convert-with-single-line.gif"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.gif")));
        }


        [Fact(DisplayName = "Convert SVG to GIF")]
        public void ConvertSVGtoGIFTest()
        {
            // @START_SNIPPET ConvertSvgToGif.cs
            // Convert SVG to GIF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-gif/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='55' fill='pink' stroke='red' stroke-width='8' />" +
                          "</svg>";

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.gif");

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert SVG to GIF
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.gif")));
        }


        [Fact(DisplayName = "SVG to GIF With ImageSaveOptions")]
        public void SVGtoGIFWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToGifWithImageSaveOptions.cs
            // Convert SVG to GIF in C# with custom background, resolution, and antialiasing settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-gif/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "gradient.svg");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "gradient-options.gif");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Initialize ImageSaveOptions. Set up the SmoothingMode, resolutions, and change the background color to AliceBlue
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Convert SVG to GIF
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "gradient-options.gif")));
        }
    }
}
