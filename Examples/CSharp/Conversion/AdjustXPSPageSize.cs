using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class AdjustXPSPageSize
    {
        public static void Run()
        {
            // ExStart:AdjustXPSPageSize
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            // Set input file name.
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
                    <div id=id3 class=''st'' style='color: red;'>Aspose.Html rendering Text in Red Color</div>
                    ");
            }
  
            // Create HtmlRenderer object
            using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
            // Create HtmlDocument instnace while passing path of already created HTML file
            using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(SimpleStyledFilePath))
            {
                // Set the page size less than document min-width. The content in the resulting file will be cropped becuase of element with width: 200px
                Aspose.Html.Rendering.Xps.XpsRenderingOptions xps_options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions
                {
                    PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(100, 100)),
                    AdjustToWidestPage = false
                },
                };
                string output = dataDir + "not-adjusted-to-widest-page_out.xps";
                using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(xps_options, output))
                {
                    // Render the output
                    renderer.Render(device, html_document);
                }
  
  
                // Set the page size less than document min-width and enable AdjustToWidestPage option
                // The page size of the resulting file will be changed according to content width
                xps_options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions
                {
                    PageSetup =
                {
                    AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(100, 100)),
                    AdjustToWidestPage = true
                },
                };
                output = dataDir + "adjusted-to-widest-page_out.xps";
                using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(xps_options, output))
                {
                    // render the output
                    renderer.Render(device, html_document);
                }
            }
            // ExEnd:AdjustXPSPageSize           
        }
    }
}