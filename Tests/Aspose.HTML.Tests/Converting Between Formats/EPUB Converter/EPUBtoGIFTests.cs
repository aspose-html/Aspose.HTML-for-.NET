using Aspose.Html.Converters;
using Aspose.Html.Drawing;
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
    public class EPUBtoGIFTests : TestsBase
    {
        public EPUBtoGIFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-gif");
        }


        [Fact(DisplayName = "Convert EPUB to GIF by Two Lines")]
        public void ConvertEPUBbyTwoLinesTest()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to GIF
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Gif), Path.Combine(OutputDir, "convert-by-two-lines.gif"));

            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.gif")));
        }


        [Fact(DisplayName = "Convert EPUB to GIF")]
        public void ConvertEPUBtoGIFTest()
        {
            // @START_SNIPPET ConvertEpubToGif.cs
            // Convert EPUB to GIF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-gif/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.gif");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Call the ConvertEPUB() method to convert EPUB to GIF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-output.gif")));
        }


        [Fact(DisplayName = "Convert EPUB to GIF with ImageSaveOptions")]
        public void ConvertEPUBtoGIFWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToGifWithImageSaveOptions.cs
            // Convert EPUB to GIF in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-gif/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "input-options.gif");

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(800, 500), new Margin(30, 20, 10, 10));

            // Call the ConvertEPUB() method to convert EPUB to GIF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-options.gif")));
        }
    }
}
