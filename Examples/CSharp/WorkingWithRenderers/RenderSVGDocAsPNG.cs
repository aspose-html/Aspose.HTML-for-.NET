using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithRenderers
{
    public class RenderSVGDocAsPNG
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.Dom.Svg.SVGDocument("<svg xmlns='http://www.w3.org/2000/svg'><circle cx='50' cy='50' r='40'/></svg>", @"c:\work\"))
            {
                using (SvgRenderer renderer = new SvgRenderer())
                using (ImageDevice device = new ImageDevice(dataDir + @"document_out.png"))
                {
                    renderer.Render(device, document);
                }
            }
            // ExEnd:1
        }
    }
}
