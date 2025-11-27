using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Advanced_Programming
{
    public class OutputStreams : TestsBase
    {
        public OutputStreams(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("advanced-programming/output-streams");
        }

        // @START_SNIPPET MemoryStreamProvider.cs
        // How to capture output in memory using a custom stream provider
        // Learn more: https://docs.aspose.com/html/net/output-streams/

        class MemoryStreamProvider : ICreateStreamProvider
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
        // @END_SNIPPET


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void SpecifyCustomStreamProviderTest()
        {
            // Create an instance of MemoryStreamProvider
            using (MemoryStreamProvider streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (HTMLDocument document = new HTMLDocument(@"<span>Hello, World!!</span>", "."))
                {
                    // Convert HTML to Image by using the MemoryStreamProvider
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

                    // Get access to the memory stream that contains the result data
                    MemoryStream memory = streamProvider.Streams.First();
                    memory.Seek(0, SeekOrigin.Begin);

                    // Flush the result data to the output file
                    using (FileStream fs = File.Create(Path.Combine(OutputDir, "output.jpg")))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }
            Assert.True(File.Exists(Path.Combine(OutputDir, "output.jpg")));
        }


        [Fact(DisplayName = "Specify Custom Stream Provider")]
        public void SpecifyCustomStreamProvider2Test()
        {
            // Create an instance of MemoryStreamProvider
            using (MemoryStreamProvider streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (HTMLDocument document = new HTMLDocument(@"<span>Hello, World!!</span>", "."))
                {
                    // Convert HTML to Image by using the MemoryStreamProvider
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

                    // Get access to the memory stream that contains the result data
                    int page = 0;
                    foreach (MemoryStream memory in streamProvider.Streams)
                    {
                        memory.Seek(0, SeekOrigin.Begin);

                        // Flush the result data to the output file
                        using (FileStream fs = File.Create(Path.Combine(OutputDir, "word_" + page + ".jpg")))
                        {
                            memory.CopyTo(fs);
                        }
                        page++;
                    }
                }
            }
            Assert.True(File.Exists(Path.Combine(OutputDir, "word_0.jpg")));
        }


        [Fact(DisplayName = "Using Custom Stream Provider to Convert HTML to JPEG")]
        public void CustomStreamProviderTest()
        {
            // @START_SNIPPET UsingCustomStreamProviderToConvertHtmlToJpeg.cs
            // Convert HTML to JPEG in C# using output memory streams for writing data
            // Learn more: https://docs.aspose.com/html/net/output-streams/

            // Create an instance of MemoryStreamProvider
            using (MemoryStreamProvider streamProvider = new MemoryStreamProvider())
            {
                // Prepare HTML code
                string code = @"<style>
                            div { page-break-after: always; }
                            </style>
                            <div style='border: 1px solid red; width: 300px'>First Page</div>
                            <div style='border: 1px solid red; width: 300px'>Second Page</div>
                            <div style='border: 1px solid red; width: 300px'>Third Page</div>
	                        ";
                // Initialize an HTML document from the HTML code
                using HTMLDocument document = new HTMLDocument(code, ".");
                {
                    // Convert HTML to Image by using the MemoryStreamProvider
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);

                    // Get access to the memory stream that contains the result data
                    int page = 1;
                    foreach (MemoryStream memory in streamProvider.Streams)
                    {
                        memory.Seek(0, SeekOrigin.Begin);

                        // Flush the result data to the output file
                        using (FileStream fs = File.Create(Path.Combine(OutputDir, "page_" + page + ".jpg")))
                        {
                            memory.CopyTo(fs);
                        }
                        page++;
                    }
                }
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "page_1.jpg")));
        }
    }
}
