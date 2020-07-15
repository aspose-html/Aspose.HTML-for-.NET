using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoDOCandDOCX
    {
        public static void Run()
        {
            // ExStart:HTMLtoDOCandDOCX
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source HTML document  
            HTMLDocument htmlDocument = new HTMLDocument(dataDir + "input.html");

            DocSaveOptions options = new DocSaveOptions();

            options.DocumentFormat = Rendering.Doc.DocumentFormat.DOCX;

            Converter.ConvertHTML(htmlDocument, options, dataDir + "HTMLtoDOCX_out.docx");
            // ExEnd:HTMLtoDOCandDOCX
        }
    }
}
