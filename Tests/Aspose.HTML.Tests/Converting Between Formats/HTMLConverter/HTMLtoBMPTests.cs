using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.HTMLConverter
{
    public class HTMLtoBMPTests : TestsBase
    {
        public HTMLtoBMPTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-bmp");
        }


        [Fact(DisplayName = "Convert HTML to BMP")]
        public void ConvertHTMLtoBMPTest()
        {
            // @START_SNIPPET ConvertHtmlToBmp.cs
            // Convert HTML to BMP using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-bmp/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "bmp.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "bmp-output.bmp");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert HTML to BMP
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "bmp-output.bmp")));
        }


        [Fact(DisplayName = "Convert HTML to BMP with ImageSaveOptions")]
        public void ConvertHTMLtoBMPWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToBmpWithImageSaveOptions.cs
            // Convert HTML to  BMP in C# with custom background, resolution, and antialiasing settings
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-bmp/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "bmp.html");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "bmp-output-options.bmp");

            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                UseAntialiasing = false,
                HorizontalResolution = 350,
                VerticalResolution = 350,
                BackgroundColor = System.Drawing.Color.Beige
            };
            
            // Convert HTML to BMP
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "bmp-output-options.bmp")));
        }
    }
}
