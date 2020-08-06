---
title: Aspose.HTML for Java 19.3 Release Notes
type: docs
weight: 60
url: /java/aspose-html-for-java-19-3-release-notes/
---

### **Aspose.HTML for Java 19.3.0 Release Notes**
-----
##### **Major Features**
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the March release of Aspose.HTML for Java. The main improvement of this release is that we created a truly parallel mechanism of processing the documents that significantly improved performance of processing the documents with lot of resources. Moreover, from this release you do not need to wait until document will be loaded, parsed and all scripts will be executed which of course is blocking the main thread of your application. You just need to subscribe to events the 'OnReadyStateChange' or 'OnLoad' and call the method 'navigate' that is not blocking main thread. Once the document is ready, these events will be fired. Also, we present a new package 'com.aspose.html.dom.mutations' that provides mechanisms to watch for changes being made to the DOM tree. Apart from these, we have made some internal bug fixes and enhancements as following:
### **Improvement and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLJAVA-109|Unable to convert HTML to PDF|Bug|
|HTMLJAVA-131|Image opacity is ignored in generated PDF|Bug|
|HTMLJAVA-185|The size parameter is not counted during the SVG rendering process|Bug|
|HTMLJAVA-211|TypeError: Failed to parse URL|Bug|
### **Added APIs:**
Added the overridden method ICSSStyleDeclaration.SetProperty to simplify the declaration object usage.

namespace Aspose.Html.Dom.Css
{
`    `public interface ICSSStyleDeclaration : IEnumerable<string>, ICSS2Properties
`    `{
`        `/// <summary>
`        `/// Used to set a property value within this declaration block.
`        `/// </summary>
`        `/// <param name="propertyName">The name of the CSS property.</param>
`        `/// <param name="value">The property value.</param>
`        `void SetProperty(string propertyName, string value);
`    `}
}
