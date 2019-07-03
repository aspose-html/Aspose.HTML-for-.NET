using Aspose.Html.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class MarkdownToHTML
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();
            // Convert markdown to HTML
            Converter.ConvertMarkdown(dataDir + "Markdown.md", dataDir + "MarkdownToHTML.html");
            // ExEnd:1          
        }
    }
}
