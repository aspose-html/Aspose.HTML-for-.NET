using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using System.Collections.Generic;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Examples derived from Tests/Aspose.HTML.Tests/Working-with-HTML-Documents/SaveSvgTests.cs
    /// </summary>
    public class SaveSvgExample : BaseExample
    {
        public SaveSvgExample()
        {
            // Sub‑directory for this example's output files
            SetOutputDir("save-svg");
        }

        /// <summary>
        /// Save an SVG document to a file.
        /// </summary>
        public void SaveSvg()
        {
            string outputPath = Path.Combine(OutputDir, "save-to-svg.svg");
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
                Console.WriteLine($"SVG saved to: {outputPath}");
            }
        }

        /// <summary>
        /// Save an SVG document to memory using a custom resource handler.
        /// </summary>
        public void NewMemorySave()
        {
            string inputPath = Path.Combine(DataDir, "flower.svg");
            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                MemoryResourceHandler handler = new MemoryResourceHandler();
                doc.Save(handler);
                handler.PrintInfo();
                Console.WriteLine("SVG saved to memory (custom handler).");
            }
        }

        /// <summary>
        /// Save an SVG document and its resources to a ZIP archive.
        /// </summary>
        public void NewZipSave()
        {
            string inputPath = Path.Combine(DataDir, "with-resources.svg");
            string dir = Directory.GetCurrentDirectory();
            string archivePath = Path.Combine(dir, "./../../../../tests-out/save-svg/new/archive.zip");

            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                using (ZipResourceHandler handler = new ZipResourceHandler(archivePath))
                {
                    doc.Save(handler);
                    Console.WriteLine($"SVG with resources saved to ZIP: {archivePath}");
                }
            }
        }

        /// <summary>
        /// Save an SVG document to a local folder using the new FileSystemResourceHandler.
        /// </summary>
        public void NewStorageSave()
        {
            string inputPath = Path.Combine(DataDir, "with-resources.svg");
            string outDir = Path.Combine(Directory.GetCurrentDirectory(), "./../../../../tests-out/save-svg/new/");

            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                doc.Save(new FileSystemResourceHandler(outDir));
                Console.WriteLine($"SVG with resources saved to folder: {outDir}");
            }
        }

        // -----------------------------------------------------------------
        // Helper classes (mirroring the test implementation)
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
                archive = new ZipArchive(zipStream, ZipArchiveMode.Update);
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