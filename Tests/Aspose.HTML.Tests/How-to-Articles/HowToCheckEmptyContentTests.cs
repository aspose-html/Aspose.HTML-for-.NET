using Aspose.Html;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToCheckEmptyContentTests : TestsBase
    {
        public HowToCheckEmptyContentTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles");
        }


        [Fact(DisplayName = "How to check if HTML text content is empty")]
        public void HowToCheckEmptyContentTest()
        {
            // @START_SNIPPET HowToCheckEmptyContent.cs
            // Check if HTML body is empty using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-check-if-html-text-content-is-empty/

            // Prepare a path to a source HTML file
            string inputPath = Path.Combine(DataDir, "file.html");

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Get the body element
                HTMLElement body = document.Body;

                // Check if the body element contains any child nodes
                if (!string.IsNullOrWhiteSpace(body.TextContent))
                    Output.WriteLine("Non-empty HTML elements found");
                else
                    Output.WriteLine("No child nodes found in the body element.");
                    Assert.Equal("HTML", document.DocumentElement.TagName);
            }
            // @END_SNIPPET
        }
    }
}
