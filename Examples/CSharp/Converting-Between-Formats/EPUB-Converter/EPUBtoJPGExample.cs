using Aspose.Html;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class EPUBtoJPGExample : BaseExample
    {
        public EPUBtoJPGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-jpg");
        }

        // Convert EPUB to JPG by two lines
        public void ConvertEPUBByTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to JPG
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-by-two-lines.jpg"));
        }

        // Convert EPUB to JPG
        public void ConvertEPUBToJpg()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.jpg");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Convert EPUB to JPG
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to JPG with ImageSaveOptions
        public void ConvertEPUBToJpgWithImageSaveOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "input-options.jpg");
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Set page size and margins
            options.PageSetup.AnyPage = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
            // Convert EPUB to JPG with custom options
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to JPG using a custom stream provider
        public void ConvertEPUBToJpgWithCustomStreamProvider()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Create an instance of the MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Convert EPUB to JPG using the MemoryStreamProvider
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
            // Save each generated stream to a file
            for (int i = 0; i < streamProvider.Streams.Count; i++)
            {
                MemoryStream memory = streamProvider.Streams[i];
                memory.Seek(0, SeekOrigin.Begin);
                using FileStream fs = File.Create(Path.Combine(OutputDir, $"input-page_{i + 1}.jpg"));
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