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
    public class HTMLtoBMPExample : BaseExample
    {
        public HTMLtoBMPExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-bmp");
        }

        // Convert HTML to BMP using C#
        public void ConvertHtmlToBmp()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "bmp.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "bmp-output.bmp");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert HTML to BMP
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to BMP with ImageSaveOptions using C#
        public void ConvertHtmlToBmpWithImageSaveOptions()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "bmp.html");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "bmp-output-options.bmp");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                UseAntialiasing = false,
                HorizontalResolution = 350,
                VerticalResolution = 350,
                BackgroundColor = System.Drawing.Color.Beige
            };

            // Convert HTML to BMP
            Converter.ConvertHTML(document, options, savePath);
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