---
title: Aspose.HTML for .NET 18.7 Release Notes
type: docs
weight: 60
url: /net/aspose-html-for-net-18-7-release-notes/
---

### **Aspose.HTML for .NET 18.7 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the July release of Aspose.HTML for .NET. In this release we have refactored and increased the performance of HTML parsing module up to 40%. Also, we have introduced a new vendor prefix -**aspose**- that allows to customize behavior of CSS properties which are in experimental and non standardized state for now. Moreover, we have made some bug fixes and enhancements as listed in the table below:
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1251|Repeat footer for each page of a PDF document|Enhancement|
|HTMLNET-1252|Support to add page numbers while rendering an HTML to PDF|Enhancement|
|HTMLNET-1271|Non English character result in squares in generated PDF file|Bug|
|HTMLNET-1267|MHT file to PDF|Bug|
|HTMLNET-1266|InvalidOperationException while converting HTM file to PDF|Bug|
|HTMLNET-1205|Huge memory consumption|Bug|
|HTMLNET-1276|The Canvas2D API does not support an Image class|Bug|
### **Public API changes**
{{% alert color="primary" %}} 

This section lists public API changes that were introduced in Aspose.HTML for .NET 18.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in Aspose.HTML which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.

{{% /alert %}} 
#### **Added APIs:**
Introduced a new type of Aspose.Html.Forms namespace: ButtonElement object.
{{< highlight java >}}

 /// <summary>

///  The ButtonElement represents a wrapper that is associated with the HTMLButtonElement.

/// </summary>

public class ButtonElement: FormElement<HTMLButtonElement>

{

    /// <summary>

    /// Represent the name attribute of the Button element.

    /// </summary>

    public override string Name { get; set; }

    /// <summary>

    /// Represents the Id attribute of the Button element.

    /// </summary>

    public override string Id { get; set; }

    /// <summary>

    /// Represents the string value of the button element that is directly mapped to the 'value' attribute.

    /// </summary>

    public override string Value { get; set; }

    /// <summary>

    /// Type of the form control.

    /// </summary>

    public ButtonType Type { get; set; }

}

{{< /highlight >}}
Added CSSMarginRule object according to CSS specification.
{{< highlight java >}}

 public interface ICSSMarginRule : ICSSRule

{

    /// <summary>

    /// The name attribute must return the name of the margin at-rule.

    /// </summary>

    string Name { get; }

    /// <summary>

    /// The declaration-block of this rule.

    /// </summary>

    ICSSStyleDeclaration Style { get; }

}

{{< /highlight >}}


Added the overridden methods to the FormSubmitter object that allow to specify CookieContainer during the web request/response operations.
{{< highlight java >}}

 public class FormSubmitter

{

    /// <summary>

    /// Submits the form data to the server with specified cookies.

    /// </summary>

    public SubmissionResult Submit(CookieContainer cookieContainer) {}

    /// <summary>

    ///  Submits the form data to the server with specified user credentials and cookies.

    /// </summary>

    public SubmissionResult Submit(ICredentials credentials, CookieContainer cookieContainer) {}

    /// <summary>

    /// Submits the form data to the server with specified user credentials and cookies.

    /// </summary>

    public SubmissionResult Submit(ICredentials credentials, TimeSpan timeout, bool preAuthenticate, CookieContainer cookieContainer) {}

}

{{< /highlight >}}


The ResponseMessage object has been changed and now supports CookieContainer property.
{{< highlight java >}}

 namespace Aspose.Html.Net

{

    /// <summary>

    /// Represents a response message.

    /// </summary>

    /// <seealso cref="System.IDisposable" />

    public class ResponseMessage : IDisposable

    {

        /// <summary>

        /// Gets or sets the cookie collection.

        /// </summary>

        public CookieCollection Cookies { get; set; }

    }

}

{{< /highlight >}}
The abstract renderer object has been extended with ability to render multiple documents into a single output device; all derived classes HtmlRenderer, SvgRenderer, MhtmlRenderer and EpubRenderer have been extended as well.
{{< highlight java >}}

 public abstract class Renderer<TDocument> : Renderer

{

    /// <summary>

    /// Defines method for rendering multiple <see cref="TDocument"/>s into specific <see cref="IDevice" />.

    /// </summary>

    public abstract void Render(IDevice device, params TDocument[] documents);

}

{{< /highlight >}}




