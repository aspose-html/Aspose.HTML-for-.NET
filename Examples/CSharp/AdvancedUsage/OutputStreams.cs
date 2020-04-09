using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.AdvancedUsage
{
    static class OutputStreams
    {
        public static void StreamProviderUsageExample()
        {
            //ExStart: StreamProviderUsageExample
            // Create an instance of MemoryStreamProvider
            using (var streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (var document = new Aspose.Html.HTMLDocument(@"<span>Hello World!!</span>", "."))
                {
                    // Convert HTML to Image by using the MemoryStreamProvider
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg), streamProvider);

                    // Get access to the memory stream that contains the result data
                    var memory = streamProvider.Streams.First();
                    memory.Seek(0, System.IO.SeekOrigin.Begin);

                    // Flush the result data to the output file
                    using (System.IO.FileStream fs = System.IO.File.Create("output.jpg"))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }
            //ExEnd: StreamProviderUsageExample
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
