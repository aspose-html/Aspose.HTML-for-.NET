using Aspose.Html.Rendering.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithDevices
{
    public class GeneratePNGByImageDevice
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: green; }</style><p>my first paragraph</p>", @"c:\work\"))
            {
                using (ImageDevice device = new ImageDevice(dataDir + @"document_out.png"))
                {
                    document.RenderTo(device);
                }
            }
            // ExEnd:1
        }
    }
}
