using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertHTMLToImage
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Invoke the ConvertHTML method to convert the HTML code to image.
            Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello</span> <span>World!!</span>", ".", new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg), "output.jpg");
            //ExEnd: WithASingleLine
        }

        public static void ConvertHTMLToJPG()
        {
            //ExStart: ConvertHTMLToJPG
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Convert HTML to JPG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.jpg");
            }
            //ExEnd: ConvertHTMLToJPG
        }

        public static void ConvertHTMLToPNG()
        {
            //ExStart: ConvertHTMLToPNG
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                // Convert HTML to PNG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.png");
            }
            //ExEnd: ConvertHTMLToPNG
        }

        public static void ConvertHTMLToBMP()
        {
            //ExStart: ConvertHTMLToBMP
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Convert HTML to BMP
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.bmp");
            }
            //ExEnd: ConvertHTMLToBMP
        }

        public static void ConvertHTMLToGIF()
        {
            //ExStart: ConvertHTMLToGIF
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                // Convert HTML to GIF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.gif");
            }
            //ExEnd: ConvertHTMLToGIF
        }

        public static void ConvertHTMLToTIFF()
        {
            //ExStart: ConvertHTMLToTIFF
            // Prepare an HTML code and save it to the file.
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Initialize an HTML document from the html file
            using (var document = new Aspose.Html.HTMLDocument("document.html"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

                // Convert HTML to TIFF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.tiff");
            }
            //ExEnd: ConvertHTMLToTIFF
        }

        public static void SpecifyImageSaveOptions()
        {
            //ExStart: SpecifyImageSaveOptions
            // Prepare an HTML code and save it to the file
            var code = @"<span>Hello</span> <span>World!!</span>";
            System.IO.File.WriteAllText("document.html", code);

            // Set up the page-size 3000x1000 pixels and change the background color to green
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromPixels(3000), Aspose.Html.Drawing.Length.FromPixels(1000))
                    }
                },
                BackgroundColor = System.Drawing.Color.Green,
            };
            // Call the ConvertHTML to convert 'document.html' into jpeg image
            Aspose.Html.Converters.Converter.ConvertHTML("document.html", options, "output.jpg");
            //ExEnd: SpecifyImageSaveOptions
        }

        public static void SpecifyCustomStreamProvider()
        {
            //ExStart: SpecifyCustomStreamProvider
            // Create an instance of MemoryStreamProvider
            using (var streamProvider = new MemoryStreamProvider())
            {
                // Initialize an HTML document
                using (var document = new Aspose.Html.HTMLDocument(@"<span>Hello</span> <span>World!!</span>", "."))
                {
                    // Convert HTML to Image by using the MemoryStreamProvider
                    Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg), streamProvider);

                    // Get access to the memory stream that contains the result data
                    var memory = streamProvider.Streams.First();
                    memory.Seek(0, System.IO.SeekOrigin.Begin);

                    // Flush the result data to the output file
                    using (System.IO.FileStream fs = System.IO.File.Create("output.jpg"))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }
            //ExEnd: SpecifyCustomStreamProvider
        }

        class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            // List of MemoryStream objects created during the document rendering
            public List<System.IO.MemoryStream> Streams { get; } = new List<System.IO.MemoryStream>();

            public System.IO.Stream GetStream(string name, string extension)
            {
                // This method is called when the only one output stream is required, for instance for XPS, PDF or TIFF formats.
                System.IO.MemoryStream result = new System.IO.MemoryStream();
                Streams.Add(result);
                return result;
            }

            public System.IO.Stream GetStream(string name, string extension, int page)
            {
                // This method is called when the creation of multiple output streams are required. For instance during the rendering HTML to list of the image files (JPG, PNG, etc.)
                System.IO.MemoryStream result = new System.IO.MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(System.IO.Stream stream)
            {
                //  Here You can release the stream filled with data and, for instance, flush it to the hard-drive
            }

            public void Dispose()
            {
                // Releasing resources
                foreach (var stream in Streams)
                    stream.Dispose();
            }
        }
    }
}
