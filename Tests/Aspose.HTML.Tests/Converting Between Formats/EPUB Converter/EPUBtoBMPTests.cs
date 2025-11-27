using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.EPUB_Converter
{
    public class EPUBtoBMPTests : TestsBase
    {
        public EPUBtoBMPTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-bmp");
        }


        [Fact(DisplayName = "Convert EPUB to BMP by Two Lines")]
        public void ConvertEPUBbyTwoLinesTest()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to BMP
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Bmp), Path.Combine(OutputDir, "convert-by-two-lines.bmp"));

            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.bmp")));
        }


        [Fact(DisplayName = "Convert EPUB to BMP")]
        public void ConvertEPUBtoBMPTest()
        {
            // @START_SNIPPET ConvertEpubToBmp.cs
            // Convert EPUB to BMP using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-bmp/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-output.bmp");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Call the ConvertEPUB() method to convert EPUB to BMP
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-output.bmp")));
        }


        [Fact(DisplayName = "Convert EPUB to BMP with ImageSaveOptions")]
        public void ConvertEPUBtoBMPWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToBmpWithCustomSettings.cs
            // Convert EPUB to BMP in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-bmp/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "input-options.bmp");

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Call the ConvertEPUB() method to convert EPUB to BMP
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-options.bmp")));
        }
    }
}
