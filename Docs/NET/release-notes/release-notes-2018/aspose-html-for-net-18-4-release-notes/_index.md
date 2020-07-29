---
title: Aspose.HTML for .NET 18.4 Release Notes
type: docs
weight: 100
url: /net/aspose-html-for-net-18-4-release-notes/
---

### **Aspose.HTML for .NET 18.4 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are pleased to announce the April release of Aspose.HTML for .NET. In this release, we have made some internal bug fixes related to the document rendering. Additionally, we have improved the mechanism of the external fonts loading and introduced 'Text Rendering Options' object in order to give user an ability configure the text rendering quality.
### **Improvement and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1037|HTML to PNG - not same image quality|Bug|
|HTMLNET-1038|HTML to PNG - missing symbols|Bug|
|HTMLNET-1045|CSS properties are ignored|Bug|
|HTMLNET-1044|Styles are ignored in a large HTML file|Bug|
|HTMLNET-965|Incorrect HTML to PDF rendering|Bug|
|HTMLNET-1024|System.ArgumentNullException occurred at Render() method|Bug|
|HTMLNET-1079|An exception raises while loading document from HTML file|Bug|
### **Public API changes**
#### **Added APIs:**
{{< highlight java >}}

 //  TextOptions has been introduced in order to specify text rendering quality options

class Aspose.Web.Rendering.Rendering.Image.TextOptions

property Aspose.Web.Rendering.Rendering.Image.TextOptions.TextRenderingHint

// ImageRenderingOptions object has been extended by adding 'Text Rendering Options' property

property Aspose.Html.Rendering.Image.ImageRenderingOptions.Text

// Added possibility to specify CSS parsing rules by setting CSSEngineMode enumeration

enumeration Aspose.Html.Dom.Css.CSSEngineMode

{{< /highlight >}}
