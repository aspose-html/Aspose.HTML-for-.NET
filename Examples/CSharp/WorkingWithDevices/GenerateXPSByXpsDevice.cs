using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Xps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithDevices
{
    public class GenerateXPSByXpsDevice
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: green; }</style><p>my first paragraph</p>", @"c:\work\"))
            {
                using (XpsDevice device = new XpsDevice(new XpsRenderingOptions()
                {
                    PageSetup =
                    {
                        AnyPage = new Page(new Size(500, 500), new Margin(50, 50, 50, 50))
                    }
                }, dataDir + @"document_out.xps"))
                {
                    document.RenderTo(device);
                }
            }
            // ExEnd:1
        }
    }
}
