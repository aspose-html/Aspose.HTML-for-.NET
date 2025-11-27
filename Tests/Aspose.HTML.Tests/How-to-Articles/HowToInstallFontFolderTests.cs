using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToInstallFontFolderTests : TestsBase
    {
        public HowToInstallFontFolderTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles");
        }


        [Fact(DisplayName = "Set Font Folder to Render HTML to PDF")]
        public void SetFontFolderToRenderHTMLtoPDFTest()
        {
            // @START_SNIPPET SetFontFolderToRenderHtmlToPdf.cs
            // Use custom font folder in HTML to PDF conversion
            // Learn more: https://docs.aspose.com/html/net/how-to-set-font-folder/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Create an instance of Configuration
            using Configuration configuration = new Configuration();
            
            // Get the IUserAgentService
            IUserAgentService service = configuration.GetService<IUserAgentService>();

            // Set a custom font folder path
            service.FontsSettings.SetFontsLookupFolder(Path.Combine(DataDir + "fonts"));

            // Initialize the HTML document with specified configuration
            using (HTMLDocument document = new HTMLDocument(documentPath, configuration))
            {
                // Convert HTML to PDF
                Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "file-fontsetting.pdf"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "file-fontsetting.pdf")));
        }


        [Fact(DisplayName = "Set Font Folder to Render HTML to Image")]
        public void SetFontFolderToRenderHTMLtoImageTest()
        {
            // @START_SNIPPET SetFontFolderToRenderHtmlToImage.cs
            // Set custom font folder for HTML to PNG conversion in C#
            // Learn more: https://docs.aspose.com/html/net/how-to-set-font-folder/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "file-output.png");

            // Create an instance of the Configuration class
            using Configuration configuration = new Configuration();
            
            // Get the IUserAgentService
            IUserAgentService userAgentService = configuration.GetService<IUserAgentService>();

            // Use the SetFontsLookupFolder() method to set a directory which will act as a new fontsFolder
            // Pass "true" as the recursive parameter to use all nested directories
            userAgentService.FontsSettings.SetFontsLookupFolder(Path.Combine(DataDir + "font"), true);

            // Initialize the HTML document with specified configuration
            using (HTMLDocument document = new HTMLDocument(documentPath, configuration))
            {
                // Convert HTML to Image
                Converter.ConvertHTML(document, new ImageSaveOptions(), savePath);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "file-output.png")));
        }
    }
}
