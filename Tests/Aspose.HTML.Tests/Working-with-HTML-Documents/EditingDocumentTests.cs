using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using System.IO;
using System.Linq;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests
{
    public class EditingDocumentTests : TestsBase
    {
        public EditingDocumentTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("editing");
        }


        [Fact(DisplayName = "Edit a Document Tree")]
        public void EditDocumentTreeTest()
        {
            // @START_SNIPPET EditDocumentTree.cs
            // Edit HTML document using DOM Tree
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

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
                document.Save(Path.Combine(OutputDir, "edit-document-tree.html"));
                Assert.True(File.Exists(Path.Combine(OutputDir, "edit-document-tree.html")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Using DOM")]
        public void UsingDOMTest()
        {
            // @START_SNIPPET CreateHtmlDocumentUsingDomAndConvertToPdf.cs
            // Create and add new HTML elements using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

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
                document.Save(Path.Combine(OutputDir, "using-dom.html"));

                // Create an instance of the PDF output device and render the document into this device
                using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "using-dom.pdf")))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
                Assert.True(File.Exists(Path.Combine(OutputDir, "using-dom.pdf")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Using OuterHTML")] 
        public void UsingOuterHTMLTest()
        {
            // @START_SNIPPET UsingOuterHTML.cs
            // Read and output full HTML content from a loaded document in C#
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

            string documentPath = Path.Combine(DataDir, "document.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Set an html variable for the document 
                string html = document.DocumentElement.OuterHTML;

                Output.WriteLine(html);
                Assert.StartsWith("<html", html.Trim());
                Assert.Contains("</html>", html);
                Assert.Contains("<body>Hello, World!</body>", html);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Using InnerHTML & OuterHTML")]
        public void UsingInnerHTMLOuterHTMLTest()
        {
            // @START_SNIPPET UsingInnerHTMLOuterHTML.cs
            // Edit HTML body content and get modified document as string
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Write the content of the HTML document into the console output
                Output.WriteLine(document.DocumentElement.OuterHTML); // output: <html><head></head><body></body></html>

                // Set the content of the body element
                document.Body.InnerHTML = "<p>HTML is the standard markup language for Web pages.</p>";

                // Set an html variable for the document content viewing
                string html = document.DocumentElement.OuterHTML;

                // Write the content of the HTML document into the console output
                Output.WriteLine(html); // output: <html><head></head><body><p>HTML is the standard markup language for Web pages.</p></body></html>
                Assert.Equal("HTML", document.DocumentElement.TagName);
                Assert.Contains("<p>HTML is the standard markup language for Web pages.</p>", html);
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Edit Inline CSS")]
        public void EditInlineCSSTest()
        {
            // @START_SNIPPET EditInlineCss.cs
            // How to set inline CSS styles in an HTML element using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

            // Create an instance of an HTML document with specified content
            string content = "<p>InlineCSS </p>";
            using (HTMLDocument document = new HTMLDocument(content, "."))
            {
                // Find the paragraph element to set a style
                HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();

                // Set the style attribute
                paragraph.SetAttribute("style", "font-size:250%; font-family:verdana; color:#cd66aa");

                // Save the HTML document to a file 
                document.Save(Path.Combine(OutputDir, "edit-inline-css.html"));

                // Create an instance of PDF output device and render the document into this device
                using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "edit-inline-css.pdf")))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
                Assert.True(File.Exists(Path.Combine(OutputDir, "edit-inline-css.pdf")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Edit Internal CSS")]
        public void EditInternalCSSTest()
        {
            // @START_SNIPPET EditInternalCss.cs
            // Edit HTML with internal CSS using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

            // Create an instance of an HTML document with specified content
            string content = "<div><p>Internal CSS</p><p>An internal CSS is used to define a style for a single HTML page</p></div>";
            using (HTMLDocument document = new HTMLDocument(content, "."))
            {
                Element style = document.CreateElement("style");
                style.TextContent = ".frame1 { margin-top:50px; margin-left:50px; padding:20px; width:360px; height:90px; background-color:#a52a2a; font-family:verdana; color:#FFF5EE;} \r\n" +
                                    ".frame2 { margin-top:-90px; margin-left:160px; text-align:center; padding:20px; width:360px; height:100px; background-color:#ADD8E6;}";

                // Find the document header element and append the style element to the header
                Element head = document.GetElementsByTagName("head").First();
                head.AppendChild(style);

                // Find the first paragraph element to inspect the styles
                HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
                paragraph.ClassName = "frame1";

                // Find the last paragraph element to inspect the styles
                HTMLElement lastParagraph = (HTMLElement)document.GetElementsByTagName("p").Last();
                lastParagraph.ClassName = "frame2";

                // Set a color to the first paragraph
                paragraph.Style.FontSize = "250%";
                paragraph.Style.TextAlign = "center";

                // Set a font-size to the last paragraph
                lastParagraph.Style.Color = "#434343";
                lastParagraph.Style.FontSize= "150%";
                lastParagraph.Style.FontFamily = "verdana";

                // Save the HTML document to a file 
                document.Save(Path.Combine(OutputDir, "edit-internal-css.html"));

                // Create the instance of the PDF output device and render the document into this device
                using (PdfDevice device = new PdfDevice(Path.Combine(OutputDir, "edit-internal-css.pdf")))
                {
                    // Render HTML to PDF
                    document.RenderTo(device);
                }
                Assert.True(document.QuerySelectorAll("style").Length > 0);
                Assert.True(File.Exists(Path.Combine(OutputDir, "edit-internal-css.pdf")));
                Assert.True(File.Exists(Path.Combine(OutputDir, "edit-internal-css.html")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "External CSS")]
        public void ExternalCSSTest()
        {
            // @START_SNIPPET UseExternalCss.cs
            // How to use an external CSS file in HTML using Aspose.HTML for .NET
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

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

                Assert.True(document.QuerySelectorAll("link").Length > 0);
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "external-css.html")));
        }


        [Fact(DisplayName = "Edit External CSS")]
        public void EditExternalCSSTest()
        {
            // @START_SNIPPET EditExternalCss.cs
            // Edit HTML with external CSS using C#
            // Learn more: https://docs.aspose.com/html/net/edit-html-document/

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
                // Save the HTML document to a file 
                document.Save(Path.Combine(OutputDir, "edit-external-css.html"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "edit-external-css.html")));
        }
    }
}