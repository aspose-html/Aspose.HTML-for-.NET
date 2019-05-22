using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class MHTMLtoXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source EPUUB document  
            FileStream fileStream = File.OpenRead(dataDir + "sample.mht");
            // Initialize XpsSaveOptions 
            XpsSaveOptions options = new XpsSaveOptions()
            {
                BackgroundColor = System.Drawing.Color.Cyan
            };
            // Output file path 
            string outputFile = dataDir + "MHTMLtoXPS_Output.xps";
            // Convert MHTML to XPS 
            Converter.ConvertMHTML(fileStream, options, outputFile);
            // ExEnd:1   
        }

    }
}
