using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class AdjustPdfPageSize
    {
        public static void Run()
        {
            // ExStart:AdjustPdfPageSize
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            String SimpleStyledFilePath = dataDir + "FirstFile.html";
           using (FileStream fs = File.Create(SimpleStyledFilePath))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(
                    @"<style>
                    .st
                    {
                    color: green;
                    }
                    </style>
                    <div id=id1>Aspose.Html rendering Text in Black Color</div>
                    <div id=id2 class=''st''>Aspose.Html rendering Text in Green Color</div>
                    <div id=id3 class=''st'' style='color: blue;'>Aspose.Html rendering Text in Blue Color</div>
                    <div id=id3 class=''st'' style='color: red;'><font face='Arial'>Aspose.Html rendering Text in Red Color</font></div>
                    ");
            } 
            
            string pdf_output;
            // Create HtmlRenderer object
            using (Aspose.Html.Rendering.HtmlRenderer pdf_renderer = new Aspose.Html.Rendering.HtmlRenderer())
            // Create HtmlDocument instnace while passing path of already created HTML file
            using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(SimpleStyledFilePath))
            {
                // Set the page size less than document min-width. The content in the resulting file will be cropped becuase of element with width: 200px
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdf_options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions
                {
                    PageSetup =
                    {
                        AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(100, 100)),
                        AdjustToWidestPage = false
                    },
                };
                pdf_output = dataDir + "not-adjusted-to-widest-page_out.pdf";
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdf_options, pdf_output))
                {
                    // Render the output
                    pdf_renderer.Render(device, html_document);
                }
 
                // Set the page size less than document min-width and enable AdjustToWidestPage option. The page size of the resulting file will be changed according to content width
                pdf_options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions
                {
                    PageSetup =
                    {
                        AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(100, 100)),
                        AdjustToWidestPage = true
                    },
                };
                pdf_output = dataDir +  "adjusted-to-widest-page_out.pdf";
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdf_options, pdf_output))
                {
                    // Render the output
                    pdf_renderer.Render(device, html_document);
                }
            }
            // ExEnd:AdjustPdfPageSize           
        }
    }
}