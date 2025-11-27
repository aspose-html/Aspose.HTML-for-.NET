using Aspose.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Xunit;
using Xunit.Abstractions;
using System.Text;

namespace Aspose.HTML.Tests.Working_with_HTML_Documents
{
    public class ManagingTablesTests : TestsBase
    {
        public ManagingTablesTests(ITestOutputHelper output) : base(output)
        {
            SetOutputDir("tables");
        }


        [Fact(DisplayName = "Add Table To HTML")]
        public void AddTableToHTMLTest()
        {           
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "input.html");

            // Prepare a path for resulting file saving 
            string savePath = Path.Combine(OutputDir, "add-table.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Create a table element
                HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");
                table.Border = "2";
                table.Align = "center";
                table.Style.Border = "2px #ff0000 dotted";
                //table.Style.Width = "80%";
                table.SetAttribute("width", "50%");

                // Add html rows & columns
                for (int i = 0; i < 3; i++)
                {
                    HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    for (int j = 0; j < 4; j++)
                    {
                        HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                        cell.TextContent = $"Row: {i + 1}, Column {j + 1}";
                        //cell.TextContent = $"content";
                    }
                }

                // Attach the table to the document body
                body.AppendChild(table);

                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }            
        }


        [Fact(DisplayName = "Edit HTML Table")]
        public void EditHtmlTableTest()
        {            
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "add-table.html");

