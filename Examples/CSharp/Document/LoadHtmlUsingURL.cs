using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Document
{
    public class LoadHtmlUsingURL
    {
        public static void Run()
        {
            // ExStart:LoadHtmlUsingURL
            String InputHtml = "http://aspose.com/";
            // Load HTML file using Url instance
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(InputHtml));
            // Print inner HTML of file to console
            Console.WriteLine(document.Body.InnerHTML);
            // ExEnd:LoadHtmlUsingURL           
        }
    }
}