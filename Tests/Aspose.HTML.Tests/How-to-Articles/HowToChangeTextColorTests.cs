using Aspose.Html;
using System.IO;
using System.Linq;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Working_with_HTML_Documents
{
    public class HowToChangeTextColorTests : TestsBase
    {
        public HowToChangeTextColorTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/color");
        }


        [Fact(DisplayName = "How to Change Paragraph Color Using Inline CSS")]
        public void HowToChangeParagraphtColorInlineCSSTest()
        {
            // @START_SNIPPET HowToChangeParagraphtColorWithInlineCss.cs
            // Change HTML paragraph color using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-text-color/

            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "change-paragraph-color-inline-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the first paragraph element to set a style attribute
            HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();

            // Set the style attribute with color property
            paragraph.Style.Color = "#8B0000";
            
            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Paragraph Color Using Internal CSS")]
        public void HowToChangePragraphColorInternalCSSTest()
        {
            // @START_SNIPPET HowToChangePragraphColorWithInternalCss.cs
            // Change HTML text color using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-text-color/

            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "change-paragraph-color-internal-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a style element and assign the text color value for all paragraph elements
            Element style = document.CreateElement("style");
            style.TextContent = "p { color:#8B0000 }";

            // Find the document head element and append style element to the head
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            
            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change H1 Color Using Inline CSS")]
        public void HowToChangeHeaderColorInlineCSSTest()
        {
            // Prepare output path for document saving
            string savePath = Path.Combine(OutputDir, "change-h1-color-inline-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the h1 element to set a style attribute
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();

            // Set the style attribute with color property
            header.Style.Color = "DarkRed";

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change H1 Color Using Internal CSS")]
        public void HowToChangeHeaderColorTest()
        {
            // Prepare output path for document saving
            string savePath = Path.Combine(OutputDir, "change-h1-color-internal-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a style element and assign the color value for all h1 elements
            Element style = document.CreateElement("style");
            style.TextContent = "h1 { color:DarkRed }";

            // Find the document head element and append style element to the head
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));
            Assert.True(File.Exists(savePath));
        }
    }
}
