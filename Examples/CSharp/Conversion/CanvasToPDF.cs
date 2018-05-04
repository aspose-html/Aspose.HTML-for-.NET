using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    class CanvasToPDF
    {
        public static void Run()
        {
            // ExStart:CanvasToPDF
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new HTMLDocument(dataDir + "canvas.html"))
            {
                // Create an instance of HTML renderer and XPS output device
                using (var renderer = new Rendering.HtmlRenderer())
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(dataDir + "canvas.pdf"))
                {
                    //  Render the document to the specified device
                    renderer.Render(device, document);
                }
            }
            // ExEnd:CanvasToPDF           
        }
    }
}
