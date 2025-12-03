using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Pdf;

namespace Aspose.Html.Examples
{
    public class EditingDocumentExample : BaseExample
    {
        public EditingDocumentExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("editing");
        }

        /// <summary>
        /// Edit a Document Tree – demonstrates DOM tree manipulation
        /// </summary>
        public void EditDocumentTree()
        {
            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                HTMLElement body = document.Body;

                // Create a paragraph element
                HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");

                // Set a custom attribute
                p.SetAttribute("id", "my-paragraph");

                // Create a text node
                Text text = document.CreateTextNode("my first paragraph");

                // Attach the text to the paragraph
                p.AppendChild(text);

                // Attach the paragraph to the document body
                body.AppendChild(p);

                // Save the HTML document to a file
                string outPath = Path.Combine(OutputDir, "edit-document-tree.html");
                document.Save(outPath);
                Console.WriteLine($"Document tree edited and saved to: {outPath}");
            }
        }

        /// <summary>
        /// Demonstrates using DOM, creating a styled paragraph and rendering to PDF
        /// </summary>
        public void UsingDomAndRenderToPdf()
        {
            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a <style> element and assign the green color for all elements with class-name equals 'gr'.
                Element style = document.CreateElement("style");
                style.TextContent = ".gr { color: green }";

                // Find the document <head> element and append the <style> element to it
                Element head = document.GetElementsByTagName("head").First();
                head.AppendChild(style);

                // Create a paragraph element with class-name 'gr'.
                HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");
                p.ClassName = "gr";

                // Create a text node
                Text text = document.CreateTextNode("Hello World!!");

                // Append the text node to the paragraph
                p.AppendChild(text);

                // Append the paragraph to the document <body> element
                document.Body.AppendChild(p);

                // Save the HTML document to a file 
                string htmlPath = Path.Combine(OutputDir, "using-dom.html");
                document.Save(htmlPath);
                Console.WriteLine($"HTML with DOM saved to: {htmlPath}");

                // Render the document to PDF
                string pdfPath = Path.Combine(OutputDir, "using-dom.pdf");
                using (PdfDevice device = new PdfDevice(pdfPath))
                {
                    document.RenderTo(device);
                }
                Console.WriteLine($"Rendered PDF saved to: {pdfPath}");
            }
        }

        /// <summary>
        /// Demonstrates extracting OuterHTML of the document
        /// </summary>
        public void UsingOuterHtml()
        {
            // Load an existing HTML file
            string documentPath = Path.Combine(DataDir, "document.html");
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                string html = document.DocumentElement.OuterHTML;
                Console.WriteLine("OuterHTML of loaded document:");
                Console.WriteLine(html);
            }
        }

        /// <summary>
        /// Demonstrates editing InnerHTML and OuterHTML
        /// </summary>
        public void UsingInnerAndOuterHtml()
        {
            using (HTMLDocument document = new HTMLDocument())
            {
                Console.WriteLine("Original document:");
                Console.WriteLine(document.DocumentElement.OuterHTML); // <html><head></head><body></body></html>

                // Set the content of the body element
                document.Body.InnerHTML = "<p>HTML is the standard markup language for Web pages.</p>";

                string html = document.DocumentElement.OuterHTML;
                Console.WriteLine("Modified document:");
                Console.WriteLine(html);
            }
        }

        /// <summary>
        /// Demonstrates editing inline CSS
        /// </summary>
        public void EditInlineCss()
        {
            string content = "<p>InlineCSS </p>";
            using (HTMLDocument document = new HTMLDocument(content, "."))
            {
                HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
                paragraph.SetAttribute("style", "font-size:250%; font-family:verdana; color:#cd66aa");

                string outPath = Path.Combine(OutputDir, "edit-inline-css.html");
                document.Save(outPath);
                Console.WriteLine($"Document with inline CSS saved to: {outPath}");
            }
        }

        /// <summary>
        /// Demonstrates editing internal CSS
        /// </summary>
        public void EditInternalCss()
        {
            string content = "<div><p>Internal CSS</p><p>An internal CSS is used to define a style for a single HTML page</p></div>";
            using (HTMLDocument document = new HTMLDocument(content, "."))
            {
                Element style = document.CreateElement("style");
                style.TextContent = ".frame1 { margin-top:50px; margin-left:50px; padding:20px; width:360px; height:90px; background-color:#a52a2a; font-family:verdana; color:#FFF5EE;}\r\n" +
                                    ".frame2 { margin-top:-90px; margin-left:160px; text-align:center; padding:20px; width:360px; height:100px; background-color:#ADD8E6;}";
                Element head = document.GetElementsByTagName("head").First();
                head.AppendChild(style);

                HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
                paragraph.ClassName = "frame1";

                HTMLElement lastParagraph = (HTMLElement)document.GetElementsByTagName("p").Last();
                lastParagraph.ClassName = "frame2";

                paragraph.Style.FontSize = "250%";
                paragraph.Style.TextAlign = "center";

                lastParagraph.Style.Color = "#434343";
                lastParagraph.Style.FontSize = "150%";
                lastParagraph.Style.FontFamily = "verdana";

                string outPath = Path.Combine(OutputDir, "edit-internal-css.html");
                document.Save(outPath);
                Console.WriteLine($"Document with internal CSS saved to: {outPath}");
            }
        }

        /// <summary>
        /// Demonstrates using an external CSS file
        /// </summary>
        public void ExternalCss()
        {
            // Create an instance of HTML document with specified content
            string htmlContent = "<link rel=\"stylesheet\" href=\"https://docs.aspose.com/html/net/edit-html-document/external.css\" type=\"text/css\" />\r\n" +
                                 "<div class=\"rect1\" ></div>\r\n" +
                                 "<div class=\"rect2\" ></div>\r\n" +
                                 "<div class=\"frame\">\r\n" +
                                 "<p style=\"font-size:2.5em; color:#ae4566;\"> External CSS </p>\r\n" +
                                 "<p class=\"rect3\"> An external CSS can be created once and applied to multiple web pages</p></div>\r\n";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "."))
            {
                // Save the HTML document to a file 
                document.Save(Path.Combine(OutputDir, "external-css.html"));

                // Create the instance of the PDF output device and render the document into this device
                using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "external-css.pdf")))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
            }
        }

        /// <summary>
        /// Demonstrates editing external CSS
        /// </summary>
        public void EditExternalCss()
        {
            // Prepare content of a CSS file
            string styleContent = ".flower1 { width:120px; height:40px; border-radius:20px; background:#4387be; margin-top:50px; } \r\n" +
                                  ".flower2 { margin-left:0px; margin-top:-40px; background:#4387be; border-radius:20px; width:120px; height:40px; transform:rotate(60deg); } \r\n" +
                                  ".flower3 { transform:rotate(-60deg); margin-left:0px; margin-top:-40px; width:120px; height:40px; border-radius:20px; background:#4387be; }\r\n" +
                                  ".frame { margin-top:-50px; margin-left:310px; width:160px; height:50px; font-size:2em; font-family:Verdana; color:grey; }\r\n";

            // Prepare a linked CSS file
            File.WriteAllText("flower.css", styleContent);

            // Create an instance of an HTML document with specified content
            string htmlContent = "<link rel=\"stylesheet\" href=\"flower.css\" type=\"text/css\" /> \r\n" +
                                 "<div style=\"margin-top: 80px; margin-left:250px; transform: scale(1.3);\" >\r\n" +
                                 "<div class=\"flower1\" ></div>\r\n" +
                                 "<div class=\"flower2\" ></div>\r\n" +
                                 "<div class=\"flower3\" ></div></div>\r\n" +
                                 "<div style = \"margin-top: -90px; margin-left:120px; transform:scale(1);\" >\r\n" +
                                 "<div class=\"flower1\" style=\"background: #93cdea;\"></div>\r\n" +
                                 "<div class=\"flower2\" style=\"background: #93cdea;\"></div>\r\n" +
                                 "<div class=\"flower3\" style=\"background: #93cdea;\"></div></div>\r\n" +
                                 "<div style =\"margin-top: -90px; margin-left:-80px; transform: scale(0.7);\" >\r\n" +
                                 "<div class=\"flower1\" style=\"background: #d5effc;\"></div>\r\n" +
                                 "<div class=\"flower2\" style=\"background: #d5effc;\"></div>\r\n" +
                                 "<div class=\"flower3\" style=\"background: #d5effc;\"></div></div>\r\n" +
                                 "<p class=\"frame\">External</p>\r\n" +
                                 "<p class=\"frame\" style=\"letter-spacing:10px; font-size:2.5em \">  CSS </p>\r\n";

            using (HTMLDocument document = new HTMLDocument(htmlContent, "."))
            {
                string outPath = Path.Combine(OutputDir, "edit-external-css.html");
                document.Save(outPath);
                Console.WriteLine($"Document with edited external CSS saved to: {outPath}");
            }
        }
    }
}