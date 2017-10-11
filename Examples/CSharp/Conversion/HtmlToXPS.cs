using System.IO;
using System;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HtmlToXPS
    {
        public static void Run()
        {
            // ExStart:HtmlToXPS
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_Data();

            String InputHtml = dataDir + "FirstFile.html";
            using (FileStream fs = File.Create(InputHtml))
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
 
            // File name for resultant XPS file
            string Resultnat_output = dataDir + "simple-any-page_out.xps";
            // Create XpxRendering Options object
            Aspose.Html.Rendering.Xps.XpsRenderingOptions xps_options = new Aspose.Html.Rendering.Xps.XpsRenderingOptions();
            // The PageSetup also provides different properties i.e. FirstPage, LastPage, LeftPage, RightPage and they are used to setup (PageSize, Margin) for every page. 
            // In most cases, usage of setup any page is enough, but in some complicated cases, you may need to fine tune page settings. It can be done either by CSS styles or by using rendering options.
            // the size for drawing is in pixels
            xps_options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(200, 60));
            // Instantiate XPSDevice object while passing XPSRenderingOptions and resultant file path as arguments
            using (Aspose.Html.Rendering.Xps.XpsDevice device = new Aspose.Html.Rendering.Xps.XpsDevice(xps_options, Resultnat_output))
            // Create HtmlRenderer object
            using (Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer())
            // Create HtmlDocument instnace while passing path of already created HTML file
            using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(InputHtml))
            {
                // Render the output using HtmlRenderer
                renderer.Render(device, html_document);
            }
            // ExEnd:HtmlToXPS           
        }
    }
}