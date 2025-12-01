using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Traversal;
using Aspose.Html.Dom.Traversal.Filters;
using Aspose.Html.Dom.XPath;

namespace Aspose.Html.Examples
{
    public class HtmlNavigationExample : BaseExample
    {
        public HtmlNavigationExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation");
        }

        /// <summary>
        /// Demonstrates basic DOM navigation
        /// </summary>
        public void NavigateThroughHTML()
        {
            // Prepare simple HTML code
            string htmlCode = "<span>Hello,</span> <span>World!</span>";

            // Initialize a document from the HTML string
            using HTMLDocument document = new HTMLDocument(htmlCode, ".");

            // Get the first child (first <span>) of the body
            Node element = document.Body.FirstChild;
            Console.WriteLine(element.TextContent); // Hello,

            // Get the whitespace text node between the spans
            element = element.NextSibling;
            Console.WriteLine(element.TextContent); // ' '

            // Get the second <span> element
            element = element.NextSibling;
            Console.WriteLine(element.TextContent); // World!

            // Output the full HTML of the document
            string html = document.DocumentElement.OuterHTML;
            Console.WriteLine(html);
        }

        /// <summary>
        /// Inspects an HTML document loaded from a file
        /// </summary>
        public void InspectHtmlDocument()
        {
            // Path to a local HTML file (replace with actual file if needed)
            string documentPath = Path.Combine(DataDir, "html_file.html");
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Access the root <html> element
            Element html = document.DocumentElement;
            Console.WriteLine(html.TagName); // HTML

            // Access the <body> element
            Element body = html.LastElementChild;
            Console.WriteLine(body.TagName); // BODY

            // Access the first element in the body
            Element first = body.FirstElementChild;
            Console.WriteLine(first.TagName); // H1
            Console.WriteLine(first.TextContent); // Header 1
        }

        /// <summary>
        /// Uses a custom node filter to process only image elements
        /// </summary>
        public void NodeFilterUsage()
        {
            // Prepare HTML code containing images
            string code = @"
                <p>Hello,</p>
                <img src='image1.png'>
                <img src='image2.png'>
                <p>World!</p>";

            // Initialize a document based on the prepared code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create a TreeWalker with a custom filter that accepts only IMG elements
            using (ITreeWalker iterator = document.CreateTreeWalker(document, NodeFilter.SHOW_ALL, new OnlyImageFilter()))
            {
                // Walk through the nodes
                while (iterator.NextNode() != null)
                {
                    // Current node is guaranteed to be an HTMLImageElement
                    HTMLImageElement image = (HTMLImageElement)iterator.CurrentNode;
                    Console.WriteLine(image.Src);
                }
            }
        }

        /// <summary>
        /// Executes an XPath query to select nodes
        /// </summary>
        public void XPathQueryUsage()
        {
            // Prepare HTML code with elements having class 'happy'
            string code = @"
                <div class='happy'>
                    <div>
                        <span>Hello,</span>
                    </div>
                </div>
                <p class='happy'>
                    <span>World!</span>
                </p>";

            // Initialize a document from the code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Evaluate XPath expression selecting all <span> elements inside elements with class 'happy'
            IXPathResult result = document.Evaluate("//*[@class='happy']//span",
                document,
                null,
                XPathResultType.Any,
                null);

            // Iterate over the resulting nodes
            for (Node node; (node = result.IterateNext()) != null;)
            {
                Console.WriteLine(node.TextContent);
            }
        }

        /// <summary>
        /// Uses a CSS selector to retrieve elements
        /// </summary>
        public void CssSelectorUsage()
        {
            // Prepare HTML code with elements having class 'happy'
            string code = @"
                <div class='happy'>
                    <div>
                        <span>Hello,</span>
                    </div>
                </div>
                <p class='happy'>
                    <span>World!</span>
                </p>";

            // Initialize a document from the code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Select all <span> elements that are descendants of elements with class 'happy'
            var elements = document.QuerySelectorAll(".happy span");

            // Iterate over the selected elements
            foreach (HTMLElement element in elements)
            {
                Console.WriteLine(element.InnerHTML);
            }
        }

        // Custom node filter that accepts only IMG elements
        class OnlyImageFilter : Aspose.Html.Dom.Traversal.Filters.NodeFilter
        {
            public override short AcceptNode(Node n)
            {
                // Accept only nodes with local name 'img'
                return string.Equals("img", n.LocalName, StringComparison.OrdinalIgnoreCase)
                    ? FILTER_ACCEPT
                    : FILTER_SKIP;
            }
        }
    }
}