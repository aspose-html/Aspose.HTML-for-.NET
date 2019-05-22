using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class EPUBtoXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source EPUB document  
            FileStream epubDocumentStream = File.OpenRead(dataDir + "input.epub");
            // Initialize XpsSaveOptions 
            XpsSaveOptions options = new XpsSaveOptions()
            {
                BackgroundColor = System.Drawing.Color.Cyan
            };
            // Output file path 
            string outputFile = dataDir + "EPUBtoXPS_Output.xps";
            // Convert EPUB to XPS 
            Converter.ConvertEPUB(epubDocumentStream, options, outputFile);
            // ExEnd:1   
        }

    }
}
