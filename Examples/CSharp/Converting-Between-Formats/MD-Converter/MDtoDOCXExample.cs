using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class MDtoDOCXExample : BaseExample
    {
        public MDtoDOCXExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("md-converter/md-to-docx");
        }

        // Convert Markdown to DOCX
        public void ConvertMarkdownToDocx()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(OutputDir, "document.md");

            // Prepare a simple Markdown example
            string code = "### Hello, World!" +
                          "\r\n" +
                          "Convert Markdown to DOCX!";

            // Create a Markdown file
            File.WriteAllText(sourcePath, code);

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Prepare a path for the converted DOCX file
            string savePath = Path.Combine(OutputDir, "document-output.docx");

            // Convert the HTML document to DOCX format
            Converter.ConvertHTML(document, new DocSaveOptions(), savePath);
        }

        // Convert Markdown to DOCX with custom DocSaveOptions
        public void ConvertMarkdownToDocxWithOptions()
        {
            // Prepare a path to a source Markdown file
            string sourcePath = Path.Combine(DataDir, "nature.md");

            // Convert Markdown to HTML
            using HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            // Create DocSaveOptions with custom page size and margins
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Size(500, 1000), new Margin(20, 20, 10, 10));

            // Prepare a path for the converted DOCX file
            string savePath = Path.Combine(OutputDir, "nature-output.docx");

            // Convert the HTML document to DOCX format
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}