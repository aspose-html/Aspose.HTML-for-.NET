using Aspose.Html;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.IO;
using Aspose.Html.Dom.Svg;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class SVGtoPDFExample : BaseExample
    {
        public SVGtoPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-pdf");
        }

        // Convert SVG to PDF in one line
        public void ConvertSVGToPdfWithSingleLine()
        {
            // Convert SVG to PDF
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new PdfSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.pdf"));
        }

        // Convert SVG to PDF
        public void ConvertSVGToPdf()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='50' fill='none' stroke='red' stroke-width='5' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.pdf");
            // Initialize PdfSaveOptions
            PdfSaveOptions options = new PdfSaveOptions();
            // Convert SVG to PDF
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to PDF with custom page settings
        public void ConvertSVGToPdfWithPdfSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "aspose.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "aspose-options.pdf");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize PdfSaveOptions with custom settings
            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 100
            };
            options.PageSetup.AnyPage = new Page(new Size(500, 500), new Margin(30, 10, 10, 10));
            // Convert SVG to PDF
            Converter.ConvertSVG(document, options, savePath);
        }

        // Convert SVG to PDF using a custom stream provider
        public void ConvertSVGToPdfWithCustomStreamProvider()
        {
            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>";
            // Convert SVG to PDF using the MemoryStreamProvider
            Converter.ConvertSVG(code, ".", new PdfSaveOptions(), streamProvider);
            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);
            // Flush the result data to the output file
            using FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.pdf"));
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