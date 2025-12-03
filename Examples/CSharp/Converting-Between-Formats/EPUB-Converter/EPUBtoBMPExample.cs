using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class EPUBtoBMPExample : BaseExample
    {
        public EPUBtoBMPExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("epub-converter/epub-to-bmp");
        }

        // Convert EPUB to BMP by two lines
        public void ConvertEPUBByTwoLines()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Convert EPUB to BMP
            Converter.ConvertEPUB(stream, new ImageSaveOptions(ImageFormat.Bmp), Path.Combine(OutputDir, "convert-by-two-lines.bmp"));
        }

        // Convert EPUB to BMP
        public void ConvertEPUBToBmp()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "input-output.bmp");
            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // Convert EPUB to BMP
            Converter.ConvertEPUB(stream, options, savePath);
        }

        // Convert EPUB to BMP with ImageSaveOptions
        public void ConvertEPUBToBmpWithImageSaveOptions()
        {
            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "input-options.bmp");
            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp)
            {
                UseAntialiasing = true,
                HorizontalResolution = 400,
                VerticalResolution = 400,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            // Convert EPUB to BMP
            Converter.ConvertEPUB(stream, options, savePath);
        }
    }
}