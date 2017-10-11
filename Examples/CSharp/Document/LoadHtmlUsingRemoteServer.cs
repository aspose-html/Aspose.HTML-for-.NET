using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Document
{
    public class LoadHtmlUsingRemoteServer
    {
        public static void Run()
        {
            // ExStart:LoadHtmlUsingRemoteServer
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(@"https://www.w3.org/TR/html5/"));

            // Read children nodes and get length information
            if (document.Body.ChildNodes.Length == 0)
                Console.WriteLine("No ChildNodes found...");
            // Print Document URI to console. As per information above, it has to be https://www.w3.org/TR/html5/
            Console.WriteLine("Print Document URI = " + document.DocumentURI);
            // Print domain name for remote HTML
            Console.WriteLine("Domain Name = " + document.Domain);
            // ExEnd:LoadHtmlUsingRemoteServer           
        }
    }
}