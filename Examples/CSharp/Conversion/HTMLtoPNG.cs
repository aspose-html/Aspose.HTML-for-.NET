using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoPNG
    {
        public static void Run()
        {
            // ExStart:HTMLToPNG
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            Aspose.Html.Rendering.Image.ImageRenderingOptions img_options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();

            // Instantiate PdfDevice object while passing PdfRenderingOptions and resultant file path as arguments
            using (Aspose.Html.Rendering.Image.ImageDevice img_device = new Aspose.Html.Rendering.Image.ImageDevice(img_options, dataDir + "Aspose_HTML.png"))
            // Create HtmlRenderer object
            using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
            // Create HtmlDocument instance while passing path of already created HTML file
            using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(dataDir + "input.html"))
            {
                // Render the output using HtmlRenderer
                renderer.Render(img_device, html_document);
            }
            // ExEnd:HTMLToPNG           
        }
    }
}
