using System;

namespace Aspose.Html.Examples
{
    class RunExamples
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Running custom examples from Examples...");
            Console.WriteLine("--------------------------------------------------");
            /*
            // Document creation examples
            */
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
            envConfig.RuntimeService();
            envConfig.NetworkService();

            var managingImages = new ManagingImagesExample();
            managingImages.AddImage();
            managingImages.AddImageToHtml();
            managingImages.ResizeImage();
            managingImages.ExtractImageUrl();
            managingImages.Extract(); // Download all images referenced in a local HTML file
            managingImages.ExtractImageFromWebsite(); // Download all images from a web page
            managingImages.RemoveImage();
            managingImages.RemoveImageWithCheck();
            managingImages.RemoveAllImages();

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
            
            // Converting Between Formats examples

            // Flatten PDF examples
            var flattenPdf = new FlattenPDFExample();
            flattenPdf.ConvertHtmlToPdfAndFlattenPdf();
            flattenPdf.ConvertMhtmlToPdfAndFlattenPdf();

            // EPUB converters
            var epubToBmp = new EPUBtoBMPExample();
            epubToBmp.ConvertEPUBByTwoLines();
            epubToBmp.ConvertEPUBToBmp();
            epubToBmp.ConvertEPUBToBmpWithImageSaveOptions();

            var epubToDocx = new EPUBtoDOCXExample();
            epubToDocx.ConvertEpubToDocxWithTwoLines();
            epubToDocx.ConvertEpubToDocx();
            epubToDocx.ConvertEpubToDocxFromPath();
            epubToDocx.ConvertEpubToDocxWithOptions();
            epubToDocx.ConvertEpubToDocxWithCustomStreamProvider();

            var epubToGif = new EPUBtoGIFExample();
            epubToGif.ConvertEPUBByTwoLines();
            epubToGif.ConvertEPUBToGif();
            epubToGif.ConvertEPUBToGifWithImageSaveOptions();

            var epubToJpg = new EPUBtoJPGExample();
            epubToJpg.ConvertEPUBByTwoLines();
            epubToJpg.ConvertEPUBToJpg();
            epubToJpg.ConvertEPUBToJpgWithImageSaveOptions();
            epubToJpg.ConvertEPUBToJpgWithCustomStreamProvider();

            var epubToPdf = new EPUBtoPDFExample();
            epubToPdf.ConvertEpubToPdfWithTwoLines();
            epubToPdf.ConvertEpubToPdf();
            epubToPdf.ConvertEpubToPdfFromPath();
            epubToPdf.ConvertEpubToPdfWithOptions();
            epubToPdf.ConvertEpubToPdfWithCustomStreamProvider();

            var epubToPng = new EPUBtoPNGExample();
            epubToPng.ConvertEpubToPngWithSingleLine();
            epubToPng.ConvertEpubToPngWithOptions();
            epubToPng.ConvertEpubToPngWithCustomStreamProvider();

            var epubToXps = new EPUBtoXPSExample();
            epubToXps.ConvertEPUBToXps();
            epubToXps.ConvertEPUBToXpsWithTwoLines();
            epubToXps.ConvertEPUBToXpsWithXpsSaveOptions();
            epubToXps.ConvertEPUBToXpsWithCustomStreamProvider();

            // HTML converters
            var htmlToBmp = new HTMLtoBMPExample();
            htmlToBmp.ConvertHtmlToBmpWithImageSaveOptions();
            htmlToBmp.ConvertHtmlToBmp();

            var htmlToDocx = new HTMLtoDOCXExample();
            htmlToDocx.ConvertHtmlToDocxWithSingleLine();
            htmlToDocx.ConvertHtmlToDocx();

            var htmlToGif = new HTMLtoGIFExample();
            htmlToGif.ConvertHtmlToGifWithImageSaveOptions();
            htmlToGif.ConvertHtmlToGif();

            var htmlToJpg = new HTMLtoJPGExample();
            htmlToJpg.ConvertHtmlToJpgWithSingleLine();
            htmlToJpg.ConvertHtmlToJpg();

