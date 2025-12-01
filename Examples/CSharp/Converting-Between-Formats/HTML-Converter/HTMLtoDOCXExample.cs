using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Aspose.Html.Examples
{
    public class HTMLtoDOCXExample : BaseExample
    {
        public HTMLtoDOCXExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-converter/html-to-docx");
        }

        // Convert HTML to DOCX with a single line
        public void ConvertHtmlToDocxWithSingleLine()
        {
            // Convert HTML to DOCX in C#
            Converter.ConvertHTML(@"<h1>Convert HTML to DOCX!</h1>", ".", new DocSaveOptions(), Path.Combine(OutputDir, "convert-with-single-line.docx"));
        }

        // Convert HTML to DOCX from a file
        public void ConvertHtmlToDocx()
        {
            // Convert HTML to DOCX using C#
            string documentPath = Path.Combine(DataDir, "canvas.html");
            string savePath = Path.Combine(OutputDir, "canvas-output.docx");
            using HTMLDocument document = new HTMLDocument(documentPath);
            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to DOCX with custom page size and margins
        public void ConvertHtmlToDocxWithDocSaveOptions()
        {
            // Convert HTML to DOCX in C# with custom page size and margins
            string documentPath = Path.Combine(DataDir, "canvas.html");
            string savePath = Path.Combine(OutputDir, "canvas-output-options.docx");
            using HTMLDocument document = new HTMLDocument(documentPath);
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(600, 400), new Margin(10, 10, 10, 10));
            Converter.ConvertHTML(document, options, savePath);
        }

        // Specify DocSaveOptions with custom page size
        public void SpecifyDocSaveOptions()
        {
            // Convert HTML to DOCX in C# with custom settings
            string documentPath = Path.Combine(OutputDir, "save-options.html");
            string savePath = Path.Combine(OutputDir, "save-options-output.docx");
            string code = "<h1>DocSaveOptions Class</h1>\r\n" +
                          "<p>Using DocSaveOptions Class, you can programmatically apply a wide range of conversion parameters.</p>\r\n";
            File.WriteAllText(documentPath, code);
            using HTMLDocument document = new HTMLDocument(documentPath);
            DocSaveOptions options = new DocSaveOptions();
            options.PageSetup.AnyPage = new Page(new Aspose.Html.Drawing.Size(Length.FromInches(8.3f), Length.FromInches(5.8f)));
            Converter.ConvertHTML(document, options, savePath);
        }

        // Convert HTML to DOCX using a custom memory‑stream provider
        public void ConvertHtmlToDocxWithCustomStreamProvider()
        {
            // Convert HTML to DOCX in C# using memory stream
            using MemoryStreamProvider streamProvider = new MemoryStreamProvider();
            using HTMLDocument document = new HTMLDocument(@"<h1>Convert HTML to DOCX File Format!</h1>", ".");
            Converter.ConvertHTML(document, new DocSaveOptions(), streamProvider);
            MemoryStream memory = streamProvider.Streams.First();
            memory.Seek(0, SeekOrigin.Begin);
            using (FileStream fs = File.Create(Path.Combine(OutputDir, "stream-provider.docx")))
            {
                memory.CopyTo(fs);
            }
        }

        // Custom memory‑stream provider implementation
        private class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
        {
            public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

            public Stream GetStream(string name, string extension)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public Stream GetStream(string name, string extension, int page)
            {
                MemoryStream result = new MemoryStream();
                Streams.Add(result);
                return result;
            }

            public void ReleaseStream(Stream stream) { }

            public void Dispose()
            {
                foreach (MemoryStream stream in Streams)
                    stream.Dispose();
            }
        }
    }
}