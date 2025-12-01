using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class EPUBtoPDFExample : BaseExample
    {
        public EPUBtoPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-pdf");
        }

        // Convert EPUB to PDF with two lines
        public void ConvertEpubToPdfWithTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to PDF
            Converter.ConvertEPUB(stream, new PdfSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.pdf"));
        }

        // Convert EPUB to PDF from a stream
        public void ConvertEpubToPdf()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.pdf");
            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            // Convert EPUB to PDF
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to PDF from a file path
        public void ConvertEpubToPdfFromPath()
        {
            // Prepare a path to a source EPUB file
            string documentPath = Path.Combine(DataDir, "input.epub");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "output.pdf");
            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            // Convert EPUB to PDF
            Converter.ConvertEPUB(documentPath, options, savePath);
        }

        // Convert EPUB to PDF with custom PdfSaveOptions
        public void ConvertEpubToPdfWithOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.pdf");
            // Create PDF save options with custom page size and background color
            PdfSaveOptions options = new PdfSaveOptions()
            {
                PageSetup =
                {
                    AnyPage = new Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(Length.FromPixels(1000), Length.FromPixels(1000))
                    }
                },
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert EPUB to PDF
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to PDF using a custom memory‑stream provider
        public void ConvertEpubToPdfWithCustomStreamProvider()
        {
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the result
            string savePath = Path.Combine(OutputDir, "stream-provider.pdf");
            // Convert EPUB to PDF using the provider
            Converter.ConvertEPUB(stream, new PdfSaveOptions(), streamProvider);
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