            var htmlToMhtml = new HTMLtoMHTMLExample();
            htmlToMhtml.ConvertHtmlToMhtmlWithSingleLine();
            htmlToMhtml.ConvertHtmlToMhtml();

            var htmlToMd = new HTMLtoMDExample();
            htmlToMd.ConvertHtmlToMarkdown();
            htmlToMd.ConvertInlineHtmlToMarkdown();
            htmlToMd.ConvertHtmlToMarkdownWithOptions();

            var htmlToPdf = new HTMLtoPDFExample();
            htmlToPdf.ConvertHtmlToPdfWithSingleLine();
            htmlToPdf.ConvertHtmlToPdfFromFile();
            htmlToPdf.ConvertHtmlFromUrlToPdf();
            htmlToPdf.ConvertHtmlToPdfWithEncryption();
            htmlToPdf.ConvertHtmlToPdfWithSaveOptions();
            htmlToPdf.ConvertHtmlToPdfWithCustomPageSettings();
            htmlToPdf.SpecifyPdfSaveOptions();
            htmlToPdf.ConvertHtmlToPdfWithCustomStreamProvider();

            var htmlToPng = new HTMLtoPNGExample();
            htmlToPng.ConvertHtmlToPngWithSingleLine();
            htmlToPng.ConvertHtmlToPng();

            var htmlToTiff = new HTMLtoTIFFExample();
            htmlToTiff.ConvertHtmlToTiffWithImageSaveOptions();
            htmlToTiff.ConvertHtmlToTiff();

            var htmlToXps = new HTMLtoXPSExample();
            htmlToXps.ConvertHtmlToXpsWithSingleLine();
            htmlToXps.ConvertHtmlToXps();
            
            // MD converters
            var mdToBmp = new MDtoBMPExample();
            mdToBmp.ConvertMarkdownToBmp();
            mdToBmp.ConvertMarkdownToBmp();

            var mdToDocx = new MDtoDOCXExample();
            mdToDocx.ConvertMarkdownToDocx();
            mdToDocx.ConvertMarkdownToDocxWithOptions();

            var mdToGif = new MDtoGIFExample();
            mdToGif.ConvertMarkdownToGif();

            var mdToHtml = new MDtoHTMLExample();
            mdToHtml.ConvertMarkdownToHtml();
            mdToHtml.ConvertMarkdownFileToHtml();
            mdToHtml.ConvertMarkdownStringToHtml();

            var mdToJpg = new MDtoJPGExample();
            mdToJpg.ConvertMarkdownToJpg();
            mdToJpg.ConvertMarkdownToJpgWithOptions();

            var mdToPdf = new MDtoPDFExample();
            mdToPdf.ConvertMarkdownToPdf();
            mdToPdf.ConvertMarkdownToPdfWithOptions();

            var mdToPng = new MDtoPNGExample();
            mdToPng.ConvertMarkdownToPng(); 

            var mdToTiff = new MDtoTIFFExample();
            mdToTiff.ConvertMarkdownToTiff();

            var mdToXps = new MDtoXPSExample();
            mdToXps.ConvertMarkdownToXps();
            mdToXps.ConvertMarkdownToXpsWithOptions();
            
            // MHTML converters
            var mhtmlToDocx = new MHTMLtoDOCXExample();
            mhtmlToDocx.ConvertMhtmlToDocxWithTwoLines();
            mhtmlToDocx.ConvertMhtmlToDocx();
            mhtmlToDocx.ConvertMhtmlToDocxWithOptions();
            mhtmlToDocx.ConvertMhtmlToDocxWithStreamProvider();

            var mhtmlToImage = new MHTMLtoImageExample();
            mhtmlToImage.ConvertMhtmlToJpgWithTwoLines();
            mhtmlToImage.ConvertMhtmlToJpg();
            mhtmlToImage.ConvertMhtmlToPng();
            mhtmlToImage.ConvertMhtmlToGif();
            mhtmlToImage.ConvertMhtmlToBmp();
            mhtmlToImage.ConvertMhtmlToTiff();
            mhtmlToImage.ConvertMhtmlToJpgWithOptions();
            mhtmlToImage.ConvertMhtmlToJpgWithCustomStreamProvider();

