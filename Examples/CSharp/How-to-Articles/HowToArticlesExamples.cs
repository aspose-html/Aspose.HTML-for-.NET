using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Converters;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;
using Aspose.Html.Services;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Examples for How‑to articles
    /// </summary>
    public class HowToArticlesExamples : BaseExample
    {
        public HowToArticlesExamples()
        {
            // Set a sub‑directory for this group of examples
            SetOutputDir("how-to-articles");
        }

        /// <summary>
        /// Convert web page to PDF using C#
        /// </summary>
        public void ConvertWebpageToPdf()
        {
            // Set the target webpage URL
            string url = "https://docs.aspose.com/html/";
            // Define the output path
            string outputPath = Path.Combine(OutputDir, "website.pdf");
            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(url);
            // Configure PDF rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(1920, 1080));
            // Create a PDF rendering device
            PdfDevice device = new PdfDevice(options, outputPath);
            // Render the document
            HtmlRenderer renderer = new HtmlRenderer();
            renderer.Render(device, document);
            // Dispose resources
            renderer.Dispose();
            device.Dispose();
            document.Dispose();
        }

        /// <summary>
        /// Add image to HTML using C#
        /// </summary>
        public void AddImageToHtml()
        {
            using (HTMLDocument document = new HTMLDocument())
            {
                HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();
                var img = document.CreateElement("img");
                img.SetAttribute("src", "https://docs.aspose.com/html/images/aspose-html-for-net.png");
                img.SetAttribute("alt", "Aspose.HTML for .NET Product Logo");
                img.SetAttribute("width", "128");
                img.SetAttribute("height", "128");
                body.AppendChild(img);
                document.Save(Path.Combine(OutputDir, "add-image.html"), new HTMLSaveOptions());
            }
        }

        /// <summary>
        /// Add image to existing HTML using C#
        /// </summary>
        public void AddImageToExistingHtml()
        {
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "file.html")))
            {
                HTMLCollection paragraphs = document.GetElementsByTagName("p");
                if (paragraphs.Length >= 2)
                {
                    var img = document.CreateElement("img");
                    img.SetAttribute("src", "https://docs.aspose.com/html/images/aspose-html-for-net.png");
                    img.SetAttribute("alt", "Aspose.HTML for .NET Product Logo");
                    img.SetAttribute("width", "128");
                    img.SetAttribute("height", "128");
                    Element secondParagraph = paragraphs[1];
                    secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
                }
                document.Save(Path.Combine(OutputDir, "add-image-after-paragraph.html"), new HTMLSaveOptions());
            }
        }

        /// <summary>
        /// Add background image to HTML body using inline CSS
        /// </summary>
        public void AddBackgroundImageToBody()
        {
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document.html")))
            {
                HTMLElement body = document.QuerySelector("body") as HTMLElement;
                if (body != null)
                {
                    body.SetAttribute("style", "background-image: url('flower.png');");
                }
                document.Save(Path.Combine(OutputDir, "add-background-image.html"));
            }
        }

        /// <summary>
        /// Add background image to HTML using internal CSS
        /// </summary>
        public void AddBackgroundImageToHtml()
        {
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document.html")))
            {
                HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");
                string css = "body { background-image: url('background.png'); }";
                styleElement.AppendChild(document.CreateTextNode(css));
                HTMLElement head = document.QuerySelector("head") as HTMLElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }
                head.AppendChild(styleElement);
                document.Save(Path.Combine(OutputDir, "add-background-image-to-entire-page.html"));
            }
        }

        /// <summary>
        /// Add background image to HTML element using CSS
        /// </summary>
        public void AddBackgroundImageToElement()
        {
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document-with-h1.html")))
            {
                HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");
                string css = "h1 { background-image: url('background.png'); background-repeat: no-repeat; padding: 60px; }";
                styleElement.AppendChild(document.CreateTextNode(css));
                HTMLElement head = document.QuerySelector("head") as HTMLElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }
                head.AppendChild(styleElement);
                document.Save(Path.Combine(OutputDir, "add-background-image-to-h1.html"));
            }
        }

        /// <summary>
        /// Add missing alt text to images in HTML
        /// </summary>
        public void AddMissingAltText()
        {
            string inputPath = Path.Combine(DataDir, "test-checker.html");
            string outputPath = Path.Combine(OutputDir, "test-checker-updated.html");
            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection images = document.GetElementsByTagName("img");
            foreach (Element node in images)
            {
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image: " + Path.GetFileName(img.Src);
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }
            document.Save(outputPath);
        }

        /// <summary>
        /// Change background color for paragraph using inline CSS
        /// </summary>
        public void ChangeBackgroundColorForParagraph()
        {
            string savePath = Path.Combine(OutputDir, "change-background-color-p-inline-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.BackgroundColor = "#e5f3fd";
            document.Save(savePath);
        }

        /// <summary>
        /// Change background color using inline CSS on body
        /// </summary>
        public void ChangeBackgroundColorInlineCss()
        {
            string savePath = Path.Combine(OutputDir, "change-background-color-inline-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "#e5f3fd";
            document.Save(savePath);
        }

        /// <summary>
        /// Change background color using internal CSS
        /// </summary>
        public void ChangeBackgroundColorInternalCss()
        {
            string savePath = Path.Combine(OutputDir, "change-background-color-internal-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.RemoveProperty("background-color");
            Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save(savePath);
        }

        /// <summary>
        /// Change SVG background color in HTML using internal CSS
        /// </summary>
        public void ChangeSvgBackgroundColorInHtml()
        {
            string documentPath = Path.Combine(DataDir, "aspose-svg.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            Element styleElement = document.QuerySelector("style");
            styleElement.TextContent = styleElement.InnerHTML + "svg {background-color: #fef4fd;}";
            document.Save(Path.Combine(OutputDir, "with-background-color.html"));
        }

        /// <summary>
        /// Change SVG background color in HTML using JavaScript
        /// </summary>
        public void ChangeSvgBackgroundColorInHtmlUsingScript()
        {
            HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "aspose-svg.html"));
            Element svgElement = document.QuerySelector("svg[id='mySvg']");
            if (svgElement != null)
            {
                Element scriptElement = document.CreateElement("script");
                scriptElement.TextContent = @"
                    var svgElement = document.getElementById('mySvg');
                    if (svgElement) {
                        var rectElement = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
                        rectElement.setAttribute('x', '0');
                        rectElement.setAttribute('y', '0');
                        rectElement.setAttribute('width', '100%');
                        rectElement.setAttribute('height', '100%');
                        rectElement.setAttribute('fill', '#fef4fd');
                        svgElement.insertBefore(rectElement, svgElement.firstChild);
                    };
                ";
                document.Body.AppendChild(scriptElement);
            }
            document.Save(Path.Combine(OutputDir, "svg-background-color-html-script.html"));
        }

        /// <summary>
        /// Change border color for h1 element
        /// </summary>
        public void ChangeBorderColor()
        {
            string savePath = Path.Combine(OutputDir, "change-border-color.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.Color = "#8B0000";
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "rgb(220,30,100)";
            document.Save(savePath);
        }

        /// <summary>
        /// Change border color for four sides of an element
        /// </summary>
        public void ChangeBorderColorForFourSides()
        {
            string savePath = Path.Combine(OutputDir, "change-four-border-color.html");
            string documentPath = Path.Combine(DataDir, "change-border-color.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "red blue green gray";
            document.Save(savePath);
        }

        /// <summary>
        /// Change border color using internal CSS
        /// </summary>
        public void ChangeBorderColorInternalCss()
        {
            string savePath = Path.Combine(OutputDir, "change-border-color-internal-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            Element style = document.CreateElement("style");
            style.TextContent = "h1 {color:DarkRed; border-style:solid; border-color:rgb(220,30,100) }";
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save(savePath);
        }

        /// <summary>
        /// Change table border color using inline CSS
        /// </summary>
        public void ChangeTableBorderColorInlineCss()
        {
            string savePath = Path.Combine(OutputDir, "change-table-border-color-inline-css.html");
            string documentPath = Path.Combine(DataDir, "table.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            Element element = document.QuerySelector("table");
            element.SetAttribute("style", "border: 2px #0000ff solid");
            document.Save(savePath);
        }

        /// <summary>
        /// Change table border color using internal CSS
        /// </summary>
        public void ChangeTableBorderColorInternalCss()
        {
            string savePath = Path.Combine(OutputDir, "change-table-border-color-internal-css.html");
            string documentPath = Path.Combine(DataDir, "table.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            Element style = document.CreateElement("style");
            style.TextContent = "table { border-style:solid; border-color:rgb(0, 0, 255) }";
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save(savePath);
        }

        /// <summary>
        /// Change paragraph text color using inline CSS
        /// </summary>
        public void ChangeParagraphTextColorInlineCss()
        {
            string savePath = Path.Combine(OutputDir, "change-paragraph-color-inline-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.Color = "#8B0000";
            document.Save(savePath);
        }

        /// <summary>
        /// Change h1 text color using inline CSS
        /// </summary>
        public void ChangeHeaderColorInlineCss()
        {
            string savePath = Path.Combine(OutputDir, "change-h1-color-inline-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            HTMLElement header = (HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.Color = "DarkRed";
            document.Save(savePath);
        }

        /// <summary>
        /// Change h1 text color using internal CSS
        /// </summary>
        public void ChangeHeaderColorInternalCss()
        {
            string savePath = Path.Combine(OutputDir, "change-h1-color-internal-css.html");
            string documentPath = Path.Combine(DataDir, "file.html");
            HTMLDocument document = new HTMLDocument(documentPath);
            Element style = document.CreateElement("style");
            style.TextContent = "h1 { color:DarkRed }";
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save(savePath);
        }

        /// <summary>
        /// Check if HTML body is empty
        /// </summary>
        public void CheckEmptyContent()
        {
            string inputPath = Path.Combine(DataDir, "file.html");
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLElement body = document.Body;
                if (!string.IsNullOrWhiteSpace(body.TextContent))
                    Console.WriteLine("Non‑empty HTML elements found");
                else
                    Console.WriteLine("No child nodes found in the body element.");
            }
        }

        /// <summary>
        /// Set custom font folder for HTML to PDF conversion
        /// </summary>
        public void SetFontFolderForPdf()
        {
            string documentPath = Path.Combine(DataDir, "file.html");
            using Configuration configuration = new Configuration();
            IUserAgentService service = configuration.GetService<IUserAgentService>();
            service.FontsSettings.SetFontsLookupFolder(Path.Combine(DataDir, "fonts"));
            using (HTMLDocument document = new HTMLDocument(documentPath, configuration))
            {
                Converter.ConvertHTML(document, new PdfSaveOptions(), Path.Combine(OutputDir, "file-fontsetting.pdf"));
            }
        }

        /// <summary>
        /// Set custom font folder for HTML to image conversion
        /// </summary>
        public void SetFontFolderForImage()
        {
            string documentPath = Path.Combine(DataDir, "file.html");
            using Configuration configuration = new Configuration();
            IUserAgentService service = configuration.GetService<IUserAgentService>();
            service.FontsSettings.SetFontsLookupFolder(Path.Combine(DataDir, "font"), true);
            using (HTMLDocument document = new HTMLDocument(documentPath, configuration))
            {
                Converter.ConvertHTML(document, new ImageSaveOptions(), Path.Combine(OutputDir, "file-output.png"));
            }
        }

        /// <summary>
        /// Serialize input value in HTML form
        /// </summary>
        public void SerializeInputValue()
        {
            string html = @"
                <html>
                    <body>
                        <div>The new input element value: <input type = ""text"" value=""No"" /></div>
                    </body>
                </html>";
            using HTMLDocument doc = new HTMLDocument(html, string.Empty);
            HTMLCollection inputElements = doc.GetElementsByTagName("input");
            HTMLInputElement input = (HTMLInputElement)inputElements[0];
            input.Value = "Text";
            string savePath = Path.Combine(OutputDir, "result.html");
            doc.Save(savePath, new HTMLSaveOptions { SerializeInputValue = true });
        }

        /// <summary>
        /// Convert CSS units – pixels to centimeters
        /// </summary>
        public void ConvertPxToCm()
        {
            var px = Unit.FromPixels(1000);
            var cm = px.GetValue(UnitType.Cm);
            Console.WriteLine(cm.ToString("F2"));
        }

        /// <summary>
        /// Convert CSS units – centimeters to pixels
        /// </summary>
        public void ConvertCmToPx()
        {
            var cm = Unit.FromCentimeters(100);
            var px = cm.GetValue(UnitType.Px);
            Console.WriteLine(px.ToString("F2"));
        }

        /// <summary>
        /// Convert CSS units – inches to pixels
        /// </summary>
        public void ConvertInToPx()
        {
            var inch = Unit.FromInches(100);
            var px = inch.GetValue(UnitType.Px);
            Console.WriteLine(px.ToString("F2"));
        }

        /// <summary>
        /// Convert CSS units – pixels to inches
        /// </summary>
        public void ConvertPxToIn()
        {
            var px = Unit.FromPixels(800);
            var inch = px.GetValue(UnitType.In);
            Console.WriteLine(inch.ToString("F2"));
        }

        /// <summary>
        /// Use XPath to select all img nodes
        /// </summary>
        public void XPathSelectAllImages()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Console.WriteLine(img.Src);
                }
            }
        }

        /// <summary>
        /// Use XPath to select img nodes inside main
        /// </summary>
        public void XPathSelectImagesInMain()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//main//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Console.WriteLine(img.Src);
                }
            }
        }

        /// <summary>
        /// Use XPath to get links to images (odd positioned divs)
        /// </summary>
        public void XPathSelectOddDivImages()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//main/div[position() mod 2 = 1]//img", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Console.WriteLine(img.Src);
                }
            }
        }

        /// <summary>
        /// Use XPath to get only photo images
        /// </summary>
        public void XPathSelectPhotoImages()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "xpath-image.htm")))
            {
                IXPathResult result = doc.Evaluate("//main/div[position() mod 2 = 1]//img[@class = 'photo']", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node node;
                while ((node = result.IterateNext()) != null)
                {
                    HTMLImageElement img = (HTMLImageElement)node;
                    Console.WriteLine(img.Src);
                }
            }
        }

        /// <summary>
        /// Use XPath to select dealer nodes in XML
        /// </summary>
        public void XPathSelectDealersInXml()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                IXPathResult dealers = doc.Evaluate("//Dealer", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Console.WriteLine(dealer.TextContent);
                }
            }
        }

        /// <summary>
        /// Use XPath axes to select dealers with recent cars
        /// </summary>
        public void XPathSelectDealersWithRecentCars()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Console.WriteLine(dealer.TextContent);
                }
            }
        }

        /// <summary>
        /// Use XPath to select dealers with recent cars and price limit
        /// </summary>
        public void XPathSelectDealersWithPriceLimit()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;
                while ((dealer = dealers.IterateNext()) != null)
                {
                    Console.WriteLine(dealer.TextContent);
                }
            }
        }

        /// <summary>
        /// Use XPath to get dealer info and car IDs
        /// </summary>
        public void XPathDealerInfoAndCarIds()
        {
            using (HTMLDocument doc = new HTMLDocument(Path.Combine(DataDir, "cars.xml")))
            {
                IXPathResult dealers = doc.Evaluate("//Dealer[descendant::Car[descendant::Model > 2005 and descendant::Price < 25000]]", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                Node dealer;
                while ((dealer = dealers.IterateNext()) != null)
                {
                    IXPathResult dealerInfo = doc.Evaluate("concat('Dealer name: ', Name/text(), ' Telephone: ', Telephone/text())", dealer, doc.CreateNSResolver(doc), XPathResultType.String, null);
                    Console.WriteLine(dealerInfo.StringValue);
                    IXPathResult carIds = doc.Evaluate(".//Car[descendant::Model > 2005 and descendant::Price < 25000]/@CarID", dealer, doc.CreateNSResolver(doc), XPathResultType.Any, null);
                    Node carId;
                    while ((carId = carIds.IterateNext()) != null)
                    {
                        Console.WriteLine("Car id: " + carId.TextContent);
                    }
                }
            }
        }
        /// <summary>
        /// Convert HTML to image with default rendering options
        /// </summary>
        public void ConvertHTMLWithDefaultRenderingOptions()
        {
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
        }

        /// <summary>
        /// Convert HTML to image using FitWidth option
        /// </summary>
        public void UsingFitWidth()
        {
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
        }

        /// <summary>
        /// Convert HTML to image using FitToContentWidth and FitToContentHeight
        /// </summary>
        public void FitPage()
        {
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
                HorizontalResolution = 96,
                VerticalResolution = 96
            };
            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);
        }

        /// <summary>
        /// Convert HTML to PDF using FitToContentWidth and FitToContentHeight
        /// </summary>
        public void FitPagePdf()
        {
            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");
            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitPage.pdf");
            // Initialize the HTML document
            using HTMLDocument document = new HTMLDocument(documentPath);
            // Initialize a PdfRenderingOptions object with custom options. Use FitToContentWidth and FitToContentHeight flags
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
        }

        /// <summary>
        /// Convert HTML to image using small custom page size
        /// </summary>
        public void UsingFitSmallPage()
        {
            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");
            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "FitSmallPage.jpg");
            // Initialize HTMLDocument
            using HTMLDocument document = new HTMLDocument(documentPath);
            // Initialize an ImageRenderingOptions object with custom options. Use the FitToWidestContentWidth and FitToContentHeight flags
            ImageRenderingOptions opt = new ImageRenderingOptions(ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.FitToWidestContentWidth | PageLayoutOptions.FitToContentHeight,
                    AnyPage = new Page(new Size(20, 20))
                }
            };
            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);
        }

        /// <summary>
        /// Scale HTML content to fixed page size
        /// </summary>
        public void ScaleSmallPage()
        {
            // Prepare path to a source HTML file
            string documentPath = Path.Combine(DataDir, "rendering.html");
            // Prepare path for converted file saving 
            string savePath = Path.Combine(OutputDir, "ScaleSmallPage.png");
            // Create an instance of HTMLDocument object
            using HTMLDocument document = new HTMLDocument(documentPath);
            // Initialize an ImageRenderingOptions object and use ScaleToPageWidth and ScaleToPageHeight flags
            ImageRenderingOptions opt = new ImageRenderingOptions()
            {
                PageSetup =
                {
                    PageLayoutOptions = PageLayoutOptions.ScaleToPageWidth | PageLayoutOptions.ScaleToPageHeight,
                    AnyPage = new Page(new Size(200, 200))
                }
            };
            // Create an output rendering device and convert HTML
            using ImageDevice device = new ImageDevice(opt, savePath);
            document.RenderTo(device);
        }

        /// <summary>
        /// Use CSS selector to extract content
        /// </summary>
        public void UsingCssSelectorToExtractContent()
        {
            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "queryselector.html");
            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);
            // Here we create a CSS Selector that extracts the first paragraph element
            Element element = document.QuerySelector("p");
            // Print content of the first paragraph  
            Console.WriteLine(element.InnerHTML);
            // Set style attribute with properties for the selected element
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            // Save the HTML document
            document.Save(Path.Combine(OutputDir, "queryselector-p.html"));
        }

        /// <summary>
        /// Use CSS selector to style element
        /// </summary>
        public void UsingCssSelectorToStyleElement()
        {
            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "css-celector-style.html");
            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "nature.html");
            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);
            // Create a CSS Selector that selects <div> element that is the last child of its parent
            Element element = document.QuerySelector("div:last-child");
            // Set the style attribute with properties for the selected element
            element.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe; text-align:center");
            // Save the HTML document
            document.Save(Path.Combine(OutputDir, savePath));
        }

        /// <summary>
        /// Use CSS selector to style multiple elements
        /// </summary>
        public void CssSelectorToStyleElement()
        {
            // Prepare output path for HTML document saving
            string savePath = Path.Combine(OutputDir, "css-selector-color.html");
            // Prepare path to source HTML file
            string documentPath = Path.Combine(DataDir, "spring.html");
            // Create an instance of an HTML document
            HTMLDocument document = new HTMLDocument(documentPath);
            // Here we create a CSS Selector that extracts all elements whose 'class' attribute equals 'square2'
            NodeList elements = document.QuerySelectorAll(".square2");
            // Iterate over the resulted list of elements
            foreach (HTMLElement element in elements)
            {
                // Set the style attribute with new background-color property
                element.Style.BackgroundColor = "#b0d7fb";
            }
            // Save the HTML document
            document.Save(Path.Combine(OutputDir, savePath));
        }

        /// <summary>
        /// Run all How‑to article examples
        /// </summary>
        public void RunAll()
        {
            ConvertWebpageToPdf();
            AddImageToHtml();
            AddImageToExistingHtml();
            AddBackgroundImageToBody();
            AddBackgroundImageToHtml();
            AddBackgroundImageToElement();
            AddMissingAltText();
            ChangeBackgroundColorForParagraph();
            ChangeBackgroundColorInlineCss();
            ChangeBackgroundColorInternalCss();
            ChangeSvgBackgroundColorInHtml();
            ChangeSvgBackgroundColorInHtmlUsingScript();
            ChangeBorderColor();
            ChangeBorderColorForFourSides();
            ChangeBorderColorInternalCss();
            ChangeTableBorderColorInlineCss();
            ChangeTableBorderColorInternalCss();
            ChangeParagraphTextColorInlineCss();
            ChangeHeaderColorInlineCss();
            ChangeHeaderColorInternalCss();
            CheckEmptyContent();
            //SetFontFolderForPdf();
            SetFontFolderForImage();
            SerializeInputValue();
            ConvertPxToCm();
            ConvertCmToPx();
            ConvertInToPx();
            ConvertPxToIn();
            XPathSelectAllImages();
            XPathSelectImagesInMain();
            XPathSelectOddDivImages();
            XPathSelectPhotoImages();
            XPathSelectDealersInXml();
            XPathSelectDealersWithRecentCars();
            XPathSelectDealersWithPriceLimit();
            XPathDealerInfoAndCarIds();
        }
    }
}