using Aspose.Html;
using Aspose.Html.Converters;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.MD_Converter
{
    public class MDtoHTMLTests : TestsBase
    {
        public MDtoHTMLTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("md-converter/md-to-html");
        }


        [Fact(DisplayName = "Convert Markdown to HTML Test")]
        public void ConvertMDtoHTMLTest()
        {
            // @START_SNIPPET ConvertMarkdownToHtml.cs
            // Convert Markdown to HTML using C#
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-html/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "[visit applications](https://products.aspose.app/html/)";
            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "document-output.html");

            // Convert Markdown to HTML document
            Converter.ConvertMarkdown(sourcePath, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert Markdown from File to HTML Test")]
        public void ConvertMarkdowntoHTMLest()
        {
            // @START_SNIPPET ConvertMarkdownFileToHtml.cs
            // Convert Markdown to HTML in C#
            // Learn more: https://docs.aspose.com/html/net/convert-ai-markdown-to-html/

            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "nature-output.html");

            // Convert Markdown to HTML
            Converter.ConvertMarkdown(sourcePath, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }

                
        [Fact(DisplayName = "Convert Markdown from String to HTML Test")]
        public void ConvertMDSringToHTMLTest()
        {
            // @START_SNIPPET ConvertMarkdownSringToHtml.cs
            // Convert Markdown to styled HTML with injected CSS and semantic head structure using stream input
            // Learn more: https://docs.aspose.com/html/net/convert-markdown-to-html/

            // AI response in Markdown format with the text, code example and link
            string markdownContent = "# How to Convert a Markdown File to HTML\n" +
                                 "Markdown is a lightweight markup language used for formatting text. If you need to convert a Markdown file to an HTML document, you can use **Aspose.HTML for .NET**.\n\n" +
                                 "## Steps to Convert\n" +
                                 "1. Load the Markdown file.\n" +
                                 "2. Convert it to an HTML document.\n" +
                                 "3. Save the output file.\n\n" +
                                 "## Example Code\n" +
                                 "```csharp\n" +
                                 "// Convert a Markdown file to HTML\n" +
                                 "Converter.ConvertMarkdown(\"input.md\", \"output.html\");\n" +
                                 "```\n\n" +
                                 "For more details, refer to the [official documentation](https://docs.aspose.com/html/net/convert-markdown-to-html/).\n";

            // Create a memory stream from the Markdown string
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent)))
            {
                // Convert Markdown to HTML
                HTMLDocument document = Converter.ConvertMarkdown(stream, "");

                // Ensure the document has a <head> element
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                // Create a <style> element with CSS styles
                string cssStyles = "body { font-family: Open Sans, sans-serif; max-width: 800px; margin: auto; padding: 20px; background-color: #f9f9f9; }\n" +
                               "h1, h2 { color: #333; }\n" +
                               "p, li { font-size: 14px; }\n" +
                               "code, pre { font-family: Consolas, monospace; color: #f8f8f2; background-color: #272822; padding: 10px; border-radius: 5px; display: block; }\n";

                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = cssStyles;

                // Append the <style> element to the <head>
                head.AppendChild(styleElement);

                // Save the resulting HTML file
                string outputPath = Path.Combine(OutputDir, "chartAnswer.html");
                document.Save(outputPath);

                // Print the HTML content to the console
                Output.WriteLine(document.DocumentElement.OuterHTML);

                Output.WriteLine("Conversion completed. HTML saved at " + outputPath);
                Assert.True(File.Exists(outputPath));
            }
            // @END_SNIPPET
        }
    }
}
