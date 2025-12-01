using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Rendering.Image;

namespace Aspose.Html.Examples
{
    /// <summary>
    /// Examples for working with HTML templates – populate from XML or JSON data sources
    /// </summary>
    public class HTMLTemplateExamples : BaseExample
    {
        public HTMLTemplateExamples()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("html-template");
        }

        /// <summary>
        /// Convert Template to HTML using a single line of code
        /// </summary>
        public void ConvertWithASingleLine()
        {
            // Convert template to HTML
            Converter.ConvertTemplate(
                Path.Combine(DataDir, "template.html"),
                new TemplateData(Path.Combine(DataDir, "data-source.json")),
                new TemplateLoadOptions(),
                Path.Combine(OutputDir, "template-with-single-line.html"));
        }

        /// <summary>
        /// Populate HTML template with external XML data and convert to HTML
        /// </summary>
        public void ConvertTemplate()
        {
            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "template.html");

            // Prepare a path to an XML template data file
            string templateDataPath = Path.Combine(DataDir, "templateData.xml");

            // Define TemplateData object instance
            TemplateData templateData = new TemplateData(templateDataPath);

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "result.html");

            // Define default TemplateLoadOptions object
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Initialize an HTML document as conversion source
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());

            // Convert template to HTML
            Converter.ConvertTemplate(document, templateData, options, resultPath);

            // Clear resources
            document.Dispose();
        }

        /// <summary>
        /// Convert another HTML template with XML data to HTML
        /// </summary>
        public void ConvertTemplate1()
        {
            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "html-template.html");

            // Prepare a path to an XML template data file
            string templateDataPath = Path.Combine(DataDir, "template-data.xml");

            // Define TemplateData object instance
            TemplateData templateData = new TemplateData(templateDataPath);

            // Prepare a path to the result file
            string resultPath = Path.Combine(OutputDir, "document.html");

            // Define default TemplateLoadOptions object
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Initialize an HTML document as conversion source
            HTMLDocument document = new HTMLDocument(sourcePath, new Configuration());

            // Convert template to HTML
            Converter.ConvertTemplate(document, templateData, options, resultPath);

            // Clear resources
            document.Dispose();
        }

        /// <summary>
        /// Populate an HTML template with structured JSON data on‑the‑fly
        /// </summary>
        public void ConvertHTMLTemplateOnTheFly()
        {
            // Prepare a path to JSON data source file
            string jsonPath = Path.Combine(OutputDir, "data-source.json");

            // Prepare a JSON data source and save it to the file
            string data = @"{
                ""FirstName"": ""John"",
                ""LastName"": ""Doe"",
                ""Address"": {
                    ""City"": ""Dallas"",
                    ""Street"": ""Austin rd."",
                    ""Number"": ""200""
                }
            }";
            File.WriteAllText(jsonPath, data);

            // Prepare a path to an HTML Template file
            string sourcePath = Path.Combine(OutputDir, "template.html");

            // Prepare an HTML Template and save it to the file
            string template = @"
                <table border=1>
                    <tr>
                        <th>Person</th>
                        <th>Address</th>
                    </tr>
                    <tr>
                        <td>{{FirstName}} {{LastName}}</td>
                        <td>{{Address.Street}} {{Address.Number}}, {{Address.City}}</td>
                    </tr>
                </table>
                ";
            File.WriteAllText(sourcePath, template);

            // Prepare a path to the output file (data‑filled template file)
            string outputPath = Path.Combine(OutputDir, "template-output.html");

            // Populate template with the JSON data source
            Converter.ConvertTemplate(sourcePath, new TemplateData(jsonPath), new TemplateLoadOptions(), outputPath);
        }

        /// <summary>
        /// Bind XML data to HTML template and export as HTML and PNG
        /// </summary>
        public void FillHTMLTemplate()
        {
            // Create a template with a string of HTML code
            string htmlCode = "<input type=\"checkbox\" disabled {{attr}} />";

            // Set data for the template in XML format
            string dataSource = "<Data><attr>checked</attr></Data>";

            // Convert template to HTML
            using (HTMLDocument htmlDocument = Converter.ConvertTemplate(
                htmlCode,
                string.Empty,
                new TemplateData(new TemplateContentOptions(dataSource, TemplateContent.XML)),
                new TemplateLoadOptions()))
            {
                // Request the input checkbox element that we specified in the template
                HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();

                // Output attribute information
                Console.WriteLine("Checked: " + input.Checked);
                Console.WriteLine("Attributes.Length: " + input.Attributes.Length);
                Console.WriteLine("Attributes[0].Name: " + input.Attributes[0].Name);
                Console.WriteLine("Attributes[1].Name: " + input.Attributes[1].Name);
                Console.WriteLine("Attributes[2].Name: " + input.Attributes[2].Name);

                // Save the HTML document to a file
                htmlDocument.Save(Path.Combine(OutputDir, "out-checked.html"));

                // Prepare a path to the output image file
                string outputPath = Path.Combine(OutputDir, "out-checked.png");

                // Convert HTML to PNG using RenderTo() method
                htmlDocument.RenderTo(new ImageDevice(new ImageRenderingOptions(), outputPath));
            }
        }

        /// <summary>
        /// Populate HTML template with XML data using attribute control – unchecked example
        /// </summary>
        public void UncheckedTemplate()
        {
            // Create a template with a string of HTML code
            string htmlCode = "<input type=\"checkbox\" disabled {{attr}} />";

            // Create an empty data source that won't set an attribute
            string dataSource = "<Data><attr></attr></Data>";

            // Convert template to HTML
            using (HTMLDocument htmlDocument = Converter.ConvertTemplate(
                htmlCode,
                string.Empty,
                new TemplateData(new TemplateContentOptions(dataSource, TemplateContent.XML)),
                new TemplateLoadOptions()))
            {
                // Request the input checkbox element that we specified in the template
                HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();

                // Output attribute information
                Console.WriteLine("Checked: " + input.Checked);
                Console.WriteLine("Attributes.Length: " + input.Attributes.Length);
                Console.WriteLine("Attributes[0].Name: " + input.Attributes[0].Name);
                Console.WriteLine("Attributes[1].Name: " + input.Attributes[1].Name);

                // Save the HTML document to a file
                htmlDocument.Save(Path.Combine(OutputDir, "out-unchecked.html"));

                // Prepare a path to the output file
                string outputPath = Path.Combine(OutputDir, "out-unchecked.png");

                // Convert HTML to PNG
                htmlDocument.RenderTo(new ImageDevice(new ImageRenderingOptions(), outputPath));
            }
        }
    }
}