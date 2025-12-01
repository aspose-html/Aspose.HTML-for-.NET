using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Html.Rendering;
using Aspose.Html.Drawing;

namespace Aspose.Html.Examples
{
    public class MHTMLtoXPSExample : BaseExample
    {
        public MHTMLtoXPSExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("mhtml-converter/mhtml-to-xps");
        }

        // Convert MHTML to XPS with two lines
        public void ConvertMhtmlToXpsWithTwoLines()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Convert MHTML to XPS
            Converter.ConvertMHTML(stream, new XpsSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.xps"));
        }

        // Convert MHTML to XPS
        public void ConvertMhtmlToXps()
        {
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.xps");
            // Create XPS save options
            XpsSaveOptions options = new XpsSaveOptions();
            // Convert MHTML to XPS
            Converter.ConvertMHTML(stream, options, savePath);
        }        

        // Convert MHTML to XPS using a custom memory‑stream provider
        public void ConvertMhtmlToXpsWithCustomStreamProvider()
        {
            // Create a memory‑stream provider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            // Prepare a path for the result
            string savePath = Path.Combine(OutputDir, "stream-provider.xps");
            // Convert MHTML to XPS using the provider
            Converter.ConvertMHTML(stream, new XpsSaveOptions(), streamProvider);
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