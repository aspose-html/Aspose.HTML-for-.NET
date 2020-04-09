using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class FineTuningConverters
    {
        public static void SpecifyOutputDevice()
        {
            //ExStart: SpecifyOutputDevice
            // Prepare an HTML code
            var code = @"<span>Hello World!!</span>";

            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the PDF Device and specify the output file to render
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyOutputDevice
        }

        public static void SpecifyRenderingOptions()
        {
            //ExStart: SpecifyRenderingOptions
            // Prepare an HTML code
            var code = @"<span>Hello World!!</span>";

            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the instance of PdfRenderingOptions and set a custom page-size
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions()
                {
                    PageSetup =
                    {
                        AnyPage = new Aspose.Html.Drawing.Page(
                            new Aspose.Html.Drawing.Size(
                                Aspose.Html.Drawing.Length.FromInches(5),
                                Aspose.Html.Drawing.Length.FromInches(2)))
                    }
                };

                // Create the PDF Device and specify options and output file
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyRenderingOptions
        }

        public static void SpecifyResolution()
        {
            //ExStart: SpecifyResolution
            // Prepare an HTML code and save it to the file.
            var code = @"
                <style>
                p
                { 
                    background: blue; 
                }
                @media(min-resolution: 300dpi)
                {
                    p 
                    { 
                        /* high resolution screen color */
                        background: green
                    }
                }
                </style>
                <p>Hello World!!</p>";

            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of HTML document
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Create options for low-resolution screens
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions()
                {
                    HorizontalResolution = 50,
                    VerticalResolution = 50
                };

                // Create an instance of PDF device
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output_resolution_50.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }


                // Create options for high-resolution screens
                options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };

                // Create an instance of PDF device
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output_resolution_300.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyResolution
        }

        public static void SpecifyBackgroundColor()
        {
            //ExStart: SpecifyBackgroundColor
            // Prepare an HTML code and save it to the file.
            var code = @"<p>Hello World!!</p>";
            System.IO.File.WriteAllText("document.html", code);

            // Create an instance of HTML document
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize options with 'cyan' as a background-color
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions()
                {
                    BackgroundColor = System.Drawing.Color.Cyan
                };

                // Create an instance of PDF device
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyBackgroundColor
        }

        public static void SpecifyLeftRightPageSize()
        {
            //ExStart: SpecifyLeftRightPageSize
            // Prepare an HTML code
            var code = @"<style>div { page-break-after: always; }</style>
            <div>First Page</div>
            <div>Second Page</div>
            <div>Third Page</div>
            <div>Fourth Page</div>";

            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the instance of Rendering Options and set a custom page-size
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.SetLeftRightPage(
                    new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(400, 200)),
                    new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(400, 100))
                );

                // Create the PDF Device and specify options and output file
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyLeftRightPageSize
        }

        public static void AdjustPageSizeToContent()
        {
            //ExStart: AdjustPageSizeToContent
            // Prepare an HTML code
            var code = @"<style>
                div { page-break-after: always; }
            </style>
            <div style='border: 1px solid red; width: 400px'>First Page</div>
            <div style='border: 1px solid red; width: 600px'>Second Page</div>
            ";
            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the instance of Rendering Options and set a custom page-size
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(500, 200));

                // Enable auto-adjusting for the page size
                options.PageSetup.AdjustToWidestPage = true;

                // Create the PDF Device and specify options and output file
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: AdjustPageSizeToContent
        }

        public static void SpecifyPDFPermissions()
        {
            //ExStart: SpecifyPDFPermissions
            // Prepare an HTML code
            var code = @"<div>Hello World!!</div>";
            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the instance of Rendering Options
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

                // Set the permissions to the file
                options.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                    "user_pwd",
                    "owner_pwd",
                    Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                    Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);

                // Create the PDF Device and specify options and output file
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyPDFPermissions
        }

        public static void SpecifyImageSpecificOptions()
        {
            //ExStart: SpecifyImageSpecificOptions
            // Prepare an HTML code
            var code = @"<div>Hello World!!</div>";

            // Initialize an instance of HTML document based on prepared code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create an instance of Rendering Options
                var options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    Format = Aspose.Html.Rendering.Image.ImageFormat.Jpeg,

                    // Disable smoothing mode
                    SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None,

                    // Set the image resolution as 75 dpi
                    VerticalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(75),
                    HorizontalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(75),
                };


                // Create an instance of Image Device 
                using (var device = new Aspose.Html.Rendering.Image.ImageDevice(options, "output.jpg"))
                {
                    // Render HTML to Image
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyImageSpecificOptions
        }

        public static void SpecifyXpsRenderingOptions()
        {
            //ExStart: SpecifyXpsRenderingOptions
            // Prepare an HTML code
            var code = @"<span>Hello World!!</span>";

            // Initialize the HTML document from the HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create the instance of XpsRenderingOptions and set a custom page-size
                var options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(5),
                        Aspose.Html.Drawing.Length.FromInches(2)));

                // Create the XPS Device and specify options and output file
                using (var device = new Aspose.Html.Rendering.Xps.XpsDevice(options, "output.xps"))
                {
                    // Render HTML to XPS
                    document.RenderTo(device);
                }
            }
            //ExEnd: SpecifyXpsRenderingOptions
        }

        public static void CombineMultipleHTMLToPDF()
        {
            //ExStart: CombineMultipleHTMLToPDF
            // Prepare an HTML code
            var code1 = @"<br><span style='color: green'>Hello World!!</span>";
            var code2 = @"<br><span style='color: blue'>Hello World!!</span>";
            var code3 = @"<br><span style='color: red'>Hello World!!</span>";

            // Create three HTML documents to merge later
            using (var document1 = new Aspose.Html.HTMLDocument(code1, "."))
            using (var document2 = new Aspose.Html.HTMLDocument(code2, "."))
            using (var document3 = new Aspose.Html.HTMLDocument(code3, "."))
            {
                // Create an instance of HTML Renderer
                using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
                {
                    // Create an instance of PDF device
                    using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
                    {
                        // Merge all HTML documents into PDF
                        renderer.Render(device, document1, document2, document3);
                    }
                }
            }
            //ExEnd: CombineMultipleHTMLToPDF
        }

        public static void RendererTimeoutExample()
        {
            //ExStart: RendererTimeoutExample
            // Prepare an HTML code
            var code = @"
            <script>
                var count = 0;
                setInterval(function()
                    {
                        var element = document.createElement('div');
                        var message = (++count) + '. ' + 'Hello World!!';
                        var text = document.createTextNode(message);
                        element.appendChild(text);
                        document.body.appendChild(element);
                    }, 1000);
            </script>
            ";

            // Initialize an HTML document based on prepared HTML code
            using (var document = new Aspose.Html.HTMLDocument(code, "."))
            {
                // Create an instance of HTML Renderer
                using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
                {
                    // Create an instance of PDF device
                    using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
                    {
                        // Render HTML to PDF
                        renderer.Render(device, System.TimeSpan.FromSeconds(5), document);
                    }
                }
            }
            //ExEnd: RendererTimeoutExample
        }
    }
}
