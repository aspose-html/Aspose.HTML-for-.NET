using System;
using System.IO;
using Aspose.Html;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Example of downloading a web page based on the DownloadWebsite test
    /// </summary>
    public static class WebScrapingExample
    {
        /// <summary>
        /// Download a web page by URL and save it to a local file
        /// </summary>
        public static void DownloadWebPage()
        {
            string url = "https://docs.aspose.com/html/net/message-handlers/";
            string outputPath = Path.Combine(BaseExample.GetOutputDir(), "downloaded-page.html");
            using (HTMLDocument doc = new HTMLDocument(url))
            {
                doc.Save(outputPath);
            }
            Console.WriteLine($"Web page saved to: {outputPath}");
        }

    }
}