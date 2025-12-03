using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

namespace Aspose.Html.Examples
{
    public class MHTMLtoImageExample : BaseExample
    {
        public MHTMLtoImageExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("mhtml-converter/mhtml-to-image");
        }

        // Convert MHTML to JPG with two lines
        public void ConvertMhtmlToJpgWithTwoLines()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Convert MHTML to JPG
            Converter.ConvertMHTML(stream, new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-by-two-lines.jpg"));
        }

        // Convert MHTML to JPG
        public void ConvertMhtmlToJpg()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.jpg");
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Convert MHTML to JPG
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to PNG
        public void ConvertMhtmlToPng()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.png");
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            // Convert MHTML to PNG
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to BMP
        public void ConvertMhtmlToBmp()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.bmp");
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // Convert MHTML to BMP
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to GIF
        public void ConvertMhtmlToGif()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.gif");
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Convert MHTML to GIF
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to TIFF
        public void ConvertMhtmlToTiff()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.tiff");
            // Create an instance of ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            // Convert MHTML to TIFF
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to JPG with custom ImageSaveOptions
        public void ConvertMhtmlToJpgWithOptions()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-options.jpg");
            // Initialize ImageSaveOptions with custom page size and background color
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    AnyPage = new Page()
                    {
                        Size = new Size(Length.FromPixels(1000), Length.FromPixels(500))
                    }
                },
                BackgroundColor = System.Drawing.Color.Beige
            };
            // Convert MHTML to JPG
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to JPG using a custom memory‑stream provider
        public void ConvertMhtmlToJpgWithCustomStreamProvider()
        {
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the result
            string savePath = Path.Combine(OutputDir, "stream-provider.jpg");
            // Convert MHTML to JPG using the provider
            Converter.ConvertMHTML(stream, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
            // Retrieve the memory stream containing the result
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);
            // Write the result to a file
            using (FileStream fs = File.Create(savePath))
            {
                memory.CopyTo(fs);
            }
        }

        // Custom memory‑stream provider implementation
        private class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream) { }

            public void Dispose()
            {
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
    }
}