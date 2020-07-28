---
title: Aspose.HTML for .NET 19.2 Release Notes
type: docs
weight: 110
url: /net/aspose-html-for-net-19-2-release-notes/
---

### **Aspose.HTML for .NET 19.2 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honoured to announce the February release of Aspose.HTML for .NET. In this release, we have made some internal bug fixes related to the document rendering and page splitting algorithms. 
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1629|Problem repeating header on each page|Bug|
|HTMLNET-1736|An exception raises while loading an HTML file|Bug|
|HTMLNET-1550|Problem converting HTML to PDF|Bug|
### **Added APIs:**
Added the overridden method ICSSStyleDeclaration.SetProperty to simplify the declaration object usage.

{{< highlight java >}}

 namespace Aspose.Html.Dom.Css

{

    public interface ICSSStyleDeclaration : IEnumerable<string>, ICSS2Properties

    {

        /// <summary>

        /// Used to set a property value within this declaration block.

        /// </summary>

        /// <param name="propertyName">The name of the CSS property.</param>

        /// <param name="value">The property value.</param>

        void SetProperty(string propertyName, string value);

    }

}

{{< /highlight >}}
