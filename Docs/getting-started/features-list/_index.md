---
title: Features List
type: docs
weight: 10
url: /net/features-list/
---

Aspose.HTML is a **headless browser**, written in C#, which offers the following features: create, open existing, manipulate, navigate through and convert (X)HTML, SVG, EPUB, MHTML and Markdown documents into the various supported output formats such as: PDF, XPS, Markdown, JPG, PNG, etc. All the core modules are implemented according to the official HTML, CSS and JavaScript documentations, which leads to high quality parsing, conversion and manipulation results.

Aspose.HTML provides a rich set of features, related to many different areas:
## **Document Manipulation**
- Create a [new](/html/net/creating-a-document/#creatingadocument-createanewhtmldocument) or open an existing [(X)HTML](/html/net/creating-a-document/#creatingadocument-loadfromafile) or [SVG](/html/net/creating-a-document/#creatingadocument-svgdocument) document. With the help of Aspose.HTML you will be able to open document not only from the local file, but directly from the web!
- [Save](/html/net/saving-a-document/#savingadocument-savehtml) the document along with all the referenced resources, such as CSS and images. Aspose.HTML offers you the highly customizable saver, which is able to save not only the document itself, with all the referenced resources, but even other documents, referenced by it!
- [Create, edit, remove and replace](/html/net/editing-a-document/) HTML nodes via the rich API based on the Document Object Model (DOM) defined in the official [documentation](https://dom.spec.whatwg.org/).
- Wide possibilities of environment [customization](/html/net/environment-configuration/). You can specify [user style sheet](/html/net/environment-configuration/#environmentconfiguration-userstylesheet), [font folder](/html/net/environment-configuration/#environmentconfiguration-setpathtothefontfolder), [external resource handler](/html/net/environment-configuration/#environmentconfiguration-networkservice) and much more.
## **Web Scraping**
Although Aspose.HTML is not a web scraper by itself, but it can be used to collect information from the opened document:

- [Navigate](/html/net/web-scraping/#webscraping-htmlnavigation) through the HTML elements with the help of DOM API. Aspose.HTML implements [Traversal](https://dom.spec.whatwg.org/#traversal) interfaces which allows you to easily navigate through the DOM tree.
- Collect information from the HTML documents, using high performance [XPath queries](/html/net/web-scraping/#webscraping-xpath). Aspose.HTML supports XPath 1.0 interfaces, defined in the official [documentation](https://dom.spec.whatwg.org/#xpath).
- Collect HTML elements, by executing [CSS Selector queries](/html/net/web-scraping/#webscraping-cssselector). Aspose.HTML implements [CSS Selectors API](https://www.w3.org/TR/selectors-4/)  according to the lates documentation.
## **Conversion**
One of the main goals of Aspose.HTML - is to provide simple, highly customizable and precise converters. 

**Simplicity:** Aspose.HTML API provides you the ability to convert (X)HTML, SVG, EPUB and MHTML to many different formats with just one line of code. Here is an example of HTML to PDF conversion:

{{< highlight csharp >}}

 Aspose.Html.Converters.Converter.ConvertHTML(@"<span>Hello World!!</span>", ".", new Aspose.Html.Saving.PdfSaveOptions(), "output.pdf");

{{< /highlight >}}

**Сustomizability:** With Aspose.HTML you will be able to [fine-tune](/html/net/fine-tuning-converters/) many aspects of the conversion process. Many other products will allow you to setup page size or image resolution, but with Aspose.HTML you will be able to [customize processing of external resources](/html/net/environment-configuration/#environmentconfiguration-networkservice), or[ specify custom style sheet](/html/net/environment-configuration/#environmentconfiguration-userstylesheet) for your document and much more.

**Precision:** All the components of Aspose.HTML assembly are designed according to the official HTML and SVG documentations. Which leads to high precision conversion results. 

Aspose.HTML implements many converters, which can be split into three groups:

1. Fixed layout converters. These converters are responsible for conversion of (X)HTML, SVG, EPUB and MHTML to PDF, XPS and raster image formats (PNG, JPG, BMP). 
1. Markdown converters. These converters are responsible for conversion of [Markdown to HTML](/html/net/markdown-to-html-conversion/) and [HTML to Markdown](/html/net/html-to-markdown-conversion/).
1. Template converter. Which is used to create [HTML file from Template](/html/net/html-template/).

You can explore all the available converters on this [page.](/html/net/converting-between-formats/)
## **Built-in Formats**
Real world HTML page - is a very complex set of formats, working together. That's why development of high quality converter is such a complex task. Aspose.HTML includes implementations of all the HTML related formats:

- Parser works according to the latest [HTML5](https://html.spec.whatwg.org/multipage/parsing.html) specification. Which means, that Aspose.HTML will always provide you the correct DOM tree.
- Our JavaScript processing engine supports [ECMA 5.1](http://www.ecma-international.org/ecma-262/5.1/) specification. Which mean, that majority of scripts will be processed during parsing or runtime of the document. We also provide you the ability to [specify JavaScript processing timeout](/html/net/environment-configuration/#environmentconfiguration-runtimeservice) or completely [disable scripts execution](/html/net/environment-configuration/#environmentconfiguration-sandboxing).
- CSS3 is supported out-of-the-box. Aspose.HTML provides an advanced CSS manipulation API and allows to manipulate stylesheets either for the [whole document](/html/net/environment-configuration/#environmentconfiguration-userstylesheet) or for the [particular node](/html/net/editing-a-document/#editingadocument-editcss). 
- HTML Canvas is also supported by Aspose.HTML. You can draw on it, using [JavaScript](/html/net/edit-html5-canvas-programmatically/) or [HTML Canvas API](/html/net/edit-html5-canvas-programmatically/#edithtml5canvasprogrammatically-canvasrenderingcontext2d).
- SVG parsing and rendering is based on the lates [SVG 2.0 documentation](https://www.w3.org/TR/SVG2/). Which allows you to use such modern elements as filters!
## **Platform Independence**
- You can use Aspose.HTML for .NET to build any type of a 32-bit or 64-bit .NET application including ASP.NET, WCF, WinForms, .NET Core etc. 
- Aspose.HTML for .NET runs on both Windows and Linux operating systems.
- Full support of all the .NET Framework versions starting from 2.0 and higher, including Client Profile versions.
- Aspose.HTML provides you the .NET Standard 2.0 assembly, which can be used with frameworks that implement it, such as .NET Core 2.0.
## **Helpful Extensions**
- **Form Editor** -  is an utility class, which allows you to easily edit and submit HTML forms. You can find usage examples and detailed description on this [page](/html/net/html-form-editor/).
- **Vendor Specific CSS** - Aspose.HTML provides you its own CSS properties, which extend existing ones. As an example they can be used to [add page numbers](/html/net/css-extensions/).
