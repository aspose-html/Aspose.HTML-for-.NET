using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class HTMLtoMHTMLExample : BaseExample
    {
        public HTMLtoMHTMLExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-mhtml");
        }

        // Convert HTML to MHTML with a single line
        public void ConvertHtmlToMhtmlWithSingleLine()
        {
            // Convert HTML to MHTML in C#
            Converter.ConvertHTML(@"<h1>Hellow, Word!</h1>", ".", new MHTMLSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.mht"));
        }

        // Convert HTML to MHTML from a file
        public void ConvertHtmlToMhtml()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "drawing.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "drawing-output.mht");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Convert HTML to MHTML
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to MHTML with custom options
        public void ConvertHtmlToMhtmlWithOptions()
        {
            // Prepare HTML code with a link to another file and save it to the file as 'document.html'
            string code = "<span>Hello, World!!</span> " +
                          "<a href='document2.html'>click</a>";
            File.WriteAllText("document.html", code);

            // Prepare HTML code and save it to the file as 'document2.html'
            string code2 = @"<span>Hello, World!!</span>";
            File.WriteAllText("document2.html", code2);

            // Prepare a path for the result file
            string savePath = Path.Combine(OutputDir, "output-options.mht");

            // Change the resource handling depth to 1 to include directly linked resources
            MHTMLSaveOptions options = new MHTMLSaveOptions()
            {
                ResourceHandlingOptions =
                {
                    MaxHandlingDepth = 1
                }
            };

            // Convert HTML to MHTML
            Converter.ConvertHTML("document.html", options, savePath);
        }
    }
}