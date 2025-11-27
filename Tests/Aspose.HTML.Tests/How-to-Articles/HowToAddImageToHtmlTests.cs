using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class HowToAddImageToHtmlTests : TestsBase
    {
        public HowToAddImageToHtmlTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("how-to-articles/image");
        }


        [Fact(DisplayName = "Add Image to HTML")]
        public void AddImageToHTMLTest()
        {
            // @START_SNIPPET AddImageToHTML.cs
            // Add image to HTML using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-add-image/

            // Create a new HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Get a reference to the <body> element
                HTMLElement body = (HTMLElement)document.GetElementsByTagName("body").First();

                // Create an <img> element
                var img = document.CreateElement("img");
                img.SetAttribute("src", "https://docs.aspose.com/html/images/aspose-html-for-net.png"); // Specify a link URL or local path
                img.SetAttribute("alt", "Aspose.HTML for .NET Product Logo");
                img.SetAttribute("width", "128"); // Set parameters optionally
                img.SetAttribute("height", "128");

                // Add the <img> element to the <body>
                body.AppendChild(img);

                // Save file to a local file system
                document.Save(Path.Combine(OutputDir, "add-image.html"), new HTMLSaveOptions());
            }
            // @END_SNIPPET
            Output.WriteLine("HTML document with an image has been successfully created.");
            Assert.True(File.Exists(Path.Combine(OutputDir, "add-image.html")));
        }


        [Fact(DisplayName = "Add Image to Existing HTML")]
        public void AddImageToExistingHTMLTest()
        {

            // @START_SNIPPET AddImageToExistingHTML.cs
            // Add image to existing HTML using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-add-image/

            // Load an existing HTML document
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "file.html")))
            {
                // Get all <p> (paragraph) elements
                HTMLCollection paragraphs = document.GetElementsByTagName("p");

                // Check if there are at least two paragraphs
                if (paragraphs.Length >= 2)
                {
                    // Create a new <img> element
                    var img = document.CreateElement("img");
                    img.SetAttribute("src", "https://docs.aspose.com/html/images/aspose-html-for-net.png"); // Set image source (URL or local path)
                    img.SetAttribute("alt", "Aspose.HTML for .NET Product Logo");
                    img.SetAttribute("width", "128");
                    img.SetAttribute("height", "128");

                    // Get the second paragraph
                    Element secondParagraph = paragraphs[1];

                    // Insert the image after the second paragraph
                    secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
                }

                // Save the updated HTML document
                document.Save(Path.Combine(OutputDir, "add-image-after-paragraph.html"), new HTMLSaveOptions());
            }
            // @END_SNIPPET
            Output.WriteLine("Image successfully added after the second paragraph.");
            Assert.True(File.Exists(Path.Combine(OutputDir, "add-image-after-paragraph.html")));
        }


        [Fact(DisplayName = "Add Background Image to HTML Using Inline CSS")]
        public void AddBackgroundImageToHTMLBodyUsingStyleAttributeTest()
        {

            // @START_SNIPPET AddBackgroundImageToHTMLUsingInlineCss.cs
            // Add background image with CSS in C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-add-image/

            // Load an existing HTML document
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document.html")))
            {
                // Get the <body> element
                HTMLElement body = document.QuerySelector("body") as HTMLElement;

                if (body != null)
                {
                    // Set a background image using inline CSS
                    body.SetAttribute("style", "background-image: url('flower.png');");
                }

                // Save the updated HTML document
                document.Save(Path.Combine(OutputDir, "add-background-image.html"));
            }
            // @END_SNIPPET
            Output.WriteLine("Background image added successfully.");
            Assert.True(File.Exists(Path.Combine(OutputDir, "add-background-image.html")));
        }


        [Fact(DisplayName = "Add Background Image to Existing HTML")]
        public void AddBackgroundImageToHTMLTest()
        {

            // @START_SNIPPET AddBackgroundImageToHTML.cs
            // Add a background image to HTML using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-add-image/

            // Load an existing HTML document
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document.html")))
            {
                // Create a new <style> element
                HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");

                // Define CSS for background image
                string css = "body { background-image: url('background.png'); }";
                styleElement.AppendChild(document.CreateTextNode(css));

                // Get the <head> element or create one if missing
                HTMLElement head = document.QuerySelector("head") as HTMLElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                // Append the <style> element to the <head>
                head.AppendChild(styleElement);

                // Save the updated HTML document
                document.Save(Path.Combine(OutputDir, "add-background-image-to-entire-page.html"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "add-background-image-to-entire-page.html")));

        }


        [Fact(DisplayName = "Add Background Image to HTML Element")]
        public void AddBackgroundImageToHTMLElementTest()
        {

            // @START_SNIPPET AddBackgroundImageToH1Element.cs
            // Apply background image to heading <h1> with C# and CSS
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/how-to-add-image/

            // Load the existing HTML document
            using (HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "document-with-h1.html")))
            {
                // Create a new <style> element
                HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");

                // Define CSS to apply a background image to all <p> elements
                string css = "h1 { background-image: url('background.png'); background-repeat: no-repeat; padding: 60px;}";
                styleElement.AppendChild(document.CreateTextNode(css));

                // Get the <head> element or create one if missing
                HTMLElement head = document.QuerySelector("head") as HTMLElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as HTMLElement;
                    document.DocumentElement.InsertBefore(head, document.Body);
                }

                // Append the <style> element to the <head>
                head.AppendChild(styleElement);

                // Save the updated HTML document
                document.Save(Path.Combine(OutputDir, "add-background-image-to-h1.html"));
            }
            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "add-background-image-to-h1.html")));
        }


        [Fact(DisplayName = "Add Missing alt tex")]
        public void AddMissingAltTexTest()
        {
            // @START_SNIPPET AddAltTextToImagesInHtml.cs
            // How to automatically add alt text to images in an HTML file using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/

            string inputPath = Path.Combine(DataDir, "test-checker.html");
            string outputPath = Path.Combine(OutputDir, "test-checker-updated.html");

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all <img> elements in the document
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through all image elements
            foreach (Element node in images)
            {
                // Ensure the node is an HTMLImageElement
                HTMLImageElement img = node as HTMLImageElement;
                if (img != null)
                {
                    // Read the existing alt attribute
                    string alt = img.GetAttribute("alt");

                    // Check if the alt text is missing or empty
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        // Generate simple descriptive alt text using the image filename
                        string autoAlt = "Image: " + Path.GetFileName(img.Src);

                        // Add the generated alt text to the image element
                        img.SetAttribute("alt", autoAlt);                        
                    }
                }
            }

            // Save the updated HTML document
            document.Save(outputPath);
            // @END_SNIPPET
            Assert.True(File.Exists(outputPath));
        }
    }
}
