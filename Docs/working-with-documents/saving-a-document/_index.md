---
title: Saving a Document
type: docs
weight: 40
url: /net/saving-a-document/
---

{{% alert color="primary" %}} 

Please note that we have two different concepts for creating the output files. The first conception is based on creating the HTML like files as output; the [SaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/saveoptions) as a base class for this approach helps to handle the saving process of related resources such as scripts, styles, images, etc. The second concept could be use to creating a visual representation of HTML as a result. The base class for this conception is [RenderingOptions](https://apireference.aspose.com/net/html/aspose.html.rendering/renderingoptions); it has specialized methods to specify the page size, page-margins, resolution, user-styles, etc. This article only describes how to use [SaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/saveoptions). To read more about the rendering mechanism, please follow this page.

{{% /alert %}} 
## **SaveOptions**
The [SaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/saveoptions) is a base options class for saving operations. It could help you to manage the linked resources. The following table demonstrates the list of available options:

|**Option**|**Description**|
| :- | :- |
|[UrlRestriction](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/urlrestriction)|Applies restrictions to the host or folders where resources are located.|
|[MaxHandlingDepth](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/maxhandlingdepth)|If you need to save not the only specified HTML document, but also the linked HTML pages, this option gives you the ability to control the depth of the linked pages that should be saved.|
|[JavaScript](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/javascript)|This option specifies how do we need to treat the JavaScript files: it could be saved as a separated linked file, embed into HTML file or even be ignored.|
|[Default](https://apireference.aspose.com/net/html/aspose.html.saving/resourcehandlingoptions/properties/default)|This options specifies behavior for other than JavaScript files. |
## **Save HTML**
Once you have finished your changes as it is described here, you may want to save the document. The following example is the easiest way to save HTML file:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-SavingADocument-HTMLToFile.cs" >}}

The sample above is quite simple. However, in real-life applications you often need additional control over the saving process. The next few sections describe how to use resource handling options or save you document to the different formats.
### **HTML to File**
The following code snippet shows how to use [ResourceHandlingOptions](https://apireference.aspose.com/net/html/aspose.html.saving/saveoptions/properties/resourcehandlingoptions) to manage linked to your document files.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-SavingADocument-HTMLWithoutLinkedFile.cs" >}}
### **HTML to MHTML**
In some cases you need to save your document as a single file. [MHTML](https://en.wikipedia.org/wiki/MHTML) document could be very useful for this purpose since it is a web-page archive and it is store everything inside itself. 

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-SavingADocument-HTMLToMHTML.cs" >}}

As well as for [*HTML to File*](/html/net/saving-a-document/#savingadocument-htmltofile) example, you can use [MHTMLSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/mhtmlsaveoptions) and customize the required handling options.
### **HTML to Markdown**
[Markdown](https://en.wikipedia.org/wiki/Markdown) is a markup language with plain-text syntax. In order to create Markdown files by using Aspose.HTML, please take a look at following example:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-SavingADocument-HTMLToMarkdown.cs" >}}

For the more information how to use Markdown Converter, please visit [HTML to Markdown](/html/net/html-to-markdown-conversion/) article.
## **Save SVG**
Usually, you could see the [SVG](https://en.wikipedia.org/wiki/Scalable_Vector_Graphics) document as a part of HTML file, it is used to represent the vector data on the page: images, icons, tables, etc. However, SVG also could be extracted from the web page and you can manipulate it in a similar way as the HTML document.



Since [SVGDocument](https://apireference.aspose.com/net/html/aspose.html.dom.svg/svgdocument) and [HTMLDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument) are based on the same [WHATWG DOM](https://dom.spec.whatwg.org/) standard, the all operations such as loading, reading, editing, converting and saving are similar for both documents. So, the all examples where you can see manipulation with [HTMLDocument](https://apireference.aspose.com/net/html/aspose.html/htmldocument) are applicable for [SVGDocument](https://apireference.aspose.com/net/html/aspose.html.dom.svg/svgdocument) as well.

In order to save your changes, please use as it follows:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WorkingWithDocuments-SavingADocument-SVGToFile.cs" >}}



