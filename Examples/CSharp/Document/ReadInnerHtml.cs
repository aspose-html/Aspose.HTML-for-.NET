using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Document
{
    public class ReadInnerHtml
    {
        public static void Run()
        {
            // ExStart:ReadInnerHtml
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            String InputHtml = dataDir + "input.html";
            // Create HtmlDocument instance to load existing HTML file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(InputHtml);
            // Print inner HTML of file to console
            Console.WriteLine(document.Body.InnerHTML);
            // ExEnd:ReadInnerHtml           
        }
    }
}