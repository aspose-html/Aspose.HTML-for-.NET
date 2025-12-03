using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class SVGtoBMPExample : BaseExample
    {
        public SVGtoBMPExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-bmp");
        }

        // Convert SVG to BMP in one line
        public void ConvertSVGToBmpWithSingleLine()
        {
            // Convert SVG to BMP
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Bmp), Path.Combine(OutputDir, "convert-with-single-line.bmp"));
        }

        // Convert SVG to BMP
        public void ConvertSVGToBmp()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='50' fill='none' stroke='red' stroke-width='10' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.bmp");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // Convert SVG to BMP
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to BMP with ImageSaveOptions
        public void ConvertSVGToBmpWithImageSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower1.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "flower-options.bmp");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue,
                UseAntialiasing = true
            };
            // Convert SVG to BMP
            Converter.ConvertSVG(document, options, savePath);
        }
    }
}