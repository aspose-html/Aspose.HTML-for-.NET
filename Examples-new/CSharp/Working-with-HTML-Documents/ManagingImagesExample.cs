using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Services;

namespace Aspose.Html.Examples
{
    public class ManagingImagesExample : BaseExample
    {
        public ManagingImagesExample()
        {
            SetOutputDir("images");
        }

        public void AddImage()
        {
            string sourcePath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "add-image.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLElement body = document.Body;
                HTMLImageElement img = (HTMLImageElement)document.CreateElement("img");
                img.Src = "https://docs.aspose.com/html/images/georgia-castle.png";
                img.Alt = "A descriptive alt text";
                img.Width = 1550;
                img.Height = 550;
                body.AppendChild(img);
                document.Save(savePath);
                Console.WriteLine($"Image added and saved to: {savePath}");
            }
        }
        public void AddImageBase64()
        {
            string sourcePath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "add-image-base64.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLElement body = document.Body;
                HTMLImageElement img = (HTMLImageElement)document.CreateElement("img");
                // Simplified placeholder Base64 image data
                img.Src = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQAB..."; // placeholder
                img.Alt = "Base64 image placeholder";
                img.Width = 1550;
                img.Height = 550;
                body.AppendChild(img);
                document.Save(savePath);
                Console.WriteLine($"Base64 image added and saved to: {savePath}");
            }
        }
    }
}