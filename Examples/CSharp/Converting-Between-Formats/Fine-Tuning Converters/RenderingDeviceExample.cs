using Aspose.Html;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Xps;
using System;
using System.IO;

namespace Aspose.Html.Examples
{
    public class RenderingDeviceExample : BaseExample
    {
        public RenderingDeviceExample()
        {
            SetOutputDir("fine-tuning-converters");
        }

        // Render HTML to PDF from HTML code
        public void RenderHtmlToPdf()
        {
            string code = @"<span>Hello, World!!</span>";
            string savePath = Path.Combine(OutputDir, "document.pdf");
            using HTMLDocument document = new HTMLDocument(code, ".");
            using PdfDevice device = new PdfDevice(savePath);
            document.RenderTo(device);
        }

        // Render HTML to JPG
        public void RenderHtmlToJpg()
        {
            string documentPath = Path.Combine(DataDir, "spring.html");
            string savePath = Path.Combine(OutputDir, "spring-output.jpg");
            using HTMLDocument document = new HTMLDocument(documentPath);
            ImageRenderingOptions imageOptions = new ImageRenderingOptions(ImageFormat.Jpeg);
            using ImageDevice device = new ImageDevice(imageOptions, savePath);
            document.RenderTo(device);
        }

        // Render HTML to DOCX
        public void RenderHtmlToDocx()
        {
            string savePath = Path.Combine(OutputDir, "document.docx");
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");
            DocRenderingOptions docOptions = new DocRenderingOptions();
            using DocDevice device = new DocDevice(docOptions, savePath);
            document.RenderTo(device);
        }

        // Render HTML to XPS
        public void RenderHtmlToXps()
        {
            string documentPath = Path.Combine(DataDir, "spring.html");
            string savePath = Path.Combine(OutputDir, "spring.xps");
            using HTMLDocument document = new HTMLDocument(documentPath);
            using XpsDevice device = new XpsDevice(savePath);
            document.RenderTo(device);
        }
    }
}