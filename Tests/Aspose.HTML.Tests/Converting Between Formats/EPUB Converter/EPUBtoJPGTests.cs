using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.EPUB_Converter
{
    public class EPUBtoJPGTests : TestsBase
    {
        public EPUBtoJPGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-jpg");
        }


        [Fact(DisplayName = "Convert EPUB to JPG by Two Lines")]
        public void ConvertEPUBtoJPGbyTwoLinesTest()
        {
            // @START_SNIPPET ConvertEpubToJpgInTwoLinesOfCode.cs
            // Convert EPUB to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-jpg/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to JPG
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-by-two-lines.jpg"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.jpg")));
        }


        [Fact(DisplayName = "Convert EPUB to JPG")]
        public void ConvertEPUBtoJPGTest()
        {
            // @START_SNIPPET ConvertEpubTtoJpg.cs
            // Convert EPUB to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-jpg/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-output.jpg");

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Call the ConvertEPUB() method to convert EPUB to JPG
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-output.jpg")));
        }


        [Fact(DisplayName = "Convert EPUB to JPG with ImageSaveOptions")]
        public void ConvertEPUBtoJPGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToJpgWithCustomSettings.cs
            // Convert EPUB to JPG using C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-jpg/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-options.jpg");

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(800, 500), new Margin(30, 20, 10, 10));

            // Call the ConvertEPUB() method to convert EPUB to JPG
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-options.jpg")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void EPUBtoJPGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertEpubToJpgWithCustomStreamProvider.cs
            // Convert EPUB to JPG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-jpg/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Convert HTML to JPG using the MemoryStreamProvider
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
            
            // Get access to the memory streams that contain the resulted data
            for (int i = 0; i < streamProvider.Streams.Count; i++)
            {
                MemoryStream memory = streamProvider.Streams[i];
                memory.Seek(0, System.IO.SeekOrigin.Begin);

                // Flush the page to the output file
                using (FileStream fs = File.Create(Path.Combine(OutputDir, $"input-page_{i + 1}.jpg")))
                {
                    memory.CopyTo(fs);
                }
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-page_1.jpg")));
        }


        class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            // List of MemoryStream objects created during the document rendering
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                // This method is called when only one output stream is required, for instance for XPS, PDF or TIFF formats
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of image files (JPG, PNG, etc.)
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream)
            {
                // Here you can release the stream filled with data and, for instance, flush it to the hard-drive
            }

            public void Dispose()
            {
                // Releasing resources
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
    }

}
