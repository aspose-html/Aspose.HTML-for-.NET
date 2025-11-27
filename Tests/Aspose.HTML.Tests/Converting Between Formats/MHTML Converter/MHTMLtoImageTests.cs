using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.MHTML_Converter
{
    public class MHTMLtoImageTests : TestsBase
    {
        public MHTMLtoImageTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("mhtml-converter/mhtml-to-image");
        }


        [Fact(DisplayName = "Convert MHTML to JPG by Two Lines")]
        public void ConvertMHTMLtoJPGbyTwoLinesTest()
        {
            // @START_SNIPPET ConvertMHtmlToJpgWithTwoLinesOfCode.cs
            // Convert MHTML to JPG in C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Invoke the ConvertMHTML() method to convert MHTML to JPG
            Converter.ConvertMHTML(stream, new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-by-two-lines.jpg"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.jpg")));
        }


        [Fact(DisplayName = "Convert MHTML to JPG")]
        public void ConvertMHTMLToJPGTest()
        {
            // @START_SNIPPET ConvertMHtmlToJpg.cs
            // Convert MHTML to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");
                        
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Call the ConvertMHTML() method to convert MHTML to JPG
            Converter.ConvertMHTML(stream, options, Path.Combine(OutputDir, "sample-output.jpg"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sample-output.jpg")));
        }


        [Fact(DisplayName = "Convert MHTML to PNG")]
        public void ConvertMHTMLToPNGTest()
        {
            // @START_SNIPPET ConvertMHtmlToPng.cs
            // Convert MHTML to PNG using C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Call the ConvertMHTML() method to convert MHTML to PNG
            Converter.ConvertMHTML(stream, options, Path.Combine(OutputDir, "sample-output.png"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sample-output.png")));
        }


        [Fact(DisplayName = "Convert MHTML to BMP")]
        public void ConvertMHTMLToBMPTest()
        {
            // @START_SNIPPET ConvertMHtmlToBmp.cs
            // Convert MHTML to BMP using C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Call the ConvertMHTML() method to convert MHTML to BMP
            Converter.ConvertMHTML(stream, options, Path.Combine(OutputDir, "sample-output.bmp"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sample-output.bmp")));
        }


        [Fact(DisplayName = "Convert MHTML to GIF")]
        public void ConvertMHTMLToGIFTest()
        {
            // @START_SNIPPET ConvertMHtmlToGif.cs
            // Convert MHTML to GIF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Call the ConvertMHTML() method to convert MHTML to GIF
            Converter.ConvertMHTML(stream, options, Path.Combine(OutputDir, "sample-output.gif"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sample-output.gif")));
        }


        [Fact(DisplayName = "Convert MHTML to TIFF")]
        public void ConvertMHTMLToTIFFTest()
        {
            // @START_SNIPPET ConvertMHtmlToTiff.cs
            // Convert MHTML to TIFF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "sample-options.tiff");

            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

            // Call the ConvertMHTML() method to convert MHTML to TIFF
            Converter.ConvertMHTML(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "MHTML to JPG With ImageSaveOptions")]
        public void MHTMLtoJPGWithImageSaveOptionsTest()
        {
            // @START_SNIPPET ConvertMHtmlToJpgWithImageSaveOptions.cs
            // Convert MHTML to JPG in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "sample-options.jpg");

            // Initailize the ImageSaveOptions with a custom page-size and a background color
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                PageSetup =
                    {
                        AnyPage = new Page()
                        {
                            Size = new Aspose.Html.Drawing.Size(Length.FromPixels(1000), Length.FromPixels(500))
                        }
                    },
                BackgroundColor = System.Drawing.Color.Beige
            };

            // Call the ConvertMHTML() method to convert MHTML to JPG
            Converter.ConvertMHTML(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sample-options.jpg")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void MHTMLtoJPGCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertMHtmlToJpgWithCustomStreamProvider.cs
            // Convert MHTML to JPG in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-image/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "stream-provider.jpg");

            // Convert MHTML to JPG by using the MemoryStreamProvider class
            Converter.ConvertMHTML(stream, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

            // Get access to the memory streams that contain the resulted data
            for (int i = 0; i < streamProvider.Streams.Count; i++)
            {
                MemoryStream memory = streamProvider.Streams[i];
                memory.Seek(0, SeekOrigin.Begin);

                // Flush the page to the output file
                using (FileStream fs = File.Create(savePath))
                {
                    memory.CopyTo(fs);
                }
            }

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
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
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of the image files (JPG, PNG, etc.)
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
