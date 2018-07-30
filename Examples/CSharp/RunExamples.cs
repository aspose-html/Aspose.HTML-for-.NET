using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Html.Examples.CSharp.Document;
using Aspose.Html.Examples.CSharp.Conversion;
using Aspose.Html.Examples.CSharp.WorkingWithCSS;
using Aspose.Html.Examples.CSharp.WorkingWithDevices;
using Aspose.Html.Examples.CSharp.WorkingWithRenderers;
//using Aspose.Html.Examples.CSharp.QuickStart;

namespace Aspose.Html.Examples.CSharp
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");
            // Uncomment the one you want to try out

            // =====================================================
            // =====================================================
            // Aspose.HTML 
            // =====================================================
            // =====================================================

            //// Document
            //// =====================================================            
            // LoadHtmlDoc.Run();
            // ReadInnerHtml.Run();
            // LoadHtmlUsingURL.Run();
            // LoadHtmlUsingRemoteServer.Run();
            // LoadHtmlDocWithCredentials.Run();
            // CreateSimpleDocument.Run();
            // ManipulateCanvas.Run();

            //// Conversion
            //// =====================================================            
            // HtmlToPdf.Run();
            // AdjustPdfPageSize.Run();
            // HtmlToXPS.Run();
            // AdjustXPSPageSize.Run();            
            // SVGtoXPS.Run();
            // HTMLtoPNG.Run();
            // HTMLtoTIFF.Run();
            // CanvasToPDF.Run();
            // HTMLtoMarkdown.Run();
            // HTMLtoMHTML.Run();

            //// WorkingWithCSS
            //// ===================================================== 
            // UseExtendedContentProperty.Run();

            //// WorkingWithDevices
            //// ===================================================== 
            // GeneratePNGByImageDevice.Run();
            // GenerateJPGByImageDevice.Run();
            // GenerateXPSByXpsDevice.Run();
            // GenerateEncryptedPDFByPdfDevice.Run();

            //// WorkingWithRenderers
            //// ===================================================== 
            // RenderHTMLAsPNG.Run();
            // RenderSVGDocAsPNG.Run();
            // RenderEPUBAsXPS.Run();
            // RenderMHTMLAsXPS.Run();
            // RenderMultipleDocuments.Run();

            //// QuickStart
            //// =====================================================            
            // ApplyMeteredLicense.Run();

            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }          
        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }   
    }
}