using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using System.IO;
using System.Linq;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Web_Scraping
{
    public class DownloadImages : TestsBase
    {
        public DownloadImages(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("navigation/download-images");
        }


        [Fact(DisplayName = "Extract Images From Website")]
        public void ExtractImagesFromWebsiteTest()
        {
            // @START_SNIPPET ExtractImagesFromWebsite.cs
            // Extract images from website using C#
            // Learn more: https://docs.aspose.com/html/net/extract-images-from-website/

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

                // Extract image
                using ResponseMessage response = document.Context.Network.Send(request);

                // Check whether a response is successful
                if (response.IsSuccess)
                {
                    // Save image to a local file system
                    File.WriteAllBytes(Path.Combine(OutputDir, url.Pathname.Split('/').Last()), response.Content.ReadAsByteArray());

                    Assert.True(File.Exists(Path.Combine(OutputDir, url.Pathname.Split('/').Last())));
                }
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Extract Icons From Website")]
        public void ExtractIconsFromWebsiteTest()
        {
            // @START_SNIPPET ExtractIconsFromWebsite.cs
            // Download icons from website using C#
            // Learn more: https://docs.aspose.com/html/net/extract-images-from-website/

            // Open a document you want to download icons from
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Collect all <link> elements
            HTMLCollection links = document.GetElementsByTagName("link");

            // Leave only "icon" elements
            IEnumerable<Element> icons = links.Where(link => link.GetAttribute("rel") == "icon");

            // Create a distinct collection of relative icon URLs
            IEnumerable<string> urls = icons.Select(icon => icon.GetAttribute("href")).Distinct();

            // Create absolute icon URLs
            IEnumerable<Url> absUrls = urls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create a downloading request
                using RequestMessage request = new RequestMessage(url);

                // Extract icon
                using ResponseMessage response = document.Context.Network.Send(request);

                // Check whether a response is successful
                if (response.IsSuccess)
                {
                    // Save icon to a local file system
                    File.WriteAllBytes(Path.Combine(OutputDir, url.Pathname.Split('/').Last()), response.Content.ReadAsByteArray());

                    Assert.True(File.Exists(Path.Combine(OutputDir, url.Pathname.Split('/').Last())));
                }
            }
            // @END_SNIPPET
        }
    }
}