            // Prepare a path for resulting file saving 
            string savePath = Path.Combine(OutputDir, "edit-table.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Create a CSS Selector that selects <table> element that is the last child of its parent
                Element table = document.QuerySelector("table:last-child");                

                // Get the <style> element and assign the color border-style and border-color values for <table> element
                table.SetAttribute("style", "border-style:solid; border-color:rgb(0, 0, 255); width: 60%");
                
                // Save the HTML document to a file
                document.Save(savePath);
                Assert.True(File.Exists(savePath));
            }            
        }


        [Fact(DisplayName = "Extract Tables From HTML")]
        public void ExtractTablesFromHtmlTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "tables.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
                int i = 0;
                foreach (Element table in tables)
                {
                    // Save the table to a new HTML document
                    string newFileName = "table" + i + ".html";
                    HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                    newDoc.Save(Path.Combine(OutputDir, newFileName));
                    i++;
                }
            }            
        }


        [Fact(DisplayName = "Extract Tables From Website")]
        public void ExtractTablesFromWebsiteTest()
        {
            // Open a document you want to download tables from
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/edit-html-document/");
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
                int i = 0;
                foreach (Element table in tables)
                {
                    // Save table to new html document
                    string newFileName = "table" + i + ".htm";
                    HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                    newDoc.Save(Path.Combine(OutputDir, newFileName));
                    i++;

                }
            }            
        }


        [Fact(DisplayName = "Extract Tables From Website With Check")]
        public void ExtractTablsFromWebsiteWithCheckTest()
        {
            // Open a document you want to download tables from
            using HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/");
            { 
                // Check if there are any table elements in the document
                HTMLCollection tables = document.GetElementsByTagName("table");

                if (tables.Any())
                {
                    List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
                    int i = 0;
                    foreach (Element table in tables)
                    {
                        // Save table to new html document
                        string newFileName = "table" + i + ".htm";
                        HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                        newDoc.Save(Path.Combine(OutputDir, newFileName));
                        i++;
                    }
                }
                else
                {
                    // Handle the case where no tables are found
                    Output.WriteLine("No tables found in the document.");
                }                
            }
        }


        [Fact(DisplayName = "Extract Data from Tables")]
        public void ExtractDataFromTablsTest()
        {
            // Load the HTML document from file or web
            using var document = new HTMLDocument("https://docs.aspose.com/html/java/edit-a-document/");

            // Get all <table> elements
            var tables = document.GetElementsByTagName("table");

            int tableIndex = 1;

            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    Output.WriteLine($"\n📋 Table #{tableIndex++}:");

                    // Iterate over rows
                    foreach (var rowNode in table.GetElementsByTagName("tr"))
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            Output.WriteLine("| ");

                            // Iterate over <td> and <th> cells
                            foreach (var cell in row.Cells)
                            {
                                string text = cell.TextContent?.Trim();
                                Output.WriteLine(text + " | ");
                            }

                            Output.WriteLine("");
                        }
                    }
                }
            }
        }


        [Fact(DisplayName = "Extract Data from Tables and Save to File")]
        public void ExtractDataFromTablsToFileTest()
        {
            // Load the HTML document from file or web
            using var document = new HTMLDocument("https://docs.aspose.com/html/java/edit-a-document/");

            var tables = document.GetElementsByTagName("table");

            int tableIndex = 1;

            foreach (var tableNode in tables)
            {
                if (tableNode is HTMLTableElement table)
                {
                    StringBuilder csvBuilder = new StringBuilder();

                    foreach (var rowNode in table.GetElementsByTagName("tr"))
                    {
                        if (rowNode is HTMLTableRowElement row)
                        {
                            var rowValues = new StringBuilder();

                            foreach (var cell in row.Cells)
                            {
                                string text = cell.TextContent?.Trim().Replace("\"", "\"\"");
                                rowValues.Append($"\"{text}\",");
                            }

                            // Remove last comma and add newline
                            if (rowValues.Length > 0)
                            {
                                rowValues.Length--; // remove last comma
                                csvBuilder.AppendLine(rowValues.ToString());
                            }
                        }
                    }

                    // Save to file
                    string fileName = $"table_{tableIndex}.csv";
                    File.WriteAllText(fileName, csvBuilder.ToString());
                    Output.WriteLine($"✅ Saved: {fileName}");

                    tableIndex++;
                }
            }
        }


        [Fact(DisplayName = "Extract Data From Tables With Check")]
        public void ExtractDataFromTablesTest()
        {
            // Open a document you want to download table data from
            using HTMLDocument document = new HTMLDocument(Path.Combine(DataDir, "chapter-9.htm"));
            {
                // Check if there are any table elements in the document
                HTMLCollection tables = document.GetElementsByTagName("table");

                if (tables.Any())
                {
                    List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
                    //var i = 0;
                    foreach (Element table in tables)
                    {
                        // Save table to new html document
                        //var newFileName = "table" + i + ".htm";
                        //var newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                        //newDoc.Save(Path.Combine(OutputDir, newFileName));
                        //i++;

                        //extract data from tables
                        HTMLCollection tbodies = table.GetElementsByTagName("tbody");

                        foreach (Element tbody in tbodies)
                        {
                            if (tbody.Children.Length > 1)
                            {
                                foreach (Element row in tbody.Children)
                                {
                                    if (row.HasAttribute("id"))
                                    {
                                        //test row
                                        Dictionary<string, string> data = new Dictionary<string, string>();

                                        data["Id"] = row.GetAttribute("id");
                                        if (row.Children.Length > 0)
                                        {
                                            Element td = row.Children[0];
                                            if (td.Children.Length > 0)
                                            {
                                                Element element = td.Children[0].TagName == "STRONG"
                                                    ? td.Children[0].Children[0]
                                                    : td.Children[0];
                                                string href = ((HTMLAnchorElement)element).Href;
                                                data["Href"] = href;
                                                data["TestName"] = Path.GetFileNameWithoutExtension(href);
                                            }
                                        }

                                        data["TestComment"] = string.Join(" ",
                                            row.Children[3].TextContent
                                                .Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList()
                                                .Select(x => x.Trim()));
                                        result.Add(data);
                                    }
                                }
                                string json = JsonSerializer.Serialize(result);
                                Output.WriteLine(json);
                            }
                        }
                    }
                }
                else
                {
                    // Handle the case where no tables are found
                    Output.WriteLine("No tables found in the document.");
                }
            }
        }


        [Fact(DisplayName = "Remove Table")]
        public void RemoveTableTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "add-table.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-table.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Find the first table element
                HTMLElement table = (HTMLElement)document.GetElementsByTagName("table").First();

                // Remove the table
                body.RemoveChild(table);

                // Save the HTML document to a file
                document.Save(savePath);

                Assert.True(File.Exists(savePath));
            }
        }


        [Fact(DisplayName = "Remove Table with Check")]
        public void RemoveTableCheckTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "file.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-table-check.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                // Check if there are any table elements in the document
                HTMLCollection tables = document.GetElementsByTagName("table");

                if (tables.Any())
                {
                    // If there are tables, remove the first table
                    HTMLElement table = (HTMLElement)tables.First();
                    body.RemoveChild(table);

                    // Save the HTML document to a file
                    document.Save(savePath);
                }
                else
                {
                    // Handle the case where no tables are found
                    Output.WriteLine("No tables found in the document.");
                }
            }
        }


        [Fact(DisplayName = "Remove All Tables")]
        public void RemoveAllTablesTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "tables.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "remove-all-tables.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))            
            {
                // Find all table elements in the document
                HTMLCollection tables = document.GetElementsByTagName("table");

                // Remove each table element
                foreach (Element table in tables.ToList()) // ToList() to avoid collection modification during iteration
                {
                    table.ParentNode.RemoveChild(table);
                }

                // Save the modified document
                document.Save(savePath);
            }
        }

        [Fact(DisplayName = "Edit HTML Tables")]
        public void EditHTMLTableTest()
        {
            // Prepare a path to a source HTML file
            string documentPath = Path.Combine(DataDir, "tables.html");

            // Prepare a path for converted file saving 
            string savePath = Path.Combine(OutputDir, "edited-tables.html");

            // Create an instance of an HTML document
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                // Find the first <table> element
                HTMLTableElement table = (HTMLTableElement)document.GetElementsByTagName("table").First();
                // var table = ()document.CreateElement("table");

                // Add html rows & columns
                for (int i = 0; i < 3; i++)
                {
                    HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    for (int j = 0; j < 4; j++)
                    {
                        HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                        cell.TextContent = $"Added Row: {i + 1}, Column {j + 1}";
                    }
                }

                // Get the style attribute and assign the color border-style, border-color, and width values for the first <table> element
                table.SetAttribute("style", "border-style:solid; border-color:rgb(255, 0, 0); width: 40%");

                // Save the modified document
                document.Save(savePath);
            }
        }
    }
}
