using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Document
{
    class SaveDocument
    {
        public static void Run()
        {

        }
        private static void SaveToFile()
        {
            //ExStart: SaveToFile
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", "about:blank"))
            {
                document.Save(dataDir + "SaveToFile_out.html");
            }
            //ExEnd: SaveToFile
        }

        private static void SaveUsingHTMLSaveOptions()
        {
            //ExStart: SaveUsingHTMLSaveOptions
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", "about:blank"))
            {
                // Create options object
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

                // Set the maximum depth of resource which will be handled.
                // Depth of 1 means that only resources directly referenced from the saved document will be handled.
                // Setting this property to -1 will lead to handling of all resources.
                // Default value is 3
                options.ResourceHandlingOptions.MaxHandlingDepth = 1;

                // This property is used to set restriction applied to handlers of external resources.
                // SameHost means that only resources located at the same host will be saved.
                options.ResourceHandlingOptions.UrlRestriction = Aspose.Html.Saving.UrlRestriction.SameHost;

                // This property is used to setup processing behaviour of any type of resource.
                // ResourceHandling.Save means all resources will be saved to the output folder
                options.ResourceHandlingOptions.Default = Aspose.Html.Saving.ResourceHandling.Save;

                // This property is used to set up processing behaviour of particular 'application/javascript' mime type.
                // In our case all scripts will be skipped during saving
                options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Discard;

                // Save the document
                document.Save(dataDir + "SaveUsingHTMLSaveOptions_out.html", options);
            }
            //ExEnd: SaveUsingHTMLSaveOptions
        }

        private static void HTMLToMHTML()
        {
            //ExStart: HTMLToMHTML
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument(@"
<link href=""c:\work\style.css"" rel=""stylesheet"">
<p>my first paragraph</p>", "about:blank"))
            {
                // Create corresponding save options
                var saveOptions = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Set default resource handling behaviour to "embed"
                saveOptions.ResourceHandlingOptions.Default = Aspose.Html.Saving.ResourceHandling.Embed;

                // Remove URL restrictions because referenced resource is in another domain 
                saveOptions.ResourceHandlingOptions.UrlRestriction = Aspose.Html.Saving.UrlRestriction.None;

                // Save to .mht file
                document.Save(dataDir + "HtmlToMhtml_out.mht", saveOptions);
            }
            //ExEnd:HTMLToMHTML
        }

        private static void HTMLToMarkDown()
        {
            //ExStart: HTMLToMarkDown
            string dataDir = RunExamples.GetDataDir_Data();
            using (var document = new Aspose.Html.HTMLDocument("<h1>heading text</h1>", "about:blank"))
            {
                // Create corresponding save options
                var saveOptions = Aspose.Html.Saving.MarkdownSaveOptions.Git;

                // Save to .md file
                document.Save(dataDir+ "HTMLToMarkDown_out.md", saveOptions);
            }
            //ExEnd: HTMLToMarkDown
        }
    }
}
