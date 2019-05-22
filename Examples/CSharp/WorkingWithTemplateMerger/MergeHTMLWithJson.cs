using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace Aspose.Html.Examples.CSharp.WorkingWithTemplateMerger
{
    public class MergeHTMLWithJson
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // HTML template document 
            HTMLDocument templateHtml = new HTMLDocument(dataDir + "HTMLTemplateForJson.html");
            //XML data for merging 
            TemplateData data = new TemplateData(dataDir + "JsonTemplate.json");
            //Output file path 
            string templateOutput = dataDir + "MergeHTMLWithJson_Output.html";
            //Merge HTML tempate with XML data
            Converter.ConvertTemplate(templateHtml, data, new TemplateLoadOptions(), templateOutput);
            // ExEnd:1
        }
    }
}
