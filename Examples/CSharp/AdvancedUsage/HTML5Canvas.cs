using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.AdvancedUsage
{
    static class HTML5Canvas
    {
        public static void ManipulateUsingJavaScript()
        {
            //ExStart: ManipulateUsingJavaScript
            // Prepare a document with HTML5 Canvas inside and save it to the file 'document.html'
            var code = @"
                <canvas id=myCanvas width='200' height='100' style='border:1px solid #d3d3d3;'></canvas>
                <script>
                    var c = document.getElementById('myCanvas');
                    var context = c.getContext('2d');
                    context.font = '20px Arial';
                    context.fillStyle = 'red';
                    context.fillText('Hello World', 40, 50);
                </script>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new HTMLDocument("document.html"))
            {
                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");
            }
            //ExEnd: ManipulateUsingJavaScript
        }

        public static void ManipulateUsingCode()
        {
            //ExStart: ManipulateUsingCode
            // Create an empty HTML document
            using (var document = new Aspose.Html.HTMLDocument())
            {
                // Create the Canvas element
                var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");

                // with a specified size
                canvas.Width = 300;
                canvas.Height = 150;

                // and append it to the document body
                document.Body.AppendChild(canvas);

                // Get the canvas rendering context to draw
                var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Prepare the gradient brush
                var gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
                gradient.AddColorStop(0, "magenta");
                gradient.AddColorStop(0.5, "blue");
                gradient.AddColorStop(1.0, "red");

                // Assign brush to the content
                context.FillStyle = gradient;
                context.StrokeStyle = gradient;

                // Write the Text
                context.FillText("Hello World!", 10, 90, 500);

                // Fill the Rectangle
                context.FillRect(0, 95, 300, 20);
                
                // Create the PDF output device
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice("canvas.pdf"))
                {
                    // Render HTML5 Canvas to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: ManipulateUsingCode
        }
    }
}
