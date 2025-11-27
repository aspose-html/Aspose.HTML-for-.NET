using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Working_with_HTML_Documents
{
    public class SaveSvgTests : TestsBase
    {
        public SaveSvgTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("save-svg");
        }

        [Fact(DisplayName = "Save SVG ")]
        public void SaveSVGTest()
        {
            // Prepare an output path for an SVG document saving
            string documentPath = Path.Combine(OutputDir, "save-to-svg.svg");

            // Prepare SVG code
            string code = @"
        <svg xmlns='http://www.w3.org/2000/svg' height='200' width='300'>
            <g fill='none' stroke-width= '10' stroke-dasharray='30 10'>
                <path stroke='red' d='M 25 40 l 215 0' />
                <path stroke='black' d='M 35 80 l 215 0' />
                <path stroke='blue' d='M 45 120 l 215 0' />
            </g>
        </svg>";

            // Initialize an SVG instance from the content string
            using (SVGDocument document = new SVGDocument(code, "."))
            {
                // Save the SVG file to a disk
                document.Save(documentPath);
            }
        }


        [Fact(DisplayName = "New Memory Save")]
        public void NewMemorySave()
        {
            // Prepare a path to a source SVG file
            string inputPath = Path.Combine(DataDir, "flower.svg");

            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                // Create an instance of the MemoryResourceHandler class and save SVG to memory
                MemoryResourceHandler resourceHandler = new MemoryResourceHandler();
                doc.Save(resourceHandler);
                resourceHandler.PrintInfo();

                //Output.WriteLine(memoryStorage.GetInfo());
            }
        }

        /*
        [Fact(DisplayName = "Old Memory Save")]
        public void OldMemorySave()
        {
            // Prepare a path to a source SVG file
            string inputPath = Path.Combine(DataDir, "flower.svg");

            using (var doc = new SVGDocument(inputPath))
            {
                // Create an instance of the MemoryOutputStorage class and save SVG to memory
                var memoryStorage = new MemoryOutputStorage();
                doc.Save(memoryStorage);
                memoryStorage.PrintInfo();
            }
        }        


        internal class MemoryOutputStorage : IOutputStorage
        {
            public List<Tuple<OutputStream, string>> Streams;

            public MemoryOutputStorage()
            {
                Streams = new List<Tuple<OutputStream, string>>();
            }

            public OutputStream CreateStream(OutputStreamContext context)
            {
                var normalizedPath = new Url(context.Uri).Pathname;
                var uri = new Url(Path.GetFileName(normalizedPath), "memory:///").Href;
                var outputStream = new OutputStream(new MemoryStream(), uri);
                Streams.Add(Tuple.Create(outputStream, uri));
                return outputStream;
            }

            public void ReleaseStream(OutputStream stream)
            {
                stream.Flush();
            }

            public void PrintInfo()
            {
                foreach (var stream in Streams)
                    Console.WriteLine($"uri:{stream.Item2}, length:{stream.Item1.Length}");
            }
        }
        */
        internal class MemoryResourceHandler : ResourceHandler
        {
            public List<Tuple<Stream, Resource>> Streams;

            public MemoryResourceHandler()
            {
                Streams = new List<Tuple<Stream, Resource>>();
            }

            public override void HandleResource(Resource resource, ResourceHandlingContext context)
            {
                MemoryStream outputStream = new MemoryStream();
                Streams.Add(Tuple.Create<Stream, Resource>(outputStream, resource));
                resource
                    .WithOutputUrl(new Url(Path.GetFileName(resource.OriginalUrl.Pathname), "memory:///"))
                    .Save(outputStream, context);
            }

            public void PrintInfo()
            {
                foreach (Tuple<Stream, Resource> stream in Streams)
                    Console.WriteLine($"uri:{stream.Item2.OutputUrl}, length:{stream.Item1.Length}");
            }
        }


        [Fact(DisplayName = "New Zip Save")]
        public void NewZipSave()
        {
            // Prepare a path to a source SVG file 
            string inputPath = Path.Combine(DataDir, "with-resources.svg");

            string dir = Directory.GetCurrentDirectory();

            // Prepare a full path to an output zip storage
            string customArchivePath = Path.Combine(dir, "./../../../../tests-out/save-svg/new/archive.zip");

            // Load the SVG document 
            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                // Initialize an instance of the ZipResourceHandler class
                using (ZipResourceHandler resourceHandler = new ZipResourceHandler(customArchivePath))
                {
                    // Save SVG with resources to a Zip archive
                    doc.Save(resourceHandler);
                }
            }
        }

        /*
        [Fact(DisplayName = "Old Zip Save")]
        public void OldZipSave()
        {
            // Prepare a path to a source SVG file 
            string inputPath = Path.Combine(DataDir, "with-resources.svg");

            var dir = Directory.GetCurrentDirectory();

            // Prepare a full path to an output zip storage
            string customArchivePath = Path.Combine(dir, "./../../../../tests-out/save-svg/old/archive.zip");
            
            // Load the SVG document 
            using (var doc = new SVGDocument(inputPath))
            {
                // Initialize an instance of the ZipStorage class
                using (var zipStorage = new ZipStorage(customArchivePath))
                {
                    // Save SVG with resources to a Zip archive
                    doc.Save(zipStorage);
                }
            }
        }

        */
        internal class ZipResourceHandler : ResourceHandler, IDisposable
        {
            private FileStream zipStream;
            private ZipArchive archive;
            private int streamsCounter;
            private bool initialized;

            public ZipResourceHandler(string name)
            {
                DisposeArchive();
                zipStream = new FileStream(name, FileMode.Create);
                archive = new ZipArchive(zipStream, ZipArchiveMode.Update);
                initialized = false;
            }

            public override void HandleResource(Resource resource, ResourceHandlingContext context)
            {
                string zipUri = (streamsCounter++ == 0
                    ? Path.GetFileName(resource.OriginalUrl.Href)
                    : Path.Combine(Path.GetFileName(Path.GetDirectoryName(resource.OriginalUrl.Href)),
                        Path.GetFileName(resource.OriginalUrl.Href)));
                string samplePrefix = String.Empty;
                if (initialized)
                    samplePrefix = "my_";
                else
                    initialized = true;

                using (Stream newStream = archive.CreateEntry(samplePrefix + zipUri).Open())
                {
                    resource.WithOutputUrl(new Url("file:///" + samplePrefix + zipUri)).Save(newStream, context);
                }
            }

            private void DisposeArchive()
            {
                if (archive != null)
                {
                    archive.Dispose();
                    archive = null;
                }

                if (zipStream != null)
                {
                    zipStream.Dispose();
                    zipStream = null;
                }

                streamsCounter = 0;
            }

            public void Dispose()
            {
                DisposeArchive();
            }
        }

        /*
        internal class ZipStorage : IOutputStorage, IDisposable
        {
            private FileStream zipStream;
            private ZipArchive archive;
            private int streamsCounter;
            private bool initialized;

            public ZipStorage(string name)
            {
                DisposeArchive();
                zipStream = new FileStream(name, FileMode.Create);
                archive = new ZipArchive(zipStream, ZipArchiveMode.Update);
                initialized = false;
            }

            public OutputStream CreateStream(OutputStreamContext context)
            {
                var zipUri = (streamsCounter++ == 0
                    ? Path.GetFileName(context.Uri)
                    : Path.Combine(Path.GetFileName(Path.GetDirectoryName(context.Uri)), Path.GetFileName(context.Uri)));
                var samplePrefix = String.Empty;
                if (initialized)
                    samplePrefix = "my_";
                else
                    initialized = true;

                var newStream = archive.CreateEntry(samplePrefix + zipUri).Open();
                var outputStream = new OutputStream(newStream, "file:///" + samplePrefix + zipUri);
                return outputStream;
            }

            public void ReleaseStream(OutputStream stream)
            {
                stream.Flush();
                stream.Close();
            }

            private void DisposeArchive()
            {
                if (archive != null)
                {
                    archive.Dispose();
                    archive = null;
                }

                if (zipStream != null)
                {
                    zipStream.Dispose();
                    zipStream = null;
                }

                streamsCounter = 0;
            }

            public void Dispose()
            {
                DisposeArchive();
            }
        }

        [Fact(DisplayName = "Old Local Save")]
        public void OldStorageSave()
        {
            // Prepare a path to a source SVG file  
            string inputPath = Path.Combine(DataDir, "with-resources.svg");

            // Prepare a full path to an output directory 
            string customOutDir = Path.Combine(Directory.GetCurrentDirectory(), "./../../../../tests-out/save-svg/old/");

            // Load the SVG document from a file
            using (var doc = new SVGDocument(inputPath))
            {
                // Save SVG with resources
                doc.Save(new LocalFileSystemStorage(customOutDir));
            }
        }


        */
        [Fact(DisplayName = "New Local Save")]
        public void NewStorageSave()
        {
            // Prepare a path to a source SVG file  
            string inputPath = Path.Combine(DataDir, "with-resources.svg");

            // Prepare a full path to an output directory 
            string customOutDir = Path.Combine(Directory.GetCurrentDirectory(), "./../../../../tests-out/save-svg/new/");

            // Load the SVG document from a file
            using (SVGDocument doc = new SVGDocument(inputPath))
            {
                // Save SVG with resources
                doc.Save(new FileSystemResourceHandler(customOutDir));
            }
        }


        /*
        public class LocalFileSystemStorage : IOutputStorage
        {
            private int streamsCounter;

            /// <summary>
            /// Initializes a new instance of the <see cref="LocalFileSystemStorage" /> class.
            /// </summary>
            public LocalFileSystemStorage()
                : this(Directory.GetCurrentDirectory())
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="LocalFileSystemStorage" /> class.
            /// </summary>
            /// <param name="outputDirectory">The output directory</param>
            public LocalFileSystemStorage(string outputDirectory)
            {
                OutputDirectory = outputDirectory;
            }

            /// <summary>
            ///  Gets or sets the output directory.
            /// </summary>
            public string OutputDirectory { get; set; }

            /// <summary>
            /// Creates the output file stream <see cref="OutputStream"/>.
            /// </summary>
            /// <param name="context">Specifies the output stream context <see cref="OutputStreamContext" />.</param>
            /// <returns>The output file stream.</returns>
            public virtual OutputStream CreateStream(OutputStreamContext context)
            {
                var fileName = Path.GetFileName(context.Uri);
                var outputDirectory = streamsCounter++ == 0
                    ? OutputDirectory
                    : Path.Combine(OutputDirectory, Path.GetFileName(Path.GetDirectoryName(context.Uri)));

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                var outputPath = Path.Combine(outputDirectory, fileName);
                return new OutputStream(System.IO.File.Create(outputPath), outputPath);
            }

            /// <summary>
            /// Releases the output file stream.
            /// </summary>
            /// <param name="stream">The output file stream.</param>
            public virtual void ReleaseStream(OutputStream stream)
            {
                stream.Flush();
                stream.Dispose();
            }
        } */
    }
}