            var mhtmlToPdf = new MHTMLtoPDFExample();
            mhtmlToPdf.ConvertMhtmlToPdfWithTwoLines();
            mhtmlToPdf.ConvertMhtmlToPdf();
            mhtmlToPdf.ConvertMhtmlToPdfWithOptions();
            mhtmlToPdf.ConvertMhtmlToPdfWithCustomStreamProvider();

            var mhtmlToXps = new MHTMLtoXPSExample();
            mhtmlToXps.ConvertMhtmlToXpsWithTwoLines();
            mhtmlToXps.ConvertMhtmlToXps();
            mhtmlToXps.ConvertMhtmlToXpsWithCustomStreamProvider();
            
            // SVG converters
            var svgToBmp = new SVGtoBMPExample();
            svgToBmp.ConvertSVGToBmpWithSingleLine();
            svgToBmp.ConvertSVGToBmp();

            var svgToDocx = new SVGtoDOCXExample();
            svgToDocx.ConvertSVGToDocxWithSingleLine();
            svgToDocx.ConvertSVGToDocx();

            var svgToGif = new SVGtoGIFExample();
            svgToGif.ConvertSVGToGifWithSingleLine();
            svgToGif.ConvertSVGToGif();

            var svgToJpg = new SVGtoJPGExample();
            svgToJpg.ConvertSVGToJpgWithSingleLine();
            svgToJpg.ConvertSVGToJpg();

            var svgToPdf = new SVGtoPDFExample();
            svgToPdf.ConvertSVGToPdfWithSingleLine();
            svgToPdf.ConvertSVGToPdf();
            svgToPdf.ConvertSVGToPdfWithPdfSaveOptions();
            svgToPdf.ConvertSVGToPdfWithCustomStreamProvider();

            var svgToPng = new SVGtoPNGExample();
            svgToPng.ConvertSVGToPngWithSingleLine();
            svgToPng.ConvertSVGToPng();

            // Fine‑tuning converters
            var renderers = new RenderersExample();
            renderers.ConvertHtmlToPdfWithRenderingOptions();
            renderers.MergeHtmlToPdf();
            renderers.MergeHtmlToPdfWithRenderingOptions();
            renderers.ConvertMhtmlToPdfWithRenderingOptions();
            renderers.ConvertMhtmlToImage();
            renderers.ConvertEpubToDocxWithRenderingOptions();
            renderers.ConvertEpubToPdfWithOption();
            renderers.MergeSvgToPdf();
            renderers.RenderSvgToPdf();
            renderers.SetTimeout();

            var renderingDevice = new RenderingDeviceExample();
            renderingDevice.RenderHtmlToPdf();
            renderingDevice.RenderHtmlToJpg();
            renderingDevice.RenderHtmlToDocx();
            renderingDevice.RenderHtmlToXps();

            var renderingOptions = new RenderingOptionsExample();
            
            renderingOptions.UseRenderingOptions();
            renderingOptions.UseGeneralOptions();
            renderingOptions.UseResolution();
            renderingOptions.UseBackgroundColor();
            renderingOptions.UsePageSetup();
            renderingOptions.UsePageSetupAdjustToWidestPage();
            renderingOptions.UsePdfRenderingOptions();
            renderingOptions.UseImageRenderingOptions();
            renderingOptions.UseXpsRenderingOptions();
            renderingOptions.UseDocRenderingOptions();

            // Working with HTML Templates examples
            var htmlTemplate = new HTMLTemplateExamples();
            htmlTemplate.ConvertWithASingleLine();
            htmlTemplate.ConvertTemplate();
            htmlTemplate.ConvertTemplate1();
            htmlTemplate.ConvertHTMLTemplateOnTheFly();
            htmlTemplate.FillHTMLTemplate();
            htmlTemplate.UncheckedTemplate();

            // How‑to Articles examples
            var howTo = new HowToArticlesExamples();
            howTo.RunAll();

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