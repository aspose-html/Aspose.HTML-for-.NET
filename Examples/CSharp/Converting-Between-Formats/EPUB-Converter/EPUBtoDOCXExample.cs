using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class EPUBtoDOCXExample : BaseExample
    {
        public EPUBtoDOCXExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-docx");
        }

        // Convert EPUB to DOCX with two lines
        public void ConvertEpubToDocxWithTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to DOCX
            Converter.ConvertEPUB(stream, new DocSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.docx"));
        }

        // Convert EPUB to DOCX from a stream
        public void ConvertEpubToDocx()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.docx");
            // Create DOCX save options
            DocSaveOptions options = new DocSaveOptions();
            // Convert EPUB to DOCX
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to DOCX from a file path
        public void ConvertEpubToDocxFromPath()
        {
            // Prepare a path to a source EPUB file
            string documentPath = Path.Combine(DataDir, "input.epub");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output2.docx");
            // Create DOCX save options
            DocSaveOptions options = new DocSaveOptions();
            // Convert EPUB to DOCX
            Converter.ConvertEPUB(documentPath, options, savePath);
        }

        // Convert EPUB to DOCX with custom DocSaveOptions
        public void ConvertEpubToDocxWithOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-options.docx");
            // Create DOCX save options with custom page size
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(8.3f), Length.FromInches(5.8f)));
            // Convert EPUB to DOCX
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to DOCX using a custom memory‑stream provider
        public void ConvertEpubToDocxWithCustomStreamProvider()
        {
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the result
            string savePath = Path.Combine(OutputDir, "stream-provider.docx");
            // Convert EPUB to DOCX using the provider
            Converter.ConvertEPUB(stream, new DocSaveOptions(), streamProvider);
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