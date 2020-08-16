# HTML File Manipulation .NET API

The [.NET HTML API](https://products.aspose.com/html/net) assists developers to write, read, modify, navigate and convert (X)HTML documents from within .NET applications.

Aspose.HTML for .NET API works as a headless browser that allows you to [create or open existing HTML documents](https://docs.aspose.com/html/net/creating-a-document/) from various sources in order to perform manipulation operations such as remove and replace HTML nodes, save HTML documents, extract CSS from HTML, configure a document sandbox and more. You may navigate HTML documents by using various methods, such as, element traversal, document traversal, XPath queries, and CSS selector queries as well as manipulate HTML DOM via JavaScript, convert HTML file to images or fixed layout formats, and convert (X)HTML and EPUB files to other file formats.

<p align="center">

  <a title="Download complete Aspose.HTML for .NET source code" href="https://github.com/aspose-html/Aspose.HTML-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

## HTML Processing Features

- Convert HTML to [many popular formats](https://docs.aspose.com/html/net/supported-file-formats/) including PDF, XPS and images.
- Load & convert SVG & EPUB to XPS, PDF and images.
- Navigate through document either by NodeIterator or TreeWalker.
- Control the timeout of rendering process.
- [MutationObserver](https://docs.aspose.com/html/net/dom-mutationobserver/) to watch over DOM modifications.
- Populate HTML document with external data (XML & JSON).
- Support of single (PDF, XPS) or multiple (image formats) output file streams.
- Extract CSS styling information.
- Configuring Sandbox for the environment independent of the execution machine.

## Read & Write Web Formats

**Web:** HTML, XHTML, MHTML.

## Save HTML As

**Fixed Layout:** PDF, XPS\
**Images:** TIFF, JPEG, PNG, BMP\
**Markdown:** MD

## Read Formats

EPUB, SVG

## Platform Independence

Aspose.HTML for .NET is written completely in C# and can be used to build any type of a 32-bit or 64-bit .NET application including ASP.NET, WCF, WinForms & .NET Core. Development platforms include all flavors of Windows, Linux and Mac OS X x64 (10.12+).

## Get Started with Aspose.HTML for .NET

Are you ready to give Aspose.HTML for .NET a try? Simply execute `Install-Package Aspose.Html` from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.HTML for .NET and want to upgrade the version, please execute `Update-Package Aspose.Html` to get the latest version.

## Convert HTML to GIT-based Markdown (MD) Format

```csharp
using (var document = new Aspose.Html.HTMLDocument("<p>my first paragraph</p>", dir))
{
    // save to Markdown using default GIT formatting model
    document.Save(dir + "Markdown.md", Saving.MarkdownSaveOptions.Git);
}
```

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/html/net) | [Docs](https://docs.aspose.com/html/net/) | [Demos](https://products.aspose.app/html/family) | [API Reference](https://apireference.aspose.com/html/net) | [Examples](https://github.com/aspose-html/Aspose.Html-for-.NET) | [Blog](https://blog.aspose.com/category/html/) | [Free Support](https://forum.aspose.com/c/html) |  [Temporary License](https://purchase.aspose.com/temporary-license)
