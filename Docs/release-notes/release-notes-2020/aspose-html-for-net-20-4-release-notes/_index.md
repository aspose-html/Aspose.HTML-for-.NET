---
title: Aspose.HTML for .NET 20.4 Release Notes
type: docs
weight: 90
url: /net/aspose-html-for-net-20-4-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes information for Aspose.HTML for .NET 20.4.

{{% /alert %}} 

As per the regular monthly update process of all APIs being offered by Aspose, we are honored to announce the April release of Aspose.HTML for .NET.
In this release, we have made a number of improvements related to the CSS processing algorithm and the quality of rendering. These include:

- Increase in quality of inline styles serialization
- Updated parsing of the font-family property according to the CSS3 documentation
- Introduction of processing of the column group borders
- Improved positioning of the float images

We have also made some minor usability improvements in this release such as clarified the URL parsing exceptions and added new signatures to the Document creation methods.
## **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-2508|Memory leak during rendering to image|Bug|
|HTMLNET-2417|On conversion to TIFF some images overlap and part of the text overlaps an image|Bug|
|HTMLNET-2511|CssStyle changing error|Bug|
|HTMLNET-2205|HTML to Image - no borders for table|Bug|
|HTMLNET-2493|HTML not properly converted to PDF|Bug|
## **Public API and Backward Incompatible Changes**
We have added new signatures to the Document creation methods. Now you can specify a base URL using the [URL](https://apireference.aspose.com/net/html/aspose.html/url) class.



{{< highlight java >}}

 namespace Aspose.Html.Dom

{

    public class Document : Node, IDocumentTraversal, IXPathEvaluator, IDocumentEvent, IParentNode, INonElementParentNode, IDocumentStyle, IGlobalEventHandlers

    {

        /// <summary>

        /// Loads the document from specified content and using baseUri to resolve relative resources, replacing the previous content.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI to resolve relative resources.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public void Navigate(string content, Url baseUri);

        /// <summary>

        /// Loads the document from specified content and using baseUri to resolve relative resources, replacing the previous content.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI to resolve relative resources.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public void Navigate(Stream content, Url baseUri);

    }

}

namespace Aspose.Html

{

    public class HTMLDocument : Document, IDocumentCSS

    {

        /// <summary>

        /// Initializes a new instance of the <see cref="HTMLDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(string, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public HTMLDocument(string content, Url baseUri);

        /// <summary>

        /// Initializes a new instance of the <see cref="HTMLDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(string, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public HTMLDocument(string content, Url baseUri, Configuration configuration);

        /// <summary>

        /// Initializes a new instance of the <see cref="HTMLDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(Stream, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public HTMLDocument(Stream content, Url baseUri);

        /// <summary>

        /// Initializes a new instance of the <see cref="HTMLDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(Stream, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public HTMLDocument(Stream content, Url baseUri, Configuration configuration);

    }

}

namespace Aspose.Html.Dom.Svg

{

    public class SVGDocument : Document, IDocumentCSS

    {

        /// <summary>

        /// Initializes a new instance of the <see cref="SVGDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(Stream, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public SVGDocument(Stream content, Url baseUri);

        /// <summary>

        /// Initializes a new instance of the <see cref="SVGDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(Stream, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The configuration.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public SVGDocument(Stream content, Url baseUri, Configuration configuration);

        /// <summary>

        /// Initializes a new instance of the <see cref="SVGDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(string, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public SVGDocument(string content, Url baseUri);

        /// <summary>

        /// Initializes a new instance of the <see cref="SVGDocument"/> class. Constructor works synchronously, it waits for loading of all the external resources (images, scripts, etc.).

        /// To load document asynchronously use method <see cref="Document.Navigate(string, Url)"/> or its overloads.

        /// Or you can disable loading of some external resources by setting appropriate flags in <see cref="IBrowsingContext.Security"/>.

        /// </summary>

        /// <param name="content">The document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The configuration.</param>

        /// <exception cref="ArgumentNullException"><c>baseUri</c> is <c>null</c>.</exception>

        public SVGDocument(string content, Url baseUri, Configuration configuration);

    }

}

{{< /highlight >}}
