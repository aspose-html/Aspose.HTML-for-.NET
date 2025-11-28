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
    public class DownloadSvgFromWebsiteExample : BaseExample
    {
        public DownloadSvgFromWebsiteExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation/download-svg-from-website");
        }

        /// <summary>
        /// Extract inline SVG images from a webpage and save them locally
        /// </summary>
        public void ExtractInlineSvg()
        {
            // Open a document from the target website
            using HTMLDocument document = new HTMLDocument("https://products.aspose.com/html/net/");

            // Collect all <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            for (int i = 0; i < svgs.Length; i++)
            {
                // Save each SVG element as an individual .svg file
                string fileName = $"{i}.svg";
                File.WriteAllText(Path.Combine(OutputDir, fileName), svgs[i].OuterHTML);
                Console.WriteLine($"Inline SVG saved to: {Path.Combine(OutputDir, fileName)}");
            }
        }

        /// <summary>
        /// Extract external SVG images from a webpage and save them locally
        /// </summary>
        public void ExtractExternalSvg()
        {
            // Open a document from the target website
            using HTMLDocument document = new HTMLDocument("https://products.aspose.com/html/net/");

            // Collect all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Create a distinct collection of relative image URLs
            IEnumerable<string> urls = images.Select(e => e.GetAttribute("src")).Distinct();

            // Filter only URLs that end with .svg
            IEnumerable<string> svgUrls = urls.Where(u => u.EndsWith(".svg", StringComparison.OrdinalIgnoreCase));

            // Create absolute URLs based on the document base URI
            IEnumerable<Url> absUrls = svgUrls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create a request for the SVG image
                using RequestMessage request = new RequestMessage(url);

                // Send the request and receive the response
                using ResponseMessage response = document.Context.Network.Send(request);

                // Save the SVG image if the request succeeded
                if (response.IsSuccess)
                {
                    string fileName = url.Pathname.Split('/').Last();
                    File.WriteAllBytes(Path.Combine(OutputDir, fileName), response.Content.ReadAsByteArray());
                    Console.WriteLine($"External SVG saved to: {Path.Combine(OutputDir, fileName)}");
                }
            }
        }
    }
}