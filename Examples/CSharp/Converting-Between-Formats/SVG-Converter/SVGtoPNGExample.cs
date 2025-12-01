using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class SVGtoPNGExample : BaseExample
    {
        public SVGtoPNGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-png");
        }

        // Convert SVG to PNG in one line
        public void ConvertSVGToPngWithSingleLine()
        {
            // Convert SVG to PNG
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.png"));
        }

        // Convert SVG to PNG
        public void ConvertSVGToPng()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='60' fill='none' stroke='red' stroke-width='10' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.png");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions();
            // Convert SVG to PNG
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to PNG with ImageSaveOptions
        public void ConvertSVGToPngWithImageSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower1.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "flower-options.png");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions()
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                UseAntialiasing = true
            };
            // Convert SVG to PNG
            Converter.ConvertSVG(document, options, savePath);
        }
    }
}