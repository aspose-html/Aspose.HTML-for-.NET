using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
namespace Aspose.Html.Examples.CSharp.Conversion
{
    public class SVGtoImage
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory
            string dataDir = RunExamples.GetDataDir_Data();
            // Source SVG document  
            SVGDocument svgDocument = new SVGDocument(dataDir + "input.svg");
            // Initialize ImageSaveOptions 
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Output file path 
            string outputFile = dataDir + "SVGtoImage_Output.jpeg";
            // Convert SVG to Image
            Converter.ConvertSVG(svgDocument, options, outputFile);
            // ExEnd:1           
        }
    }
}
