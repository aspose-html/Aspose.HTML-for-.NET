using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertSVGToPDF
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Prepare an SVG code.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";

            // Call the ConvertSVG method to convert the SVG code to PDF.
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
            //ExEnd: WithASingleLine
        }

        public static void ConvertSVGDocumentToPDF()
        {
            //ExStart: ConvertSVGDocumentToPDF
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize PdfSaveOptions.
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.pdf");
            }
            //ExEnd: ConvertSVGDocumentToPDF
        }

        public static void SpecifyPdfSaveOptions()
        {
            //ExStart: SpecifyPdfSaveOptions
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Set A5 as a page-size and change the background color to green
            var options = new Aspose.Html.Saving.PdfSaveOptions()
            {
                PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromInches(8.3f), Aspose.Html.Drawing.Length.FromInches(5.8f))
                    }
                },
                BackgroundColor = System.Drawing.Color.Green,
            };
            // Convert SVG document to PDF
            Aspose.Html.Converters.Converter.ConvertSVG("document.svg", options, "output.pdf");
            //ExEnd: SpecifyPdfSaveOptions
        }

        public static void SpecifyCustomStreamProvider()
        {
            //ExStart: SpecifyCustomStreamProvider
            // Create an instance of MemoryStreamProvider
            using (var streamProvider = new MemoryStreamProvider())
            {

                // Prepare an SVG code
                var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                           "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                           "</svg>";

                // Initialize an SVG document
                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(code, "."))
                {
                    // Convert SVG to PDF by using the MemoryStreamProvider
                    Aspose.Html.Converters.Converter.ConvertSVG(document, new Aspose.Html.Saving.PdfSaveOptions(), streamProvider);

                    // Get access to the memory stream that contains the result data
                    var memory = streamProvider.Streams.First();
                    memory.Seek(0, System.IO.SeekOrigin.Begin);

                    // Flush the result data to the output file
                    using (System.IO.FileStream fs = System.IO.File.Create("output.pdf"))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }
            //ExEnd: SpecifyCustomStreamProvider
        }

        class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            // List of MemoryStream objects created during the document rendering
            public List<System.IO.MemoryStream> Streams { get; } = new List<System.IO.MemoryStream>();

            public System.IO.Stream GetStream(string name, string extension)
            {
                // This method is called when the only one output stream is required, for instance for XPS, PDF or TIFF formats.
                System.IO.MemoryStream result = new System.IO.MemoryStream();
                Streams.Add(result);
                return result;
            }

            public System.IO.Stream GetStream(string name, string extension, int page)
            {
                // This method is called when the creation of multiple output streams are required. For instance during the rendering HTML to list of the image files (JPG, PNG, etc.)
                System.IO.MemoryStream result = new System.IO.MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(System.IO.Stream stream)
            {
                //  Here You can release the stream filled with data and, for instance, flush it to the hard-drive
            }

            public void Dispose()
            {
                // Releasing resources
                foreach (var stream in Streams)
                    stream.Dispose();
            }
        }
    }
}
