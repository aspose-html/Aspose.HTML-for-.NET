using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.QuickStart
{
    public class ApplyMeteredLicense
    {
        public static void Run()
        {
            // ExStart:ApplyMeteredLicense
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // set metered public and private keys
            Aspose.Html.Metered metered = new Aspose.Html.Metered();
            // Access the setMeteredKey property and pass public and private keys as parameters
            metered.SetMeteredKey("*****", "*****");

            // Load the document from disk.
            HTMLDocument document = new HTMLDocument(dataDir + "input.html");
            // Print inner HTML of file to console
            Console.WriteLine(document.Body.InnerHTML);
            // ExEnd:ApplyMeteredLicense 
        }
    }
}