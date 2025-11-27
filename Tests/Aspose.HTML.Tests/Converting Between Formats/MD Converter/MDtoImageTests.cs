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

namespace Aspose.HTML.Tests.Converting_Between_Formats.MD_Converter
{
    public class MDtoImageTests : TestsBase
    {
        public MDtoImageTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("md-converter/md-to-image");
        }


        [Fact(DisplayName = "Convert Markdown to JPG")]
        public void ConvertMDtoJPGTest()
        {
            // @START_SNIPPET ConvertMarkdownToJpg.cs
            // Convert Markdown to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "[visit applications](https://products.aspose.app/html/family)";
            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "document-output.jpg");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to JPG image file format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "document-output.jpg")));
        }


        [Fact(DisplayName = "Convert Markdown to JPG with ImageSaveOptions")]
        public void ConvertMDtoJPGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertMarkdownToJpgWithImageSaveOptions.cs
            // Convert Markdown to JPG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-options.jpg");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 950), new Margin(30, 20, 10, 10));

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "nature-options.jpg")));
        }


        [Fact(DisplayName = "Convert Markdown to PNG")]
        public void ConvertMDtoPNGTest()
        {
            // @START_SNIPPET ConvertMarkdownToPng.cs
            // Convert Markdown to PNG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "document.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "output.png");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to PNG image file format
            Converter.ConvertHTML(document, new ImageSaveOptions(), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "output.png")));
        }

        
        [Fact(DisplayName = "Convert Markdown to BMP")]
        public void ConvertMDtoBMPTest()
        {
            // @START_SNIPPET ConvertMarkdownToBmp.cs
            // Convert Markdown to BMP using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "document.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "output.bmp");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to BMP image file format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Bmp), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "output.bmp")));
        }


        [Fact(DisplayName = "Convert Markdown to GIF")]
        public void ConvertMDtoGIFTest()
        {
            // @START_SNIPPET ConvertMarkdownToGif.cs
            // Convert Markdown to GIF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "document.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "output.gif");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to GIF image file format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Gif), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "output.gif")));
        }


        [Fact(DisplayName = "Convert Markdown to TIFF")]
        public void ConvertMDtoTIFFTest()
        {
            // @START_SNIPPET ConvertMarkdownToTiff.cs
            // Convert Markdown to TIFF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-image/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "document.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "output.tiff");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Convert HTML document to TIFF image file format
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Tiff), savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
