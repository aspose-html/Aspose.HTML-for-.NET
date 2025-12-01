using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;

namespace Aspose.Html.Examples
{
    public class DownloadWebsiteExample : BaseExample
    {
        public DownloadWebsiteExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation/download-website");
        }

        /// <summary>
        /// Save a web page with default save options
        /// </summary>
        public void SaveWebpageDefault()
        {
            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Prepare a path to save the downloaded file
            string savePath = Path.Combine(OutputDir, "root/result.html");

            // Save the HTML document to the specified file
            document.Save(savePath);

            Console.WriteLine($"Web page saved to: {savePath}");
        }

        /// <summary>
        /// Download a website using HTMLSaveOptions
        /// </summary>
        public void DownloadWebsite()
        {
            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Create an HTMLSaveOptions object and set the JavaScript property
            HTMLSaveOptions options = new HTMLSaveOptions
            {
                ResourceHandlingOptions = { JavaScript = ResourceHandling.Embed }
            };

            // Prepare a path to save the downloaded file
            string savePath = Path.Combine(OutputDir, "rootAndEmbedJs/result.html");

            // Save the HTML document with the specified options
            document.Save(savePath, options);

            Console.WriteLine($"Website downloaded with embedded JavaScript to: {savePath}");
        }

        /// <summary>
        /// Download a website using MaxHandlingDepth option
        /// </summary>
        /// </summary>
        public void DownloadSiteUsingMaxHandlingDepth()
        {
            // Load an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Create an HTMLSaveOptions object and set the MaxHandlingDepth property
            HTMLSaveOptions options = new HTMLSaveOptions
            {
                ResourceHandlingOptions = { MaxHandlingDepth = 1 }
            };

            // Prepare the output path for saving the downloaded content
            string savePath = Path.Combine(OutputDir, "rootAndAdjacent/result.html");

            // Save the document along with adjacent resources only
            document.Save(savePath, options);

            Console.WriteLine($"Website saved with limited resource depth to: {savePath}");
        }

        /// <summary>
        /// Download a website using PageUrlRestriction option
        /// </summary>
        public void SaveWebsiteUsingPageUrlRestriction()
        {
            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Configure HTMLSaveOptions with restricted resource handling
            HTMLSaveOptions options = new HTMLSaveOptions
            {
                ResourceHandlingOptions =
                {
                    MaxHandlingDepth = 1,
                    PageUrlRestriction = UrlRestriction.SameHost
                }
            };

            // Prepare the output path for the saved content
            string savePath = Path.Combine(OutputDir, "rootAndManyAdjacent/result.html");

            // Save the HTML document and allowed resources to the specified path
            document.Save(savePath, options);

            Console.WriteLine($"Website saved with page URL restriction to: {savePath}");
        }
    }
}