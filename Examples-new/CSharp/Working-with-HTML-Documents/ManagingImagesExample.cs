using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Services;
using Aspose.Html.Collections;
using System.Collections.Generic;
using Aspose.Html.Net;

namespace Aspose.Html.Examples
{
    public class ManagingImagesExample : BaseExample
    {
        public ManagingImagesExample()
        {
            SetOutputDir("images");
        }

        // Add an image to HTML
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

        // Add an image to an existing HTML file
        public void AddImageToHtml()
        {
            string sourcePath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "with-added-image.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLElement body = document.Body;
                HTMLImageElement img = (HTMLImageElement)document.CreateElement("img");
                img.Src = "https://docs.aspose.com/svg/files/lineto.svg";
                img.Alt = "A descriptive alt text";
                img.Width = 550;
                img.Height = 550;
                body.AppendChild(img);
                document.Save(savePath);
                Console.WriteLine($"Image added to existing HTML and saved to: {savePath}");
            }
        }

        // Resize the last image in an HTML document
        public void ResizeImage()
        {
            string sourcePath = Path.Combine(DataDir, "html_file.html");
            string savePath = Path.Combine(OutputDir, "resize-image.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                // Select the last <img> element
                Element element = document.QuerySelector("img:last-child");
                element.SetAttribute("width", "100");
                element.SetAttribute("height", "100");
                document.Save(savePath);
                Console.WriteLine($"Image resized and saved to: {savePath}");
            }
        }

        // Extract and prints image URLs from an HTML file
        public void ExtractImageUrl()
        {
            string sourcePath = Path.Combine(DataDir, "images-from-html.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Element image in images)
                {
                    string imageUrl = image.GetAttribute("src");
                    Console.WriteLine($"Image URL: {imageUrl}");
                }
            }
        }

        // Download all images referenced in a local HTML file
        public void Extract()
        {
            string sourcePath = Path.Combine(DataDir, "images-from-html.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                IEnumerable<string> urls = images.Select(e => e.GetAttribute("src")).Distinct();
                IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

                foreach (Url url in absUrls)
                {
                    using RequestMessage request = new RequestMessage(url);
                    using ResponseMessage response = document.Context.Network.Send(request);

                    if (response.IsSuccess)
                    {
                        string imgName = url.Pathname.Split('/').Last();
                        string outPath = Path.Combine(OutputDir, imgName);
                        File.WriteAllBytes(outPath, response.Content.ReadAsByteArray());
                        Console.WriteLine($"Saved image: {outPath}");
                    }
                }
            }
        }

        // Download all images from a web page
        public void ExtractImageFromWebsite()
        {
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/svg/net/drawing-basics/svg-shapes/");

            HTMLCollection images = document.GetElementsByTagName("img");
            IEnumerable<string> urls = images.Select(e => e.GetAttribute("src")).Distinct();
            IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                using RequestMessage request = new RequestMessage(url);
                using ResponseMessage response = document.Context.Network.Send(request);

                if (response.IsSuccess)
                {
                    string imgName = url.Pathname.Split('/').Last();
                    string outPath = Path.Combine(OutputDir, imgName);
                    File.WriteAllBytes(outPath, response.Content.ReadAsByteArray());
                    Console.WriteLine($"Saved image from web: {outPath}");
                }
            }
        }

        // Remove the first image from an HTML document
        public void RemoveImage()
        {
            string sourcePath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "remove-image.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLElement body = document.Body;
                HTMLElement img = (HTMLElement)document.GetElementsByTagName("img").First();
                body.RemoveChild(img);
                document.Save(savePath);
                Console.WriteLine($"First image removed, saved to: {savePath}");
            }
        }

        // Remove the first image if any exist, otherwise logs a message
        public void RemoveImageWithCheck()
        {
            string sourcePath = Path.Combine(DataDir, "file.html");
            string savePath = Path.Combine(OutputDir, "remove-image-with-check.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLElement body = document.Body;
                HTMLCollection images = document.GetElementsByTagName("img");

                if (images.Any())
                {
                    HTMLElement img = (HTMLElement)images.First();
                    body.RemoveChild(img);
                    document.Save(savePath);
                    Console.WriteLine($"Image removed with check, saved to: {savePath}");
                }
                else
                {
                    Console.WriteLine("No images found to remove");
                }
            }
        }

        // Remove all images from an HTML document
        public void RemoveAllImages()
        {
            string sourcePath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "remove-all-images.html");

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Element img in images.ToList())
                {
                    img.ParentNode.RemoveChild(img);
                }
                document.Save(savePath);
                Console.WriteLine($"All images removed, saved to: {savePath}");
            }
        }
    }
}