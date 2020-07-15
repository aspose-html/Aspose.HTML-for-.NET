using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Html.Examples.CSharp.AdvancedUsage;
using Aspose.Html.Examples.CSharp.Document;
using Aspose.Html.Examples.CSharp.Conversion;
using Aspose.Html.Examples.CSharp.ConvertingBetweenFormats;
using Aspose.Html.Examples.CSharp.WorkingWithCSS;
using Aspose.Html.Examples.CSharp.WorkingWithDevices;
using Aspose.Html.Examples.CSharp.WorkingWithDocuments;
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

            #region EnvironmentConfiguration
            //EnvironmentConfiguration.DisableScriptsExecution();
            //EnvironmentConfiguration.SpecifyUserStyleSheet();
            //EnvironmentConfiguration.JavaScriptExecutionTimeout();
            //EnvironmentConfiguration.CustomMessageHandler();
            #endregion

            #region CreatingADocument
            //CreatingADocument.HTMLDocumentFromScratch();
            //CreatingADocument.HTMLDocumentFromFile();
            //CreatingADocument.HTMLDocumentFromURL();
            //CreatingADocument.HTMLDocumentFromString();
            //CreatingADocument.HTMLDocumentFromMemoryStream();
            //CreatingADocument.SVGDocumentFromString();
            //CreatingADocument.HTMLDocumentAsynchronouslyOnReadyStateChange();
            //CreatingADocument.HTMLDocumentAsynchronouslyOnLoad();
            #endregion

            #region EditingADocument
            //EditingADocument.UsingDOM();
            //EditingADocument.UsingInnerOuterHTML();
            //EditingADocument.EditCSS();
            #endregion

            #region SavingADocument
            //SavingADocument.HTMLToFile();
            //SavingADocument.HTMLWithoutLinkedFile();
            //SavingADocument.HTMLToMHTML();
            //SavingADocument.HTMLToMarkdown();
            //SavingADocument.SVGToFile();
            #endregion

            #region ConvertHTMLToImage
            //ConvertHTMLToImage.WithASingleLine();
            //ConvertHTMLToImage.ConvertHTMLToJPG();
            //ConvertHTMLToImage.ConvertHTMLToPNG();
            //ConvertHTMLToImage.ConvertHTMLToBMP();
            //ConvertHTMLToImage.ConvertHTMLToGIF();
            //ConvertHTMLToImage.ConvertHTMLToTIFF();
            //ConvertHTMLToImage.SpecifyImageSaveOptions();
            //ConvertHTMLToImage.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertHTMLToPDF
            //ConvertHTMLToPDF.WithASingleLine();
            //ConvertHTMLToPDF.ConvertHTMLDocumentToPDF();
            //ConvertHTMLToPDF.SpecifyPdfSaveOptions();
            //ConvertHTMLToPDF.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertHTMLToXPS
            //ConvertHTMLToXPS.WithASingleLine();
            //ConvertHTMLToXPS.ConvertHTMLDocumentToXPS();
            //ConvertHTMLToXPS.SpecifyXpsSaveOptions();
            //ConvertHTMLToXPS.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertHTMLToMarkdown
            //ConvertHTMLToMarkdown.WithASingleLine();
            //ConvertHTMLToMarkdown.SpecifyMarkdownSaveOptions();
            //ConvertHTMLToMarkdown.ConvertUsingGitSyntax();
            //ConvertHTMLToMarkdown.InlineHTML();
            #endregion

            #region ConvertHTMLToMHTML
            //ConvertHTMLToMHTML.WithASingleLine();
            //ConvertHTMLToMHTML.ConvertHTMLDocumentToMHTML();
            //ConvertHTMLToMHTML.SpecifyMHTMLSaveOptions();
            #endregion

            HTMLtoDOCandDOCX.Run();

            #region ConvertSVGToImage
            //ConvertSVGToImage.WithASingleLine();
            //ConvertSVGToImage.ConvertSVGToJPG();
            //ConvertSVGToImage.ConvertSVGToPNG();
            //ConvertSVGToImage.ConvertSVGToBMP();
            //ConvertSVGToImage.ConvertSVGToGIF();
            //ConvertSVGToImage.ConvertSVGToTIFF();
            //ConvertSVGToImage.SpecifyImageSaveOptions();
            //ConvertSVGToImage.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertSVGToPDF
            //ConvertSVGToPDF.WithASingleLine();
            //ConvertSVGToPDF.ConvertSVGDocumentToPDF();
            //ConvertSVGToPDF.SpecifyPdfSaveOptions();
            //ConvertSVGToPDF.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertSVGToXPS
            //ConvertSVGToXPS.WithASingleLine();
            //ConvertSVGToXPS.ConvertSVGDocumentToXPS();
            //ConvertSVGToXPS.SpecifyXpsSaveOptions();
            //ConvertSVGToXPS.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertEPUBToImage
            //ConvertEPUBToImage.WithASingleLine();
            //ConvertEPUBToImage.ConvertEPUBToJPG();
            //ConvertEPUBToImage.ConvertEPUBToPNG();
            //ConvertEPUBToImage.ConvertEPUBToBMP();
            //ConvertEPUBToImage.ConvertEPUBToGIF();
            //ConvertEPUBToImage.ConvertEPUBToTIFF();
            //ConvertEPUBToImage.SpecifyImageSaveOptions();
            //ConvertEPUBToImage.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertEPUBToPDF
            //ConvertEPUBToPDF.WithASingleLine();
            //ConvertEPUBToPDF.ConvertEPUBFileToPDF();
            //ConvertEPUBToPDF.SpecifyPdfSaveOptions();
            //ConvertEPUBToPDF.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertEPUBToXPS
            //ConvertEPUBToXPS.WithASingleLine();
            //ConvertEPUBToXPS.ConvertEPUBFileToXPS();
            //ConvertEPUBToXPS.SpecifyXpsSaveOptions();
            //ConvertEPUBToXPS.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertMHTMLToImage
            //ConvertMHTMLToImage.WithASingleLine();
            //ConvertMHTMLToImage.ConvertMHTMLToJPG();
            //ConvertMHTMLToImage.ConvertMHTMLToPNG();
            //ConvertMHTMLToImage.ConvertMHTMLToBMP();
            //ConvertMHTMLToImage.ConvertMHTMLToGIF();
            //ConvertMHTMLToImage.ConvertMHTMLToTIFF();
            //ConvertMHTMLToImage.SpecifyImageSaveOptions();
            //ConvertMHTMLToImage.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertMHTMLToPDF
            //ConvertMHTMLToPDF.WithASingleLine();
            //ConvertMHTMLToPDF.ConvertMHTMLFileToPDF();
            //ConvertMHTMLToPDF.SpecifyPdfSaveOptions();
            //ConvertMHTMLToPDF.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertMHTMLToXPS
            //ConvertMHTMLToXPS.WithASingleLine();
            //ConvertMHTMLToXPS.ConvertMHTMLFileToXPS();
            //ConvertMHTMLToXPS.SpecifyXpsSaveOptions();
            //ConvertMHTMLToXPS.SpecifyCustomStreamProvider();
            #endregion

            #region ConvertMarkdownToHTML
            //ConvertMarkdownToHTML.WithASingleLine();
            //ConvertMarkdownToHTML.ConvertMarkdownToPNG();
            #endregion

            #region HTMLTemplate
            //HTMLTemplate.CreateHTMLFromTemplate();
            #endregion

            #region FineTuningConverters
            //FineTuningConverters.SpecifyOutputDevice();
            //FineTuningConverters.SpecifyRenderingOptions();
            //FineTuningConverters.SpecifyResolution();
            //FineTuningConverters.SpecifyBackgroundColor();
            //FineTuningConverters.SpecifyLeftRightPageSize();
            //FineTuningConverters.AdjustPageSizeToContent();
            //FineTuningConverters.SpecifyPDFPermissions();
            //FineTuningConverters.SpecifyImageSpecificOptions();
            //FineTuningConverters.SpecifyXpsRenderingOptions();
            //FineTuningConverters.CombineMultipleHTMLToPDF();
            //FineTuningConverters.RendererTimeoutExample();
            #endregion

            #region WebScraping
            //WebScraping.WebScraping.NavigateThroughHTML();
            //WebScraping.WebScraping.NodeFilterUsageExample();
            //WebScraping.WebScraping.XPathQueryUsageExample();
            //WebScraping.WebScraping.CSSSelectorUsageExample();
            #endregion

            #region HTML5Canvas
            //HTML5Canvas.ManipulateUsingJavaScript();
            //HTML5Canvas.ManipulateUsingCode();
            #endregion

            #region OutputStreams
            //OutputStreams.StreamProviderUsageExample();
            #endregion

            #region DOMMutationObserver
            //DOMMutationObserver.ObserveHowNodesAreAdded();
            #endregion

            #region HTMLFormEditor
            //HTMLFormEditor.FillFormAndSubmitIt();
            #endregion

            #region CSSExtensions
            //CSSExtensions.AddTitleAndPageNumber();
            #endregion

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
            //GenerateEncryptedPDFByPdfDevice.Run();
            //GenerateJPGByImageDevice.Run();
            //GeneratePNGByImageDevice.Run();
            //GenerateXPSByXpsDevice.Run();
            #endregion

            #region WorkingWithRenderers
            //// ===================================================== 
            //RenderEPUBAsXPS.Run();
            //RenderHTMLAsPNG.Run();
            //RenderingTimeout.IndefiniteTimeout();
            //RenderingTimeout.Run();
            //RenderMHTMLAsXPS.Run();
            //RenderMultipleDocuments.Run();
            //RenderSVGDocAsPNG.Run();
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