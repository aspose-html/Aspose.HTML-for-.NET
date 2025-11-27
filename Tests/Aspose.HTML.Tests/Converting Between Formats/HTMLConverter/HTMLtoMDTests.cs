using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.HTMLConverter
{
    public class HTMLtoMDTests : TestsBase
    {
        public HTMLtoMDTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter/html-to-md");
        }


        [Fact(DisplayName = "Convert HTML to MD")]
        public void ConvertHTMLtoMDTest()
        {
            // @START_SNIPPET ConvertHtmlToMarkdown.cs
            // Convert HTML to Markdown in C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-markdown/

            // Prepare HTML code and save it to a file
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Convert HTML to Markdown</p>";
            File.WriteAllText("convert.html", code);

            // Call ConvertHTML() method to convert HTML to Markdown
            Converter.ConvertHTML("convert.html", new MarkdownSaveOptions(), Path.Combine(OutputDir, "convert.md"));

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert.md")));
        }


        [Fact(DisplayName = "Convert HTML to MD Using Git Syntax")]
        public void ConvertHTMLtoMDUsingGitSyntaxTest()
        {
            // @START_SNIPPET ConvertHtmlToMarkdownUsingGitSyntax.cs
            // Convert HTML to Markdown in C# using Git syntax
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-markdown/

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "output-git.md");

            // Prepare HTML code and save it to the file
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Hello, World!!</p>";
            File.WriteAllText(Path.Combine(OutputDir, "document.html"), code);

            // Call ConvertHTML() method to convert HTML to Markdown
            Converter.ConvertHTML(Path.Combine(OutputDir, "document.html"), MarkdownSaveOptions.Git, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Inline HTML")]
        public void InlineHTMLTest()
        {
            // @START_SNIPPET ConvertInlineHtmlElementsToMarkdown.cs
            // Convert inline HTML elements to Markdown using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-markdown/

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "inline-html.md");

            // Prepare HTML code and save it to the file
            string code = "text<div markdown='inline'><code>text</code></div>";
            File.WriteAllText(Path.Combine(OutputDir, "inline.html"), code);

            // Call ConvertHTML() method to convert HTML to Markdown
            Converter.ConvertHTML(Path.Combine(OutputDir, "inline.html"), new MarkdownSaveOptions(), savePath);

            // Output file will contain: text\r\n<div markdown="inline"><code>text</code></div>

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Specify MarkdownSaveOptions")]
        public void SpecifyMarkdownSaveOptionsTest()
        {
            // @START_SNIPPET SpecifyMarkdownSaveOptions.cs
            // Convert selective HTML tags to Markdown using C#
            // Learn more: https://docs.aspose.com/html/net/convert-html-to-markdown/

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "options-output.md");

            // Prepare HTML code and save it to the file
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Hello, World!!</p>" +
                          "<a href='aspose.com'>aspose</a>";
            File.WriteAllText(Path.Combine(OutputDir, "options.html"), code);

            // Create an instance of SaveOptions and set up the rule: 
            // - only <a> and <p> elements will be converted to Markdown
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;

            // Call the ConvertHTML() method to convert the HTML to Markdown
            Converter.ConvertHTML(Path.Combine(OutputDir, "options.html"), options, savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
