using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Pdf.Encryption;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.Fine_Tuning_Converters
{
    public class Renderers : TestsBase
    {
        public Renderers(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("fine-tuning-converters");
        }


        [Fact(DisplayName = "Convert HTML to PDF with Rendering Options")]
        public void ConvertHTMLtoPDFOptionTsest()
        {
            // @START_SNIPPET ConvertHtmlToPdfWithRenderingOptions.cs
            // Render HTML to PDF with custom page settings using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of HTML Renderer
            using HtmlRenderer renderer = new HtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "convert-html-options.pdf");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 200));
            options.Encryption = new PdfEncryptionInfo(
                   "user_pwd",
                   "owner_pwd",
                   PdfPermissions.PrintDocument,
                   PdfEncryptionAlgorithm.RC4_128);

            // Create an instance of PDF device
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            renderer.Render(device, document);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Merge HTML to PDF")]
        public void MergeHTMLtoPDFTest()
        {
            // @START_SNIPPET MergeHtmlToPdf.cs
            // Merge HTML to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Prepare HTML code
            string code1 = @"<br><span style='color: green'>Hello, World!!</span>";
            string code2 = @"<br><span style='color: blue'>Hello, World!!</span>";
            string code3 = @"<br><span style='color: red'>Hello, World!!</span>";

            // Create three HTML documents to merge later
            using HTMLDocument document1 = new HTMLDocument(code1, ".");
            using HTMLDocument document2 = new HTMLDocument(code2, ".");
            using HTMLDocument document3 = new HTMLDocument(code3, ".");

            // Create an instance of HTML Renderer
            using HtmlRenderer renderer = new HtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "merge-html.pdf");

            // Create an instance of PDF device
            using PdfDevice device = new PdfDevice(savePath);

            // Merge all HTML documents into PDF
            renderer.Render(device, document1, document2, document3);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Merge HTML with Rendering Options")]
        public void MergeHTMLtoPDFTOptionTsest()
        {
            // @START_SNIPPET MergeHhtmlToPdfWithRenderingOption.cs
            // Merge HTML to PDF with custom page settings using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Prepare HTML code
            string code1 = @"<br><span style='color: green'>Hello, World!!</span>";
            string code2 = @"<br><span style='color: blue'>Hello, World!!</span>";
            string code3 = @"<br><span style='color: red'>Hello, World!!</span>";

            // Create three HTML documents to merge later
            using HTMLDocument document1 = new HTMLDocument(code1, ".");
            using HTMLDocument document2 = new HTMLDocument(code2, ".");
            using HTMLDocument document3 = new HTMLDocument(code3, ".");

            // Create an instance of HTML Renderer
            using HtmlRenderer renderer = new HtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "merge-html-options.pdf");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(400, 100));
            options.BackgroundColor = System.Drawing.Color.Azure;

            // Create an instance of PDF device
            using PdfDevice device = new PdfDevice(options, savePath);

            // Merge all HTML documents into PDF
            renderer.Render(device, document1, document2, document3);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert MHTML with Rendering Options")]
        public void ConvertMHTMLtoPDFwithRenderingOptionTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdfWithRenderingOptions.cs
            // Convert MHTML to PDF with custom page settings using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");
            
            // Create an instance of MHTML Renderer
            using MhtmlRenderer renderer = new MhtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "convert-mhtml-options.pdf");

            // Create the instance of Rendering Options and set a custom page-size and background color
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 200));
            options.BackgroundColor = System.Drawing.Color.Azure;

            // Create an instance of PDF device
            using PdfDevice device = new PdfDevice(options, savePath);

            // Convert MHTML to PDF
            renderer.Render(device, stream);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert MHTML to Image")]
        public void ConvertMHTMLtoImageTest()
        {
            // @START_SNIPPET ConvertMHtmlToImage.cs
            // Convert MHTML to PNG with custom page settings using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Open an existing MHTML file for reading
            using FileStream stream = File.OpenRead(DataDir + "sample.mht");

            // Create an instance of MHTML Renderer
            using MhtmlRenderer renderer = new MhtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "convert-mhtml.png");

            // Create the instance of Rendering Options and set a custom page-size and background color
            ImageRenderingOptions options = new ImageRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(200, 100));
            options.BackgroundColor = System.Drawing.Color.Bisque;

            // Create an instance of ImageDevice
            using ImageDevice device = new ImageDevice(options, savePath);

            // Convert MHTML to PNG
            renderer.Render(device, stream);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "convert-mhtml.png")));
        }


        [Fact(DisplayName = "Convert EPUB with Rendering Options")]
        public void ConvertEPUBtoDOCXwithRenderingOptionsTest()
        {
            // @START_SNIPPET ConvertEpubToDocxWithRenderingOptions.cs
            // Convert EPUB to DOCX with custom page size using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Create an instance of EPUB Renderer
            using EpubRenderer renderer = new EpubRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "convert-epub-options.docx");

            // Create the instance of Rendering Options and set a custom page-size
            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 400));

            // Create an instance of the DocDevice class
            using DocDevice device = new DocDevice(options, savePath);

            // Render EPUB to DOCX
            renderer.Render(device, stream);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Convert EPUB to PDF")]
        public void ConvertEpubToPDFOptionTest()
        {
            // @START_SNIPPET ConvertEpubToPdfWithOption.cs
            // Convert EPUB to PDF with custom page size using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Open an existing EPUB file for reading
            using FileStream stream = File.OpenRead(DataDir + "input.epub");

            // Create an instance of EPUB Renderer
            using EpubRenderer renderer = new EpubRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "convert-epub.pdf");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 400));

            // Create an instance of the PdfDevice class
            using PdfDevice device = new PdfDevice(options, savePath);

            // Convert EPUB to PDF
            renderer.Render(device, stream);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Merge SVG to PDF")]
        public void MergeSVGtoPDFTest()
        {
            // @START_SNIPPET MergeSvgToPdf.cs
            // Merge SVG to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Initialize an SVG document from the file
            using SVGDocument document1 = new SVGDocument(Path.Combine(DataDir, "shapes.svg"));
            using SVGDocument document2 = new SVGDocument(Path.Combine(DataDir, "aspose.svg"));

            // Create an instance of SVG Renderer
            using SvgRenderer renderer = new SvgRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "merge-svg.pdf");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 500));

            // Create an instance of the Pdfdevice class
            using PdfDevice device = new PdfDevice(options, savePath);

            // Merge all SVG documents into PDF
            renderer.Render(device, document1, document2);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Render SVG to PDF")]
        public void RenderSVGtoPDFTest()
        {
            // @START_SNIPPET RenderingSvgToPdf.cs
            // Render SVG to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Initialize an SVG document from the file
            using SVGDocument document = new SVGDocument(Path.Combine(DataDir, "shapes.svg"));

            // Create an instance of SVG Renderer
            using SvgRenderer renderer = new SvgRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "rendering-svg.pdf");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 500));

            // Create an instance of the Pdfdevice class
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render SVG to PDF
            renderer.Render(device, document);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Set Timeout")]
        public void SetTimeoutTest()
        {
            // @START_SNIPPET RenderHtmlToPdfWithTimeoutSetting.cs
            // Render HTML to PDF with timeout settings using C#
            // Learn more: https://docs.aspose.com/html/net/renderers/

            // Prepare HTML code
            string code = @"
            <script>
                var count = 0;
                setInterval(function()
                    {
                        var element = document.createElement('div');
                        var message = (++count) + '. ' + 'Hello, World!! I know how to use Renderers!';
                        var text = document.createTextNode(message);
                        element.appendChild(text);
                        document.body.appendChild(element);
                    }, 1000);
            </script>";

            // Initialize an HTML document based on prepared HTML code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create an instance of HTML Renderer
            using HtmlRenderer renderer = new HtmlRenderer();

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "output-timeout.pdf");

            // Create an instance of the PdfDevice class
            using PdfDevice device = new PdfDevice(savePath);

            // Render HTML to PDF
            renderer.Render(device, TimeSpan.FromSeconds(5), document);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
