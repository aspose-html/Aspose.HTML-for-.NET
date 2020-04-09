using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertMarkdownToHTML
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Prepare a simple Markdown example
            var code = "### Hello World" +
                       "\r\n" +
                       "[visit applications](https://products.aspose.app/html/family)";
            // Create a Markdown file
            System.IO.File.WriteAllText("document.md", code);

            // Convert Markdown to HTML document
            Aspose.Html.Converters.Converter.ConvertMarkdown("document.md", "document.html");
            //ExEnd: WithASingleLine
        }

        public static void ConvertMarkdownToPNG()
        {
            //ExStart: ConvertMarkdownToPNG
            // Prepare a simple Markdown example
            var code = "### Hello World" +
                       "\r\n" +
                       "[visit applications](https://products.aspose.app/html/family)";
            // Create a Markdown file
            System.IO.File.WriteAllText("document.md", code);

            // Convert Markdown to HTML document
            using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown("document.md"))
            {
                // Convert HTML document to PNG image file format
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png), "output.png");
            }
            //ExEnd: ConvertMarkdownToPNG
        }
    }
}
