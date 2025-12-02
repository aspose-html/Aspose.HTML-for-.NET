# Basic Usage

This guide introduces common usage scenarios for [Aspose.HTML for .NET](https://products.aspose.com/html/net/). Here, you will find practical examples to quickly get started with HTML, SVG, and MHTML processing.

## Load HTML from a URL and Convert to PDF

You can load HTML content directly from a web page and convert it to a PDF:

```c#
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

    // Load HTML document from a URL
    using (HTMLDocument document = new HTMLDocument("https://docs.aspose.com/html/net/"))
    {
        // Convert to PDF
        Converter.ConvertHTML(document, new PdfSaveOptions(), "webpage.pdf");
    }
```

**Use Case:** Automatically archive web pages or generate reports from online content.

## Convert MHTML to PDF

```c#
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

    // Open an existing MHTML file for reading
    using FileStream stream = File.OpenRead("document.mht");
    // Convert MHTML to PDF
    Converter.ConvertMHTML(stream, new PdfSaveOptions(), "convert-mhtml-to.pdf");
```

**Use Case:** Archive emails, web page snapshots, or complex documents that include images and CSS.

## Add Table to HTML

Create dynamic HTML content programmatically using the DOM API:

```c#
using Aspose.Html;
using System.IO;


    // Create new HTML document
    using (HTMLDocument document = new HTMLDocument())
    {
        HTMLElement body = document.Body;

        // Create a table element
        HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");
        table.Border = "2";
        table.Style.Border = "2px #ff0000 dotted";
        document.Body.AppendChild(table);

        HTMLTableRowElement row = (HTMLTableRowElement)document.CreateElement("tr");
        table.AppendChild(row);

        HTMLTableCellElement cell = (HTMLTableCellElement)document.CreateElement("td");
        cell.InnerHTML = "Hello Table!";
        row.AppendChild(cell);

        // Prepare a path for resulting file saving 
        string savePath = Path.Combine(OutputDir, "add-simple-table.html");
        document.Save(savePath);
    }
```

## Notes

- You can combine conversion and DOM manipulation in a single workflow.
- All examples can be adapted for SVG, EPUB, Markdown rendering & conversion, or custom save options.
- Refer to the [official Aspose.HTML documentation](https://docs.aspose.com/html/net/) for advanced settings, page layouts, and rendering configuration.
