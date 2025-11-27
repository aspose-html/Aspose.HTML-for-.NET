using Aspose.Html;
using System.IO;
using System.Linq;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToChangeBorderColorTests : TestsBase
    {
        public HowToChangeBorderColorTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/color");
        }


        [Fact(DisplayName = "How to Change Border Color")]
        public void HowToChangeBorderColorTest()
        {
            // @START_SNIPPET HowToChangeBorderColor.cs
            // Сhange border color for <h1> element using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-border-color/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "change-border-color.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the h1 element to set a style attribute
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();

            // Set the style attribute properties
            header.Style.Color = "#8B0000";
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "rgb(220,30,100)";

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Border Color for Four Sides")]
        public void HowToChangeBorderColorForFourSidesTest()
        {
            // @START_SNIPPET HowToChangeBorderColorForFourSides.cs
            // Set different colors for all four borders of HTML element using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-border-color/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "change-four-border-color.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "change-border-color.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Find the h1 element to set a style attribute
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();

            // Set the style attribute properties
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "red blue green gray";

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Border Color Using Internal CSS")]
        public void HowToChangeBorderColorInternalCSSTest()
        {
            // @START_SNIPPET HowToChangeBorderColorWithInternalCss.cs
            // Add internal CSS to style HTML in C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-border-color/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "change-border-color-internal-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a style element and assign the color border-style and border-color values for h1 element
            Element style = document.CreateElement("style");
            style.TextContent = "h1 {color:DarkRed; border-style:solid; border-color:rgb(220,30,100) }";

            // Find the document head element and append style element to the head
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Table Border Color Using Inline CSS")]
        public void HowToChangeTableBorderColorInlineCSSTest()
        {
            // @START_SNIPPET HowToChangeTableBorderColorWithInlineCss.cs
            // Change table border color using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-border-color/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "change-table-border-color-inline-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "table.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a CSS Selector that selects the first table element
            Element element = document.QuerySelector("table");

            // Set style attribute with properties for the selected element
            element.SetAttribute("style", "border: 2px #0000ff solid");

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "How to Change Table Border Color Using Internal CSS")]
        public void HowToChangeTableBorderColorInternalCSSTest()
        {
            // @START_SNIPPET HowToChangeTableBorderColorWithInternalCss.cs
            // Change HTML table border color using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-change-border-color/

            // Prepare an output path for a document saving
            string savePath = Path.Combine(OutputDir, "change-table-border-color-internal-css.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "table.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a style element and assign the color border-style and border-color values for table element
            Element style = document.CreateElement("style");
            style.TextContent = "table { border-style:solid; border-color:rgb(0, 0, 255) }";

            // Find the document head element and append style element to the head
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
