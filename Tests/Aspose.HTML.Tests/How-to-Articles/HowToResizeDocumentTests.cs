using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToResizeDocumentTests : TestsBase
    {
        public HowToResizeDocumentTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("resize-document");
        }


        [Fact(DisplayName = "Convert HTML With Default RenderingOptions")]
        public void ConvertHTMLWithDefaultRenderingOptionsTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithDefaultRenderingOptions.cs
            // Render HTML to PDF with default RenderingOptions
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "a4.png");

            // Create an instance of the HTMLDocument class
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an ImageRenderingOptions object with default options
            ImageRenderingOptions opt = new ImageRenderingOptions();

            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "a4.png")));
        }


        [Fact(DisplayName = "Using FitWidth")]
        public void UsingFitWidthTest()
        {
            // @START_SNIPPET FitHtmlToWidthImage.cs
            // Render HTML to image with width fitting in C#
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitWidth.jpg");

            // Create an instance of HTMLDocument class
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an ImageRenderingOptions object with custom options. Use the FitToWidestContentWidth flag
            ImageRenderingOptions opt = new ImageRenderingOptions(ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.FitToWidestContentWidth
                }
            };

            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "FitWidth.jpg")));
        }


        [Fact(DisplayName = "Using FitToWidestContentWidth and FitToContentHeight")]
        public void FitPageTest()
        {
            // @START_SNIPPET FitHtmlToContentSize.cs
            // Fit HTML to content size when rendering to image in C#
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitPage.png");

            // Create an instance of the HTMLDocument class
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an ImageRenderingOptions object with custom options. Use FitToContentWidth and FitToContentHeight flags
            ImageRenderingOptions opt = new ImageRenderingOptions()
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.FitToContentWidth | PageLayoutOptions.FitToContentHeight
                },
                HorizontalResolution=96,
                VerticalResolution=96
            };

            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "FitPage.png")));
        }


        [Fact(DisplayName = "Using FitToWidestContentWidth and FitToContentHeight for Render to PDF")]
        public void FitPagePdfTest()
        {
            // @START_SNIPPET RenderHtmlToPdfWithFitPageSize.cs
            // Fit HTML to content size when rendering to PDF in C#
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitPage.pdf");

            // Initialize HTMLDocument
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an PdfRenderingOptions object with custom options. Use FitToContentWidth and FitToContentHeight flags
            PdfRenderingOptions opt = new PdfRenderingOptions()
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.FitToContentWidth | PageLayoutOptions.FitToContentHeight
                }
            };

            // Create an output rendering device and convert HTML
            using PdfDevice device = new PdfDevice(opt, savePath);
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "FitPage.pdf")));
        }


        [Fact(DisplayName = "Using FitSmallPage")]
        public void UsingFitSmallPageTest()
        {
            // @START_SNIPPET RenderHtmlToJpgWithSmallCustomPageSize.cs
            // Render HTML to image with small custom page size
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitSmallPage.jpg");

            // Initialize HTMLDocument
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an ImageRenderingOptions object with custom options. Use FitToWidestContentWidth and FitToContentHeight flags
            ImageRenderingOptions opt = new ImageRenderingOptions(ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.FitToWidestContentWidth | PageLayoutOptions.FitToContentHeight,
                    AnyPage = new Page(new Size(20,20))
                }
            };

            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "FitSmallPage.jpg")));
        }


        [Fact(DisplayName = "Using ScaleToPageWidth and ScaleToPageHeight")]
        public void ScaleSmallPageTest()
        {
            // @START_SNIPPET ScaleSmallPage.cs
            // Scale HTML content to fixed page size
            // Learn more: https://docs.aspose.com/html/net/resize-document/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");

            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "ScaleSmallPage.png");

            // Initialize an HTMLDocument object
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize an ImageRenderingOptions object and use ScaleToPageWidth and ScaleToPageHeight flags
            ImageRenderingOptions opt = new ImageRenderingOptions()
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.ScaleToPageWidth | PageLayoutOptions.ScaleToPageHeight,
                    AnyPage = new Page(new Size(200,200))
                }
            };

            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "ScaleSmallPage.png")));
        }
    }
}
