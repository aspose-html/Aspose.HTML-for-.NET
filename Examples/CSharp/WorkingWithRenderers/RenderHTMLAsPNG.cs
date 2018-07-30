using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithRenderers
{
    public class RenderHTMLAsPNG
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: green; }</style><p>my first paragraph</p>", @"c:\work\"))
            {
                using (HtmlRenderer renderer = new HtmlRenderer())
                using (ImageDevice device = new ImageDevice(dataDir + @"document_out.png"))
                {
                    renderer.Render(device, document);
                }
            }
            // ExEnd:1
        }
    }
}
