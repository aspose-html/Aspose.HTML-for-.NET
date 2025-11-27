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
    public class HTMLtoTIFFTests : TestsBase
    {
        public HTMLtoTIFFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-tiff");
        }


        [Fact(DisplayName = "Convert HTML to TIFF")]
        public void ConvertHTMLtoTIFFTest()
        {
            // @START_SNIPPET ConvertHtmlToTiff.cs
            // Convert HTML to TIFF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-tiff/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "nature-output.tiff");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Convert HTML to TIFF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert HTML to TIFF With ImageSaveOptions")]
        public void ConvertHTMLtoTIFFWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToTiffWithImageSaveOptions.cs
            // Convert HTML to TIFF with custom settings using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-tiff/

            string documentPath = Path.Combine(DataDir, "nature.html");
            string savePath = Path.Combine(OutputDir, "nature-output-options.tiff");


            // Initialize an HTML Document from the html file
            using HTMLDocument document = new HTMLDocument(documentPath);
            
            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
            {
                Compression = Compression.None,
                BackgroundColor = System.Drawing.Color.Bisque,
                HorizontalResolution = 150,
                VerticalResolution = 150,
                UseAntialiasing = true,
            };

            // Convert HTML to TIFF
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
