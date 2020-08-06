---
title: FAQ
type: docs
weight: 70
url: /net/faq/
---

![todo:image_alt_text](faq_1.png)

Q: How to convert HTML document to PDF?

**Answer:**

It is very simple. You can do this literally with a single line of code! 

{{< highlight csharp >}}

 Aspose.Html.Converters.Converter.ConvertHTML("document.html", new PdfSaveOptions(), "output.pdf");

{{< /highlight >}}

For more examples, please visit [Converting Between Formats](/html/net/converting-between-formats/) guides.

![todo:image_alt_text](faq_1.png)

Q: What formats does Aspose.HTML support?

**Answer:** 

Out-of-the-box we support (X)HTML, SVG, EPub, MHTML and Markdown documents. As a part of mentioned documents we also support CSS, JavaScript, XPath and HTML5 Canvas specifications. For more details, please visit [Features List](/html/net/features-list/) page.

![todo:image_alt_text](faq_1.png)

Q: Can I use HTMLDocument to load EPub file format?

**Answer:** 

In order to load EPUB, MHTML, SVG or other supported formats, we prepared specialized end-points and described it in the [Create Document](/html/net/creating-a-document/) guide. The HTMLDocument class is designed only to work with HTML files.

![todo:image_alt_text](faq_1.png)

Q: Can I use Aspose.HTML to extract information from a document?

**Answer:** 

Sure, we have a powerful API to inspect the content of HTML documents. It is described in [Web Scraping](/html/net/web-scraping/) article.

![todo:image_alt_text](faq_1.png)

Q: Do you support XPath syntax?

**Answer:** 

Yes.

Moreover, we support CSS Selectors and the native navigation mechanism that is called Document/Element Traversal. You can find the usage examples [here](/html/net/web-scraping/#webscraping-xpath).

![todo:image_alt_text](faq_1.png)

Q: Is it possible to save a few HTML documents at once?

**Answer:** 

Yes, if you have HTML files which are linked to each other, you can use [MaxHandlingDepth](/html/net/saving-a-document/) parameter to save them as a set of files.

![todo:image_alt_text](faq_1.png)

Q: Is it possible to disable JavaScript for a Document?

**Answer:** 

Yes. You should use [**sandboxing flags**](/html/net/environment-configuration/)* *to disable potentially untrusted resources.

![todo:image_alt_text](faq_1.png)

Q: How to use the MemoryStream object to store the rendering result instead of the file system?

**Answer:** 

You can implement *Aspose.Html.IO.ICreateStreamProvider* interface to handle the output streams, as it’s described [here](/html/net/output-streams/).

![todo:image_alt_text](faq_1.png)

Q: How to check the list of resources that are loaded along with an HTML document?

**Answer:** 

We have a specialized [Network Service](/html/net/environment-configuration/) that gives you full control over the all request/response messages. You can use it to trace the requests, create a custom cache, substitute the content of response messages and much more.

![todo:image_alt_text](faq_1.png)

Q: How to override the document style?

**Answer:** 

There is a ‘[User Style Sheet](/html/net/environment-configuration/)’ property that can be useful exactly for this purpose.

![todo:image_alt_text](faq_1.png)

Q: My document does not parse properly, I see black-squares instead of letters! How can I fix it?

**Answer:** 

We parse a document headers to detect the character-set (encoding) of the document. If the encoding is not defined we use UTF-8, which is defined as a default for HTML5 specification. If you know that encoding is different from the default UTF-8, please specify it directly as it described [here](/html/net/environment-configuration/).

![todo:image_alt_text](faq_1.png)

Q: I want to see page numbers at the bottom of the document, how to do this?

**Answer:** 

Since CSS is used to describe the visual layout of the document, we designed specialized [CSS Extensions](/html/net/css-extensions/) that can be used to write information on page margins.
