using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Xps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithRenderers
{
    public class RenderMultipleDocuments
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: green; }</style><p>my first paragraph</p>", @"c:\work\"))
            using (var document2 = new Aspose.Html.HTMLDocument("<style>p { color: blue; }</style><p>my first paragraph</p>", @"c:\work\"))
            {
                using (HtmlRenderer renderer = new HtmlRenderer())
                using (XpsDevice device = new XpsDevice(dataDir + @"document_out.xps"))
                {
                    renderer.Render(device, document, document2);
                }
            }
            // ExEnd:1
        }
    }
}
