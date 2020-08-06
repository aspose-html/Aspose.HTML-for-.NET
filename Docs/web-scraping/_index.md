---
title: Web Scraping
type: docs
weight: 40
url: /net/web-scraping/
---

**Web scraping**, also well known as **web harvesting**, **web data extraction** or **web crawling**, is used for extracting data from websites. A **web scraping software** will help you to automate the process of extracting data based on your requirements. However, configuring **web scraping software** sometimes is a challenging task. Using *Aspose.HTML* class library, you can easily create your own application, since our API provides a powerful toolset to analyze and collect information from HTML documents.
## **HTML navigation**
There are many ways that can be used to make HTML navigation. The following shortlist shows the simplest way to access to all DOM elements:

|**Property**|**Description**|
| :- | :- |
|[FirstChild](https://apireference.aspose.com/net/html/aspose.html.dom/node/properties/firstchild)|Accessing this attribute of an element must return a reference to the first child node.|
|[LastChild](https://apireference.aspose.com/net/html/aspose.html.dom/node/properties/lastchild)|Accessing this attribute of an element must return a reference to the last child node|
|[NextSibling](https://apireference.aspose.com/net/html/aspose.html.dom/node/properties/nextsibling)|Accessing this attribute of an element must return a reference to the sibling node of that element which most immediately follows that element.|
|[PreviousSibling](https://apireference.aspose.com/net/html/aspose.html.dom/node/properties/previoussibling)|Accessing this attribute of an element must return a reference to the sibling node of that element which most immediately precedes that element.|
|[ChildNodes](https://apireference.aspose.com/net/html/aspose.html.dom/node/properties/childnodes)|Returns a [list](https://apireference.aspose.com/net/html/aspose.html.collections/nodelist) that contains all children of that element.|

Using the mentioned properties, you can navigate through an HTML document as it follows:



{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WebScraping-WebScraping-NavigateThroughHTML.cs" >}}

For the more complicated scenarios, when you need to find a node based on a specific pattern (e.g., get the list of headers, links, etc.), you can use a specialized [TreeWalker](https://apireference.aspose.com/net/html/aspose.html.dom.document/createtreewalker/methods/2) or [NodeIterator](https://apireference.aspose.com/net/html/aspose.html.dom.document/createnodeiterator/methods/2) object with a custom [Filter](https://apireference.aspose.com/net/html/aspose.html.dom.traversal.filters/nodefilter) implementation.

The next example shows how to implement your own [NodeFilter](https://apireference.aspose.com/net/html/aspose.html.dom.traversal.filters/nodefilter) to skip all elements except images:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WebScraping-WebScraping-OnlyImageFilter.cs" >}}

Once you implement a filter, you can use HTML navigation as it follows:



{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WebScraping-WebScraping-NodeFilterUsageExample.cs" >}}
## **XPath**
The alternative to the *HTML Navigation* is [XML Path Language](https://www.w3.org/TR/xpath20/). The syntax of the XPath expressions is quite simple and what is more important, it is easy to read and support.

The following example shows how to use XPath queries within Aspose.HTML API::

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WebScraping-WebScraping-XPathQueryUsageExample.cs" >}}
## **CSS Selector**
Along with *HTML Navigation* and *XPath* you can use [CSS Selector API](http://www.w3.org/TR/selectors-4/) that is also supported by our library. This API is designed to create a search pattern to match elements in a document tree based on [CSS Selectors](https://www.w3.org/TR/selectors-3/#selectors) syntax.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-WebScraping-WebScraping-CSSSelectorUsageExample.cs" >}}
