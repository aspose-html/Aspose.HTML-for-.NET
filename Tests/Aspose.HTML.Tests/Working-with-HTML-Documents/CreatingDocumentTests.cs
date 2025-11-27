using Aspose.Html;
using Aspose.Html.Dom.Svg;
using System.IO;
using System.Threading;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests
{
    public class CreatingDocumentTests : TestsBase
    {
        public CreatingDocumentTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("creating");
        }
        

        [Fact(DisplayName = "Create an Empty HTML Document")]
        public void CreateEmptyDocumentTest()
        {
            // @START_SNIPPET CreateEmptyHtmlDocument.cs
            // Create an empty HTML document using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "create-empty-document.html");

            // Initialize an empty HTML Document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Work with the document

                // Save the document to a file
                document.Save(documentPath);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Create a New HTML Document")]
        public void CreateNewDocumentTest()
        {
            // @START_SNIPPET CreateNewHtmlDocument.cs
            // Create an HTML document using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "create-new-document.html");

            // Initialize an empty HTML Document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a text node and add it to the document
                Text text = document.CreateTextNode("Hello, World!");
                document.Body.AppendChild(text);

                // Save the document to a disk
                document.Save(documentPath);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Create an HTML Document from Scratch")]
        public void CreateDocumentFromScratchTest()
        {
            // @START_SNIPPET CreateDocumentFromScratch.cs
            // Create HTML from scratch using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Prepare an output path for a document saving
            string documentPath = Path.Combine(OutputDir, "create-new-document.html");

            // Initialize an empty HTML Document
            using (HTMLDocument document = new HTMLDocument())
            {
                HTMLElement body = document.Body;

                // Create a heading element <h1> and set its text
                HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
                Text texth1 = document.CreateTextNode("Create HTML file");

                // Create a paragraph element set its text
                HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");                
                Text text = document.CreateTextNode("Learn how to create HTML file");

                // Attach the text to the h1 and paragraph
                h1.AppendChild(texth1);
                p.AppendChild(text);

                // Attach h1 and paragraph to the document body
                body.AppendChild(h1);
                body.AppendChild(p);

                // Save the document to a disk
                document.Save(documentPath);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(documentPath));
        }


        [Fact(DisplayName = "Create an HTML Document from a String")]
        public void CreateDocumentFromContentStringTest()
        {
            // @START_SNIPPET CreateHtmlDocumentFromString.cs
            // Create HTML from a string using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Prepare HTML code
            string html_code = "<p>Hello, World!</p>";

            // Initialize a document from the string variable
            using (HTMLDocument document = new HTMLDocument(html_code, "."))
            {
                // Save the document to a disk
                document.Save(Path.Combine(OutputDir, "create-from-string.html"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "create-from-string.html")));
        }


        [Fact(DisplayName = "Load HTML From Existing HTML File")]
        public void LoadHtmlDocumentFromExistingFileTest()
        {
            // @START_SNIPPET LoadHtmlDocumentFromExistingFile.cs
            // Load an HTML documment from a file using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Prepare a file path
            string documentPath = Path.Combine(DataDir, "sprite.html");

            // Initialize an HTML document from the file
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Work with the document

                // Save the document to a disk
                document.Save(Path.Combine(OutputDir, "sprite_out.html"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "sprite_out.html")));
        }


        [Fact(DisplayName = "Load an HTML Document from a File")]
        public void LoadHtmlDocumentFromFileTest()
        {
            // @START_SNIPPET LoadHtmlDocumentFromFile.cs
            // Load HTML from a file using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            string htmlFile = Path.Combine(OutputDir, "load-from-file.html");

            // Prepare a load-from-file.html document
            File.WriteAllText(htmlFile, "Hello, World!");

            // Load from the load-from-file.html 
            using (HTMLDocument document = new HTMLDocument(htmlFile))
            {
                // Write the document content to the output stream
                Output.WriteLine(document.DocumentElement.OuterHTML);
                Assert.Contains("<html>", document.DocumentElement.OuterHTML);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Load an HTML Document from a Stream")]
        public void LoadHtmlDocumentFromStreamTest()
        {
            // @START_SNIPPET LoadHtmlDocumentFromStream.cs
            // Load HTML from a stream using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Create a memory stream object
            using (MemoryStream mem = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(mem))
            {
                // Write the HTML code into memory object
                sw.Write("<p>Hello, World! I love HTML!</p>");

                // It is important to set the position to the beginning, since HTMLDocument starts the reading exactly from the current position within the stream
                sw.Flush();
                mem.Seek(0, SeekOrigin.Begin);

                // Initialize a document from the string variable
                using (HTMLDocument document = new HTMLDocument(mem, "."))
                {
                    // Save the document to disk
                    document.Save(Path.Combine(OutputDir, "load-from-stream.html"));
                    Assert.True(document.QuerySelectorAll("p").Length > 0);
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Load an HTML Document from a URL")]
        public void LoadHtmlDocumentFromUrlTest()
        {
            // @START_SNIPPET LoadHtmlDocumentFromUrl.cs
            // Load HTML from a URL using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Load a document from 'https://docs.aspose.com/html/files/document.html' web page
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html"))
            {
                string html = document.DocumentElement.OuterHTML;

                // Write the document content to the output stream
                Output.WriteLine(html);
                Assert.StartsWith("<html", html.Trim());
                Assert.Contains("</html>", html);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Load an SVG document from a String")]
        public void LoadSvgDocumentFromStringTest()
        {
            // @START_SNIPPET LoadSvgDocumentFromString.cs
            // Load SVG from a string using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Initialize an SVG document from a string object
            using (SVGDocument document = new SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", "."))
            {
                // Write the document content to the output stream
                Output.WriteLine(document.DocumentElement.OuterHTML);
                Assert.True(document.QuerySelectorAll("circle").Length > 0);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Using Asynchronous Operations - OnReadyStateChange")]
        public void UsingAsynchronousOperationsTest()
        {
            // @START_SNIPPET UsingAsynchronousOperations.cs
            // Load HTML asynchronously using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Initialize an AutoResetEvent
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a string variable for the OuterHTML property reading
            string outerHTML = string.Empty;

            // Subscribe to ReadyStateChange event
            // This event will be fired during the document loading process
            document.OnReadyStateChange += (sender, @event) =>
            {
                // Check the value of the ReadyState property
                // This property is representing the status of the document. For detail information please visit https://www.w3schools.com/jsref/prop_doc_readystate.asp
                if (document.ReadyState == "complete")
                {
                    // Fill the outerHTML variable by value of loaded document
                    outerHTML = document.DocumentElement.OuterHTML;
                    resetEvent.Set();
                }
            };

            // Navigate asynchronously at the specified Uri
            document.Navigate("https://docs.aspose.com/html/files/document.html");

            // Here the outerHTML is empty yet
            Assert.True(string.IsNullOrEmpty(outerHTML));

            Output.WriteLine($"outerHTML = {outerHTML}");

            //  Wait 5 seconds for the file to load
            Assert.True(resetEvent.WaitOne(5000), "Thread works too long, more than 5000 ms");

            // Here the outerHTML is filled 
            Output.WriteLine("outerHTML = {0}", outerHTML);

            // @END_SNIPPET
            Assert.False(string.IsNullOrEmpty(outerHTML));
            Assert.Contains("<body>Hello World!</body>", outerHTML);
            Assert.True(document.DocumentElement.TagName.ToLower() == "html");
        }


        [Fact(DisplayName = "Using Asynchronous Operations - OnLoad")]
        public void HTMLDocumentAsynchronouslyOnLoadTest()
        {
            // @START_SNIPPET UsingAsynchronousOperationsOnLoad.cs
            // Handle an HTML document load using C#
            // Learn more: https://docs.aspose.com/html/net/creating-a-document/

            // Initialize an AutoResetEvent
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            // Initialize an HTML document
            HTMLDocument document = new HTMLDocument();
            bool isLoading = false;

            // Subscribe to the OnLoad event
            // This event will be fired once the document is fully loaded
            document.OnLoad += (sender, @event) =>
            {
                isLoading = true;
                resetEvent.Set();
            };

            // Navigate asynchronously at the specified Uri
            document.Navigate("https://docs.aspose.com/html/files/document.html");
            
            Assert.False(isLoading); // Here the document is not loaded yet
            Assert.True(resetEvent.WaitOne(5000), "Thread works too long, more than 5000 ms"); // Wait 5 seconds for the file to load
            Assert.True(isLoading); // Here is the loaded document

            Output.WriteLine("outerHTML = {0}", document.DocumentElement.OuterHTML);
            // @END_SNIPPET
        }
    }
}
