using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

namespace Aspose.Html.Examples
{
    public class ExtractHtmlTableExample : BaseExample
    {
        public ExtractHtmlTableExample()
        {
            // Set a sub‑directory for this example's output files
            SetOutputDir("navigation/extract-tables");
        }

        /// <summary>
        /// Extract data from HTML tables and save as JSON
        /// </summary>
        public void ExtractDataFromTable()
        {
            // Load the HTML document from a URL
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/edit-html-document/");

            // Collect all <table> elements
            HTMLCollection tables = document.GetElementsByTagName("table");

            // List to hold extracted hyperlink data
            List<Dictionary<string, string>> linkList = new List<Dictionary<string, string>>();

            for (int t = 0; t < tables.Length; t++)
            {
                // Cast the table element to HTMLElement
                HTMLElement htmlTable = tables[t] as HTMLElement;
                if (htmlTable == null) continue;

                // Get all <a> elements inside the current table
                HTMLCollection links = htmlTable.GetElementsByTagName("a");

                for (int i = 0; i < links.Length; i++)
                {
                    Element link = links[i];
                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                    if (!string.IsNullOrEmpty(href))
                    {
                        var item = new Dictionary<string, string>
                        {
                            { "text", text },
                            { "href", href }
                        };
                        linkList.Add(item);
                    }
                }
            }

            // Serialize the list to indented JSON
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(linkList, options);

            // Save JSON to a file
            string outputPath = Path.Combine(OutputDir, "links.json");
            File.WriteAllText(outputPath, json);
            Console.WriteLine($"Extracted links saved to: {outputPath}");
        }
    }
}