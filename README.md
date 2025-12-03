[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/html/net/) | [Docs](https://docs.aspose.com/html/net/) | [NuGet Package](https://www.nuget.org/packages/Aspose.HTML/) | [Demos](https://products.aspose.app/html/applications) | [API Reference](https://reference.aspose.com/html/net/) | [Blog](https://blog.aspose.com/categories/aspose.html-product-family/) | [Free Support](https://forum.aspose.com/c/html/29) | [Temporary License](https://purchase.aspose.com/temporary-license/)

![Nuget](https://img.shields.io/nuget/v/Aspose.HTML) ![Nuget](https://img.shields.io/nuget/dt/Aspose.HTML) ![GitHub](https://img.shields.io/github/license/aspose-html/Aspose.HTML-for-.NET)

# Aspose.HTML for .NET – HTML File Manipulation .NET API

High-performance .NET API for working with HTML, MHTML, EPUB, Markdown, and SVG – convert, render, edit, and automate web content using C#.

[Aspose.HTML for .NET](https://products.aspose.com/html/net/) is a developer-friendly library that makes it easy to load, create, parse, convert, and render HTML, MHTML, and SVG content inside any .NET application. The .NET API works as a headless browser, allowing you to create or open existing HTML documents from various sources to perform operations such as removing and replacing HTML nodes, saving and converting HTML documents, extracting CSS from HTML, configuring a document sandbox, and much more. This library provides you with all the tools you need.

<p align="center">

  <a title="Download complete Aspose.HTML for .NET source code" href="https://github.com/aspose-html/Aspose.HTML-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

## HTML Processing Features

- [Programmatic DOM manipulation](https://docs.aspose.com/html/net/edit-html-document/) – create, navigate, modify, and remove HTML elements in C#.
- [Load documents](https://docs.aspose.com/html/net/creating-a-document/) from file, URL, stream, or string.
- [Navigate through document](https://docs.aspose.com/html/net/html-navigation/) either by NodeIterator or TreeWalker.
- [MutationObserver](https://docs.aspose.com/html/net/mutationobserver/) to watch over DOM modifications.
- High-fidelity HTML rendering engine with CSS, JS, fonts, and media support.
- Control the [timeout of rendering process](https://docs.aspose.com/html/net/renderers/#set-timeout).
- [Convert HTML](https://docs.aspose.com/html/net/html-converter/) to many popular formats including PDF, DOCX, XPS and images.
- [Populate HTML document](https://docs.aspose.com/html/net/working-with-html-template/) with external data (XML & JSON).
- Support of single (PDF, XPS) or multiple (image formats) [output file streams](https://docs.aspose.com/html/net/convert-html-to-pdf/#output-stream-providers).
- [Extract CSS styling information](https://docs.aspose.com/html/net/data-extraction/).
- [Configuring Sandbox](https://docs.aspose.com/html/net/sandboxing/) for the environment independent of the execution machine.

## Quick Start with Aspose.HTML for .NET

Run the following command in the Package Manager Console in Visual Studio to fetch the NuGet package:

```c#
Install-Package Aspose.Html
```
If you already have Aspose.HTML for .NET installed and want to update to the latest version, please execute 

```c#
Update-Package Aspose.Html
```
### Convert HTML to PDF

This example demonstrates how to convert HTML to PDF in just one line of C#. It shows the simplest way to transform dynamic HTML content into a high-quality PDF document using Aspose.HTML for .NET.

```csharp
using Aspose.Html.Converters;
using Aspose.Html.Saving;

    // Convert HTML to PDF using C#
    Converter.ConvertHTML(@"<h1>Convert HTML to PDF!</h1>", ".", new PdfSaveOptions(), "convert-with-single-line.pdf");
```

### Convert SVG to PNG

Convert inline SVG code into a PNG image programmatically. A great starting point for generating charts, icons, and dynamic graphics in .NET applications.

```csharp
using Aspose.Html.Converters;
using Aspose.Html.Saving;

    // Prepare SVG code
    string code = "<svg xmlns='http://www.w3.org/2000/svg'><circle cx='100' cy='100' r='60' fill='none' stroke='red' stroke-width='10' /></svg>";
    // Prepare a path to save the converted file
    string savePath = Path.Combine(OutputDir, "circle.png");
    // Create an instance of the ImageSaveOptions class
    ImageSaveOptions options = new ImageSaveOptions();
    // Convert SVG to PNG
    Converter.ConvertSVG(code, ".", options, savePath);
```

### Edit HTML document using DOM Tree

A practical illustration of DOM manipulation in .NET: create nodes, append content, and build HTML structure dynamically. Ideal for automated content generation or templating.

```csharp
    // Create an instance of an HTML document
    using (HTMLDocument document = new HTMLDocument())
    {
        HTMLElement body = document.Body;
        // Create a paragraph element
        HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");
        // Set a custom attribute
        p.SetAttribute("id", "my-paragraph");
        // Create a text node
        Text text = document.CreateTextNode("my first paragraph");
        // Attach the text to the paragraph
        p.AppendChild(text);
        // Attach the paragraph to the document body
        body.AppendChild(p);
        // Save the HTML document to a file
        string outPath = Path.Combine(OutputDir, "edit-document-tree.html");
        document.Save(outPath);
    }
```
## How This Repository Complements the Official Documentation

This repository works hand in hand with the [official Aspose.HTML for .NET documentation](https://docs.aspose.com/html/net/). The documentation includes structured guides, conceptual explanations, and step-by-step tutorials, along with a set of practical code samples covering both common and unconventional scenarios you might encounter in real-world .NET projects.

The examples provided here are intended to complement the documentation, extend it, and provide ready-to-use code snippets for converting HTML to PDF, rendering SVG, working with the DOM, processing MHTML, and more.

## Contributing

We warmly welcome contributions that help improve this repository and make the examples even more valuable for the community. To contribute, please follow this simple workflow:

1. Create a Feature Branch. Open a new branch for your changes using the feature/* naming pattern. This keeps contributions organized and easy to review.
1. Submit a Pull Request. Once your update is ready, open a pull request. It will be automatically routed to the appropriate reviewer for evaluation and feedback.
1. Merge After Approval. When your pull request is approved, it will be merged into the repository. Thank you for helping us improve the project!

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/html/net/) | [Docs](https://docs.aspose.com/html/net/) | [NuGet Package](https://www.nuget.org/packages/Aspose.HTML/)| [Demos](https://products.aspose.app/html/applications) | [API Reference](https://reference.aspose.com/html/net/) | [Blog](https://blog.aspose.com/categories/aspose.html-product-family/) | [Free Support](https://forum.aspose.com/c/html/29) | [Temporary License](https://purchase.aspose.com/temporary-license/)