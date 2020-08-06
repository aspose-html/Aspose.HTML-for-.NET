---
title: HTML to Markdown Conversion
type: docs
weight: 40
url: /net/html-to-markdown-conversion/
---

[Markdown](http://en.wikipedia.org/wiki/Markdown) is a markup language with a plain-text-formatting syntax. Markdown is often used as a format for documentation and readme files, since it allows writing in an easy-to-read and easy-to-write style. Its design allows it to be easily converted to many output formats, but originally it was created to convert the only to HTML. Aspose.HTML class library provides a reversed conversion from HTML to Markdown. You can convert HTML to Markdown format in your C# and other .NET programming languages. The following code snippet shows how to convert HTML to Markdown literally with a single line of code!

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMarkdown-WithASingleLine.cs" >}}

{{% alert color="primary" %}} 

<https://products.aspose.app/html/conversion/md>

{{% /alert %}} 
## **Save Options**
The [MarkdownSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/markdownsaveoptions) has a number of properties that give you control over the conversion process. The most important option is [MarkdownSaveOptions.Features](https://apireference.aspose.com/net/html/aspose.html.saving/markdownsaveoptions/properties/features). This option allows you to enable/disable the conversion of the particular element.

The following example shows how to process the only links, images, and paragraphs, other HTML elements remain as is.

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMarkdown-SpecifyMarkdownSaveOptions.cs" >}}

To convert HTML to Markdown you can define your own set of rules or use the predefined templates. For instance, you can use the template based on [GitLab Flavored Markdown](https://guides.github.com/features/mastering-markdown/) syntax:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMarkdown-ConvertUsingGitSyntax.cs" >}}
## **Limitation**
Markdown is a lightweight and easy-to-use syntax. Not all HTML elements are possible to convert to Markdown since there is no equivalent in Markdown syntax. The elements such as [STYLE](https://html.spec.whatwg.org/multipage/semantics.html#the-style-element), [SCRIPT](https://html.spec.whatwg.org/multipage/scripting.html#the-script-element), [LINK](https://html.spec.whatwg.org/multipage/semantics.html#the-link-element), [EMBED](https://html.spec.whatwg.org/multipage/iframe-embed-object.html#the-embed-element), etc. will be discarded during conversion.
### **Inline HTML**
Markdown allows you to specify the pure HTML code, which will be rendered as is. The feature, which allows this behaviour, is called "Inline HTML". In order to use it, you should place one of the specific elements, supported by this feature, at the beginning of new line. Or you can mark one of such elements as "Inline HTML", by adding the attribute *markdown* with the value *inline* to this element. Here is small example, which demonstrate, how to use this attribute:

{{< gist "aspose-com-gists" "f3606888162b6b9cad4e80c485ee4ec3" "Examples-CSharp-ConvertingBetweenFormats-ConvertHTMLToMarkdown-InlineHTML.cs" >}}

As you can see, content of the div element is not converted to Markdown and is treated by Markdown Processor as-is. The list of elements, which support this feature, is different for every Markdown processor.

The original Markdown specification supports these tags: BLOCKQUOTE,H1, H2, H3, H4, H5, H6, P, PRE, OL, UL, DL, DIV, INS, DEL, IFRAME, FIELDSET, NOSCRIPT, FORM, MATH.

The GitLab Flavored Markdown extends this list with the next tags: ARTICLE, FOOTER, NAV, ASIDE, HEADER, ADDRESS, HR, DD, FIGURE, FIGCAPTION, ABBR, VIDEO, AUDIO, OUTPUT, CANVAS, SECTION, DETAILS, HGROUP, SUMMARY.
### **Features nesting**
Markdown supports a lot of features, but not all of them can be used together. As an example list elements inside of table elements would not be converted. The following table shows what features can be nested. Each feature is a member of the [MarkdownFeatures](https://apireference.aspose.com/net/html/aspose.html.saving/markdownfeatures) enumeration.

|**Parent feature** |**Features which can be processed inside**|
| :- | :- |
|Header |Link, Emphasis, Strong, InlineCode, Image, Strikethrough, Video |
|Blockquote |Any |
|List |AutomaticParagraph, Link, Emphasis, Strong, InlineCode, Image, LineBreak, Strikethrough, Video, TaskList, List |
|Link |Emphasis, Strong, InlineCode, Image, LineBreak, Strikethrough |
|AutomaticParagraph |Link, Emphasis, Strong, InlineCode, Image, LineBreak, Strikethrough |
|Strikethrough |Link, Emphasis, Strong, InlineCode, Image, LineBreak |
|Table |Video, Strikethrough, Image, InlineCode, Emphasis, Strong, Link |
|Emphasis |Link, InlineCode, Image, LineBreak, Strikethrough, Video |
|Strong |Link, InlineCode, Image, LineBreak, Strikethrough, Video|

