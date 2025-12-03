using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class HTMLtoPNGExample : BaseExample
    {
        public HTMLtoPNGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-png");
        }

        // Convert HTML to PNG with a single line
        public void ConvertHtmlToPngWithSingleLine()
        {
            // Convert HTML to PNG using C#
            Converter.ConvertHTML(@"<h1>Convert HTML to PNG!</h1>", ".", new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));
        }

        // Convert HTML to PNG from a file
        public void ConvertHtmlToPng()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-output.png");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Convert HTML to PNG
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PNG with custom ImageSaveOptions
        public void ConvertHtmlToPngWithImageSaveOptions()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-output-options.png");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions()
            {
                UseAntialiasing = false,
                HorizontalResolution = 100,
                VerticalResolution = 100,
                BackgroundColor = System.Drawing.Color.Beige
            };

            // Convert HTML to PNG
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to PNG using a custom memory‑stream provider
        public void ConvertHtmlToPngWithCustomStreamProvider()
        {
            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to PNG File Format!</h1>", ".");

            // Convert HTML to PNG using the MemoryStreamProvider
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Png), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.png")))
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