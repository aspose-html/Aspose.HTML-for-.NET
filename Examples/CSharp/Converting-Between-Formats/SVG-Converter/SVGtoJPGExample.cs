using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class SVGtoJPGExample : BaseExample
    {
        public SVGtoJPGExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-jpg");
        }

        // Convert SVG to JPG in one line
        public void ConvertSVGToJpgWithSingleLine()
        {
            // Convert SVG to JPG
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Jpeg), Path.Combine(OutputDir, "convert-with-single-line.jpg"));
        }

        // Convert SVG to JPG
        public void ConvertSVGToJpg()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='55' fill='green' stroke='red' stroke-width='10' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.jpg");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Convert SVG to JPG
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to JPG with ImageSaveOptions
        public void ConvertSVGToJpgWithImageSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "flower.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "flower-options.jpg");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert SVG to JPG
            Converter.ConvertSVG(document, options, savePath);
        }
    }
}