using Aspose.Html;
using System.IO;
using System.Linq;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Working_with_HTML_Documents
{
    public class HowToChangeBackgroundColorTests : TestsBase
    {
        public HowToChangeBackgroundColorTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/color");
        }


        [Fact(DisplayName = "How to Change Background Color for Paragraph")]
        public void HowToChangeBackgroundColorForParagraphTest()
        {
            // @START_SNIPPET HowToChangeBackgroundColorForParagraph.cs
            // Change background color for HTML paragraph using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-background-color/

            // Prepare output path for document saving
            string savePath = Path.Combine(OutputDir, "change-background-color-p-inline-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the paragraph element to set a style attribute
            HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();

            // Set the style attribute with background-color property
            paragraph.Style.BackgroundColor = "#e5f3fd";

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Background Color Using Inline CSS")]
        public void ChangeBackgroundColorInlineCSSTest()
        {
            // @START_SNIPPET ChangeBackgroundColorWithInlineCss.cs
            // Change background color with inline CSS in C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-background-color/

            // Prepare output path for document saving
            string savePath = Path.Combine(OutputDir, "change-background-color-inline-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the body element to set a style attribute
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();

            // Set the style attribute with background-color property
            body.Style.BackgroundColor = "#e5f3fd";

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Background Color Using Internal CSS")]
        public void ChangeBackgroundColorInternalCSSTest()
        {
            // @START_SNIPPET ChangeBackgroundColorWithInternalCss.cs
            // Change background color for HTML using internal CSS - C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-background-color/

            // Prepare output path for document saving
            string savePath = Path.Combine(OutputDir, "change-background-color-internal-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the body element
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();

            // Remove the background-color property from the style attribute
            body.Style.RemoveProperty("background-color");

            // Create a style element and assign the background-color value for body element
            Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Find the document head element and append style element to the head
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the HTML document
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Change SVG Background Color in HTML Test")]
        public void ChangeSvgBackgroundColorInHtmlTest()
        {
            // Prepare a path to a source HTML file with SVG image
            string documentPath = Path.Combine(DataDir, "aspose-svg.html");

            // Load an HTML document from the file
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find a <style> element and assign a background color value for all svg elements
            Element styleElement = document.QuerySelector("style");

            // Print content of the <style>
            Output.WriteLine(styleElement.InnerHTML);

            // Assign a text content for the <style> element
            styleElement.TextContent = styleElement.InnerHTML + "svg {background-color: #fef4fd;}";

            // Save the HTML document
            document.Save(Path.Combine(OutputDir, "with-background-color.html"));

            Assert.True(File.Exists(Path.Combine(OutputDir, "with-background-color.html")));
        }


        [Fact(DisplayName = "Change SVG Background Color in HTML using JavaScript Test")]
        public void ChangeSvgBackgroundColorInHtmlUsingScriptTest()
        {
            // Load an HTML document from the file
            HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "aspose-svg.html"));

            // Find the SVG element by its ID (or any other attribute)
            Element svgElement = document.QuerySelector("svg[id='mySvg']");

            if (svgElement != null)
            {
                // Create a new <script> element
                Element scriptElement = document.CreateElement("script");

                // Define JavaScript code to add a <rect> element as the background
                scriptElement.TextContent = @"
                    var svgElement = document.getElementById('mySvg');
                    if (svgElement) {
                        var rectElement = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
                        rectElement.setAttribute('x', '0');
                        rectElement.setAttribute('y', '0');
                        rectElement.setAttribute('width', '100%');
                        rectElement.setAttribute('height', '100%');
                        rectElement.setAttribute('fill', '#fef4fd');
                        svgElement.insertBefore(rectElement, svgElement.firstChild);
                    };
                ";

                // Append the <script> element to the HTML document's body
                document.Body.AppendChild(scriptElement);
            }
            else
            {
                // Handle the case where the svgElement was not found
                Output.WriteLine("SVG element not found.");
            }

            // Save the SVG document
            document.Save(Path.Combine(OutputDir, "svg-background-color-html-script.html"));

            Assert.True(File.Exists(Path.Combine(OutputDir, "svg-background-color-html-script.html")));
        }
    }
}
