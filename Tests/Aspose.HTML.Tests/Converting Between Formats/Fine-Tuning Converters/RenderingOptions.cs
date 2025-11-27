using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Rendering.Xps;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats.Fine_Tuning_Converters
{
    public class RenderingOptions : TestsBase
    {
        public RenderingOptions(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("fine-tuning-converters");
        }


        [Fact(DisplayName = "Use Rendering Options")]
        public void UseRenderingOptionsTest()
        {
            // @START_SNIPPET RenderHtmlToPdfWithCustomPageSize.cs
            // Render HTML to PDF in C# with custom page size
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            string code = @"<span>Hello, World!!</span>";

            // Initialize an HTML document from HTML code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create an instance of PdfRenderingOptions and set a custom page size
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                PageSetup =
                    {
                        AnyPage = new Page(new Size(Length.FromInches(4),Length.FromInches(2)))
                    }
            };

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "file-with-custom-page-size.pdf");

            // Create an instance of the PdfDevice and specify the options and output file to render
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use General Options")]
        public void UseGeneralOptionsTest()
        {
            // @START_SNIPPET RenderHtmlToPdfWithCustomResolution.cs
            // Render HTML to PDF in C# with custom resolution
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare HTML code and save it to a file
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
                        /* high resolution screen color */
                        background: orange
                    }
                }
                </style>
                <p>Hello, World!!</p>";

            File.WriteAllText("document.html", code);

            // Prepare a path to save output file 
            string savePath1 = Path.Combine(OutputDir, "output_resolution_50.pdf");
            string savePath2 = Path.Combine(OutputDir, "output_resolution_300.pdf");

            // Create an instance of HTML document
            using (HTMLDocument document = new HTMLDocument("document.html"))
            {

                // Create options for low-resolution screens
                PdfRenderingOptions options1 = new PdfRenderingOptions()
                {
                    HorizontalResolution = 50,
                    VerticalResolution = 50
                };

                // Create an instance of PDF device
                using PdfDevice device1 = new PdfDevice(options1, savePath1);

                // Render HTML to PDF
                document.RenderTo(device1);


                // Create options for high-resolution screens
                PdfRenderingOptions options2 = new PdfRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };

                // Create an instance of PDF device
                using PdfDevice device2 = new PdfDevice(options2, savePath2);

                // Render HTML to PDF
                document.RenderTo(device2);
            }

            // @END_SNIPPET
            Assert.True(File.Exists(savePath1));
        }


        [Fact(DisplayName = "Use Resolution Options")]
        public void UseResolutionTest()
        {
            // @START_SNIPPET RenderHtmlToPngWithCustomResolution.cs
            // Render HTML to PNG with custom resolution using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Create an instance of HTML document
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Prepare path to save output file 
            string savePath1 = Path.Combine(OutputDir, "output_resolution_50.png");
            string savePath2 = Path.Combine(OutputDir, "output_resolution_300.png");

            // Create options for low-resolution screens
                ImageRenderingOptions options1 = new ImageRenderingOptions()
                {
                    HorizontalResolution = 50,
                    VerticalResolution = 50
                };

            // Create an instance of Image device
            using ImageDevice device1 = new ImageDevice(options1, savePath1);

            // Render HTML to PNG
            document.RenderTo(device1);


            // Create options for high-resolution screens
            ImageRenderingOptions options2 = new ImageRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300
            };

            // Create an instance of Image device
            using ImageDevice device2 = new ImageDevice(options2, savePath2);

            // Render HTML to PNG
            document.RenderTo(device2);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "output_resolution_50.png")));
        }


        [Fact(DisplayName = "Use Background Color")]
        public void UseBackgroundColorTest()
        {
            // @START_SNIPPET UseBackgroundColor.cs
            // Render HTML to PDF with custom background color using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "spring.pdf");

            // Create an instance of HTML document
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Initialize options with 'Azure' as a background-color
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                BackgroundColor = System.Drawing.Color.Azure
            };

            // Create an instance of PDF device
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use Page Setup")]
        public void UsePageSetupTest()
        {
            // @START_SNIPPET UsePageSetup.cs
            // Render HTML to PDF with custom page size using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare HTML code
            string code = @"<style>div { page-break-after: always; }</style>
            <div>First Page</div>
            <div>Second Page</div>
            <div>Third Page</div>
            <div>Fourth Page</div>";

            // Initialize an HTML document from the HTML code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create the instance of Rendering Options and set a custom page size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.SetLeftRightPage(
                new Page(new Size(400, 150)),
                new Page(new Size(400, 50))
            );

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "output-custom-page-size.pdf");

            // Create the PDF Device and specify options and output file
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use PageSetup.AdjustToWidestPage")]
        public void PageSetupAdjustToWidestPageTest()
        {
            // @START_SNIPPET PageSetupAdjustToWidestPage.cs
            // Render HTML to PDF and adjust to the widest page with C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare HTML code
            string code = @"<style>
                div { page-break-after: always; }
            </style>
            <div style='border: 1px solid red; width: 300px'>First Page</div>
            <div style='border: 1px solid red; width: 500px'>Second Page</div>";

            // Initialize an HTML document from the HTML code
            using HTMLDocument document = new HTMLDocument(code, ".");

            // Create the instance of Rendering Options and set a custom page-size
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(400, 200));

            // Enable auto-adjusting for the page size
            options.PageSetup.AdjustToWidestPage = true;

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "output-widest-page-size.pdf");

            // Create the PdfDevice and specify options and output file
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use PdfRenderingOptions")]
        public void UsePdfRenderingOptionsTest()
        {
            // @START_SNIPPET UsePdfRenderingOptions.cs
            // Render HTML to PDF with password protection using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "document.html");

            // Initialize the HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create the instance of Rendering Options
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Set the permissions to the file
            options.Encryption = new PdfEncryptionInfo(
                    "user_pwd",
                    "owner_pwd",
                    PdfPermissions.PrintDocument,
                    PdfEncryptionAlgorithm.RC4_128);

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "output-options.pdf");

            // Create an instance of the PdfDevice and specify options and output file
            using PdfDevice device = new PdfDevice(options, savePath);

            // Render HTML to PDF
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use ImageRenderingOptions")]
        public void UseImageRenderingOptionsTest()
        {
            // @START_SNIPPET UseImageRenderingOptions.cs
            // Render HTML to JPG with custom resolution and antialiasing settings with C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "color.html");

            // Initialize the HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of Rendering Options
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg)
            {
                // Disable smoothing mode
                UseAntialiasing = false,

                // Set the image resolution as 75 dpi
                VerticalResolution = Resolution.FromDotsPerInch(75),
                HorizontalResolution = Resolution.FromDotsPerInch(75),
            };

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "color-options.jpg");

            // Create an instance of the ImageDevice and specify options and output file
            using ImageDevice device = new ImageDevice(options, savePath);

            // Render HTML to JPG
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "color-options.jpg")));
        }


        [Fact(DisplayName = "Use XpsRenderingOptions")]
        public void UseXpsRenderingOptionsTest()
        {
            // @START_SNIPPET UseXpsRenderingOptions.cs
            // Render HTML to XPS with custom page size using C#
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "document.html");

            // Initialize the HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of Rendering Options
            XpsRenderingOptions options = new XpsRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(5), Length.FromInches(2)));

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "document-options.xps");

            // Create an instance of the XpsDevice and specify options and output file
            using XpsDevice device = new XpsDevice(options, savePath);

            // Render HTML to XPS
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }


        [Fact(DisplayName = "Use DocRenderingOptions")]
        public void UseDocRenderingOptionsTest()
        {
            // @START_SNIPPET UseDocRenderingOptions.cs
            // Render HTML to DOCX in C# with custom page settings
            // Learn more: https://docs.aspose.com/html/net/rendering-options/

            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");

            // Initialize the HTML document from the file
            using HTMLDocument document = new HTMLDocument(documentPath);

            // Create an instance of Rendering Options and set a custom page size
            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(Length.FromInches(8), Length.FromInches(10)));
            options.FontEmbeddingRule = (FontEmbeddingRule.Full);

            // Prepare a path to save the converted file 
            string savePath = Path.Combine(OutputDir, "nature-options.docx");

            // Create an instance of the DocDevice and specify options and output file
            using DocDevice device = new DocDevice(options, savePath);

            // Render HTML to DOCX
            document.RenderTo(device);

            // @END_SNIPPET
            Assert.True(File.Exists(savePath));
        }
    }
}
