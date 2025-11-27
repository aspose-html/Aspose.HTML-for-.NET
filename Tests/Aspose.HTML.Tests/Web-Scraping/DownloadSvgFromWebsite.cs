using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using System.IO;
using System.Linq;
using Aspose.Html.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Web_Scraping
{
    public class DownloadSvgFromWebsite : TestsBase
    {
        public DownloadSvgFromWebsite(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("navigation/download-svg-from-website");
        }


        [Fact(DisplayName = "Extract Inline SVG")]
        public void ExtractInlineSvgTest()
        {
            // @START_SNIPPET ExtractInlineSvg.cs
            // How to extract inline SVG images from a webpage using C#
            // Learn more: https://docs.aspose.com/html/net/extract-svg-from-website/

            // Open a document you want to download inline SVG images from
            using HTMLDocument document = new HTMLDocument("https://products.aspose.com/html/net/");

            // Collect all inline SVG images
            HTMLCollection images = document.GetElementsByTagName("svg");

            for (int i = 0; i < images.Length; i++)
            {
                // Save each SVG element as an individual .svg file
                File.WriteAllText(Path.Combine(OutputDir, $"{i}.svg"), images[i].OuterHTML);
                Assert.True(File.Exists(Path.Combine(OutputDir, $"{i}.svg")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Extract External SVG")]
        public void ExtractExternalSvgTest()
        {
            // @START_SNIPPET ExtractExternalSvg.cs
            // Download external SVG images from HTML using C#
            // Learn more: https://docs.aspose.com/html/net/extract-svg-from-website/

            // Open a document you want to download external SVGs from
            using HTMLDocument document = new HTMLDocument("https://products.aspose.com/html/net/");

            // Collect all image elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Create a distinct collection of relative image URLs
            IEnumerable<string> urls = images.Select(element => element.GetAttribute("src")).Distinct();

            // Filter out non SVG images
            IEnumerable<string> svgUrls = urls.Where(url => url.EndsWith(".svg"));

            // Create absolute SVG image URLs
            IEnumerable<Url> absUrls = svgUrls.Select(src => new Url(src, document.BaseURI));

            foreach (Url url in absUrls)
            {
                // Create a downloading request
                using RequestMessage request = new RequestMessage(url);

                // Download SVG image
                using ResponseMessage response = document.Context.Network.Send(request);

                // Check whether response is successful
                if (response.IsSuccess)
                {
                    // Save SVG image to a local file system
                    File.WriteAllBytes(Path.Combine(OutputDir, url.Pathname.Split('/').Last()), response.Content.ReadAsByteArray());

                    Assert.True(File.Exists(Path.Combine(OutputDir, url.Pathname.Split('/').Last())));
                }
            }
            // @END_SNIPPET
        }
    }
}

