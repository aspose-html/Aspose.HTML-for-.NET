using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class MDtoHTMLExample : BaseExample
    {
        public MDtoHTMLExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-html");
        }

        // Convert Markdown file to HTML file (output path specified)
        public void ConvertMarkdownToHtml()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/)";

            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Prepare a path to save the converted HTML file
            string savePath = Path.Combine(OutputDir, "document-output.html");

            // Convert Markdown to HTML
            Converter.ConvertMarkdown(sourcePath, savePath);
        }

        // Convert Markdown file located in the data folder to HTML file
        public void ConvertMarkdownFileToHtml()
        {
            // Prepare a path to a source Markdown file in the data folder
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Prepare a path to save the converted HTML file
            string savePath = Path.Combine(OutputDir, "nature-output.html");

            // Convert Markdown to HTML
            Converter.ConvertMarkdown(sourcePath, savePath);
        }

        // Convert Markdown string to HTML document, add custom CSS and save
        public void ConvertMarkdownStringToHtml()
        {
            // Markdown content as a string
            string markdownContent = "# How to Convert a Markdown File to HTML\n" +
                                    "Markdown is a lightweight markup language used for formatting text. " +
                                    "If you need to convert a Markdown file to an HTML document, you can use **Aspose.HTML for .NET**.\n\n" +
                                    "## Steps to Convert\n" +
                                    "1. Load the Markdown file.\n" +
                                    "2. Convert it to an HTML document.\n" +
                                    "3. Save the output file.\n\n" +
                                    "## Example Code\n" +
                                    "```csharp\n" +
                                    "// Convert a Markdown file to HTML\n" +
                                    "Converter.ConvertMarkdown(\"input.md\", \"output.html\");\n" +
                                    "```\n\n" +
                                    "For more details, refer to the [official documentation](https://docs.aspose.com/html/net/convert-markdown-to-html/).";

            // Create a memory stream from the Markdown string
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdownContent)))
            {
                // Convert Markdown to HTML document
                HTMLDocument document = Converter.ConvertMarkdown(stream, "");

                // Ensure the document has a <head> element
                HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLHeadElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                // Add custom CSS styles
                string cssStyles = "body { font-family: Arial, sans-serif; max-width: 800px; margin: auto; padding: 20px; background-color: #f9f9f9; }\n" +
                                   "h1, h2 { color: #333; }\n" +
                                   "p, li { font-size: 14px; }\n" +
                                   "code, pre { font-family: Consola, monospace; color: #f8f8f2; background-color: #272822; padding: 10px; border-radius: 5px; display: block; }";

                HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
                styleElement.TextContent = cssStyles;
                head.AppendChild(styleElement);

                // Save the resulting HTML file
                string outputPath = Path.Combine(OutputDir, "markdown-string-output.html");
                document.Save(outputPath);
            }
        }
    }
}