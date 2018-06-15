using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    class HTMLtoMHTML
    {
        public static void Run()
        {
            // ExStart:HTMLToMHTML
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", dataDir))
            {
                // Save to MHTML format
                document.Save(dataDir + "document.mht", HTMLSaveFormat.MHTML);
            }
            // ExEnd:HTMLToMHTML           
        }
        public static void MHTMLSaveOptions()
        {

            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();
            // ExStart:MHTMLSaveOptions
            using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", dataDir))
            {
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();
                // Set the resource handling rules
                options.ResourceHandlingOptions.MaxHandlingDepth = 1;

                // Save to MHTML format
                document.Save(dataDir + "document.mht", options);
            }
            // ExEnd:MHTMLSaveOptions          
        }

    }
}
