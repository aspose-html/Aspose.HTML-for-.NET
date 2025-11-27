using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Drawing;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using System.Drawing.Drawing2D;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoBMPTests : TestsBase
    {
        public SVGtoBMPTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-bmp");
        }


        [Fact(DisplayName = "Convert SVG to BMP In One Line")]
        public void ConvertSVGtoBMPWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToBmpInOneLine.cs
            // Convert SVG to BMP in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-bmp/

            // Invoke the ConvertSVG() method for SVG to BMP conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Bmp), Path.Combine(OutputDir, "convert-with-single-line.bmp"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.bmp")));
        }


        [Fact(DisplayName = "Convert SVG to BMP")]
        public void ConvertSVGtoBMPTest()
        {
            // @START_SNIPPET ConvertSvgToBmp.cs
            // Convert SVG to BMP using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-bmp/

            // Prepare SVG code 
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='50' fill='none' stroke='red' stroke-width='10' />" +
                          "</svg>";

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.bmp");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert SVG to BMP
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.bmp")));
        }


        [Fact(DisplayName = "SVG to BMP With ImageSaveOptions")]
        public void SVGtoBMPWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToBmpWithImageSaveOptions.cs
            // Convert SVG to BMP in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-bmp/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower1.svg");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "flower-options.bmp");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Initialize ImageSaveOptions. Set up the SmoothingMode, resolutions, and change the background color to AliceBlue 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                UseAntialiasing = true,
            };

            // Convert SVG to BMP
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "flower-options.bmp")));
        }
    }
}
