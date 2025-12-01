using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class SVGtoDOCXExample : BaseExample
    {
        public SVGtoDOCXExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-docx");
        }

        // Convert SVG to DOCX in one line
        public void ConvertSVGToDocxWithSingleLine()
        {
            // Convert SVG to DOCX
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new DocSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.docx"));
        }

        // Convert SVG to DOCX
        public void ConvertSVGToDocx()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='50' fill='none' stroke='red' stroke-width='10' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.docx");
            // Initialize DocSaveOptions
            DocSaveOptions options = new DocSaveOptions();
            // Convert SVG to DOCX
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to DOCX with custom page settings
        public void ConvertSVGToDocxWithDocSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "shapes.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "shapes-options.docx");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize DocSaveOptions with custom page size and margins
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Size(500, 500), new Margin(30, 10, 10, 10));
            // Convert SVG to DOCX
            Converter.ConvertSVG(document, options, savePath);
        }
    }
}