using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithRenderers
{
    public class RenderEPUBAsXPS
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var fs = File.OpenRead(dataDir + "document.epub"))
            using (var device = new Aspose.Html.Rendering.Xps.XpsDevice(dataDir + "document_out.xps"))
            using (var renderer = new Aspose.Html.Rendering.EpubRenderer())
            {
                renderer.Render(device, fs);
            }
            // ExEnd:1
        }
    }
}
