using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class ConvertWebpageTests : TestsBase
    {
        public ConvertWebpageTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("saving");
        }
    

        [Fact(DisplayName = "Convert web page to PDF")]
        public void ConvertHTMLtoPDFTest()
        {
            // @START_SNIPPET SaveWebSiteAsPdf.cs
            // How to save a website as a pdf using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/

            // Set the target webpage URL
            string url = "https://docs.aspose.com/html/";

            // Define the output path (OutputDir is assumed to exist)
            string outputPath = Path.Combine(OutputDir, "website.pdf");

            // Load the HTML document from the specified URL
            HTMLDocument document = new HTMLDocument(url);

            // Configure PDF rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(1920, 1080));            

            // Create a PDF rendering device with the defined options and output file
            PdfDevice device = new PdfDevice(options, outputPath);

            // Initialize the HTML renderer
            HtmlRenderer renderer = new HtmlRenderer();

            // Render the document to the specified device
            renderer.Render(device, document);

            // Dispose of resources
            renderer.Dispose();
            device.Dispose();
            document.Dispose();
            // @END_SNIPPET SaveWebPageAsPdf.cs
            Assert.True(File.Exists(Path.Combine(OutputDir, "website.pdf")));
        }
    }
}
