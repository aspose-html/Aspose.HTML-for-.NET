using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Net;

namespace Aspose.Html.Examples
{
    public class DownloadFileFromWebsiteExample : BaseExample
    {
        public DownloadFileFromWebsiteExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation/download-file-from-website");
        }

        /// <summary>
        /// Download a file from a URL and save it locally
        /// </summary>
        public void DownloadFile()
        {
            // Create a blank document; required for network operations
            using HTMLDocument document = new HTMLDocument();

            // URL of the resource to download
            Url url = new Url("https://docs.aspose.com/html/net/message-handlers/message-handlers.png");

            // Create a request message
            using RequestMessage request = new RequestMessage(url);

            // Send the request
            using ResponseMessage response = document.Context.Network.Send(request);

            // If successful, save the file
            if (response.IsSuccess)
            {
                string fileName = url.Pathname.Split('/').Last();
                File.WriteAllBytes(Path.Combine(OutputDir, fileName), response.Content.ReadAsByteArray());
                Console.WriteLine($"File saved to: {Path.Combine(OutputDir, fileName)}");
            }
        }
    }
}