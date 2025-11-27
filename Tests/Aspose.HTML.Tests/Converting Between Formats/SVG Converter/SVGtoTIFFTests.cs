using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Drawing;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoTIFFTests : TestsBase
    {
        public SVGtoTIFFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-tiff");
        }


        [Fact(DisplayName = "Convert SVG to TIFF With a Single Line")]
        public void ConvertSVGtoTIFFWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToTiffInOneLine.cs
            // Convert SVG to TIFF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-tiff/

            // Invoke the ConvertSVG() method for SVG to TIFF conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Tiff), Path.Combine(OutputDir, "convert-with-single-line.tiff"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.tiff")));
        }


        [Fact(DisplayName = "Convert SVG to TIFF")]
        public void ConvertSVGtoTIFFTest()
        {
            // @START_SNIPPET ConvertSvgToTiff.cs
            // Convert SVG to TIFF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-tiff/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='50' fill='pink' stroke='red' stroke-width='10' />" +
                          "</svg>";

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "circle.tiff");

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert SVG to TIFF
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.tiff")));
        }


        [Fact(DisplayName = "SVG to TIFF With ImageSaveOptions")]
        public void SVGtoTIFFWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToTiffWithImageSaveOptions.cs
            // Convert SVG to TIFF in C# with custom background, resolution, and compression settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-tiff/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "gradient.svg");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "gradient-options.tiff");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Initialize ImageSaveOptions. Set up the compression, resolutions, and change the background color to AliceBlue
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
            {
                Compression = Compression.None,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Convert SVG to TIFF
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
