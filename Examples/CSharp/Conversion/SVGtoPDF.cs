using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class SVGtoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source SVG document  
            SVGDocument svgDocument = new SVGDocument(dataDir + "input.svg");
            // Initialize pdfSaveOptions 
            PdfSaveOptions options = new PdfSaveOptions()
            {
                JpegQuality = 100
            };
            // Output file path 
            string outputFile = dataDir + "SVGtoPDF_Output.pdf";
            // Convert SVG to PDF 
            Converter.ConvertSVG(svgDocument, options, outputFile);
            // ExEnd:1
        }
    }
}
