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
    public class HTMLtoJPGExample : BaseExample
    {
        public HTMLtoJPGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-jpg");
        }

        // Convert HTML to JPG with a single line
        public void ConvertHtmlToJpgWithSingleLine()
        {
            // Convert HTML to JPG in C#
            Converter.ConvertHTML(@"<h1>Convert HTML to JPG!</h1>", ".", new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-with-single-line.jpg"));
        }

        // Convert HTML to JPG from a file
        public void ConvertHtmlToJpg()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "spring-output.jpg");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to JPG with ImageSaveOptions
        public void ConvertHtmlToJpgWithImageSaveOptions()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "color.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "color-output-options.jpg");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 500), new Margin(30, 20, 10, 10));

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);
        }

        // Specify ImageSaveOptions with custom page size and background
        public void SpecifyImageSaveOptions()
        {
            // Prepare a path for the HTML source file
            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.jpg");

            // Prepare HTML code and save it to a file
            string code = "<h1> Image SaveOptions </h1>\r\n" +
                          "<p>Using ImageSaveOptions Class, you can programmatically apply a wide range of conversion parameters such as BackgroundColor, Format, Compression, PageSetup, etc.</p>\r\n";
            File.WriteAllText(documentPath, code);

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions with custom background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                BackgroundColor = System.Drawing.Color.AntiqueWhite
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 250), new Margin(40, 40, 20, 20));

            // Convert HTML to JPG
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to JPG using a custom memory‑stream provider
        public void ConvertHtmlToJpgWithCustomStreamProvider()
        {
            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Initialize an HTML document from a string
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to JPG File Format!</h1>", ".");

            // Convert HTML to JPG using the MemoryStreamProvider
            Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.jpg")))
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