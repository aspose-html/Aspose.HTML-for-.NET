using Aspose.Html;
using Aspose.Html.Net;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Web_Scraping
{
    public class DownloadFileFromWebsite : TestsBase
    {
        public DownloadFileFromWebsite(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("navigation/download-file-from-website");
        }


        [Fact(DisplayName = "Download File From URL")]
        public void DownloadFileFromURLTest()
        {
            // @START_SNIPPET SaveFileFromUrl.cs
            // Download file from URL using C#
            // Learn more: https://docs.aspose.com/html/net/save-file-from-url/

            // Create a blank document; it is required to access the network operations functionality
            using HTMLDocument document = new HTMLDocument();

            // Create a URL with the path to the resource you want to download
            Url url = new Url("https://docs.aspose.com/html/net/message-handlers/message-handlers.png");

            // Create a file request message
            using RequestMessage request = new RequestMessage(url);

            // Download file from URL
            using ResponseMessage response = document.Context.Network.Send(request);

            // Check whether response is successful
            if (response.IsSuccess)
            {
                // Save file to a local file system
                File.WriteAllBytes(Path.Combine(OutputDir, url.Pathname.Split('/').Last()), response.Content.ReadAsByteArray());

                Assert.True(File.Exists(Path.Combine(OutputDir, url.Pathname.Split('/').Last())));
            }
            // @END_SNIPPET
        }
    }
}
