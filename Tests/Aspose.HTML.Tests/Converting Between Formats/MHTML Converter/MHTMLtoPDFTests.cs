using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.MHTML_Converter
{
    public class MHTMLtoPDFTests : TestsBase
    {
        public MHTMLtoPDFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("mhtml-converter/mhtml-to-pdf");
        }


        [Fact(DisplayName = "Convert MHTML to PDF by Two Lines of Code")]
        public void ConvertMHTMLtoPDFbyTwoLinesTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdfWithTwoLinesOfCode.cs
            // Convert MHTML to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-pdf/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Invoke the ConvertMHTML() method to convert MHTML to PDF
            Converter.ConvertMHTML(stream, new PdfSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.pdf"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.pdf")));
        }


        [Fact(DisplayName = "Convert MHTML to PDF")]
        public void ConvertMHTMLToPDFTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdf.cs
            // Convert MHTML to PDF in C#
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-pdf/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "sample-output.pdf");

            // Create an instance of PdfSaveOptions
            PdfSaveOptions options = new PdfSaveOptions();

            // Call the ConvertMHTML() method to convert MHTML to PDF
            Converter.ConvertMHTML(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "MHTML to PDF With PdfSaveOptions")]
        public void MHTMLtoPDFWithPdfSaveOptionsTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdfWithCustomSettings.cs
            // Convert MHTML to PDF in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-pdf/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "sample-options.pdf");

            // Create an instance of PdfSaveOptions. Set up the page-size and change the background color to AliceBlue
            PdfSaveOptions options = new PdfSaveOptions()
            {
                PageSetup =
                    {
                        AnyPage = new Page()
                        {
                            Size = new Aspose.Html.Drawing.Size(Length.FromPixels(3000), Length.FromPixels(1000))
                        }
                    },
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Call the ConvertMHTML() method to convert MHTML to PDF
            Converter.ConvertMHTML(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void MHTMLtoPDFCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdfWithCustomStreamProvider.cs
            // Convert MHTML to PDF in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-mhtml-to-pdf/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "stream-provider.pdf");

            // Convert MHTML to PDF by using the MemoryStreamProvider class
            Converter.ConvertMHTML(stream, new PdfSaveOptions(), streamProvider);

            // Get access to the memory stream that contains the result data
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);

            // Flush the result data to the output file
            using (FileStream fs = File.Create(savePath))
            {
                memory.CopyTo(fs);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
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
                // This method is called when the creation of multiple output streams are required. For instance, during the rendering HTML to list of the image files (JPG, PNG, etc.)
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
