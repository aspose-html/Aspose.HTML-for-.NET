using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.EPUB_Converter
{
    public class EPUBtoPDFTests : TestsBase
    {
        public EPUBtoPDFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-pdf");
        }


        [Fact(DisplayName = "Convert EPUB to PDF by Two Lines")]
        public void ConvertEPUBtoPDFbyTwoLinesTest()
        {
            // @START_SNIPPET ConvertEpubToPdfInTwoLinesOfCode.cs
            // Convert EPUB to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-pdf/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to PDF
            Converter.ConvertEPUB(stream, new PdfSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.pdf"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.pdf")));
        }


        [Fact(DisplayName = "Convert EPUB to PDF")]
        public void ConvertEPUBtoPDFTest()
        {
            // @START_SNIPPET ConvertEpubToPdf.cs
            // Convert EPUB to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-pdf/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-output.pdf");

            // Create an instance of the PdfSaveOptions class
            PdfSaveOptions options = new PdfSaveOptions();

            // Call the ConvertEPUB() method to convert EPUB to PDF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert EPUB to PDF Test2")]
        public void ConvertEPUBToPDFTest2()
        {
            // Prepare a path to a source EPUB file
            string documentPath = Path.Combine(DataDir, "input.epub");
           
            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-output2.pdf");

            // Create an instance of the PdfSaveOptions class
            PdfSaveOptions options = new PdfSaveOptions();

            // Call the ConvertEPUB() method to convert EPUB to PDF
            Converter.ConvertEPUB(documentPath, options, savePath);

            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "EPUB to PDF With PdfSaveOptions")]
        public void EPUBtoPDFWithPdfSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToPdfWithPdfSaveOptions.cs
            // Convert EPUB to PDF in C# with custom settings
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-pdf/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-options.pdf");

            // Create an instance of PdfSaveOptions. Set up the page-size and change the background color to AliceBlue 
            PdfSaveOptions options = new PdfSaveOptions()
            {
                PageSetup =
                    {
                        AnyPage = new Page()
                        {
                            Size = new Aspose.Html.Drawing.Size(Length.FromPixels(1000), Length.FromPixels(1000))
                        }
                    },
                BackgroundColor = System.Drawing.Color.AliceBlue
            };

            // Call the ConvertEPUB() method to convert EPUB to PDF
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void EPUBtoPdfCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertEpubToPdfWithCustomStreamProvider.cs
            // Convert EPUB to PDF in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-pdf/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "stream-provider.pdf");

            // Convert EPUB to PDF by using the MemoryStreamProvider class
            Converter.ConvertEPUB(stream, new PdfSaveOptions(), streamProvider);

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
