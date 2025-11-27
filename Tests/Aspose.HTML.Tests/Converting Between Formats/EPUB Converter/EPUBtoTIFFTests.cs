using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.EPUB_Converter
{
    public class EPUBtoTIFFTests : TestsBase
    {
        public EPUBtoTIFFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-tiff");
        }


        [Fact(DisplayName = "Convert EPUB to TIFF by Two Lines")]
        public void ConvertEPUBbyTwoLinesTest()
        {
            // Open an existing EPUB file for reading.
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to TIFF
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Tiff), Path.Combine(OutputDir, "convert-by-two-lines.tiff"));

            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.tiff")));
        }


        [Fact(DisplayName = "Convert EPUB to TIFF")]
        public void ConvertEPUBtoTIFFTest()
        {
            // @START_SNIPPET ConvertEpubToTiff.cs
            // Convert EPUB to TIFF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-tiff/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.tiff");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Call the ConvertEPUB() method to convert EPUB to TIFF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-output.tiff")));
        }


        [Fact(DisplayName = "Convert EPUB to TIFF with ImageSaveOptions")]
        public void ConvertEPUBtoGTIFFWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToTiffWithImageSaveOptions.cs
            // Convert EPUB to TIFF in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-tiff/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.tiff");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
            {
                Compression = Compression.None,
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(800, 500), new Margin(30, 20, 10, 10));

            // Call the ConvertEPUB() method to convert EPUB to TIFF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-options.tiff")));
        }
    }
}
