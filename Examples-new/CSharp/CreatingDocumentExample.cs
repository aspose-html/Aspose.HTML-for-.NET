using System;
using System.Reflection;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Threading;
using Aspose.Html.Dom.Svg;

namespace Aspose.Html.Examples
{    
    public static class CreatingDocumentExample
    {
        /// <summary>
        /// Create an empty document and save it to a file
        /// </summary>
        public static void CreateEmptyDocument()
        {
            string outputPath = Path.Combine(BaseExample.GetOutputDir(), "create-empty-document.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                doc.Save(outputPath);
            }
            Console.WriteLine($"Empty document saved to: {outputPath}");
        }

        /// <summary>
        /// Create a document, add simple text and save it
        /// </summary>
        public static void CreateDocumentWithText()
        {
            string outputPath = Path.Combine(BaseExample.GetOutputDir(), "create-with-text.html");
            using (HTMLDocument doc = new HTMLDocument())
            {
                Text txt = doc.CreateTextNode("Hello, Aspose.HTML!");
                doc.Body.AppendChild(txt);
                doc.Save(outputPath);
            }
            Console.WriteLine($"Document with text saved to: {outputPath}");
        }

    
        /// <summary>
        /// Returns the path to the data directory containing test files.
        /// </summary>
    /// <summary>
    /// Load an HTML document from an existing file and save it
    /// </summary>
    public static void LoadHtmlDocumentFromExistingFile()
    {
        string documentPath = Path.Combine(BaseExample.GetDataDir(), "sprite.html");
        using (HTMLDocument document = new HTMLDocument(documentPath))
        {
            // Work with the document
            document.Save(Path.Combine(BaseExample.GetOutputDir(), "sprite_out.html"));
            Console.WriteLine($"Loaded from existing file and saved to: {Path.Combine(BaseExample.GetOutputDir(), "sprite_out.html")}");
        }
    }

    /// <summary>
    /// Create a simple HTML file, then load it and output its content
    /// </summary>
    public static void LoadHtmlDocumentFromFile()
    {
        string htmlFile = Path.Combine(BaseExample.GetOutputDir(), "load-from-file.html");
        File.WriteAllText(htmlFile, "Hello, World!");
        using (HTMLDocument document = new HTMLDocument(htmlFile))
        {
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
    }

    /// <summary>
    /// Load an HTML document from a memory stream
    /// </summary>
    public static void LoadHtmlDocumentFromStream()
    {
        using (MemoryStream mem = new MemoryStream())
        using (StreamWriter sw = new StreamWriter(mem))
        {
            sw.Write("<p>Hello, World! I love HTML!</p>");
            sw.Flush();
            mem.Seek(0, SeekOrigin.Begin);
            using (HTMLDocument document = new HTMLDocument(mem, "."))
            {
                document.Save(Path.Combine(BaseExample.GetOutputDir(), "load-from-stream.html"));
                Console.WriteLine("Document loaded from stream and saved.");
            }
        }
    }

    /// <summary>
    /// Load an HTML document from a URL
    /// </summary>
    public static void LoadHtmlDocumentFromUrl()
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
    public static void LoadSvgDocumentFromString()
    {
        using (SVGDocument document = new SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", "."))
        {
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
    }

    /// <summary>
    /// Demonstrate asynchronous loading using OnReadyStateChange event
    /// </summary>
    public static void UsingAsynchronousOperations()
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
    public static void HTMLDocumentAsynchronouslyOnLoad()
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
    public static void CreateDocumentFromScratch()
    {
        string outputPath = Path.Combine(BaseExample.GetOutputDir(), "create-from-scratch.html");
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
    public static void CreateDocumentFromContentString()
    {
        string htmlCode = "<p>Hello, World!</p>";
        string outputPath = Path.Combine(BaseExample.GetOutputDir(), "create-from-string.html");
        using (HTMLDocument doc = new HTMLDocument(htmlCode, "."))
        {
            doc.Save(outputPath);
        }
        Console.WriteLine($"Document from string saved to: {outputPath}");
    }

    }
}