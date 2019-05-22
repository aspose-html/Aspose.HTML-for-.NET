using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class HTMLtoTIFF
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source HTML document  
            HTMLDocument htmlDocument = new HTMLDocument(dataDir + "input.html");
            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            // Output file path 
            string outputFile = dataDir + "HTMLtoPNG_Output.tif";
            // Convert HTML to TIFF
            Converter.ConvertHTML(htmlDocument, options, outputFile);
            // ExEnd:1                    
        }
    }
}
