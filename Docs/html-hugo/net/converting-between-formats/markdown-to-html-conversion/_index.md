---
title: Markdown To HTML Conversion
type: docs
weight: 150
url: /net/markdown-to-html-conversion/
---

{{% alert color="primary" %}} 

<https://products.aspose.app/html/markdown> 

{{% /alert %}} 

[Markdown](http://en.wikipedia.org/wiki/Markdown) is a markup language with a plain-text-formatting syntax. Markdown is often used as a format for documentation and readme files since it allows writing in an easy-to-read and easy-to-write style. Its design allows it to be easily converted to many output formats, but initially it was created to convert the only to HTML. Using the Aspose.HTML class library in your C# application, you can easily convert Markdown into HTML file with just a single line of code!

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertMarkdownToHTML-WithASingleLine.cs" >}}

If your scenario is required rendering Markdown document, for instance, to the Image file format, the following example demonstrates how that is simple.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertMarkdownToHTML-ConvertMarkdownToPNG.cs" >}}
## **Markdown Syntax**
This article demonstrates the syntax declared in the [core Markdown specification](https://daringfireball.net/projects/markdown/) and [GitLab Flavored Markdown](https://docs.gitlab.com/ee/user/markdown.html) variation. All these features are supported by Aspose.HTML out-of-the-box.
### **Headers**
Markdown supports two styles of headers, *Setext* and *atx*:



{{< highlight java >}}

 This is an H1

\=============

This is an H2

\-------------

{{< /highlight >}}

{{< highlight java >}}

 # This is an H1

\## This is an H2

\###### This is an H6

{{< /highlight >}}
### **Lists**
Markdown supports ordered (numbered) and unordered (bulleted) lists.

Unordered lists use asterisks, pluses, and hyphens — interchangably — as list markers:

{{< highlight java >}}

 *   Red

\*   Green

\*   Blue

{{< /highlight >}}

Ordered lists use numbers followed by periods:

{{< highlight java >}}

 1.  Bird

\2.  McHale

\3.  Parish

{{< /highlight >}}
### **Images**
Inline image syntax looks like this:

{{< highlight java >}}

 ![Alt text](/path/to/img.jpg)

{{< /highlight >}}
### **Links**
Links syntax looks like this:

{{< highlight java >}}

 [an example](http://example.com/ "Title")

{{< /highlight >}}
### **Emphasis**
Markdown treats asterisks * and underscores (_) as indicators of emphasis:

{{< highlight java >}}

 *single asterisks*

_single underscores_

**double asterisks**

__double underscores__

{{< /highlight >}}
### **Blockquotes**
Markdown uses email-style > characters for blockquoting:

{{< highlight java >}}

 > This is the first level of quoting.

\>

\> > This is nested blockquote.

{{< /highlight >}}
### **Code Block**
To indicate a span of code, wrap it with backtick quotes (`):

{{< highlight java >}}

 javascript

function myFunc() {

   alert('Hello World!!!');

}

\

{{< /highlight >}}
### **Tables**
Tables aren’t part of the core Markdown spec, but they are part of GFM:

{{< highlight java >}}

 | header 1 | header 2 | header 3 |

\| --- | ------ |--------- |

| cell 1 | cell 2 | cell 3 |

{{< /highlight >}}
