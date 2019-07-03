using Aspose.Html.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithICreateStreamProvider
{
    // ExStart:1
    public class MemoryStreamProvider : ICreateStreamProvider
    {
        // List of MemoryStream objects created during the document rendering
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        public Stream GetStream(string name, string extension)
        {
            // This method is called when the only one output stream is required, for instance for XPS, PDF or TIFF formats
            MemoryStream result = new MemoryStream();
            Streams.Add(result);
            return result;
        }

        public Stream GetStream(string name, string extension, int page)
        {
            // This method is called when the creation of multiple output streams are required. For instance during the rendering HTML to list of the image files (JPG, PNG, etc.)
            MemoryStream result = new MemoryStream();
            Streams.Add(result);
            return result;
        }

        public void ReleaseStream(Stream stream)
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
    // ExStart:1
}
