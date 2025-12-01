using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Threading;
using Aspose.Html.Dom.Svg;

namespace Aspose.Html.Examples
{
    public class CreatingDocumentExample : BaseExample
    {
        public CreatingDocumentExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("creating-document");
        }

        /// <summary>
        /// Create an empty document and save it to a file
        /// </summary>
        public void CreateEmptyDocument()
        {
            string outputPath = Path.Combine(OutputDir, "create-empty-document.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                doc.Save(outputPath);
            }
            Console.WriteLine($"Empty document saved to: {outputPath}");
        }

        /// <summary>
        /// Create a document, add simple text and save it
        /// </summary>
        public void CreateDocumentWithText()
        {
            string outputPath = Path.Combine(OutputDir, "create-with-text.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                Text txt = doc.CreateTextNode("Hello, Aspose.HTML!");
                doc.Body.AppendChild(txt);
                doc.Save(outputPath);
            }
            Console.WriteLine($"Document with text saved to: {outputPath}");
        }

        /// <summary>
        /// Load an HTML document from an existing file and save it
        /// </summary>
        public void LoadHtmlDocumentFromExistingFile()
        {
            string documentPath = Path.Combine(DataDir, "sprite.html");
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                document.Save(Path.Combine(OutputDir, "sprite_out.html"));
                Console.WriteLine($"Loaded from existing file and saved to: {Path.Combine(OutputDir, "sprite_out.html")}");
            }
        }

        /// <summary>
        /// Create a simple HTML file, then load it and output its content
        /// </summary>
        public void LoadHtmlDocumentFromFile()
        {
            string htmlFile = Path.Combine(OutputDir, "load-from-file.html");
            File.WriteAllText(htmlFile, "Hello, World!");
            using (HTMLDocument document = new HTMLDocument(htmlFile))
            {
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
        }

        /// <summary>
        /// Load an HTML document from a memory stream
        /// </summary>
        public void LoadHtmlDocumentFromStream()
        {
            using (MemoryStream mem = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(mem))
            {
                sw.Write("<p>Hello, World! I love HTML!</p>");
                sw.Flush();
                mem.Seek(0, SeekOrigin.Begin);
                using (HTMLDocument document = new HTMLDocument(mem, "."))
                {
                    document.Save(Path.Combine(OutputDir, "load-from-stream.html"));
                    Console.WriteLine("Document loaded from stream and saved.");
                }
            }
        }

        /// <summary>
        /// Load an HTML document from a URL
        /// </summary>
        public void LoadHtmlDocumentFromUrl()
        {
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html"))
            {
                string html = document.DocumentElement.OuterHTML;
                Console.WriteLine(html);
            }
        }

        /// <summary>
        /// Load an SVG document from a string
        /// </summary>
        public void LoadSvgDocumentFromString()
        {
            using (SVGDocument document = new SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", "."))
            {
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
        }

        /// <summary>
        /// Demonstrate asynchronous loading using OnReadyStateChange event
        /// </summary>
        public void UsingAsynchronousOperations()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            HTMLDocument document = new HTMLDocument();
            string outerHTML = string.Empty;
            document.OnReadyStateChange += (sender, @event) =>
            {
                if (document.ReadyState == "complete")
                {
                    outerHTML = document.DocumentElement.OuterHTML;
                    resetEvent.Set();
                }
            };
            document.Navigate("https://docs.aspose.com/html/files/document.html");
            resetEvent.WaitOne(5000);
            Console.WriteLine($"outerHTML = {outerHTML}");
        }

        /// <summary>
        /// Demonstrate asynchronous loading using OnLoad event
        /// </summary>
        public void HTMLDocumentAsynchronouslyOnLoad()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            HTMLDocument document = new HTMLDocument();
            bool isLoading = false;
            document.OnLoad += (sender, @event) =>
            {
                isLoading = true;
                resetEvent.Set();
            };
            document.Navigate("https://docs.aspose.com/html/files/document.html");
            resetEvent.WaitOne(5000);
            Console.WriteLine($"Document loaded, isLoading={isLoading}");
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }

        /// <summary>
        /// Create an HTML document from scratch with heading and paragraph
        /// </summary>
        public void CreateDocumentFromScratch()
        {
            string outputPath = Path.Combine(OutputDir, "create-from-scratch.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                HTMLElement body = doc.Body;
                HTMLHeadingElement h1 = (HTMLHeadingElement)doc.CreateElement("h1");
                Text txtH1 = doc.CreateTextNode("Create HTML file");
                h1.AppendChild(txtH1);
                HTMLParagraphElement p = (HTMLParagraphElement)doc.CreateElement("p");
                Text txtP = doc.CreateTextNode("Learn how to create HTML file");
                p.AppendChild(txtP);
                body.AppendChild(h1);
                body.AppendChild(p);
                doc.Save(outputPath);
            }
            Console.WriteLine($"Document from scratch saved to: {outputPath}");
        }

        /// <summary>
        /// Create an HTML document from a string
        /// </summary>
        public void CreateDocumentFromContentString()
        {
            string htmlCode = "<p>Hello, World!</p>";
            string outputPath = Path.Combine(OutputDir, "create-from-string.html");
            using (HTMLDocument doc = new HTMLDocument(htmlCode, "."))
            {
                doc.Save(outputPath);
            }
            Console.WriteLine($"Document from string saved to: {outputPath}");
        }
    }
}