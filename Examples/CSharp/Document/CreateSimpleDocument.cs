using System;

namespace Aspose.Html.Examples.CSharp.Document
{
    /// <summary>
    /// Create a simple document, which contains one image, one ordered list and a table 3x3.
    /// </summary>
    class CreateSimpleDocument
    {
        public static void Run()
        {
            // ExStart:CreateSimpleDocument
            string dataDir = RunExamples.GetDataDir_Data();
            String outputHtml = dataDir + "SimpleDocument.html";

            // Create an instance of HTMLDocument
            var document = new HTMLDocument();

            // Add image
            if (document.CreateElement("img") is HTMLImageElement img)
            {
                img.Src = "http://via.placeholder.com/400x200";
                img.Alt = "Placeholder 400x200";
                img.Title = "Placeholder image";
                document.Body.AppendChild(img);
            }

            // Add ordered list
            var orderedListElement = document.CreateElement("ol") as HTMLOListElement;
            for (int i = 0; i < 10; i++)
            {
                var listItem = document.CreateElement("li") as HTMLLIElement;
                listItem.TextContent = $" List Item {i + 1}";
                orderedListElement.AppendChild(listItem);
            }
            document.Body.AppendChild(orderedListElement);

            // Add table 3x3 
            var table = document.CreateElement("table") as HTMLTableElement;
            var tBody = document.CreateElement("tbody") as HTMLTableSectionElement;
            for (var i = 0; i < 3; i++)
            {
                var row = document.CreateElement("tr") as HTMLTableRowElement;
                row.Id = "trow_" + i;
                for (var j = 0; j < 3; j++)
                {
                    var cell = document.CreateElement("td") as HTMLTableCellElement;
                    cell.Id = $"cell{i}_{j}";
                    cell.TextContent = "Cell " + j;
                    row.AppendChild(cell);
                }
                tBody.AppendChild(row);
            }
            table.AppendChild(tBody);
            document.Body.AppendChild(table);

            //Save the document to disk                        
            document.Save(outputHtml);

            // ExEnd:CreateSimpleDocument           
        }
    }
}
