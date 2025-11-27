using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats
{
    public class FlattenPDFTests : TestsBase
    {
        public FlattenPDFTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-converter");
        }


        [Fact(DisplayName = "Convert HTML to PDF and Flatten PDF")]
        public void ConvertHTMLToPDFAndFlattenPDFTest()
        {
            // @START_SNIPPET ConvertHtmlToPdfAndFlattenPdf.cs
            // Flatten PDF during HTML to PDF conversion using C#
            // Learn more: https://docs.aspose.com/html/net/flatten-pdf/

            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "SampleHtmlForm.html");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(sourcePath);

            // Prepare PDF save options
            PdfSaveOptions options = new PdfSaveOptions
            {
                // Flatten all form fields
                FormFieldBehaviour = FormFieldBehaviour.Flattened
            };

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "form-flattened.pdf");

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, resultPath);

            // @END_SNIPPET
            Assert.True(File.Exists(resultPath));
        }


        [Fact(DisplayName = "Convert MHTML to PDF and Flatten PDF")]
        public void ConvertMHTMLToPDFAndFlattenPDFTest()
        {
            // @START_SNIPPET ConvertMHtmlToPdfAndFlattenPdf.cs
            // Flatten PDF during MHTML to PDF conversion using C#
            // Learn more: https://docs.aspose.com/html/net/flatten-pdf/

            // Prepare a path to an MHTML source file
            string sourcePath = Path.Combine(DataDir, "SampleHtmlForm.mhtml");

            // Initialize PDF save options
            PdfSaveOptions options = new PdfSaveOptions
            {
                // Flatten all form fields
                FormFieldBehaviour = FormFieldBehaviour.Flattened
            };

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "document-flattened.pdf");

            // Convert MHTML to PDF
            Converter.ConvertMHTML(sourcePath, options, resultPath);

            // @END_SNIPPET
            Assert.True(File.Exists(resultPath));
        }
    }
}
