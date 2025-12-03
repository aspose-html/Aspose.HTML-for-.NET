using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class SVGtoGIFExample : BaseExample
    {
        public SVGtoGIFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("svg-converter/svg-to-gif");
        }

        // Convert SVG to GIF in one line
        public void ConvertSVGToGifWithSingleLine()
        {
            // Convert SVG to GIF
            Converter.ConvertSVG(Path.Combine(DataDir, "shapes.svg"), new ImageSaveOptions(ImageFormat.Gif), Path.Combine(OutputDir, "convert-with-single-line.gif"));
        }

        // Convert SVG to GIF
        public void ConvertSVGToGif()
        {
            // Prepare SVG code
            string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='55' fill='pink' stroke='red' stroke-width='8' /></svg>";
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "circle.gif");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Convert SVG to GIF
            Converter.ConvertSVG(code, ".", options, savePath);
        }

        // Convert SVG to GIF with ImageSaveOptions
        public void ConvertSVGToGifWithImageSaveOptions()
        {
            // Prepare a path to a source SVG file
            string documentPath = Path.Combine(DataDir, "gradient.svg");
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "gradient-options.gif");
            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(documentPath);
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif)
            {
                UseAntialiasing = true,
                HorizontalResolution = 200,
                VerticalResolution = 200,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert SVG to GIF
            Converter.ConvertSVG(document, options, savePath);
        }
    }
}