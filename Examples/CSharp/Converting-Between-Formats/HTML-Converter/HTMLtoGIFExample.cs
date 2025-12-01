using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Aspose.Html.Examples
{
    public class HTMLtoGIFExample : BaseExample
    {
        public HTMLtoGIFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-gif");
        }

        // Convert HTML to GIF using C#
        public void ConvertHtmlToGif()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "spring-output.gif");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageSaveOptions class
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert HTML to GIF
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to GIF with ImageSaveOptions using C#
        public void ConvertHtmlToGifWithImageSaveOptions()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(OutputDir, "convert-to-gif.html");

            // Prepare a path for the converted file
            string savePath = Path.Combine(OutputDir, "convert-to-gif-options.gif");

            // Prepare HTML code and save it to a file
            string code = "<h1> HTML to GIF Converter </h1>\r\n" +
                          "<p> GIF is a popular image format that supports animated images and frequently used in web publishing. HTML to GIF conversion allows you to save an HTML document as a GIF image.  </p>\r\n";
            File.WriteAllText(documentPath, code);

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize ImageSaveOptions with custom settings
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif)
            {
                UseAntialiasing = false,
                HorizontalResolution = 100,
                VerticalResolution = 100,
                BackgroundColor = System.Drawing.Color.MistyRose
            };
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(500, 200), new Margin(30, 20, 10, 10));

            // Convert HTML to GIF
            Converter.ConvertHTML(document, options, savePath);
        }
    }
}