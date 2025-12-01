using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.IO;

namespace Aspose.Html.Examples
{
    public class EPUBtoPNGExample : BaseExample
    {
        public EPUBtoPNGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-png");
        }

        // Convert EPUB to PNG with a single line
        public void ConvertEpubToPngWithSingleLine()
        {
            // Convert EPUB to PNG in one line
            Converter.ConvertEPUB(File.OpenRead(Path.Combine(DataDir, "input.epub")), new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));
        }

        // Convert EPUB to PNG from a stream
        public void ConvertEpubToPng()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.png");
            // Create ImageSaveOptions
            ImageSaveOptions options = new ImageSaveOptions();
            // Convert EPUB to PNG
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to PNG with custom ImageSaveOptions
        public void ConvertEpubToPngWithOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.png");
            // Create ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions()
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert EPUB to PNG
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to PNG using a custom memory‑stream provider
        public void ConvertEpubToPngWithCustomStreamProvider()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Convert EPUB to PNG using the provider
            Converter.ConvertEPUB(stream, new ImageSaveOptions(), streamProvider);
            // Write each page to a separate file
            for (int i = 0; i < streamProvider.Streams.Count; i++)
            {
                var memory = streamProvider.Streams[i];
                memory.Seek(0, SeekOrigin.Begin);
                using var fs = File.Create(Path.Combine(OutputDir, $"input-page_{i + 1}.png"));
                memory.CopyTo(fs);
            }
        }

        // Custom memory‑stream provider implementation
        private class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                var result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                var result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream) { }

            public void Dispose()
            {
                foreach (var stream in Streams)
                    stream.Dispose();
            }
        }
    }
}