---
title: Aspose.Html for Java 17.10 Release Notes
type: docs
weight: 30
url: /java/aspose-html-for-java-17-10-release-notes/
---

We are pleased to announce that our JavaScript engine has been further improved and now it also supports jQuery library inside the document scripts. Currently it supports the version 1.9, but we are working hard to enhance it and increase the support till latest version.
#### **Features and Improvements**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLJAVA-44|NullPointerException in rendering html|Exception|
|HTMLJAVA-50|Windows-style path separator on non-Windows platforms|Bug|
#### **Public API changes**
com.aspose.html.collections.HTMLCollection com.aspose.html.dom.Document.getElementsByClassName(String classNames)

` `com.aspose.html.collections.HTMLCollection com.aspose.html.dom.Element.getElementsByClassName(String classNames)

**Usage Example**

**input.html**

{{< highlight html >}}

 <html>

    <body>

        <p>hello word1</p>

        <p class="test">hello word2</p>

        <p>hello word3</p>

        <p>hello word4</p>

    </body>

</html>

{{< /highlight >}}

HTMLDocument document = new HTMLDocument("input.html");
HTMLCollection elements = document.getElementsByClassName("test");
Element element = elements.get_Item(0); // // <p>hello word2</p>
