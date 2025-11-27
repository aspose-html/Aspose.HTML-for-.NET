using Aspose.Html;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Xps;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.Fine_Tuning_Converters
{
    public class RenderingDevice : TestsBase
    {
        public RenderingDevice(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("fine-tuning-converters");
        }


        [Fact(DisplayName = "Render HTML to PDF from HTML Code")]
        public void RenderHTMLtoPDFTest()
        {
            // @START_SNIPPET RenderHtmlToPdf.cs
            // Render HTML to PDF using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-device/

            // Prepare HTML code
            string code = @"<span>Hello, World!!</span>";

            // Prepare a path to save a converted file 
            string savePath = Path.Combine(OutputDir, "document.pdf");

            // Initialize an HTML document from the HTML code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create a PDF Device and specify the output file to render
            using PdfDevice device = new PdfDevice(savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Render HTML to JPG")]
        public void RenderHTMLtoJPGTest()
        {
            // @START_SNIPPET RenderHtmlToJpg.cs
            // Render HTML to JPG using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-device/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "spring-output.jpg");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the ImageRenderingOptions class
            ImageRenderingOptions imageOptions = new ImageRenderingOptions(ImageFormat.Jpeg);

            // Create the Image Device and specify the output file to render
            using ImageDevice device = new ImageDevice(imageOptions, savePath);

            // Render HTML to JPG
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "spring-output.jpg")));
        }


        [Fact(DisplayName = "Render HTML to DOCX")]
        public void RenderHTMLtoDOCXTest()
        {
            // @START_SNIPPET RenderHtmlToDocx.cs
            // Render HTML to DOCX using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-device/

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "document.docx");

            // Load a document from 'https://docs.aspose.com/html/files/document.html' web page
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/files/document.html");

            // Create an instance of the DocRenderingOptions class
            DocRenderingOptions docOptions = new DocRenderingOptions();

            // Create the DocDevice object and specify the output file to render
            using DocDevice device = new DocDevice(docOptions, savePath);

            // Render HTML to DOCX
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Render HTML to XPS")]
        public void RenderHTMLtoXPSTest()
        {
            // @START_SNIPPET RenderHtmlToXps.cs
            // Render HTML to XPS using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-device/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file
            string savePath = Path.Combine(OutputDir, "spring.xps");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of the XpsDevice and specify the output file to render
            using XpsDevice device = new XpsDevice(savePath);

            // Render HTML to XPS
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
