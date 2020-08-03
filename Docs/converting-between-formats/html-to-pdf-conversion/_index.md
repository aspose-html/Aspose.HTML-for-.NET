---
title: HTML to PDF Conversion
type: docs
weight: 20
url: /net/html-to-pdf-conversion/
---

In this article, you will find information on how to convert an [HTML](https://en.wikipedia.org/wiki/HTML) to [PDF](https://en.wikipedia.org/wiki/PDF) and how to use [PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptions) and [ICreateStreamProvider](https://apireference.aspose.com/net/html/aspose.html.io/icreatestreamprovider) parameters.

{{% alert color="primary" %}} 

<https://products.aspose.app/html/conversion/html-to-pdf> 

{{% /alert %}} 

The static methods of the [Converter](https://apireference.aspose.com/net/html/aspose.html.converters/converter) class are primarily used as the easiest way to convert an HTML code into various formats. You can convert HTML to PDF in your C# application literally with a single line of code!

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToPDF-WithASingleLine.cs" >}}

The next example explains how to convert HTML to PDF by line by line:

1. Load the HTML file using [HtmlDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument) class.
1. Create an instance of [PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptions).
1. Use the [ConvertHTML()](https://apireference.aspose.com/net/html/aspose.html.converters.converter/converthtml/methods/1) method of [Converter](https://apireference.aspose.com/net/html/aspose.html.converters/converter) class to save HTML as a PDF file. You need to pass the [HTMLDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument), [PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptionsQ), and output file path to the ConvertHTML() method to convert HTML to PDF.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToPDF-ConvertHTMLDocumentToPDF.cs" >}}
## **Save Options**
[PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptions) allows you to customize the rendering process. You can specify the [page size](https://apireference.aspose.com/net/html/aspose.html.rendering/renderingoptions/properties/pagesetup), [margins](https://apireference.aspose.com/net/html/aspose.html.drawing/page/properties/margin), [file permissions](https://apireference.aspose.com/net/html/aspose.html.rendering.pdf.encryption/pdfencryptioninfo), [CSS media-type](https://apireference.aspose.com/net/html/aspose.html.rendering/mediatype), etc. The following example shows how to use [PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptions) *and* create a PDF file with custom page-size and background color:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToPDF-SpecifyPdfSaveOptions.cs" >}}

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.HTML for .NET x.x.x will be displayed against these fields.

To learn more about [PdfSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/pdfsaveoptions) please read [Fine-Tuning Converters](/html/net/fine-tuning-converters/) article.
## **Output Stream Providers**
If it is required to save files in the remote storage (e.g., cloud, database, etc.) you can implement [ICreateStreamProvider](https://apireference.aspose.com/net/html/aspose.html.io/icreatestreamprovider) interface to have manual control over the file creating process. This interface designed as a callback object to create a stream at the beginning of the document/page (depending on the output format) and release the early created stream after rendering document/page.

{{% alert color="primary" %}} 

Aspose.HTML for .NET provides various types of output formats for rendering operations. Some of these formats produce a single output file (for instance PDF, XPS), others create multiple files (Image formats JPG, PNG, etc.).

{{% /alert %}} 

The example below shows how to implement and use the your own *MemoryStreamProvider* in the application:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-MemoryStreamProvider.cs" >}}

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToPDF-SpecifyCustomStreamProvider.cs" >}}



