using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using System.IO;
using System.Linq;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using System.Xml;

namespace Aspose.HTML.Tests.Web_Scraping
{
    public class ExtractHtmlTable : TestsBase
    {
        public ExtractHtmlTable(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("navigation/extract-tables");
        }


        [Fact(DisplayName = "Extract Data From HTML Table")]
        public void ExtractDataFromTableTest()
        {
            // @START_SNIPPET ExtractDataFromHtmlTable.cs
            // Extract data from HTML table using C#
            // Learn more: https://docs.aspose.com/html/net/data-extraction/

            // Load the HTML document from a local file
           HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/edit-html-document/");

            // Create a list to store extracted hyperlink data
            List <Dictionary<string, string>> linkList = new List<Dictionary<string, string>>();

            // Get all <table> elements in the document
            HTMLCollection tables = document.GetElementsByTagName("table");

            for (int t = 0; t < tables.Length; t++)
            {
                // Access the table element
                Element element = tables[t];
                HTMLElement htmlTable = element as HTMLElement;

                if (htmlTable == null)
                    continue;

                // Get all <a> elements (hyperlinks) within this table only
                HTMLCollection links = htmlTable.GetElementsByTagName("a");

                for (int i = 0; i < links.Length; i++)
                {
                    Element link = links[i];
                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                    // Add hyperlink to the result list if href exists
                    if (!string.IsNullOrEmpty(href))
                    {
                        Dictionary<string, string> item = new Dictionary<string, string>
                    {
                        { "text", text },
                        { "href", href }
                    };

                        linkList.Add(item);
                    }
                }
            }

            // Configure JSON serializer to output indented (pretty) format
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // Serialize the link list to JSON
            string json = JsonSerializer.Serialize(linkList, options);

            // Ensure output directory exists
            
            // Save the JSON to a file
            string outputPath = Path.Combine(OutputDir, "links1.json");
            File.WriteAllText(outputPath, json);

            Output.WriteLine("Hyperlinks successfully extracted and saved to: " + outputPath);
        }
        // @END_SNIPPET
    }
}
