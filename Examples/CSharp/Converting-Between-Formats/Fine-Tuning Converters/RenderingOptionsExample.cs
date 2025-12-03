using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Xps;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Saving;
using System.IO;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf.Encryption;
using Size = Aspose.Html.Drawing.Size;

namespace Aspose.Html.Examples
{
    public class RenderingOptionsExample : BaseExample
    {
        public RenderingOptionsExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("fine-tuning-converters");
        }

        // Render HTML to PDF with custom page size
        public void UseRenderingOptions()
        {
            string code = @"<span>Hello, World!!</span>";
            using HTMLDocument document = new HTMLDocument(code, ".");
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                PageSetup =
                {
                    AnyPage = new Page(new Size(Length.FromInches(4), Length.FromInches(2)))
                }
            };
            string savePath = Path.Combine(OutputDir, "file-with-custom-page-size.pdf");
            using PdfDevice device = new PdfDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to PDF with custom resolution
        public void UseGeneralOptions()
        {
            string code = @"
                <style>
                p
                { 
                    background: #a7d3fe; 
                }
                @media(min-resolution: 300dpi)
                {
                    p 
                    { 
                        background: orange
                    }
                }
                </style>
                <p>Hello, World!!</p>";
            File.WriteAllText("document.html", code);
            using HTMLDocument document = new HTMLDocument("document.html");
            string savePath1 = Path.Combine(OutputDir, "output_resolution_50.pdf");
            string savePath2 = Path.Combine(OutputDir, "output_resolution_300.pdf");
            PdfRenderingOptions options1 = new PdfRenderingOptions()
            {
                HorizontalResolution = 50,
                VerticalResolution = 50
            };
            using PdfDevice device1 = new PdfDevice(options1, savePath1);
            document.RenderTo(device1);
            PdfRenderingOptions options2 = new PdfRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300
            };
            using PdfDevice device2 = new PdfDevice(options2, savePath2);
            document.RenderTo(device2);
        }

        // Render HTML to PNG with custom resolution
        public void UseResolution()
        {
            string documentPath = Path.Combine(DataDir, "spring.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            string savePath1 = Path.Combine(OutputDir, "output_resolution_50.png");
            string savePath2 = Path.Combine(OutputDir, "output_resolution_300.png");
            ImageRenderingOptions options1 = new ImageRenderingOptions()
            {
                HorizontalResolution = 50,
                VerticalResolution = 50
            };
            using ImageDevice device1 = new ImageDevice(options1, savePath1);
            document.RenderTo(device1);
            ImageRenderingOptions options2 = new ImageRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300
            };
            using ImageDevice device2 = new ImageDevice(options2, savePath2);
            document.RenderTo(device2);
        }

        // Render HTML to PDF with custom background color
        public void UseBackgroundColor()
        {
            string documentPath = Path.Combine(DataDir, "spring.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                BackgroundColor = System.Drawing.Color.Azure
            };
            string savePath = Path.Combine(OutputDir, "spring.pdf");
            using PdfDevice device = new PdfDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to PDF with custom left/right page sizes
        public void UsePageSetup()
        {
            string code = @"<style>div { page-break-after: always; }</style>
                <div>First Page</div>
                <div>Second Page</div>
                <div>Third Page</div>
                <div>Fourth Page</div>";
            using HTMLDocument document = new HTMLDocument(code, ".");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.SetLeftRightPage(
                new Page(new Size(400, 150)),
                new Page(new Size(400, 50))
            );
            string savePath = Path.Combine(OutputDir, "output-custom-page-size.pdf");
            using PdfDevice device = new PdfDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to PDF and adjust to widest page
        public void UsePageSetupAdjustToWidestPage()
        {
            string code = @"<style>
                div { page-break-after: always; }
                </style>
                <div style='border: 1px solid red; width: 300px'>First Page</div>
                <div style='border: 1px solid red; width: 500px'>Second Page</div>";
            using HTMLDocument document = new HTMLDocument(code, ".");
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(400, 200));
            options.PageSetup.AdjustToWidestPage = true;
            string savePath = Path.Combine(OutputDir, "output-widest-page-size.pdf");
            using PdfDevice device = new PdfDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to PDF with encryption and other options
        public void UsePdfRenderingOptions()
        {
            string documentPath = Path.Combine(DataDir, "document.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.Encryption = new PdfEncryptionInfo(
                "user_pwd",
                "owner_pwd",
                PdfPermissions.PrintDocument,
                PdfEncryptionAlgorithm.RC4_128);
            string savePath = Path.Combine(OutputDir, "output-options.pdf");
            using PdfDevice device = new PdfDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to JPG with custom resolution and antialiasing
        public void UseImageRenderingOptions()
        {
            string documentPath = Path.Combine(DataDir, "color.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg)
            {
                UseAntialiasing = false,
                VerticalResolution = Resolution.FromDotsPerInch(75),
                HorizontalResolution = Resolution.FromDotsPerInch(75)
            };
            string savePath = Path.Combine(OutputDir, "color-options.jpg");
            using ImageDevice device = new ImageDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to XPS with custom page size
        public void UseXpsRenderingOptions()
        {
            string documentPath = Path.Combine(DataDir, "document.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            XpsRenderingOptions options = new XpsRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(5), Length.FromInches(2)));
            string savePath = Path.Combine(OutputDir, "document-options.xps");
            using XpsDevice device = new XpsDevice(options, savePath);
            document.RenderTo(device);
        }

        // Render HTML to DOCX with custom page settings
        public void UseDocRenderingOptions()
        {
            string documentPath = Path.Combine(DataDir, "nature.html");
            using HTMLDocument document = new HTMLDocument(documentPath);
            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(8), Length.FromInches(10)));
            options.FontEmbeddingRule = FontEmbeddingRule.Full;
            string savePath = Path.Combine(OutputDir, "nature-options.docx");
            using DocDevice device = new DocDevice(options, savePath);
            document.RenderTo(device);
        }
    }
}