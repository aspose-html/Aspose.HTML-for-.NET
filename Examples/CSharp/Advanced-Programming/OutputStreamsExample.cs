using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates how to capture output in memory using a custom stream provider and save images
    /// </summary>
    public class OutputStreamsExample : BaseExample
    {
        public OutputStreamsExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("advanced-programming/output-streams");
        }

        // -----------------------------------------------------------------
        // Helper class – custom stream provider
        // -----------------------------------------------------------------
        private class MemoryStreamProvider : ICreateStreamProvider, IDisposable
        {
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                var result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                var result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream)
            {
                // No special handling required for this example
            }

            public void Dispose()
            {
                foreach (var stream in Streams)
                {
                    stream.Dispose();
                }
            }
        }

        // -----------------------------------------------------------------
        // Example 1 – single output stream (e.g., PDF, JPEG, etc.)
        // -----------------------------------------------------------------
        public void SpecifyCustomStreamProvider()
        {
            using (var streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (var document = new HTMLDocument(@"<span>Hello, World!!</span>", "."))
                {
                    // Convert HTML to Image using the custom stream provider
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
                }

                // Retrieve the generated image from the memory stream
                MemoryStream memory = streamProvider.Streams.First();
                memory.Seek(0, SeekOrigin.Begin);

                // Save the image to a file
                string outputPath = Path.Combine(OutputDir, "output.jpg");
                using (FileStream fs = File.Create(outputPath))
                {
                    memory.CopyTo(fs);
                }

                Console.WriteLine($"Image saved to: {outputPath}");
            }
        }

        // -----------------------------------------------------------------
        // Example 2 – multiple output streams (e.g., multi‑page output)
        // -----------------------------------------------------------------
        public void SpecifyCustomStreamProviderMultiple()
        {
            using (var streamProvider = new MemoryStreamProvider())
            {
                using (var document = new HTMLDocument(@"<span>Hello, World!!</span>", "."))
                {
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
                }

                int page = 0;
                foreach (MemoryStream memory in streamProvider.Streams)
                {
                    memory.Seek(0, SeekOrigin.Begin);
                    string outputPath = Path.Combine(OutputDir, $"page_{page}.jpg");
                    using (FileStream fs = File.Create(outputPath))
                    {
                        memory.CopyTo(fs);
                    }
                    Console.WriteLine($"Page {page} image saved to: {outputPath}");
                    page++;
                }
            }
        }

        // -----------------------------------------------------------------
        // Example 3 – custom stream provider with multiple images from HTML
        // -----------------------------------------------------------------
        public void CustomStreamProvider()
        {
            using (var streamProvider = new MemoryStreamProvider())
            {
                // HTML code that generates several pages
                string code = @"
                    <style>
                        div { page-break-after: always; }
                    </style>
                    <div style='border:1px solid red; width:300px'>First Page</div>
                    <div style='border:1px solid red; width:300px'>Second Page</div>
                    <div style='border:1px solid red; width:300px'>Third Page</div>";

                using (var document = new HTMLDocument(code, "."))
                {
                    Converter.ConvertHTML(document, new ImageSaveOptions(ImageFormat.Jpeg), streamProvider);
                }

                int page = 1;
                foreach (MemoryStream memory in streamProvider.Streams)
                {
                    memory.Seek(0, SeekOrigin.Begin);
                    string outputPath = Path.Combine(OutputDir, $"page_{page}.jpg");
                    using (FileStream fs = File.Create(outputPath))
                    {
                        memory.CopyTo(fs);
                    }
                    Console.WriteLine($"Custom page {page} image saved to: {outputPath}");
                    page++;
                }
            }
        }
    }
}