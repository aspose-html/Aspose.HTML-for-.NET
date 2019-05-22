using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class EPUBtoImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source EPUB document  
            FileStream epubDocumentStream = File.OpenRead(dataDir + "input.epub");
            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Output file path 
            string outputFile = dataDir + "EPUBtoImageOutput.jpeg";
            // Convert SVG to Image
            Converter.ConvertEPUB(epubDocumentStream, options, outputFile);
            // ExEnd:1           
        }
    }
}
