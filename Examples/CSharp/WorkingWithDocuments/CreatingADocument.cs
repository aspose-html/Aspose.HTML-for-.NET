using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithDocuments
{
    static class CreatingADocument
    {
        public static void HTMLDocumentFromScratch()
        {
            //ExStart: HTMLDocumentFromScratch
            // Initialize an empty HTML Document.
            using (var document = new Aspose.Html.HTMLDocument())
            {
                // Create a text element and add it to the document
                var text = document.CreateTextNode("Hello World!");
                document.Body.AppendChild(text);

                // Save the document to disk.
                document.Save("document.html");
            }
            //ExEnd: HTMLDocumentFromScratch
        }

        public static void HTMLDocumentFromFile()
        {
            //ExStart: HTMLDocumentFromFile
            // Prepare a 'document.html' file.
            System.IO.File.WriteAllText("document.html", "Hello World!");
            // Load from a 'document.html' file.
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Write the document content to the output stream.
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
            //ExEnd: HTMLDocumentFromFile
        }

        public static void HTMLDocumentFromURL()
        {
            //ExStart: HTMLDocumentFromURL
            // Load a document from 'https://html.spec.whatwg.org/multipage/introduction.html' web page
            using (var document = new Aspose.Html.HTMLDocument("https://html.spec.whatwg.org/multipage/introduction.html"))
            {
                // Write the document content to the output stream.
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
            //ExEnd: HTMLDocumentFromURL
        }

        public static void HTMLDocumentFromString()
        {
            //ExStart: HTMLDocumentFromString
            // Prepare an HTML code
            var html_code = "<p>Hello World!</p>";

            // Initialize document from the string variable
            using (var document = new Aspose.Html.HTMLDocument(html_code, "."))
            {
                // Save the document to disk.
                document.Save("document.html");
            }
            //ExEnd: HTMLDocumentFromString
        }

        public static void HTMLDocumentFromMemoryStream()
        {
            //ExStart: HTMLDocumentFromMemoryStream
            // Create a memory stream object
            using (var mem = new System.IO.MemoryStream())
            using (var sw = new System.IO.StreamWriter(mem))
            {
                // Write the HTML Code into memory object
                sw.Write("<p>Hello World!</p>");

                // It is important to set the position to the beginning, since HTMLDocument starts the reading exactly from the current position within the stream.
                sw.Flush();
                mem.Seek(0, System.IO.SeekOrigin.Begin);

                // Initialize document from the string variable
                using (var document = new Aspose.Html.HTMLDocument(mem, "."))
                {
                    // Save the document to disk.
                    document.Save("document.html");
                }
            }
            //ExEnd: HTMLDocumentFromMemoryStream
        }

        public static void SVGDocumentFromString()
        {
            //ExStart: SVGDocumentFromString
            // Initialize the SVG Document from the string object
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", "."))
            {
                // Write the document content to the output stream.
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
            //ExEnd: SVGDocumentFromString
        }

        public static void HTMLDocumentAsynchronouslyOnReadyStateChange()
        {
            //ExStart: HTMLDocumentAsynchronouslyOnReadyStateChange
            // Create the instance of HTML Document
            var document = new Aspose.Html.HTMLDocument();

            // Subscribe to the 'ReadyStateChange' event.
            // This event will be fired during the document loading process.
            document.OnReadyStateChange += (sender, @event) =>
            {
                // Check the value of 'ReadyState' property.
                // This property is representing the status of the document. For detail information please visit https://www.w3schools.com/jsref/prop_doc_readystate.asp
                if (document.ReadyState == "complete")
                {
                    Console.WriteLine(document.DocumentElement.OuterHTML);
                    Console.WriteLine("Loading is completed. Press any key to continue...");
                }
            };

            // Navigate asynchronously at the specified Uri
            document.Navigate("https://html.spec.whatwg.org/multipage/introduction.html");

            Console.WriteLine("Waiting for loading...");
            Console.ReadLine();
            //ExEnd: HTMLDocumentAsynchronouslyOnReadyStateChange
        }

        public static void HTMLDocumentAsynchronouslyOnLoad()
        {
            //ExStart: HTMLDocumentAsynchronouslyOnLoad
            // Create the instance of HTML Document
            var document = new Aspose.Html.HTMLDocument();

            // Subscribe to the 'OnLoad' event.
            // This event will be fired once the document is fully loaded.
            document.OnLoad += (sender, @event) =>
            {
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Loading is completed. Press any key to continue...");
            };

            // Navigate asynchronously at the specified Uri
            document.Navigate("https://html.spec.whatwg.org/multipage/introduction.html");

            Console.WriteLine("Waiting for loading...");
            Console.ReadLine();
            //ExEnd: HTMLDocumentAsynchronouslyOnLoad
        }
    }
}
