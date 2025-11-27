using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Services;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Advanced_Programming
{
    public class CSSExtensions : TestsBase
    {
        public CSSExtensions(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("advanced-programming/css-extensions");
        }


        [Fact(DisplayName = "CSS Extensions")]
        public void CSSExtensionsTest()
        {
            // @START_SNIPPET SetPageMarginMarksUsingCssExtensions.cs
            // How to add custom margin marks using CSS extensions
            // Learn more: https://docs.aspose.com/html/net/css-extensions/

            // Initialize a configuration object and set up page-margins for a document
            using (Configuration configuration = new Configuration())
            {
                // Get the User Agent service
                IUserAgentService userAgent = configuration.GetService<IUserAgentService>();

                // Set the style of custom margins and create marks on it
                userAgent.UserStyleSheet = @"@page 
                                {
                                    /* Page margins should be not empty in order to write content inside the margin-boxes */
                                    margin-top: 1cm;
                                    margin-left: 2cm;
                                    margin-right: 2cm;
                                    margin-bottom: 2cm;
                                    /* Page counter located at the bottom of the page */
                                    @bottom-right
                                    {
                                        -aspose-content: ""Page "" currentPageNumber() "" of "" totalPagesNumber();
                                        color: green;
                                    }

                                    /* Page title located at the top-center box */
                                    @top-center
                                    {
                                        -aspose-content: ""Hello, World Document Title!!!"";
                                        vertical-align: bottom;
                                        color: blue;
                                    }
                                }";

                //  Initialize an HTML document
                using HTMLDocument document = new HTMLDocument("<div>Hello, World!!!</div>", ".", configuration);
                
                //  Initialize an output device
                using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "output.pdf")))
                {
                    // Send the document to the output device
                    document.RenderTo(device);
                }
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "output.pdf")));
        }
    }
}
