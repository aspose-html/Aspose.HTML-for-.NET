using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertHTMLToMarkdown
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Prepare an HTML code and save it to the file.
            var code = "<h1>Header 1</h1>" +
                       "<h2>Header 2</h2>" +
                       "<p>Hello World!!</p>";
            System.IO.File.WriteAllText("document.html", code);

            // Call ConvertHTML method to convert HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", new Aspose.Html.Saving.MarkdownSaveOptions(), "output.md");
            //ExEnd: WithASingleLine
        }

        public static void SpecifyMarkdownSaveOptions()
        {
            //ExStart: SpecifyMarkdownSaveOptions
            // Prepare an HTML code and save it to the file.
            var code = "<h1>Header 1</h1>" +
                       "<h2>Header 2</h2>" +
                       "<p>Hello World!!</p>" +
                       "<a href='aspose.com'>aspose</a>";
            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of SaveOptions and set up the rule: 
            // - only <a> and <p> elements will be converted to markdown.
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Call the ConvertHTML method to convert the HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", options, "output.md");
            //ExEnd: SpecifyMarkdownSaveOptions
        }

        public static void ConvertUsingGitSyntax()
        {
            //ExStart: ConvertUsingGitSyntax
            // Prepare an HTML code and save it to the file.
            var code = "<h1>Header 1</h1>" +
                       "<h2>Header 2</h2>" +
                       "<p>Hello World!!</p>";
            System.IO.File.WriteAllText("document.html", code);

            // Call ConvertHTML method to convert HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", Aspose.Html.Saving.MarkdownSaveOptions.Git, "output.md");
            //ExEnd: ConvertUsingGitSyntax
        }

        public static void InlineHTML()
        {
            //ExStart: InlineHTML
            // Prepare an HTML code and save it to the file.
            var code = "text<div markdown='inline'><code>text</code></div>";
            System.IO.File.WriteAllText("document.html", code);

            // Call ConvertHTML method to convert HTML to Markdown.
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", new Aspose.Html.Saving.MarkdownSaveOptions(), "output.md");
            // Output file will contain: text\r\n<div markdown="inline"><code>text</code></div>
            //ExEnd: InlineHTML
        }
    }
}
