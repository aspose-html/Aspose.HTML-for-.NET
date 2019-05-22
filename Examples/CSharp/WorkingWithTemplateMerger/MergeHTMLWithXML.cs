using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace Aspose.Html.Examples.CSharp.WorkingWithTemplateMerger
{
    public class MergeHTMLWithXML
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // HTML template document 
            HTMLDocument templateHtml = new HTMLDocument(dataDir + "HTMLTemplateforXML.html");
            //XML data for merging 
            TemplateData data = new TemplateData(dataDir + "XMLTemplate.xml");
            //Output file path 
            string templateOutput = dataDir + "HTMLTemplate_Output.html";
            //Merge HTML tempate with XML data
            Converter.ConvertTemplate(templateHtml, data, new TemplateLoadOptions(), templateOutput);
            // ExEnd:1
        }
    }
}
