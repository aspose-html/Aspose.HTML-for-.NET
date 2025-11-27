using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.SVG_Converter
{
    public class SVGtoPDFTests : TestsBase
    {
        public SVGtoPDFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("svg-converter/svg-to-pdf");
        }


        [Fact(DisplayName = "Convert SVG to PDF With a Single Line")]
        public void ConvertSVGtoPDFWithASingleLineTest()
        {
            // @START_SNIPPET ConvertSvgToPdfInOneLine.cs
            // Convert SVG to PDF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-pdf/

            // Invoke the ConvertSVG() method for SVG to PDF conversion
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new PdfSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.pdf"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-with-single-line.pdf")));
        }


        [Fact(DisplayName = "Convert SVG to PDF")]
        public void ConvertSVGtoPDFTest()
        {
            // @START_SNIPPET ConvertSvgToPdf.cs
            // Convert SVG to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-pdf/

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx ='100' cy ='100' r ='50' fill='none' stroke='red' stroke-width='5' />" +
                          "</svg>";

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "circle.pdf");
           
            // Initialize PdfSaveOptions
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert SVG to PDF
            Converter.ConvertSVG(code, ".", options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "SVG to PDF With PdfSaveOptions")]
        public void SVGtoPDFWithPdfSaveOptionsTest()
        {
            // @START_SNIPPET ConvertSvgToPdfWithPdfSaveOptions.cs
            // Convert SVG to PDF in C# with custom page settings
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-pdf/

            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "aspose.svg");

            // Prepare a path for converted file saving
            string savePath = Path.Combine(OutputDir, "aspose-options.pdf");

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);

            // Initialize PdfSaveOptions. Set up the page-size, margins, resolutions, JpegQuality, and change the background color to AliceBlue
            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                JpegQuality = 100
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 500), new Margin(30, 10, 10, 10));

            // Convert SVG to PDF
            Converter.ConvertSVG(document, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "aspose-options.pdf")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void SVGtoPDFCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertSvgToPdfWithCustomStreamProvider.cs
            // Convert SVG to PDF in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-svg-to-pdf/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                          "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                          "</svg>";

            // Convert SVG to PDF using the MemoryStreamProvider
            Converter.ConvertSVG(code, ".", new PdfSaveOptions(), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.pdf")))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "stream-provider.pdf")));
        }


        class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            // List of MemoryStream objects created during the document rendering
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                // This method is called when only one output stream is required, for instance for XPS, PDF or TIFF formats
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of image files (JPG, PNG, etc.)
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream)
            {
                // Here you can release the stream filled with data and, for instance, flush it to the hard-drive
            }

            public void Dispose()
            {
                // Releasing resources
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
    }
}
