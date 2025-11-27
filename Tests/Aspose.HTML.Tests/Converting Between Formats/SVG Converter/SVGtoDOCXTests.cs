using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoDOCXTests : TestsBase
    {
        public SVGtoDOCXTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-docx");
        }


        [Fact(DisplayName = "Convert SVG to DOCX With a Single Line")]
        public void ConvertSVGtoDOCXWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToDocxInOneLine.cs
            // Convert SVG to DOCX using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-docx/

            // Invoke the ConvertSVG() method to convert SVG to DOCX
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new DocSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.docx"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.docx")));
        }


        [Fact(DisplayName = "Convert SVG to DOCX")]
        public void ConvertSVGtoDOCXTest()
        {
            // @START_SNIPPET ConvertSvgToDocx.cs
            // Convert SVG to DOCX in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-docx/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='50' fill='none' stroke='red' stroke-width='10' />" +
                          "</svg>";

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "circle.docx");

            // Initialize DocSaveOptions
            DocSaveOptions options = new DocSaveOptions();

            // Convert SVG to DOCX
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "circle.docx")));
        }


        [Fact(DisplayName = "SVG to DOCX With DocSaveOptions")]
        public void SVGtoDOCXWithDocSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToDocxWithDocSaveOptions.cs
            // Convert SVG to DOCX in C# with custom page settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-docx/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "shapes.svg");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "shapes-options.docx");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Initialize DocSaveOptions. Set up the page-size and margins
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 500), new Margin(30, 10, 10, 10));

            // Convert SVG to DOCX
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "shapes-options.docx")));
        }
    }
}
