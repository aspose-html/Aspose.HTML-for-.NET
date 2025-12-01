using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using System.Collections.Generic;

namespace Aspose.Html.Examples
{
    public class SavingDocumentExample : BaseExample
    {
        public SavingDocumentExample()
        {
            // Sub‑directory for this example's output files
            SetOutputDir("saving");
        }

        /// <summary>
        /// Save an HTML document to a file
        /// </summary>
        public void SaveHtmlToFile()
        {
            string outputPath = Path.Combine(OutputDir, "save-to-file.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                Text txt = doc.CreateTextNode("Hello, World!");
                doc.Body.AppendChild(txt);
                doc.Save(outputPath);
                Console.WriteLine($"HTML saved to file: {outputPath}");
            }
        }

        /// <summary>
        /// Save an HTML document with a linked file, controlling resource depth
        /// </summary>
        public void SaveHtmlWithLinkedFile()
        {
            string htmlPath = Path.Combine(OutputDir, "save-with-linked-file.html");
            File.WriteAllText(htmlPath, "<p>Hello, World!</p><a href='linked.html'>linked file</a>");
            File.WriteAllText(Path.Combine(OutputDir, "linked.html"), "<p>Hello, linked file!</p>");

            using (HTMLDocument doc = new HTMLDocument(htmlPath))
            {
                HTMLSaveOptions options = new HTMLSaveOptions();
                options.ResourceHandlingOptions.MaxHandlingDepth = 1; // include linked file
                doc.Save(Path.Combine(OutputDir, "save-with-linked-file_out.html"), options);
                Console.WriteLine("HTML with linked file saved.");
            }
        }

        /// <summary>
        /// Save an HTML document and all its resources into a ZIP archive
        /// </summary>
        public void SaveHtmlWithResourcesToZip()
        {
            string inputPath = Path.Combine(DataDir, "with-resources.html");
            // Resolve the archive path to the example's output directory and ensure it exists.
            string archivePath = Path.GetFullPath(
                Path.Combine(OutputDir, "archive.zip"));

            using (HTMLDocument doc = new HTMLDocument(inputPath))
            {
                using (ZipResourceHandler handler = new ZipResourceHandler(archivePath))
                {
                    doc.Save(handler);
                    Console.WriteLine($"HTML with resources saved to ZIP: {archivePath}");
                }
            }
        }

        /// <summary>
        /// Save an HTML document to memory using a custom resource handler
        /// </summary>
        public void SaveHtmlToMemory()
        {
            string inputPath = Path.Combine(DataDir, "with-resources.html");
            using (HTMLDocument doc = new HTMLDocument(inputPath))
            {
                MemoryResourceHandler handler = new MemoryResourceHandler();
                doc.Save(handler);
                Console.WriteLine("HTML saved to memory (custom handler).");
            }
        }

        /// <summary>
        /// Save an HTML document as MHTML
        /// </summary>
        public void SaveHtmlToMHTML()
        {
            string savePath = Path.Combine(OutputDir, "save-to-mhtml.mht");
            File.WriteAllText("save-to-mhtml.html", "<p>Hello, World!</p><a href='linked-file.html'>linked file</a>");
            File.WriteAllText("linked-file.html", "<p>Hello, linked file!</p>");

            using (HTMLDocument doc = new HTMLDocument("save-to-mhtml.html"))
            {
                doc.Save(savePath, HTMLSaveFormat.MHTML);
                Console.WriteLine($"HTML saved as MHTML: {savePath}");
            }
        }

        /// <summary>
        /// Save an HTML document as Markdown
        /// </summary>
        public void SaveHtmlToMD()
        {
            string outputPath = Path.Combine(OutputDir, "save-html-to-markdown.md");
            string htmlCode = "<h2>Hello, World!</h2>";
            using (HTMLDocument doc = new HTMLDocument(htmlCode, "."))
            {
                doc.Save(outputPath, HTMLSaveFormat.Markdown);
                Console.WriteLine($"HTML saved as Markdown: {outputPath}");
            }
        }

        /// <summary>
        /// Save an HTML document as SVG
        /// </summary>
        public void SaveHtmlToSVG()
        {
            string outputPath = Path.Combine(OutputDir, "create-and-save-svg.svg");
            string code = @"
                <svg xmlns='http://www.w3.org/2000/svg' height='200' width='300'>
                    <g fill='none' stroke-width='10' stroke-dasharray='30 10'>
                        <path stroke='red' d='M 25 40 l 215 0' />
                        <path stroke='black' d='M 35 80 l 215 0' />
                        <path stroke='blue' d='M 45 120 l 215 0' />
                    </g>
                </svg>";
            using (SVGDocument doc = new SVGDocument(code, "."))
            {
                doc.Save(outputPath);
                Console.WriteLine($"HTML saved as SVG: {outputPath}");
            }
        }

        // -----------------------------------------------------------------
        // Helper classes – mirrors the test implementations
        // -----------------------------------------------------------------
        private class MemoryResourceHandler : ResourceHandler
        {
            public List<Tuple<Stream, Resource>> Streams { get; } = new List<Tuple<Stream, Resource>>();

            public override void HandleResource(Resource resource, ResourceHandlingContext context)
            {
                MemoryStream ms = new MemoryStream();
                Streams.Add(Tuple.Create<Stream, Resource>(ms, resource));
                resource.WithOutputUrl(new Url(Path.GetFileName(resource.OriginalUrl.Pathname), "memory:///"))
                       .Save(ms, context);
            }

            public void PrintInfo()
            {
                foreach (var s in Streams)
                {
                    Console.WriteLine($"uri:{s.Item2.OutputUrl}, length:{s.Item1.Length}");
                }
            }
        }

        private class ZipResourceHandler : ResourceHandler, IDisposable
        {
            private FileStream zipStream;
            private ZipArchive archive;
            private int counter;
            private bool initialized;

            public ZipResourceHandler(string name)
            {
                zipStream = new FileStream(name, FileMode.Create);
                // Use leaveOpen:true so that disposing the ZipArchive does not close the underlying FileStream.
                archive = new ZipArchive(zipStream, ZipArchiveMode.Update, true);
                initialized = false;
                counter = 0;
            }

            public override void HandleResource(Resource resource, ResourceHandlingContext context)
            {
                string zipUri = (counter++ == 0
                    ? Path.GetFileName(resource.OriginalUrl.Href)
                    : Path.Combine(Path.GetFileName(Path.GetDirectoryName(resource.OriginalUrl.Href)),
                        Path.GetFileName(resource.OriginalUrl.Href)));

                string prefix = initialized ? "my_" : "";
                if (!initialized) initialized = true;

                using (Stream s = archive.CreateEntry(prefix + zipUri).Open())
                {
                    resource.WithOutputUrl(new Url("file:///" + prefix + zipUri)).Save(s, context);
                }
            }

            public void Dispose()
            {
                archive?.Dispose();
                zipStream?.Dispose();
            }
        }
    }
}