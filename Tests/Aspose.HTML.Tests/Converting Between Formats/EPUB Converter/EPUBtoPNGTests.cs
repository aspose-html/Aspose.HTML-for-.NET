using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.EPUB_Converter
{
    public class EPUBtoPNGTests : TestsBase
    {
        public EPUBtoPNGTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-png");
        }


        [Fact(DisplayName = "Convert EPUB to PNG With One Line")]
        public void ConvertEPUBWithASingleLineTest()
        {
            // @START_SNIPPET ConvertEpubToPngWithOneLineOfCode.cs
            // Convert EPUB to PNG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-png/

            // Invoke the ConvertEPUB() method to convert EPUB to PNG
            Converter.ConvertEPUB(File.OpenRead(DataDir + "input.epub"), new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.png")));
        }


        [Fact(DisplayName = "Convert EPUB to PNG")]
        public void ConvertEPUBtoPNGTest()
        {
            // @START_SNIPPET ConvertEpubToPng.cs
            // Convert EPUB to PNG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-png/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.png");

            // Create an instance of the ImageSaveOptions class 
            ImageSaveOptions options = new ImageSaveOptions();

            // Call the ConvertEPUB() method to convert EPUB to PNG
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-output.png")));
        }


        [Fact(DisplayName = "Convert EPUB to PNG with ImageSaveOptions")]
        public void ConvertEPUBtoPNGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToPngWithImageSaveOptions.cs
            // Convert EPUB to PNG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-png/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.png");

            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions()
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Call the ConvertEPUB() method to convert EPUB to PNG
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-options.png")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void EPUBtoPngCustomStreamProviderTest()
        {
            // @START_SNIPPET EPUBtoPngCustomStreamProvider.cs
            // Convert EPUB to PNG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-png/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Convert HTML to PNG using the MemoryStreamProvider
            Converter.ConvertEPUB(stream, new ImageSaveOptions(), streamProvider);
           
            // Get access to the memory streams that contain the resulted data
            for (int i = 0; i < streamProvider.Streams.Count; i++)
            {
                MemoryStream memory = streamProvider.Streams[i];
                memory.Seek(0, System.IO.SeekOrigin.Begin);

                // Flush the page to the output file
                using (FileStream fs = File.Create(Path.Combine(OutputDir, $"input-page_{i + 1}.png")))
                {
                    memory.CopyTo(fs);
                }
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "input-page_1.png")));
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
