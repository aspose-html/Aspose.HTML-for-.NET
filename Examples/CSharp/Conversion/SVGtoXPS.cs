using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    class SVGtoXPS
    {
        public static void Run()
        {
            // ExStart:SVGtoXPS
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            // Simple SVG file
            File.WriteAllText( dataDir + "my.svg",
                "<svg xmlns=\"http://www.w3.org/2000/svg\" height=\"140\" width=\"500\">" +
                "<ellipse cx=\"200\" cy=\"80\" rx=\"100\" ry=\"50\" style=\"fill:yellow;stroke:purple;stroke-width:2\" />" +
                "</svg>");

            // Create the new SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument( dataDir + "my.svg");

            // Simple navigation and inspection the element properties
            Aspose.Html.Dom.Svg.SVGEllipseElement ellipse = (Aspose.Html.Dom.Svg.SVGEllipseElement)document.GetElementsByTagName("ellipse").First();
            Console.WriteLine(ellipse.Style.CSSText);  // fill: yellow; stroke: purple; stroke-width: 2;

            // Create the new SVG renderer & XPS device
            using (Aspose.Html.Rendering.SvgRenderer renderer = new Aspose.Html.Rendering.SvgRenderer())
            using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(dataDir + "my.xps"))
            {
                // Render to the output device
                renderer.Render(device, document);
            }
            // ExEnd:SVGtoXPS
        }
    }
}
