using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class HTMLtoMDExample : BaseExample
    {
        public HTMLtoMDExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-md");
        }

        // Convert HTML to Markdown
        public void ConvertHtmlToMarkdown()
        {
            // Convert HTML to Markdown in C#
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Convert HTML to Markdown</p>";
            File.WriteAllText("convert.html", code);
            Converter.ConvertHTML("convert.html", new MarkdownSaveOptions(), Path.Combine(OutputDir, "convert.md"));
        }

        // Convert HTML to Markdown using Git syntax
        public void ConvertHtmlToMarkdownUsingGitSyntax()
        {
            // Convert HTML to Markdown in C# using Git syntax
            string savePath = Path.Combine(OutputDir, "output-git.md");
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Hello, World!!</p>";
            File.WriteAllText(Path.Combine(OutputDir, "document.html"), code);
            Converter.ConvertHTML(Path.Combine(OutputDir, "document.html"), MarkdownSaveOptions.Git, savePath);
        }

        // Convert inline HTML elements to Markdown
        public void ConvertInlineHtmlToMarkdown()
        {
            // Convert inline HTML elements to Markdown using C#
            string savePath = Path.Combine(OutputDir, "inline-html.md");
            string code = "text<div markdown='inline'><code>text</code></div>";
            File.WriteAllText(Path.Combine(OutputDir, "inline.html"), code);
            Converter.ConvertHTML(Path.Combine(OutputDir, "inline.html"), new MarkdownSaveOptions(), savePath);
        }

        // Convert HTML to Markdown with custom options
        public void ConvertHtmlToMarkdownWithOptions()
        {
            // Convert HTML to Markdown with custom settings using C#
            string savePath = Path.Combine(OutputDir, "options-output.md");
            string code = "<h1>Header 1</h1>" +
                          "<h2>Header 2</h2>" +
                          "<p>Hello, World!!</p>" +
                          "<a href='aspose.com'>aspose</a>";
            File.WriteAllText(Path.Combine(OutputDir, "options.html"), code);
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;
            Converter.ConvertHTML(Path.Combine(OutputDir, "options.html"), options, savePath);
        }
    }
}