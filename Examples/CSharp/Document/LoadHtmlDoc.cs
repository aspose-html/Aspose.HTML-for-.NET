using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Document
{
    public class LoadHtmlDoc
    {
        public static void Run()
        {
            // ExStart:LoadHtmlDoc
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            String InputHtml = dataDir + "input.html";
            using (FileStream fs = File.Create(InputHtml))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                // Write sample HTML tags to HTML file
                sw.Write(@"<p>this is a simple text");
            }
            // ExEnd:LoadHtmlDoc           
        }
    }
}