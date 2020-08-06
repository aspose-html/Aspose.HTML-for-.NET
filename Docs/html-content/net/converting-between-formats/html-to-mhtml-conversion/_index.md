---
title: HTML to MHTML Conversion
type: docs
weight: 50
url: /net/html-to-mhtml-conversion/
---

In this article, you will find information on how to convert an [HTML](https://en.wikipedia.org/wiki/HTML) to [MHTML](https://en.wikipedia.org/wiki/MHTML) and how to use [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions).

{{% alert color="primary" %}} 

<https://products.aspose.app/html/conversion/html-to-mhtml> 

{{% /alert %}} 

The static methods of the [Converter](https://apireference.aspose.com/net/html/aspose.html.converters/converter) class are primarily used as the easiest way to convert an HTML code into various formats. You can convert HTML to MHTML in your C# application literally with a single line of code!

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMHTML-WithASingleLine.cs" >}}

The next example explains how to convert HTML to PDF by line by line:

1. Load the HTML file using [HtmlDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument) class
1. Create an instance of [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions)
1. Use the [ConvertHTML()](https://apireference.aspose.com/net/html/aspose.html.converters.converter/converthtml/methods/1) method of [Converter](https://apireference.aspose.com/net/html/aspose.html.converters/converter) class to save HTML as an MHTML file. You need to pass the [HTMLDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument), [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions), and output file path to the ConvertHTML() method to convert HTML to MHTML.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMHTML-ConvertHTMLDocumentToMHTML.cs" >}}
## **Save Options**
[MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions) allows you to customize the rendering process. You can specify the [UrlRestriction](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/urlrestriction), [MaxHandlingDepth](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/maxhandlingdepth), etc. The following example shows how to use [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions) *and* create a PDF file with custom page-size and background color:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMHTML-SpecifyMHTMLSaveOptions.cs" >}}

To learn more about [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions) please read [Fine-Tuning Converters](/html/net/fine-tuning-converters/) article.
