using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Rendering.Image;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Aspose.HTML.Tests.Converting_Between_Formats
{
    public class HTMLTemplateTests : TestsBase
    {
        public HTMLTemplateTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("html-template");
        }


        [Fact(DisplayName = "Convert Template to HTML With a Single Line")]
        public void ConvertWithASingleLineTest()
        {
            // @START_SNIPPET ConvertTemplateToHtmlInOneLine.cs
            // Convert Template to HTML using C#
            // Learn more: https://docs.aspose.com/html/net/convert-template-to-html/

            // Convert template to HTML
            Converter.ConvertTemplate(
                Path.Combine(DataDir, "template.html"),
                new TemplateData(Path.Combine(DataDir, "data-source.json")),
                new TemplateLoadOptions(),
                Path.Combine(OutputDir, "template-with-single-line.html")
            );

            // @END_SNIPPET
            Assert.True(File.Exists(Path.Combine(OutputDir, "template-with-single-line.html")));
        }


        [Fact(DisplayName = "Convert Template to HTML")]
        public void ConvertTemplateTest()
        {
            // @START_SNIPPET ConvertTemplateToHtml.cs
            // Populate HTML template with external XML data using C#
            // Learn more: https://docs.aspose.com/html/net/convert-template-to-html/

            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "template.html");

            // Prepare a path to an xml template data file
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

            // @END_SNIPPET
            Assert.True(File.Exists(resultPath));
        }

        [Fact(DisplayName = "Convert Template1 to HTML")]
        public void ConvertTemplate1Test()
        {
            // Prepare a path to an HTML source file
            string sourcePath = Path.Combine(DataDir, "html-template.html");

            // Prepare a path to an xml template data file
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

            Assert.True(File.Exists(resultPath));
        }


        
        [Fact(DisplayName = "Convert Template to HTML on-the-fly")]
        public void ConvertHTMLTemplateTest()
        {
            // @START_SNIPPET ConvertHtmlTemplateOnTheFly.cs
            // Populate an HTML template with structured JSON data using C#
            // Learn more: https://docs.aspose.com/html/net/convert-template-to-html/

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

            // Prepare a path to the output file (data-filled template file)
            string outputPath = Path.Combine(OutputDir, "template-output.html");

            // Invoke Converter.ConvertTemplate() method in order to populate "template.html" with the data source from "data-source.json" file
            Converter.ConvertTemplate(sourcePath, new TemplateData(jsonPath), new TemplateLoadOptions(), outputPath);

            // @END_SNIPPET
            Assert.True(File.Exists(outputPath));
        }


        [Fact(DisplayName = "Fill HTML Template")]
        public void FillHTMLTemplateTest()
        {
            // @START_SNIPPET FillHtmlTemplate.cs
            // Bind XML data to HTML template and export as HTML and PNG using C#
            // Learn more: https://docs.aspose.com/html/net/setting-attributes-in-html-template/

            // Create a template with a string of HTML code
            string htmlCode = "<input type=\"checkbox\" disabled {{attr}} />";

            // Set data for the template in XML format
            string dataSource = "<Data><attr>checked</attr></Data>";

            // Convert template to HTML
            using (HTMLDocument htmlDocument = Converter.ConvertTemplate(htmlCode, string.Empty,
                       new TemplateData(new TemplateContentOptions(dataSource, TemplateContent.XML)),
                       new TemplateLoadOptions()))
            {
                // Request the input checkbox element that we specified in the template
                HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();

                // Check if it has a checkmark 
                Output.WriteLine("Checked: " + input.Checked);
                Output.WriteLine("Attributes.Length: " + input.Attributes.Length);
                Output.WriteLine("Attributes[0].Name: " + input.Attributes[0].Name);
                Output.WriteLine("Attributes[1].Name: " + input.Attributes[1].Name);
                Output.WriteLine("Attributes[2].Name: " + input.Attributes[2].Name);

                /*
                This example produces the following results:

                Checked: True
                Attributes.Length: 3
                Attributes[0].Name: type
                Attributes[1].Name: disabled
                Attributes[2].Name: checked
                */

                // Save the HTML document to a file
                htmlDocument.Save(Path.Combine(OutputDir, "out-checked.html"));

                // Prepare a path to the output image file
                string outputPath = Path.Combine(OutputDir, "out-checked.png"); 
                
                // Convert HTML to PNG using RenderTo() method
                htmlDocument.RenderTo(new ImageDevice(new ImageRenderingOptions(), outputPath));
                
                Assert.True(File.Exists(Path.Combine(OutputDir, "out-checked.html")));
            }
            // @END_SNIPPET
        }


        [Fact(DisplayName = "Fill HTML Template Using Attribute Control")]
        public void UncheckedTemplateTest()
        {
            // @START_SNIPPET PopulateHtmlTemplateUsingAttributeControl.cs
            // Populate HTML template with XML data using attribute control in C#
            // Learn more: https://docs.aspose.com/html/net/setting-attributes-in-html-template/

            // Create a template with a string of HTML code
            string htmlCode = "<input type=\"checkbox\" disabled {{attr}} />";

            // Create an empty data source that won't set an attribute
            string dataSource = "<Data><attr></attr></Data>";

            // Convert template to HTML
            using (HTMLDocument htmlDocument = Converter.ConvertTemplate(htmlCode, string.Empty,
                       new TemplateData(new TemplateContentOptions(dataSource, TemplateContent.XML)),
                       new TemplateLoadOptions()))
            {
                // Request the input checkbox element that we specified in the template
                HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();

                // Сheck if the checkbox is checked - it should not be there
                Output.WriteLine("Checked: " + input.Checked);
                Output.WriteLine("Attributes.Length: " + input.Attributes.Length);
                Output.WriteLine("Attributes[0].Name: " + input.Attributes[0].Name);
                Output.WriteLine("Attributes[1].Name: " + input.Attributes[1].Name);
               
                /*
                This example produces the following results:

                Checked: False
                Attributes.Length: 2
                Attributes[0].Name: type
                Attributes[1].Name: disabled
                */

                // Save the HTML document to a file
                htmlDocument.Save(Path.Combine(OutputDir, "out-unchecked.html"));

                // Prepare a path to the output file
                string outputPath = Path.Combine(OutputDir, "out-unchecked.png");

                // Convert HTML to PNG
                htmlDocument.RenderTo(new ImageDevice(new ImageRenderingOptions(), outputPath));
                
                Assert.True(File.Exists(Path.Combine(OutputDir, "out-unchecked.html")));
            }
            // @END_SNIPPET
        }
    }
}
