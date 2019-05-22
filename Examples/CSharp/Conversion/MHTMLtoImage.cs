using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class MHTMLtoImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source MHTML document  
            FileStream fileStream = File.OpenRead(dataDir + "sample.mht");
            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Output file path 
            string outputFile = dataDir + "MHTMLtoImage.jpeg";
            // Convert SVG to Image
            Converter.ConvertMHTML(fileStream, options, outputFile);
            // ExEnd:1           
        }
    }
}
