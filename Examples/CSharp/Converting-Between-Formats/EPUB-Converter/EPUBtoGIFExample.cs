using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class EPUBtoGIFExample : BaseExample
    {
        public EPUBtoGIFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-gif");
        }

        // Convert EPUB to GIF by two lines
        public void ConvertEPUBByTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to GIF
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Gif), Path.Combine(OutputDir, "convert-by-two-lines.gif"));
        }

        // Convert EPUB to GIF
        public void ConvertEPUBToGif()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.gif");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Convert EPUB to GIF
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to GIF with ImageSaveOptions
        public void ConvertEPUBToGifWithImageSaveOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "input-options.gif");
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Set page size and margins
            options.PageSetup.AnyPage = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
            // Convert EPUB to GIF with custom options
            Converter.ConvertEPUB(stream, options, savePath);
        }
    }
}