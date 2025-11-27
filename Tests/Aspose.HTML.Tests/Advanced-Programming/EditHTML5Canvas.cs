using Aspose.Html;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Advanced_Programming
{
    public class EditHTML5Canvas : TestsBase
    {
        public EditHTML5Canvas(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("advanced-programming/html5-canvas");
        }


        [Fact(DisplayName = "Edit HTML5 Canvas")]
        public void EditHTML5CanvasTest()
        {
            // @START_SNIPPET ConvertHtml5CanvasToPdf.cs
            // How to edit HTML5 Canvas and convert it to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html5-canvas/

            // Prepare an output path
            string outputPath = Path.Combine(OutputDir, "output.pdf");

            // Prepare a document with HTML5 Canvas inside and save it to the file "document.html"
            string code = @"
                <canvas id=myCanvas width='200' height='100' style='border:1px solid #d3d3d3;'></canvas>
                <script>
                    var c = document.getElementById('myCanvas');
                    var context = c.getContext('2d');
                    context.font = '30px Arial';
                    context.fillStyle = 'red';
                    context.fillText('Hello, World', 40, 50);
                </script>";

            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (HTMLDocument document = new HTMLDocument("document.html"))
            {
                // Convert HTML to PDF
                Converter.ConvertHTML(document, new PdfSaveOptions(), outputPath);
            }
            // @END_SNIPPET

            Assert.True(File.Exists(outputPath));
        }


        [Fact(DisplayName = "Canvas Rendering Context 2D")]
        public void CanvasRenderingContext2DTest()
        {
            // @START_SNIPPET CanvasRenderingContext2D.cs
            // How to render HTML5 Canvas 2D to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html5-canvas/

            // Create an empty HTML document
            using HTMLDocument document = new HTMLDocument();

            // Create a <canvas> element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");

            // with a specified size
            canvas.Width = 500;
            canvas.Height = 150;

            // and append it to the document body
            document.Body.AppendChild(canvas);

            // Get the canvas rendering context to draw
            ICanvasRenderingContext2D context = (Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Prepare a gradient brush
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "magenta");
            gradient.AddColorStop(0.4, "blue");
            gradient.AddColorStop(0.9, "red");

            // Assign the brush to the content
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Write the text
            context.FillText("Hello, World!", 10, 90, 500);

            // Fill the rectangle
            context.FillRect(0, 95, 500, 100);

            // Prepare an output path
            string outputPath = Path.Combine(OutputDir, "canvas.pdf");

            // Create the PDF output device
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                // Render HTML5 Canvas to PDF
                document.RenderTo(device);
            }
            Assert.True(File.Exists(outputPath));
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Canvas Rendering Context 2D with Radial Gradient")]
        public void RadialGradientTest()
        {
            // Create an HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Add a <canvas> element to the document
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                document.Body.AppendChild(canvas);

                // Set the width, height and sstyle attributes of the canvas
                canvas.Width = 400;
                canvas.Height = 400;
                canvas.Style.Border = "1 solid #d3d3d3";

                // Get the rendering context of the canvas (2d context)
                ICanvasRenderingContext2D context = (Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create a radial gradient
                ICanvasGradient gradient = context.CreateRadialGradient(200, 200, 40, 200, 200, 140);
                gradient.AddColorStop(0, "#c11700");
                gradient.AddColorStop(0.5, "orange");
                gradient.AddColorStop(1, "#5a2100");

                // Write the text
                context.Font = "bold 28px serif";
                context.FillStyle = "gold";
                context.FillText("Radial Gradient", 100, 40);

                // Fill the rectangle with the radial gradient
                context.FillStyle = gradient;
                context.FillRect(50, 50, 400, 400);

                // Prepare an output path
                string outputPath = Path.Combine(OutputDir, "canvas-radial.pdf");

                // Create the PDF output device
                using PdfDevice device = new PdfDevice(outputPath);

                // Render HTML5 Canvas to PDF
                document.RenderTo(device);

                // Save the HTML document to a file
                //document.Save(Path.Combine(OutputDir, "canvas-radial.html"));

                Assert.True(File.Exists(outputPath));
            }
        }


        [Fact(DisplayName = "Canvas Rendering Context 2D Rectangle")]
        public void RectTest()
        {
            // Create an empty HTML document
            using HTMLDocument document = new HTMLDocument();

            // Create the Canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");

            // with a specified size
            canvas.Width = 500;
            canvas.Height = 500;

            // and append it to the document body
            document.Body.AppendChild(canvas);

            // Get the rendering context of the canvas (2d context in this case)
            ICanvasRenderingContext2D context = (Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw a simple rectangle on the canvas
            context.FillStyle = "green";
             context.FillRect(50, 50, 300, 100);

            // Prepare an output path
            string outputPath = Path.Combine(OutputDir, "rect.pdf");

            // Create the PDF output device
            using PdfDevice device = new PdfDevice(outputPath);

            // Render HTML5 Canvas to PDF
            document.RenderTo(device);

            Assert.True(File.Exists(outputPath));
        }
    }
}
