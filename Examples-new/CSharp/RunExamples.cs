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
            CreatingDocumentExample.CreateEmptyDocument();
            CreatingDocumentExample.CreateDocumentWithText();
            CreatingDocumentExample.LoadHtmlDocumentFromExistingFile();
            CreatingDocumentExample.LoadHtmlDocumentFromFile();
            CreatingDocumentExample.LoadHtmlDocumentFromStream();
            CreatingDocumentExample.LoadHtmlDocumentFromUrl();
            CreatingDocumentExample.LoadSvgDocumentFromString();
            CreatingDocumentExample.UsingAsynchronousOperations();
            CreatingDocumentExample.HTMLDocumentAsynchronouslyOnLoad();
            CreatingDocumentExample.CreateDocumentFromScratch();
            CreatingDocumentExample.CreateDocumentFromContentString();

            // HTML to PDF conversion examples
            HtmlToPdfExample.ConvertHtmlStringToPdf();
            HtmlToPdfExample.ConvertHtmlFileToPdf();

            // Web scraping example
            WebScrapingExample.DownloadWebPage();

            Console.WriteLine("All examples executed.");
            Console.WriteLine("Press any key to exit...");
            //Console.ReadKey(); // disabled for non-interactive
        }
    }
}