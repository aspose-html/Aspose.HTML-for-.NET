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

namespace Aspose.Html.Examples
{
    public class RenderersExample : BaseExample
    {
        public RenderersExample()
        {
            SetOutputDir("fine-tuning-converters");
        }

        // Convert HTML to PDF with rendering options
        public void ConvertHtmlToPdfWithRenderingOptions()
        {
            string documentPath = Path.Combine(DataDir, "file.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            using HtmlRenderer renderer = new HtmlRenderer();
            string savePath = Path.Combine(OutputDir, "convert-html-options.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 200));
            options.Encryption = new PdfEncryptionInfo(
                "user_pwd",
                "owner_pwd",
                PdfPermissions.PrintDocument,
                PdfEncryptionAlgorithm.RC4_128);
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, document);
        }

        // Merge HTML to PDF
        public void MergeHtmlToPdf()
        {
            string code1 = @"<br><span style='color: green'>Hello, World!!</span>";
            string code2 = @"<br><span style='color: blue'>Hello, World!!</span>";
            string code3 = @"<br><span style='color: red'>Hello, World!!</span>";
            using HTMLDocument document1 = new HTMLDocument(code1, ".");
            using HTMLDocument document2 = new HTMLDocument(code2, ".");
            using HTMLDocument document3 = new HTMLDocument(code3, ".");
            using HtmlRenderer renderer = new HtmlRenderer();
            string savePath = Path.Combine(OutputDir, "merge-html.pdf");
            using PdfDevice device = new PdfDevice(savePath);
            renderer.Render(device, document1, document2, document3);
        }

        // Merge HTML to PDF with rendering options
        public void MergeHtmlToPdfWithRenderingOptions()
        {
            string code1 = @"<br><span style='color: green'>Hello, World!!</span>";
            string code2 = @"<br><span style='color: blue'>Hello, World!!</span>";
            string code3 = @"<br><span style='color: red'>Hello, World!!</span>";
            using HTMLDocument document1 = new HTMLDocument(code1, ".");
            using HTMLDocument document2 = new HTMLDocument(code2, ".");
            using HTMLDocument document3 = new HTMLDocument(code3, ".");
            using HtmlRenderer renderer = new HtmlRenderer();
            string savePath = Path.Combine(OutputDir, "merge-html-options.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(400, 100));
            options.BackgroundColor = System.Drawing.Color.Azure;
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, document1, document2, document3);
        }

        // Convert MHTML to PDF with rendering options
        public void ConvertMhtmlToPdfWithRenderingOptions()
        {
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            using MhtmlRenderer renderer = new MhtmlRenderer();
            string savePath = Path.Combine(OutputDir, "convert-mhtml-options.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 200));
            options.BackgroundColor = System.Drawing.Color.Azure;
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, stream);
        }

        // Convert MHTML to image
        public void ConvertMhtmlToImage()
        {
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "sample.mht"));
            using MhtmlRenderer renderer = new MhtmlRenderer();
            string savePath = Path.Combine(OutputDir, "convert-mhtml.png");
            ImageRenderingOptions options = new ImageRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(200, 100));
            options.BackgroundColor = System.Drawing.Color.Bisque;
            using ImageDevice device = new ImageDevice(options, savePath);
            renderer.Render(device, stream);
        }

        // Convert EPUB to DOCX with rendering options
        public void ConvertEpubToDocxWithRenderingOptions()
        {
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            using EpubRenderer renderer = new EpubRenderer();
            string savePath = Path.Combine(OutputDir, "convert-epub-options.docx");
            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 400));
            using DocDevice device = new DocDevice(options, savePath);
            renderer.Render(device, stream);
        }

        // Convert EPUB to PDF with options
        public void ConvertEpubToPdfWithOption()
        {
            using FileStream stream = File.OpenRead(Path.Combine(DataDir, "input.epub"));
            using EpubRenderer renderer = new EpubRenderer();
            string savePath = Path.Combine(OutputDir, "convert-epub.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 400));
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, stream);
        }

        // Merge SVG to PDF
        public void MergeSvgToPdf()
        {
            using SVGDocument document1 = new SVGDocument(Path.Combine(DataDir, "shapes.svg"));
            using SVGDocument document2 = new SVGDocument(Path.Combine(DataDir, "aspose.svg"));
            using SvgRenderer renderer = new SvgRenderer();
            string savePath = Path.Combine(OutputDir, "merge-svg.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 500));
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, document1, document2);
        }

        // Render SVG to PDF
        public void RenderSvgToPdf()
        {
            using SVGDocument document = new SVGDocument(Path.Combine(DataDir, "shapes.svg"));
            using SvgRenderer renderer = new SvgRenderer();
            string savePath = Path.Combine(OutputDir, "rendering-svg.pdf");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(600, 500));
            using PdfDevice device = new PdfDevice(options, savePath);
            renderer.Render(device, document);
        }

        // Set timeout for rendering
        public void SetTimeout()
        {
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
            using HTMLDocument document = new HTMLDocument(code, ".");
            using HtmlRenderer renderer = new HtmlRenderer();
            string savePath = Path.Combine(OutputDir, "output-timeout.pdf");
            using PdfDevice device = new PdfDevice(savePath);
            renderer.Render(device, TimeSpan.FromSeconds(5), document);
        }
    }
}