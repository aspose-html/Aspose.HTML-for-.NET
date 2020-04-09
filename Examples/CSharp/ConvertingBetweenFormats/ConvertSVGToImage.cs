using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.ConvertingBetweenFormats
{
    static class ConvertSVGToImage
    {
        public static void WithASingleLine()
        {
            //ExStart: WithASingleLine
            // Prepare an SVG code.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";

            // Invoke the ConvertSVG method to convert the SVG code to image.
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg), "output.jpg");
            //ExEnd: WithASingleLine
        }

        public static void ConvertSVGToJPG()
        {
            //ExStart: ConvertSVGToJPG
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Convert HTML to JPG
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.jpg");
            }
            //ExEnd: ConvertSVGToJPG
        }

        public static void ConvertSVGToPNG()
        {
            //ExStart: ConvertSVGToPNG
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                // Convert HTML to PNG
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.png");
            }
            //ExEnd: ConvertSVGToPNG
        }

        public static void ConvertSVGToBMP()
        {
            //ExStart: ConvertSVGToBMP
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Convert HTML to BMP
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.bmp");
            }
            //ExEnd: ConvertSVGToBMP
        }

        public static void ConvertSVGToGIF()
        {
            //ExStart: ConvertSVGToGIF
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                // Convert HTML to GIF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.gif");
            }
            //ExEnd: ConvertSVGToGIF
        }

        public static void ConvertSVGToTIFF()
        {
            //ExStart: ConvertSVGToTIFF
            // Prepare an SVG code and save it to the file.
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Initialize an SVG document from the svg file.
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("document.svg"))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

                // Convert HTML to TIFF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "output.tiff");
            }
            //ExEnd: ConvertSVGToTIFF
        }

        public static void SpecifyImageSaveOptions()
        {
            //ExStart: SpecifyImageSaveOptions
            // Prepare an SVG code and save it to the file
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";
            System.IO.File.WriteAllText("document.svg", code);

            // Set up the page-size to 3000x1000 pixels and change the background color.
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg)
            {
                PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page()
                    {
                        Size = new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromPixels(3000), Aspose.Html.Drawing.Length.FromPixels(1000))
                    }
                },
                BackgroundColor = System.Drawing.Color.AliceBlue,
            };
            // Call the ConvertSVG to convert 'document.html' into jpeg image
            Aspose.Html.Converters.Converter.ConvertSVG("document.svg", options, "output.jpg");
            //ExEnd: SpecifyImageSaveOptions
        }

        public static void SpecifyCustomStreamProvider()
        {
            //ExStart: SpecifyCustomStreamProvider
            // Prepare an SVG code and save it to the file
            var code = "<svg xmlns='http://www.w3.org/2000/svg'>" +
                       "<circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' />" +
                       "</svg>";

            // Create an instance of MemoryStreamProvider
            using (var streamProvider = new MemoryStreamProvider())
            {
                // Initialize the SVG document
                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(code, "."))
                {
                    // Convert SVG to Image by using the MemoryStreamProvider
                    Aspose.Html.Converters.Converter.ConvertSVG(document, new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg), streamProvider);

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
