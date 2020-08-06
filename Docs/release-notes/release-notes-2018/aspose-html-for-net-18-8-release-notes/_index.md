---
title: Aspose.HTML for .NET 18.8 Release Notes
type: docs
weight: 50
url: /net/aspose-html-for-net-18-8-release-notes/
---

### **Aspose.HTML for .NET 18.8 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the August release of Aspose.HTML for .NET. In this release, we have improved rendering into output devices running under .NET Standard on Linux platform. Moreover, we have made some bug fixes and enhancements as listed in the table below:
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1336|Apply Header and footer during HTML to PDF|Enhancement|
|HTMLNET-1381|HTML to PDF - Bullets and text are not appearing in RTL format|Bug|
|HTMLNET-1341|Image opacity is ignored in generated PDF|Bug|
|HTMLNET-1347|Problems while rendering HTML to TIFF|Bug|
|HTMLNET-1354|Problem converting HTML to PNG|Bug|
|HTMLNET-1403|NullReferenceException during HTML to PDF conversion|Bug|
|HTMLNET-1283|HTML to PDF - doesn't wait for $(document).ready()|Bug|
### **Public API changes**
{{% alert color="primary" %}} 

This section lists public API changes that were introduced in Aspose.HTML for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in Aspose.HTML which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.

{{% /alert %}} 
#### **Added APIs:**
DocumentFragment was extended with IParentNode interface, following methods were implemented respectively.
{{< highlight java >}}

 namespace Aspose.Html.Dom

{

    /// <summary>

    /// DocumentFragment is a "lightweight" or "minimal" Document object. It is very common to want to be able to extract a portion of a document's tree or to create a new fragment of a document.

    /// </summary>

    public class DocumentFragment : Node, IParentNode

    {

        /// <summary>

        /// Returns the child elements of current element.

        /// </summary>

        /// <value>

        /// The children collection

        /// </value>

        public HTMLCollection Children { get; }

        /// <summary>

        /// Returns the first child element node of this element. null if this element has no child elements.

        /// </summary>

        /// <value>

        /// The first element child.

        /// </value>

        public Element FirstElementChild { get; }

        /// <summary>

        /// Returns the last child element node of this element. null if this element has no child elements.

        /// </summary>

        /// <value>

        /// The last element child.

        /// </value>

        public Element LastElementChild { get; }

        /// <summary>

        /// Returns the previous sibling element node of this element. null if this element has no element sibling nodes that come before this one in the document tree.

        /// </summary>

        public Element PreviousElementSibling { get; }

        /// <summary>

        /// Returns the next sibling element node of this element. null if this element has no element sibling nodes that come after this one in the document tree.

        /// </summary>

        public Element NextElementSibling { get; }

        /// <summary>

        /// Returns the current number of element nodes that are children of this element. 0 if this element has no child nodes that are of nodeType 1.

        /// </summary>

        /// <value>

        /// The child element count.

        /// </value>

        public int ChildElementCount { get; }

        /// <summary>

        /// Returns the first Element in document, which match selector

        /// </summary>

        /// <param name="selector">The selector.</param>

        /// <returns>The matched element</returns>

        public Element QuerySelector(string selector) {...}

        /// <summary>

        /// Returns a NodeList of all the Elements in document, which match selector

        /// </summary>

        /// <param name="selector">The selector</param>

        /// <returns>

        ///   <see cref="HTMLCollection" />

        /// </returns>

        public NodeList QuerySelectorAll(string selector) {...}

    }

}

{{< /highlight >}}
Added ability to set up default background color for the output documents.
{{< highlight java >}}

 namespace Aspose.Html.Rendering

{

    public class RenderingOptions

    {

        /// <summary>

        /// Gets or sets <see cref="Color"/> which will fill background of every page. Default value is <see cref="Color.Transparent"/>.

        /// </summary>

        public Color BackgroundColor { get; set; }

    }

}

{{< /highlight >}}




