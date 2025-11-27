using Aspose.Html;
using Aspose.Html.Saving;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Web_Scraping
{
    public class DownloadWebsite : TestsBase
    {
        public DownloadWebsite(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("navigation/download-website");
        }


        [Fact(DisplayName = "Save Webpage With Defalt Save Options")]
        public void SaveWebpageDefaultSaveOptionsTest()
        {
            // @START_SNIPPET SaveWebpageDefaultSaveOptions.cs
            // Extract and save a wab page with default save options in C#
            // Learn more: https://docs.aspose.com/html/net/website-to-html/

            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");
            
            // Prepare a path to save the downloaded file
            string savePath = Path.Combine(OutputDir, "root/result.html");

            // Save the HTML document to the specified file
            document.Save(savePath);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Download Website")]
        public void DownloadWebsiteTest()
        {
            // @START_SNIPPET SaveWebsiteWithHTMLSaveOptions.cs
            // Download website using HTMLSaveOptions in C#
            // Learn more: https://docs.aspose.com/html/net/website-to-html/

            // Initialize an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Create an HTMLSaveOptions object and set the JavaScript property
            HTMLSaveOptions options = new HTMLSaveOptions
            {
                ResourceHandlingOptions =
                {
                    JavaScript = ResourceHandling.Embed
                }
            };

            // Prepare a path to save the downloaded file
            string savePath = Path.Combine(OutputDir, "rootAndEmbedJs/result.html");

            // Save the HTML document to the specified file
            document.Save(savePath, options);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Download Website Using MaxHandlingDepth")]
        public void DownloadSiteUsingMaxHandlingDepthTest()
        {
            // @START_SNIPPET SaveWebsiteUsingMaxHandlingDepth.cs
            // Save a website with limited resource depth using C#
            // Learn more: https://docs.aspose.com/html/net/website-to-html/

            // Load an HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/message-handlers/");

            // Create an HTMLSaveOptions object and set the MaxHandlingDepth property
            HTMLSaveOptions options = new HTMLSaveOptions
            {
                ResourceHandlingOptions =
                {
                    MaxHandlingDepth = 1
                }
            };

            // Prepare the output path for saving the downloaded content
            string savePath = Path.Combine(OutputDir, "rootAndAdjacent/result.html");

            // Save the document along with adjacent resources only
            document.Save(savePath, options);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Download Website Using PageUrlRestriction")]
        public void SaveWebsiteUsingPageUrlRestrictionTest()
        {
            // @START_SNIPPET SaveWebsiteUsingPageUrlRestriction.cs
            // Save a website with restricted resource URLs using C#
            // Learn more: https://docs.aspose.com/html/net/website-to-html/

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

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }        
    }
}

