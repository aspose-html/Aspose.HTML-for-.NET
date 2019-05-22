using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source HTML document  
            HTMLDocument htmlDocument = new HTMLDocument(dataDir + "input.html");
            // Initialize PdfSaveOptions 
            PdfSaveOptions options = new PdfSaveOptions
            {
                JpegQuality = 100
            };
            // Output file path 
            string outputPDF = dataDir + "HTMLtoPDF_Output.pdf";
            // Convert HTML to PDF
            Converter.ConvertHTML(htmlDocument, options, outputPDF);
            // ExEnd:1
        }
    }
}