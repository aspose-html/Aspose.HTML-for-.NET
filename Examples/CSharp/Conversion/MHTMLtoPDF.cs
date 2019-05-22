using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class MHTMLtoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source MHTML document  
            FileStream fileStream = File.OpenRead(dataDir + "sample.mht");
            // Initialize pdfSaveOptions 
            PdfSaveOptions options = new PdfSaveOptions()
            {
                JpegQuality = 100
            };
            // Output file path 
            string outputFile = dataDir + "MHTMLtoPDF_Output.pdf";
            // Convert MHTML to PDF 
            Converter.ConvertMHTML(fileStream, options, outputFile);
            // ExEnd:1
        }
    }
}
