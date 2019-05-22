using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class EPUBtoPDF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source EPUB document  
            FileStream fileStream = File.OpenRead(dataDir + "input.epub");
            // Initialize pdfSaveOptions 
            PdfSaveOptions options = new PdfSaveOptions()
            {
                JpegQuality = 100
            };
            // Output file path 
            string outputFile = dataDir + "EPUBtoPDF_Output.pdf";
            // Convert EPUB to PDF 
            Converter.ConvertEPUB(fileStream, options, outputFile);
            // ExEnd:1
        }
    }
}
