using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace Aspose.Html.Examples
{
    public class ManagingTablesExample : BaseExample
    {
        public ManagingTablesExample()
        {
            // Sub‑directory for this example's output files
            SetOutputDir("tables");
        }

        /// <summary>
        /// Adds a table to an HTML document
        /// </summary>
        public void AddTableToHTML()
        {
            string documentPath = Path.Combine(DataDir, "input.html");
            string savePath = Path.Combine(OutputDir, "add-table.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;

                HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");
                table.Border = "2";
                table.Align = "center";
                table.Style.Border = "2px #ff0000 dotted";
                table.SetAttribute("width", "50%");

                for (int i = 0; i < 3; i++)
                {
                    HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    for (int j = 0; j < 4; j++)
                    {
                        HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                        cell.TextContent = $"Row: {i + 1}, Column {j + 1}";
                    }
                }

                body.AppendChild(table);
                document.Save(savePath);
                Console.WriteLine($"Table added and saved to: {savePath}");
            }
        }

        /// <summary>
        /// Edits the style of the last table element
        /// </summary>
        public void EditHtmlTable()
        {
            string documentPath = Path.Combine(DataDir, "add-table.html");
            string savePath = Path.Combine(OutputDir, "edit-table.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                Element table = document.QuerySelector("table:last-child");
                table.SetAttribute("style", "border-style:solid; border-color:rgb(0, 0, 255); width: 60%");
                document.Save(savePath);
                Console.WriteLine($"Table style edited and saved to: {savePath}");
            }
        }

        /// <summary>
        /// Extracts each table from an HTML file and saves it as a separate file
        /// </summary>
        public void ExtractTablesFromHtml()
        {
            string documentPath = Path.Combine(DataDir, "tables.html");
            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                int i = 0;
                foreach (Element table in tables)
                {
                    string newFileName = $"table{i}.html";
                    HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                    newDoc.Save(Path.Combine(OutputDir, newFileName));
                    Console.WriteLine($"Extracted table saved to: {Path.Combine(OutputDir, newFileName)}");
                    i++;
                }
            }
        }

        /// <summary>
        /// Extracts tables from a remote website and saves them
        /// </summary>
        public void ExtractTablesFromWebsite()
        {
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/edit-html-document/"))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                int i = 0;
                foreach (Element table in tables)
                {
                    string newFileName = $"web-table{i}.htm";
                    HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                    newDoc.Save(Path.Combine(OutputDir, newFileName));
                    Console.WriteLine($"Web table saved to: {Path.Combine(OutputDir, newFileName)}");
                    i++;
                }
            }
        }

        /// <summary>
        /// Extracts tables from a website with a check for existence
        /// </summary>
        public void ExtractTablesFromWebsiteWithCheck()
        {
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/"))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                if (tables.Any())
                {
                    int i = 0;
                    foreach (Element table in tables)
                    {
                        string newFileName = $"checked-web-table{i}.htm";
                        HTMLDocument newDoc = new HTMLDocument(table.OuterHTML, Path.Combine(OutputDir, newFileName));
                        newDoc.Save(Path.Combine(OutputDir, newFileName));
                        Console.WriteLine($"Checked web table saved to: {Path.Combine(OutputDir, newFileName)}");
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("No tables found on the website.");
                }
            }
        }

        /// <summary>
        /// Extracts data from tables in a remote HTML file and writes it to the console
        /// </summary>
        public void ExtractDataFromTables()
        {
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/java/edit-a-document/"))
            {
                foreach (var tableNode in document.GetElementsByTagName("table"))
                {
                    if (tableNode is HTMLTableElement table)
                    {
                        Console.WriteLine($"\n📋 Table:");
                        foreach (var rowNode in table.GetElementsByTagName("tr"))
                        {
                            if (rowNode is HTMLTableRowElement row)
                            {
                                foreach (var cell in row.Cells)
                                {
                                    Console.Write(cell.TextContent?.Trim() + " | ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Extracts data from tables and saves each table as a CSV file
        /// </summary>
        public void ExtractDataFromTablesToFile()
        {
            using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/java/edit-a-document/"))
            {
                int tableIndex = 1;
                foreach (var tableNode in document.GetElementsByTagName("table"))
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
                                if (rowValues.Length > 0)
                                {
                                    rowValues.Length--; // remove last comma
                                    csvBuilder.AppendLine(rowValues.ToString());
                                }
                            }
                        }
                        string fileName = $"table_{tableIndex}.csv";
                        File.WriteAllText(Path.Combine(OutputDir, fileName), csvBuilder.ToString());
                        Console.WriteLine($"Table data saved to CSV: {Path.Combine(OutputDir, fileName)}");
                        tableIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the first table from a document
        /// </summary>
        public void RemoveTable()
        {
            string documentPath = Path.Combine(DataDir, "add-table.html");
            string savePath = Path.Combine(OutputDir, "remove-table.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;
                HTMLElement table = (HTMLElement)document.GetElementsByTagName("table").First();
                body.RemoveChild(table);
                document.Save(savePath);
                Console.WriteLine($"First table removed and saved to: {savePath}");
            }
        }

        /// <summary>
        /// Removes the first table after checking existence
        /// </summary>
        public void RemoveTableCheck()
        {
            string documentPath = Path.Combine(DataDir, "file.html");
            string savePath = Path.Combine(OutputDir, "remove-table-check.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLElement body = document.Body;
                HTMLCollection tables = document.GetElementsByTagName("table");
                if (tables.Any())
                {
                    HTMLElement table = (HTMLElement)tables.First();
                    body.RemoveChild(table);
                    document.Save(savePath);
                    Console.WriteLine($"Table removed with check and saved to: {savePath}");
                }
                else
                {
                    Console.WriteLine("No tables found to remove.");
                }
            }
        }

        /// <summary>
        /// Removes all tables from a document
        /// </summary>
        public void RemoveAllTables()
        {
            string documentPath = Path.Combine(DataDir, "tables.html");
            string savePath = Path.Combine(OutputDir, "remove-all-tables.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLCollection tables = document.GetElementsByTagName("table");
                foreach (Element table in tables.ToList())
                {
                    table.ParentNode.RemoveChild(table);
                }
                document.Save(savePath);
                Console.WriteLine($"All tables removed and saved to: {savePath}");
            }
        }

        /// <summary>
        /// Edits an existing table by adding rows and columns and changing its style
        /// </summary>
        public void EditHTMLTable()
        {
            string documentPath = Path.Combine(DataDir, "tables.html");
            string savePath = Path.Combine(OutputDir, "edited-tables.html");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                HTMLTableElement table = (HTMLTableElement)document.GetElementsByTagName("table").First();

                for (int i = 0; i < 3; i++)
                {
                    HTMLTableRowElement row = (HTMLTableRowElement)table.InsertRow(table.Rows.Length);
                    for (int j = 0; j < 4; j++)
                    {
                        HTMLTableCellElement cell = (HTMLTableCellElement)row.InsertCell(row.Cells.Length);
                        cell.TextContent = $"Added Row: {i + 1}, Column {j + 1}";
                    }
                }

                table.SetAttribute("style", "border-style:solid; border-color:rgb(255, 0, 0); width: 40%");
                document.Save(savePath);
                Console.WriteLine($"Table edited and saved to: {savePath}");
            }
        }
    }
}