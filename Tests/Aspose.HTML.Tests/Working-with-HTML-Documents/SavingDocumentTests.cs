using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Saving.ResourceHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests
{
    public class SavingDocumentTests : TestsBase
    {
        public SavingDocumentTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("saving");
        }


        [Fact(DisplayName = "Save HTML To File")]
        public void SaveHTMLToFileTest()
        {
            // @START_SNIPPET SaveHtmlToFile.cs
            // Save HTML to a file using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "save-to-file.html");

            // Initialize an empty HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a text element and add it to the document
                Text text = document.CreateTextNode("Hello, World!");
                document.Body.AppendChild(text);

                // Save the HTML document to the file on a disk
                document.Save(documentPath);
                Assert.True(document.QuerySelectorAll("body").Length > 0);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Save HTML With a Linked File")]
        public void SaveHTMLWithLinkedFileTest()
        {
            // @START_SNIPPET SaveHtmlWithLinkedFile.cs
            // Save HTML with a linked resources using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare an output path for an HTML document 
            string documentPath = Path.Combine(OutputDir, "save-with-linked-file.html");

            // Prepare a simple HTML file with a linked document
            File.WriteAllText(documentPath, "<p>Hello, World!</p>" +
                                            "<a href='linked.html'>linked file</a>");

            // Prepare a simple linked HTML file
            File.WriteAllText(Path.Combine(OutputDir, "linked.html"), "<p>Hello, linked file!</p>");

            // Load the "save-with-linked-file.html" into memory
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Create a save options instance
                HTMLSaveOptions options = new HTMLSaveOptions();

                // The following line with value '0' cuts off all other linked HTML-files while saving this instance
                // If you remove this line or change value to the '1', the 'linked.html' file will be saved as well to the output folder
                options.ResourceHandlingOptions.MaxHandlingDepth = 1;

                // Save the document with the save options
                document.Save(Path.Combine(OutputDir, "save-with-linked-file_out.html"), options);
                Assert.True(document.QuerySelectorAll("p").Length > 0);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Save HTML With Resources to Zip")]
        public void SaveHTMLWithResourcesTest()
        {
            // @START_SNIPPET SaveHtmlWithResourcesToZip.cs
            // Save an HTML document with all linked resources into a ZIP archive using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare a path to a source HTML file 
            string inputPath = Path.Combine(DataDir, "with-resources.html");

            string dir = Directory.GetCurrentDirectory();

            // Prepare a full path to an output zip storage
            string customArchivePath = Path.Combine(dir, "./../../../../tests-out/saving/archive.zip");

            // Load the HTML document 
            using (HTMLDocument doc = new HTMLDocument(inputPath))
            {
                // Initialize an instance of the ZipResourceHandler class
                using (ZipResourceHandler resourceHandler = new ZipResourceHandler(customArchivePath))
                {
                    // Save HTML with resources to a Zip archive
                    doc.Save(resourceHandler);
                }
            }
            // @END_SNIPPET
            Assert.True(File.Exists(inputPath));
        }


        // @START_SNIPPET ZipResourceHandlerClass.cs
        // Custom resource handler to save HTML with resources into a ZIP archive
        // Learn more: https://docs.aspose.com/html/net/save-html-document/

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
        // @END_SNIPPET


        [Fact(DisplayName = "Save HTML With Resources to Memory")]
        public void SaveHTMLToMemoryTest()
        {
            // @START_SNIPPET SaveHtmlToMemory.cs
            // Save HTML with resources to memory streams using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare a path to a source HTML file 
            string inputPath = Path.Combine(DataDir, "with-resources.html");
            
            // Load the HTML document 
            using (HTMLDocument doc = new HTMLDocument(inputPath))
            {
                // Create an instance of the MemoryResourceHandler class and save HTML to memory
                MemoryResourceHandler resourceHandler = new MemoryResourceHandler();
                doc.Save(resourceHandler);
                resourceHandler.PrintInfo();
            }
            // @END_SNIPPET
            Assert.True(File.Exists(inputPath));
        }


        // @START_SNIPPET MemoryResourceHandlerClass.cs
        // In-memory resource handler that captures and stores HTML resources as streams
        // Learn more: https://docs.aspose.com/html/net/save-html-document/

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
        // @END_SNIPPET


        [Fact(DisplayName = "Save HTML With Resources to Local Storage")]
        public void SaveHTMLWithResourcesToStorageTest()
        {
            // @START_SNIPPET SaveHtmlWithResourcesToStorage.cs
            // Save HTML with resources to local storage using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare a path to a source HTML file
            string inputPath = Path.Combine(DataDir, "with-resources.html");

            // Prepare a full path to an output directory 
            string customOutDir = Path.Combine(Directory.GetCurrentDirectory(), "./../../../../tests-out/saving/");

            // Load the HTML document from a file
            using (HTMLDocument doc = new HTMLDocument(inputPath))
            {
                // Save HTML with resources
                doc.Save(new FileSystemResourceHandler(customOutDir));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(inputPath));
        }


        [Fact(DisplayName = "Save HTML As MHTML")]
        public void SaveHTMLToMHTMLTest()
        {
            // @START_SNIPPET SaveHtmlToMHtml.cs
            // Save HTML as MHTML using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "save-to-mhtml.mht");
            
            // Prepare a simple HTML file with a linked document
            File.WriteAllText("save-to-mhtml.html", "<p>Hello, World!</p>" +
                                                    "<a href='linked-file.html'>linked file</a>");

            // Prepare a simple linked HTML file
            File.WriteAllText("linked-file.html", "<p>Hello, linked file!</p>");

            // Load the "save-to-mhtml.html" into memory
            using (HTMLDocument document = new HTMLDocument("save-to-mhtml.html"))
            {
                // Save the document to MHTML format
                document.Save(savePath, HTMLSaveFormat.MHTML);
                Assert.True(document.QuerySelectorAll("a").Length > 0);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Save HTML To MD")]
        public void SaveHTMLToMDTest()
        {
            // @START_SNIPPET SaveHtmlToMarkdown.cs
            // Save HTML as Markdown using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "save-html-to-markdown.md");

            // Prepare HTML code
            string html_code = "<H2>Hello, World!</H2>";

            // Initialize a document from a string variable
            using (HTMLDocument document = new HTMLDocument(html_code, "."))
            {
                // Save the document as a Markdown file
                document.Save(documentPath, HTMLSaveFormat.Markdown);
                Assert.True(document.QuerySelectorAll("H2").Length > 0);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Save HTML To SVG")]
        public void SaveHTMLToSVGTest()
        {
            // @START_SNIPPET SaveSvgDocument.cs
            // Create and save SVG image using C#
            // Learn more: https://docs.aspose.com/html/net/save-html-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "create-and-save-svg.svg");

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
                Assert.True(document.QuerySelectorAll("path").Length > 2);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }
    }
}
