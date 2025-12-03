using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;
using System.IO;

namespace Aspose.Html.Examples
{
    public class FlattenPDFExample : BaseExample
    {
        public FlattenPDFExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("flatten-pdf");
        }

        // Convert HTML to PDF and flatten PDF
        public void ConvertHtmlToPdfAndFlattenPdf()
        {
            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "SampleHtmlForm.html");

            // Initialize an HTML document from the file
            using HTMLDocument document = new HTMLDocument(sourcePath);

            // Prepare PDF save options with flattening
            PdfSaveOptions options = new PdfSaveOptions
            {
                FormFieldBehaviour = FormFieldBehaviour.Flattened
            };

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "form-flattened.pdf");

            // Convert HTML to PDF
            Converter.ConvertHTML(document, options, resultPath);
        }

        // Convert MHTML to PDF and flatten PDF
        public void ConvertMhtmlToPdfAndFlattenPdf()
        {
            // Prepare a path to an MHTML source file
            string sourcePath = Path.Combine(DataDir, "SampleHtmlForm.mhtml");

            // Prepare PDF save options with flattening
            PdfSaveOptions options = new PdfSaveOptions
            {
                FormFieldBehaviour = FormFieldBehaviour.Flattened
            };

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "document-flattened.pdf");

            // Convert MHTML to PDF
            Converter.ConvertMHTML(sourcePath, options, resultPath);
        }
    }
}