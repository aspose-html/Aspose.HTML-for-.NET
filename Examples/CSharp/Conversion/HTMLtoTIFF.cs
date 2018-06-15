using Aspose.Html.Rendering.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoTIFF
    {
        public static void Run()
        {
            // ExStart:HTMLToTIFF
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            Aspose.Html.Rendering.Image.ImageRenderingOptions pdf_options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            pdf_options.Format = ImageFormat.Tiff;
            // Instantiate PdfDevice object while passing PdfRenderingOptions and resultant file path as arguments
            using (Aspose.Html.Rendering.Image.ImageDevice pdf_device = new Aspose.Html.Rendering.Image.ImageDevice(pdf_options, dataDir + "Aspose_HTML.tiff"))
            // Create HtmlRenderer object
            using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
            // Create HtmlDocument instance while passing path of already created HTML file
            using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(dataDir + "input.html"))
            {
                // Render the output using HtmlRenderer
                renderer.Render(pdf_device, html_document);
            }
            // ExEnd:HTMLToTIFF           
        }
    }
}
