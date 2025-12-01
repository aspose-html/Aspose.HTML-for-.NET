using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class EPUBtoXPSExample : BaseExample
    {
        public EPUBtoXPSExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-xps");
        }

        // Convert EPUB to XPS in two lines of code
        public void ConvertEPUBToXpsWithTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to XPS
            Converter.ConvertEPUB(stream, new XpsSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.xps"));
        }

        // Convert EPUB to XPS
        public void ConvertEPUBToXps()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.xps");
            // Create an instance of XpsSaveOptions
            XpsSaveOptions options = new XpsSaveOptions();
            // Convert EPUB to XPS
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to XPS with XpsSaveOptions
        public void ConvertEPUBToXpsWithXpsSaveOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.xps");
            // Create an instance of XpsSaveOptions with custom page size and background color
            XpsSaveOptions options = new XpsSaveOptions()
            {
                PageSetup =
                {
                    AnyPage = new Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(Length.FromPixels(500), Length.FromPixels(500))
                    }
                },
                BackgroundColor = System.Drawing.Color.LightGray
            };
            // Convert EPUB to XPS
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to XPS using a custom stream provider
        public void ConvertEPUBToXpsWithCustomStreamProvider()
        {
            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to XPS using the MemoryStreamProvider
            Converter.ConvertEPUB(stream, new XpsSaveOptions(), streamProvider);
            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);
            // Flush the result data to the output file
            using FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.xps"));
            memory.CopyTo(fs);
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