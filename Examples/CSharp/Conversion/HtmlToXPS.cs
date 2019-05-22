using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoXPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source HTML document  
            HTMLDocument htmlDocument = new HTMLDocument(dataDir + "input.html");
            // Initialize XpsSaveOptions 
            XpsSaveOptions options = new XpsSaveOptions
            {
                BackgroundColor = System.Drawing.Color.Cyan
            };
            // Output file path 
            string outputFile = dataDir + "input.xps";
            // Convert HTML to XPS
            Converter.ConvertHTML(htmlDocument, options, outputFile);
            // ExEnd:1         
        }
    }
}