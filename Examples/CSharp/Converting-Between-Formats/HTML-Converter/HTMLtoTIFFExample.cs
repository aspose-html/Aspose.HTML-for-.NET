using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class HTMLtoTIFFExample : BaseExample
    {
        public HTMLtoTIFFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-tiff");
        }

        // Convert HTML to TIFF
        public void ConvertHtmlToTiff()
        {
            // Convert HTML to TIFF using C#
            string documentPath = Path.Combine(DataDir, "nature.html");
            string savePath = Path.Combine(OutputDir, "nature-output.tiff");
            using HTMLDocument document = new HTMLDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to TIFF with custom ImageSaveOptions
        public void ConvertHtmlToTiffWithImageSaveOptions()
        {
            // Convert HTML to TIFF in C# with custom settings
            string documentPath = Path.Combine(DataDir, "nature.html");
            string savePath = Path.Combine(OutputDir, "nature-output-options.tiff");
            using HTMLDocument document = new HTMLDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
            {
                Compression = Compression.None,
                BackgroundColor = System.Drawing.Color.Bisque,
                HorizontalResolution = 150,
                VerticalResolution = 150,
                UseAntialiasing = true
            };
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}