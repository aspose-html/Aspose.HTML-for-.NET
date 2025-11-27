using Aspose.Html;
using System.IO;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToUseCSSSelectorsTests : TestsBase
    {
        public HowToUseCSSSelectorsTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/css-selectors");
        }


        [Fact(DisplayName = "Using a CSS Selector to Extract Content")]
        public void UsingCssSelectorToExtractContentTest()
        {
            // @START_SNIPPET UsingCssSelectorToExtractContent.cs
            // Extract HTML content using CSS selector
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-css-selector/

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "queryselector.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Here we create a CSS Selector that extracts the first paragraph element
            Element element = document.QuerySelector("p");

            // Print content of the first paragraph  
            Output.WriteLine(element.InnerHTML);
            // output: The QuerySelector() method returns the first element in the document that matches the specified selector.

            // Set style attribute with properties for the selected element
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");

            // Save the HTML document to a file
            document.Save(Path.Combine(OutputDir, "queryselector-p.html"));

            // @END_SNIPPET
            Assert.Equal("HTML", document.DocumentElement.TagName);
        }


        [Fact(DisplayName = "CSS Selector Usage to Style Selected Element")]
        public void UsingCssSelectorToStyleElementTest()
        {
            // @START_SNIPPET UsingCssSelectorToStyleElement.cs
            // Select and style HTML element with C# CSS selector
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-css-selector/

            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "css-celector-style.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create a CSS Selector that selects <div> element that is the last child of its parent
            Element element = document.QuerySelector("div:last-child");

            // Set the style attribute with properties for the selected element
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe; text-align:center");

            Assert.Equal("HTML", document.DocumentElement.TagName);

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "CSS Selector Usage to Style Selected Elements")]
        public void CssSelectorToStyleElementTest()
        {
            // @START_SNIPPET CssSelectorToStyleElement.cs
            // Apply background color to elements by class using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-use-css-selector/

            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "css-selector-color.html");

            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Here we create a CSS Selector that extracts all elements whose 'class' attribute equals 'square2'
            NodeList elements = document.QuerySelectorAll(".square2");

            // Iterate over the resulted list of elements
            foreach (HTMLElement element in elements)
            {
                // Set the style attribute with new background-color property
                element.Style.BackgroundColor = "#b0d7fb";
            }

            // Save the HTML document to a file
            document.Save(Path.Combine(savePath));

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}

