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
using Aspose.Html.Examples.CSharp.WorkingWithMutationObserver;
using Aspose.Html.Examples.CSharp.WorkingWithTemplateMerger;
using Aspose.Html.Examples.CSharp.WorkingWithICreateStreamProvider;

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

            #region Document
            //// =====================================================            
            //CreateSimpleDocument.Run();
            //LoadHtmlDoc.Run();
            //LoadHTMLdocAsyn.EventNavigate();
            //LoadHTMLdocAsyn.Run();
            //LoadHtmlDocWithCredentials.Run();
            //LoadHtmlUsingRemoteServer.Run();
            //LoadHtmlUsingURL.Run();
            //ManipulateCanvas.Run();
            //ReadInnerHtml.Run();
            #endregion

            #region Conversions
            //AdjustPdfPageSize.Run();
            //AdjustXPSPageSize.Run();
            //CanvasToPDF.Run();
            //EPUBtoImage.Run();
            //EPUBtoPDF.Run();
            //EPUBtoXPS.Run();
            //HTMLtoBMP.Run();
            //HTMLtoGIF.Run();
            //HTMLtoJPEG.Run();
            //HTMLtoMarkdown.Run();
            //HTMLtoMHTML.Run();
            //HTMLtoPDF.Run();
            //HTMLtoPNG.Run();
            //HTMLtoTIFF.Run();
            //HTMLtoXPS.Run();
            //MarkdownToHTML.Run();
            //MHTMLtoImage.Run();
            //MHTMLtoPDF.Run();
            //MHTMLtoXPS.Run();
            //SVGtoImage.Run();
            //SVGtoPDF.Run();
            //SVGtoXPS.Run();
            #endregion

            #region WorkingWithCSS
            //// ===================================================== 
            // UseExtendedContentProperty.Run();
            #endregion

            #region WorkingWithDevices
            //// ===================================================== 
            GenerateEncryptedPDFByPdfDevice.Run();
            GenerateJPGByImageDevice.Run();
            GeneratePNGByImageDevice.Run();
            GenerateXPSByXpsDevice.Run();
            #endregion

            #region WorkingWithRenderers
            //// ===================================================== 
            RenderEPUBAsXPS.Run();
            RenderHTMLAsPNG.Run();
            RenderingTimeout.IndefiniteTimeout();
            RenderingTimeout.Run();
            RenderMHTMLAsXPS.Run();
            RenderMultipleDocuments.Run();
            RenderSVGDocAsPNG.Run();
            #endregion

            #region QuickStart
            //// =====================================================            
            // ApplyMeteredLicense.Run();
            #endregion

            #region MutationObserver
            //// =====================================================            
            // MutationObserverExample.Run();
            #endregion

            #region Working with Template Merger
            //// =====================================================   
            // MergeHTMLWithXML.Run();
            // MergeHTMLWithJson.Run();
            #endregion

            #region Working with ICreateStream Provider 
            //// =====================================================
            // UseICreateStreamProvider.Run();
            #endregion

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