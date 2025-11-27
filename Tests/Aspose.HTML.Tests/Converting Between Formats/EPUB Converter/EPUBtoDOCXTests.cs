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
    public class EPUBtoDOCXTests
    : TestsBase
    {
        public EPUBtoDOCXTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("epub-converter/epub-to-docx");
        }


        [Fact(DisplayName = "Convert EPUB to DOCX in Two Lines")]
        public void ConvertEPUBbyTwoLinesTest()
        {
            // @START_SNIPPET ConvertEpubToDocxInTwoLinesOfCode.cs
            // Convert EPUB to DOCX using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-docx/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Invoke the ConvertEPUB() method to convert EPUB to DOCX
            Converter.ConvertEPUB(stream, new DocSaveOptions(), Path.Combine(OutputDir, "convert-by-two-lines.docx"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-by-two-lines.docx")));
        }


        [Fact(DisplayName = "Convert EPUB to DOCX")]
        public void ConvertEPUBToDOCXTest()
        {
            // @START_SNIPPET ConvertEpubToDocx.cs
            // Convert EPUB to DOCX using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-docx/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-output.docx");

            // Create an instance of the DocSaveOptions class
            DocSaveOptions options = new DocSaveOptions();

            // Call the ConvertEPUB() method to convert EPUB to DOCX
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "EPUB to DOCX With DocSaveOptions")]
        public void EPUBtoDOCXWithDocSaveOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToDocxWithDocSaveOptions.cs
            // Convert EPUB to DOCX with custom settings using C#
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-docx/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "input-options.docx");

            // Create an instance of DocSaveOptions. Set A5 as a page-size
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(8.3f), Length.FromInches(5.8f)));

            // Call the ConvertEPUB() method to convert EPUB to DOCX
            Converter.ConvertEPUB(stream, options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void EPUBtoDOCXCustomStreamProviderTest()
        {
            // @START_SNIPPET ConvertEpubToDocxWithCustomStreamProvider.cs
            // Convert EPUB to DOCX in C# using memory stream
            // Learn more: https://docs.aspose.com/html/net/convert-epub-to-docx/

            // Create an instance of MemoryStreamProvider
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "stream-provider.docx");

            // Convert EPUB to DOCX by using the MemoryStreamProvider class
            Converter.ConvertEPUB(stream, new DocSaveOptions(), streamProvider);

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
