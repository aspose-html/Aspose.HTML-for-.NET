using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Demonstrates editing an HTML5 canvas and rendering various canvas drawings to PDF
    /// </summary>
    public class EditHTML5CanvasExample : BaseExample
    {
        public EditHTML5CanvasExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("advanced-programming/html5-canvas");
        }


        /// <summary>
        /// Converts an HTML5 canvas to PDF (original test snippet).
        /// </summary>
        public void ConvertHtml5CanvasToPdf()
        {
            // Prepare an output path
            string outputPath = Path.Combine(OutputDir, "canvas-output.pdf");

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

            File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (HTMLDocument document = new HTMLDocument("document.html"))
            {
                // Convert HTML to PDF
                Converter.ConvertHTML(document, new PdfSaveOptions(), outputPath);
            }

            Console.WriteLine($"Canvas converted to PDF: {outputPath}");
        }

        /// <summary>
        /// Demonstrates basic 2D drawing on a canvas
        /// </summary>
        public void CanvasRenderingContext2D()
        {
            // Create an empty HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a <canvas> element
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 500;
                canvas.Height = 150;
                document.Body.AppendChild(canvas);

                // Get the canvas rendering context
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

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

                // Save the result to PDF
                string outputPath = Path.Combine(OutputDir, "canvas-2d.pdf");
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"2D canvas rendered to PDF: {outputPath}");
            }
        }

        /// <summary>
        /// Demonstrates drawing with a radial gradient
        /// </summary>
        public void RadialGradient()
        {
            using (HTMLDocument document = new HTMLDocument())
            {
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 400;
                canvas.Height = 400;
                canvas.Style.Border = "1 solid #d3d3d3";
                document.Body.AppendChild(canvas);

                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create a radial gradient
                ICanvasGradient gradient = context.CreateRadialGradient(200, 200, 40, 200, 200, 140);
                gradient.AddColorStop(0, "#c11700");
                gradient.AddColorStop(0.5, "orange");
                gradient.AddColorStop(1, "#5a2100");

                context.Font = "bold 28px serif";
                context.FillStyle = "gold";
                context.FillText("Radial Gradient", 100, 40);
                context.FillStyle = gradient;
                context.FillRect(50, 50, 400, 400);

                string outputPath = Path.Combine(OutputDir, "canvas-radial.pdf");
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Radial gradient canvas rendered to PDF: {outputPath}");
            }
        }

        /// <summary>
        /// Demonstrates drawing a simple rectangle on a canvas
        /// </summary>
        public void RectangleExample()
        {
            using (HTMLDocument document = new HTMLDocument())
            {
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 500;
                canvas.Height = 500;
                document.Body.AppendChild(canvas);

                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Draw a green rectangle
                context.FillStyle = "green";
                context.FillRect(50, 50, 300, 100);

                // Save the result to PDF
                string outputPath = Path.Combine(OutputDir, "canvas-rectangle.pdf");
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Rectangle canvas rendered to PDF: {outputPath}");
            }
        }
    }
}