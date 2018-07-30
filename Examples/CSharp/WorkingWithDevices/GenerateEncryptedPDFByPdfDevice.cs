using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering.Pdf.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.WorkingWithDevices
{
    public class GenerateEncryptedPDFByPdfDevice
    {
        public static void Run()
        {
            // ExStart:1
            string dataDir = RunExamples.GetDataDir_Data();

            using (var document = new Aspose.Html.HTMLDocument("<style>p { color: green; }</style><p>my first paragraph</p>", @"c:\work\"))
            {
                var options = new PdfRenderingOptions()
                {
                    PageSetup =
                    {
                        AnyPage = new Page(new Size(500, 500), new Margin(50, 50, 50, 50))
                    },
                    Encryption = new PdfEncryptionInfo("user", "p@wd", PdfPermissions.PrintDocument, PdfEncryptionAlgorithm.RC4_128)
                };
                using (PdfDevice device = new PdfDevice(options, dataDir + @"document_out.pdf"))
                {
                    document.RenderTo(device);
                }
            }
            // ExEnd:1
        }
    }
}
