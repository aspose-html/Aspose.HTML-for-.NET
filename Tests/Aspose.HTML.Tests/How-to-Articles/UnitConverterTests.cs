using Aspose.Html.Drawing;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.How_to_Articles
{
    public class UnitConverterTests : TestsBase
    {
        public UnitConverterTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("saving");
        }


        [Fact(DisplayName = "Convert CSS Units - px to cm")]
        public void ConvertPxToCmTest()
        {
            // @START_SNIPPET ConvertPxToCm.cs
            // Convert pixels to centimeters using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/

            // Define the number of pixels to convert
            var px = Unit.FromPixels(1000);

            // Convert pixels to centimeters
            var cm = px.GetValue(UnitType.Cm);

            // Output the result
            Output.WriteLine(cm.ToString("F2"));
            // @END_SNIPPET ConvertPxToCm.cs
        }


        [Fact(DisplayName = "Convert CSS Units - cm to px")]
        public void ConvertCmToPxTest()
        {
            // @START_SNIPPET ConvertCmToPx.cs
            // Convert centimeters to pixels using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/            

            var cm = Unit.FromCentimeters(100);
            var px = cm.GetValue(UnitType.Px);
            Output.WriteLine(px.ToString("F2"));            
            // @END_SNIPPET ConvertCmToPx.cs
        }


        [Fact(DisplayName = "Convert CSS Units - in to px")]
        public void ConvertInToPxTest()
        {
            // @START_SNIPPET ConvertInToPx.cs
            // Convert inches to pixels using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/ 

            var inch = Unit.FromInches(100);
            var px = inch.GetValue(UnitType.Px);
            Output.WriteLine(px.ToString("F2"));            
            // @END_SNIPPET ConvertInToPx.cs
        }


        [Fact(DisplayName = "Convert CSS Units - px to in")]
        public void ConvertPxToInTest()
        {
            // @START_SNIPPET ConvertPxToIn.cs
            // Convert pixels to inches using C#
            // Learn more: https://docs.aspose.com/html/net/how-to-articles/

            // Define the number of pixels to convert
            var px = Unit.FromPixels(800);

            // Convert pixels to inches
            var inch = px.GetValue(UnitType.In);

            // Print the converted value with two decimal places
            Output.WriteLine(inch.ToString("F2"));
            // @END_SNIPPET ConvertPxToIn.cs
        }
    }
}
