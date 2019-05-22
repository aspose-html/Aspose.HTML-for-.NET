using Aspose.Html.Converters;
using Aspose.Html.Saving;


namespace Aspose.Html.Examples.CSharp.Conversion
{
    class HTMLtoMHTML
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source HTML Document 
            HTMLDocument htmlDocument = new HTMLDocument(dataDir + "input.html");
            // Initialize MHTMLSaveOptions
            MHTMLSaveOptions options = new MHTMLSaveOptions();
            // Set the resource handling rules
            options.ResourceHandlingOptions.MaxHandlingDepth = 1;
            // Output file path 
            string outputPDF = dataDir + "HTMLtoMHTML_Output.mht";
            // Convert HTML to MHTML
            Converter.ConvertHTML(htmlDocument, options, outputPDF);
            // ExEnd:1          
        }
       
    }
}
