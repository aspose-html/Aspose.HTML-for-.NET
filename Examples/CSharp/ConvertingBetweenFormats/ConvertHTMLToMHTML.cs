using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertHTMLToMHTML
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Invoke the ConvertHTML method to convert the HTML to MHT.
            Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello World!!</span>", ".", new Aspose.Html.Saving.MHTMLSaveOptions(), "output.mht");
            //ExEnd: WithASingleLine
        }

        public static void ConvertHTMLDocumentToMHTML()
        {
            //ExStart: ConvertHTMLDocumentToMHTML
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize MHTMLSaveOptions
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Convert HTML to MHT
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.mht");
            }
            //ExEnd: ConvertHTMLDocumentToMHTML
        }

        public static void SpecifyMHTMLSaveOptions()
        {
            //ExStart: SpecifyMHTMLSaveOptions
            // Prepare an HTML code with a link to another file and save it to the file as 'document.html'
            var code = "<span>Hello World!!</span> " +
                       "<a href='document2.html'>click</a>";
            System.IO.File.WriteAllText("document.html", code);

            // Prepare an HTML code and save it to the file as 'document2.html'
            code = @"<span>Hello World!!</span>";
            System.IO.File.WriteAllText("document2.html", code);

            // Change the value of the resource linking depth to 1 in order to convert document with directly linked resources.
            var options = new Aspose.Html.Saving.MHTMLSaveOptions()
            {
                ResourceHandlingOptions =
                {
                    MaxHandlingDepth = 1
                }
            };

            // Convert HTML to MHT
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", options, "output.mht");
            //ExEnd: SpecifyMHTMLSaveOptions
        }
    }
}
