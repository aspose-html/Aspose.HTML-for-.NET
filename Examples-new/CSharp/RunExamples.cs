using System;

namespace Aspose.Html.Examples
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Running custom examples from Examples-new...");
            Console.WriteLine("--------------------------------------------------");

            // Document creation examples
            var creatingDoc = new CreatingDocumentExample();
            creatingDoc.CreateEmptyDocument();
            creatingDoc.CreateDocumentWithText();
            creatingDoc.LoadHtmlDocumentFromExistingFile();
            creatingDoc.LoadHtmlDocumentFromFile();
            creatingDoc.LoadHtmlDocumentFromStream();
            creatingDoc.LoadHtmlDocumentFromUrl();
            creatingDoc.LoadSvgDocumentFromString();
            creatingDoc.UsingAsynchronousOperations();
            creatingDoc.HTMLDocumentAsynchronouslyOnLoad();
            creatingDoc.CreateDocumentFromScratch();
            creatingDoc.CreateDocumentFromContentString();

            // HTML to PDF conversion examples
            var htmlToPdf = new HtmlToPdfExample();
            htmlToPdf.ConvertHtmlStringToPdf();
            htmlToPdf.ConvertHtmlFileToPdf();

            // Web scraping examples
            var downloadFile = new DownloadFileFromWebsiteExample();
            downloadFile.DownloadFile();
            
            var downloadImages = new DownloadImagesExample();
            downloadImages.ExtractImages();
            downloadImages.ExtractIcons();

            var downloadSvg = new DownloadSvgFromWebsiteExample();
            downloadSvg.ExtractInlineSvg();
            downloadSvg.ExtractExternalSvg();

            var downloadWebsite = new DownloadWebsiteExample();
            downloadWebsite.SaveWebpageDefault();
            downloadWebsite.DownloadWebsite();
            downloadWebsite.DownloadSiteUsingMaxHandlingDepth();
            downloadWebsite.SaveWebsiteUsingPageUrlRestriction();

            var extractTable = new ExtractHtmlTableExample();
            extractTable.ExtractDataFromTable();
            
            var htmlNav = new HtmlNavigationExample();
            htmlNav.NavigateThroughHTML();
            htmlNav.InspectHtmlDocument();
            htmlNav.NodeFilterUsage();
            htmlNav.XPathQueryUsage();
            htmlNav.CssSelectorUsage();

            // Working with HTML Documents examples
            var editingDoc = new EditingDocumentExample();
            editingDoc.EditDocumentTree();
            editingDoc.UsingDomAndRenderToPdf();
            editingDoc.UsingOuterHtml();
            editingDoc.UsingInnerAndOuterHtml();
            editingDoc.EditInlineCss();
            editingDoc.EditInternalCss();
            editingDoc.ExternalCss();
            editingDoc.EditExternalCss();

            var envConfig = new EnvironmentConfigurationExample();
            envConfig.Sandboxing();
            envConfig.BlockScriptExecution();
            envConfig.DisableImageLoading();
            envConfig.UserAgentServiceStyleSheet();
            envConfig.UserAgentServiceCharacterSet();
            envConfig.UserAgentServiceFontSetting();
            envConfig.RuntimeServiceTest();
            envConfig.NetworkServiceTest();

            var managingImages = new ManagingImagesExample();
            managingImages.AddImage();
            managingImages.AddImageBase64();

            var managingTables = new ManagingTablesExample();
            managingTables.AddTableToHTML();
            managingTables.EditHtmlTable();
            managingTables.ExtractTablesFromHtml();
            managingTables.ExtractTablesFromWebsite();
            managingTables.ExtractTablesFromWebsiteWithCheck();
            managingTables.ExtractDataFromTables();
            managingTables.ExtractDataFromTablesToFile();
            managingTables.RemoveTable();
            managingTables.RemoveTableCheck();
            managingTables.RemoveAllTables();
            managingTables.EditHTMLTable();

            var saveSvg = new SaveSvgExample();
            saveSvg.SaveSvg();
            saveSvg.NewMemorySave();
            saveSvg.NewZipSave();
            saveSvg.NewStorageSave();

            var savingDoc = new SavingDocumentExample();
            savingDoc.SaveHtmlToFile();
            savingDoc.SaveHtmlWithLinkedFile();
            savingDoc.SaveHtmlWithResourcesToZip();
            savingDoc.SaveHtmlToMemory();
            savingDoc.SaveHtmlToMHTML();
            savingDoc.SaveHtmlToMD();
            savingDoc.SaveHtmlToSVG();

            // Advanced programming examples
            var cssExt = new CSSExtensionsExample();
            cssExt.CSSExtensions();

            var html5Canvas = new EditHTML5CanvasExample();
            html5Canvas.ConvertHtml5CanvasToPdf();
            html5Canvas.CanvasRenderingContext2D();
            html5Canvas.RadialGradient();
            html5Canvas.RectangleExample();

            var htmlForm = new HTMLFormEditorExample();
            htmlForm.FillAndSubmitForm();

            var mutationObs = new MutationObserverExample();
            mutationObs.MutationObserver();

            var outputStreams = new OutputStreamsExample();
            outputStreams.SpecifyCustomStreamProvider();
            outputStreams.SpecifyCustomStreamProviderMultiple();
            outputStreams.CustomStreamProvider();
            Console.WriteLine("All examples executed.");
            Console.WriteLine("Press any key to exit...");
            //Console.ReadKey(); // disabled for non-interactive
        }
    }
}