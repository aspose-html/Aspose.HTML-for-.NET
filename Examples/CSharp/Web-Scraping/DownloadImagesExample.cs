using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace Aspose.Html.Examples
{
    public class DownloadImagesExample : BaseExample
    {
        public DownloadImagesExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation/download-images");
        }

        /// <summary>
        /// Extract images from a website and save them locally
        /// </summary>
        public void ExtractImages()
        {
            // Open a document from the target website
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/svg/net/drawing-basics/svg-shapes/");

            // Collect all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Create a distinct collection of relative image URLs
            IEnumerable<string> urls = images.Select(element => element.GetAttribute("src")).Distinct();

            // Create absolute image URLs based on the document base URI
            IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create a request for the image
                using RequestMessage request = new RequestMessage(url);

                // Send the request and receive the response
                using ResponseMessage response = document.Context.Network.Send(request);

                // Save the image if the request succeeded
                if (response.IsSuccess)
                {
                    string fileName = url.Pathname.Split('/').Last();
                    File.WriteAllBytes(Path.Combine(OutputDir, fileName), response.Content.ReadAsByteArray());
                    Console.WriteLine($"Image saved to: {Path.Combine(OutputDir, fileName)}");
                }
            }
        }

        /// <summary>
        /// Extract icons from a website and save them locally
        /// </summary>
        public void ExtractIcons()
        {
            // Open a document from the target website
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Collect all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Keep only elements with rel attribute equal to "icon"
            IEnumerable<Element> icons = links.Where(link => link.GetAttribute("rel") == "icon");

            // Create a distinct collection of relative icon URLs
            IEnumerable<string> urls = icons.Select(icon => icon.GetAttribute("href")).Distinct();

            // Create absolute icon URLs based on the document base URI
            IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create a request for the icon
                using RequestMessage request = new RequestMessage(url);

                // Send the request and receive the response
                using ResponseMessage response = document.Context.Network.Send(request);

                // Save the icon if the request succeeded
                if (response.IsSuccess)
                {
                    string fileName = url.Pathname.Split('/').Last();
                    File.WriteAllBytes(Path.Combine(OutputDir, fileName), response.Content.ReadAsByteArray());
                    Console.WriteLine($"Icon saved to: {Path.Combine(OutputDir, fileName)}");
                }
            }
        }
    }
}