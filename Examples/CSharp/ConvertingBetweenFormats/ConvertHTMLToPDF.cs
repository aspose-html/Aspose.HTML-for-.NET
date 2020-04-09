using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertHTMLToPDF
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Invoke the ConvertHTML method to convert the HTML to PDF.
            Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello World!!</span>", ".", new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
            //ExEnd: WithASingleLine
        }

        public static void ConvertHTMLDocumentToPDF()
        {
            //ExStart: ConvertHTMLDocumentToPDF
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the file
            using (var document = new HTMLDocument("document.html"))
            {
                // Initialize PdfSaveOptions 
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            }
            //ExEnd: ConvertHTMLDocumentToPDF
        }

        public static void SpecifyPdfSaveOptions()
        {
            //ExStart: SpecifyPdfSaveOptions
            // Prepare an HTML code and save it to the file
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

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
            // Convert HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", options, "output.pdf");
            //ExEnd: SpecifyPdfSaveOptions
        }

        public static void SpecifyCustomStreamProvider()
        {
            //ExStart: SpecifyCustomStreamProvider
            // Create an instance of MemoryStreamProvider
            using (var streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (var document = new Aspose.Html.HTMLDocument(@"<span>Hello World!!</span>", "."))
                {
                    // Convert HTML to PDF by using the MemoryStreamProvider
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), streamProvider);

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
