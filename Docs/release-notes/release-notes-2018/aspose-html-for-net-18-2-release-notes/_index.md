---
title: Aspose.HTML for .NET 18.2 Release Notes
type: docs
weight: 120
url: /net/aspose-html-for-net-18-2-release-notes/
---

### **Aspose.HTML for .NET 18.2 Release Notes**
-----
As regular monthly update process of all APIs being offered by Aspose, we are pleased to announce the February's Release of Aspose.HTML for .NET. In this release, we have added support for Aspose Metered License mechanism; reworked the request message object and created more flexible way to set up the message content as well as user credentials; we have improved the rendering options and added capability to specify CSS MediaType. Also, we have reorganized caching mechanism and increased the document loading performance.
### **Improvement and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-864|Support for metered license|Enhancement|
|HTMLNET-887|HTML to PNG image conversion|Enhancement|
|HTMLNET-888|Support for media commands @print and @screen|Enhancement|
|HTMLNET-889|The RequestMessage.Method property does not work|Bug|
|HTMLNET-820|"input" elements of HTML5 type is not rendered|Bug|
### **Public API changes**
#### **Added APIs:**
{{< highlight java >}}

 // Default and overloading constructors have been added.

Aspose.HTML.Dom.Svg.SVGDocument.#ctor

Aspose.HTML.Dom.Svg.SVGDocument.#ctor(Aspose.HTML.Net.RequestMessage)

// Aspose Metered Licensing mechanism has been added. Please, see https://purchase.aspose.com/faqs/licensing/metered for additional information.

Aspose.HTML.Metered

Aspose.HTML.Metered.SetMeteredKey(System.String,System.String)

Aspose.HTML.Metered.GetConsumptionQuantity

//Provides HTTP content based on different data types and headers.

Aspose.HTML.Net.Content

Aspose.HTML.Net.ByteArrayContent

Aspose.HTML.Net.StreamContent

Aspose.HTML.Net.StringContent

Aspose.HTML.Net.FormUrlEncodedContent

//Provides extended properties to setup the request message.

Aspose.HTML.Net.RequestMessage.Credentials

Aspose.HTML.Net.RequestMessage.PreAuthenticate

Aspose.HTML.Net.RequestMessage.CookieContainer

Aspose.HTML.Net.RequestMessage.Timeout

// This is specialized object to describe the HTTP Content-Type header parameter.

Aspose.HTML.Net.Headers.ContentTypeHeaderValue



// Added possibility to specify the CSS media type during the rendering, the default value has been changed from 'Screen' to 'Print'. In order to receive an old behavior, please specify 'Screen' type.

Aspose.HTML.Rendering.RenderingOptions.Css.MediaType

enumeration Aspose.HTML.Rendering.MediaType


// Since the 'page size' and 'page margin' could be defined both in CSS styles of document and user setting to resolve the priority conflict we have introduced 'AtPagePriority' property.

Aspose.HTML.Rendering.PageSetup.AtPagePriority

enumeration Aspose.HTML.Rendering.AtPagePriority

{{< /highlight >}}
#### **Changed APIs:**
{{< highlight java >}}

 Aspose.HTML.Net.RequestMessage.Body

Aspose.HTML.Net.ResponseMessage.Body

// The 'Body' property has been replaced with Aspose.HTML.Net.Content object.

// The inherited types Aspose.HTML.Net.ByteArrayContent, Aspose.HTML.Net.StreamContent, Aspose.HTML.Net.StringContent and Aspose.HTML.Net.FormUrlEncodedContent are available to set as a message content.

Aspose.HTML.Net.RequestMessage.Content

{{< /highlight >}}
#### **Removed APIs:**
{{< highlight java >}}

 // ContentEncoding and ContentType properties have been moved to the specialized Aspose.HTML.Net.ResponseHeaders.ContentType property.

Aspose.HTML.Net.ResponseMessage.Content

EncodingAspose.HTML.Net.ResponseMessage.ContentType

{{< /highlight >}}






