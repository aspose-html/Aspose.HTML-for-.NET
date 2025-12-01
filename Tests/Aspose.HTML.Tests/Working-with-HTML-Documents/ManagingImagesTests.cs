using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using System.IO;
using System.Linq;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Working_with_HTML_Documents
{
    public class ManagingImagesTests : TestsBase
    {
        public ManagingImagesTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("images");
        }


        [Fact(DisplayName = "Add Image")]
        public void AddImageTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Prepare a path for resulting file saving 
            string savePath = Path.Combine(OutputDir, "add-image.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Create an image element
                HTMLImageElement image = (HTMLImageElement)document.CreateElement("img");
                image.Src = "https://docs.aspose.com/html/images/georgia-castle.png";
                image.Alt = "A descriptive alt text";
                image.Width = 1550;
                image.Height = 550;

                // Attach the image to the document body
                body.AppendChild(image);

                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }
        }


        [Fact(DisplayName = "Add Image to HTML")]
        public void AddImageToHtmlTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Prepare a path for resulting file saving 
            string savePath = Path.Combine(OutputDir, "with-added-image.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Create an image element
                HTMLImageElement image = (HTMLImageElement)document.CreateElement("img");
                image.Src = "https://docs.aspose.com/svg/files/lineto.svg";
                image.Alt = "A descriptive alt text";
                image.Width = 550;
                image.Height = 550;

                // Attach the image to the document body
                body.AppendChild(image);

                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }
        }


        [Fact(DisplayName = "Resize Image")]
        public void ResizeImageTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "html_file.html");

            // Prepare a path for resulting file saving 
            string savePath = Path.Combine(OutputDir, "resize-image.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Create a CSS Selector that selects <img> element that is the last child of its parent
                Element element = document.QuerySelector("img:last-child");

                // Set width and height attributes with the desired size for the selected element
                element.SetAttribute("width", "100");
                element.SetAttribute("height", "100");

                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }
        }


        [Fact(DisplayName = "Extract Image URL")]
        public void ExtractImageUrlTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "images-from-html.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Get all image elements in the document
                HTMLCollection images = document.GetElementsByTagName("img");

                // Extract and print image URLs
                foreach (Element image in images)
                {
                    string imageUrl = image.GetAttribute("src");
                    Output.WriteLine(imageUrl);
                }
            }
        }


        [Fact(DisplayName = "Extract Images from HTML")]
        public void ExtractImagesFromHtmlTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "images-from-html.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Collect all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Create a distinct collection of relative image URLs
                IEnumerable<string> urls = images.Select(element => element.GetAttribute("src")).Distinct();

                // Create absolute image URLs
                IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

                foreach (Url url in absUrls)
                {
                    // Create an image request message
                    using RequestMessage request = new RequestMessage(url);

                    // Download image
                    using ResponseMessage response = document.Context.Network.Send(request);

                    string imgName = url.Pathname.Split('/').Last();

                    // Check whether a response is successful
                    if (response.IsSuccess)
                    {
                        // Save image to a local file system
                        File.WriteAllBytes(Path.Combine(OutputDir, imgName), response.Content.ReadAsByteArray());
                    }
                }
            }
        }


        [Fact(DisplayName = "Extract Images from Website")]
        public void ExtractImageFromWebsiteTest()
        {
            // Open a document you want to download images from
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/svg/net/drawing-basics/svg-shapes/");

            // Collect all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Create a distinct collection of relative image URLs
            IEnumerable<string> urls = images.Select(element => element.GetAttribute("src")).Distinct();

            // Create absolute image URLs
            IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create an image request message
                using RequestMessage request = new RequestMessage(url);

                // Download image
                using ResponseMessage response = document.Context.Network.Send(request);

                // Check whether a response is successful
                if (response.IsSuccess)
                {
                    // Save image to a local file system
                    File.WriteAllBytes(Path.Combine(OutputDir, url.Pathname.Split('/').Last()), response.Content.ReadAsByteArray());
                    Assert.True(File.Exists(Path.Combine(OutputDir, url.Pathname.Split('/').Last())));
                }
            }
        }


        [Fact(DisplayName = "Remove Image")]
        public void RemoveImageTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-image.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Find the first image element
                HTMLElement img = (HTMLElement)document.GetElementsByTagName("img").First();

                // Remove the image
                body.RemoveChild(img);

                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }
        }


        [Fact(DisplayName = "Remove Image With Check")]
        public void RemoveImageWithCheckTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-image-with-check.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Check if there are any image elements in the document
                HTMLCollection images = document.GetElementsByTagName("img");

                if (images.Any())
                {
                    // If there are images, remove the first image
                    HTMLElement img = (HTMLElement)images.First();
                    body.RemoveChild(img);

                    // Save the HTML document to a file
                    document.Save(savePath);
                }
                else
                {
                    // Handle the case where no images are found
                    Output.WriteLine("No images found in the document.");
                }
            }
        }


        [Fact(DisplayName = "Remove All Images")]
        public void RemoveAllImagesTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-all-images.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Find all image elements in the document
                HTMLCollection images = document.GetElementsByTagName("img");

                // Remove each image element
                foreach (Element image in images.ToList()) // ToList() to avoid collection modification during iteration
                {
                    image.ParentNode.RemoveChild(image);
                }

                // Save the modified document
                document.Save(savePath);
            }
        }
    }
}
