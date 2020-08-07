---
title: Aspose.HTML for .NET 20.2 Release Notes
type: docs
weight: 110
url: /net/aspose-html-for-net-20-2-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes information for Aspose.HTML for .NET 20.2.

{{% /alert %}} 

As per the regular monthly update process of all APIs being offered by Aspose, we are honored to announce the February release of Aspose.HTML for .NET.
In this release we have made some improvements to the quality of rendering, these improvements include:

- Improvements in the splitting of float elements
- Improvements in the font selection algorithm
- Improvements in the size calculation of SVG images

Also, we have introduced new property, which allows you to specify the JavaScript processing timeout. It can be used to speed up the rendering process or to stop the execution of infinite JavaScripts.
## **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-2267|HTM to Image: line break issue|Bug|
|HTMLNET-2404 |HTML to PDF - Some words are turned into white grid|Bug|
|HTMLNET-2319 |Null reference exception during html to image conversion|Bug|
## **Public API and Backward Incompatible Changes**
### **Added APIs**
Added new service **IRuntimeService**, which provides **JavaScriptTimeout** property, that allows you to specify JavaScript processing timeout. It can be used to speed up the rendering process or to stop the execution of infinite JavaScripts.

{{< highlight java >}}

 namespace Aspose.Html.Services

{

    /// <summary>

    /// This service is used to configure runtime related properties.

    /// </summary>

    public interface IRuntimeService : IService

    {

        /// <summary>

        /// Gets or sets <see cref="TimeSpan"/> which limits JavaScript execution time. If script is executed longer than provided <see cref="TimeSpan"/>, it will be cancelled. You can specify infinite timeout by setting <see cref="TimeSpan"/> equal to -1 millisecond. Default value is 1 minute.

        /// </summary>

        TimeSpan JavaScriptTimeout { get; set; }

    }

}

{{< /highlight >}}

