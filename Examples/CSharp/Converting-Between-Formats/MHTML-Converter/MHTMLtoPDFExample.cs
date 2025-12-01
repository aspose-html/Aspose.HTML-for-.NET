using Aspose.Html;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using System.Linq;
using Aspose.Html.Drawing;

namespace Aspose.Html.Examples
{
    public class MHTMLtoPDFExample : BaseExample
    {
        public MHTMLtoPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("mhtml-converter/mhtml-to-pdf");
        }

        // Convert MHTML to PDF with two lines
        public void ConvertMhtmlToPdfWithTwoLines()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Convert MHTML to PDF
            Converter.ConvertMHTML(stream, new PdfSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.pdf"));
        }

        // Convert MHTML to PDF from a stream
        public void ConvertMhtmlToPdf()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.pdf");
            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            // Convert MHTML to PDF
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to PDF with custom PdfSaveOptions
        public void ConvertMhtmlToPdfWithOptions()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "sample-options.pdf");
            // Create PDF save options with custom page size and background color
            PdfSaveOptions options = new PdfSaveOptions()
            {
                PageSetup =
                {
                    AnyPage = new Page()
                    {
                        Size = new Size(Length.FromPixels(3000), Length.FromPixels(1000))
                    }
                },
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert MHTML to PDF
            Converter.ConvertMHTML(stream, options, savePath);
        }

        // Convert MHTML to PDF using a custom memory‑stream provider
        public void ConvertMhtmlToPdfWithCustomStreamProvider()
        {
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path to save the result
            string savePath = Path.Combine(OutputDir, "stream-provider.pdf");
            // Convert MHTML to PDF using the provider
            Converter.ConvertMHTML(stream, new PdfSaveOptions(), streamProvider);
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