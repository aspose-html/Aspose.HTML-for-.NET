---
title: Licensing
type: docs
weight: 40
url: /net/licensing/
---

## **Evaluate Aspose.HTML for .NET**
You can easily download Aspose.HTML for .NET for evaluation purposes. Please note, that the evaluation version is the same as the purchased version. It becomes licensed when you add a few lines of code to apply the license.

The evaluation version (without a license specified) provides full product functionality, but it has some limitations:

- **Saved HTML files contains the evaluation watermarks.** Some content of the saved HTML document is replaced with the evaluation watermark.
- **Saved SVG files contains the evaluation watermark and limited number of elements.** Some nodes of the saved SVG are removed and the evaluation watermark is added.
- **Converted documents contains the evaluation watermarks and limited number of pages.** Each converted page contains the evaluation watermark and the number of converted pages is limited to four.

{{% alert color="primary" %}} 

If you want to test Aspose.HTML for .NET without the evaluation version limitations, you can also request a 30-day Temporary License. Please refer to [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)

{{% /alert %}} 
## **Applying a License**
Aspose.HTML for .NET provides you the number of ways to apply a license. They will be described in the following paragraphs.

If you are using any other Aspose for .NET component along with Aspose.HTML for .NET, please specify complete namespace for License like[ Aspose.Html.License](https://apireference.aspose.com/html/net/aspose.html/license) or [Aspose.Html.Metered](https://apireference.aspose.com/html/net/aspose.html/metered),
### **Applying a License from Disk or Stream**
The easiest way to apply a license is to put the license file in the same folder as the Aspose.HTML.dll file and specify just the file name without a path.

{{< highlight java >}}

 // Instantiate the License object.

Aspose.Html.License htmlLicense = new Aspose.Html.License();

// Apply a license using the file name.

htmlLicense.SetLicense("Aspose.HTML.lic");

{{< /highlight >}}

It is also possible to apply a license from the license file stream.

{{< highlight java >}}

 // Instantiate the License object.

Aspose.Html.License htmlLicense = new Aspose.Html.License();

// Open the license file stream.

using (var stream = new System.IO.FileStream("Aspose.HTML.lic", System.IO.FileMode.Open))

{

    // Apply a license using the stream.

    htmlLicense.SetLicense(stream);

}

{{< /highlight >}}
### **Applying a License as an Embedded Resource**
Another neat way of packaging the license with your application is to include it as an embedded resource into one of the assemblies that calls Aspose.HTML for .NET. 

To include the license file as an embedded resource, perform the following steps:

1. In Visual Studio, include the .lic file into your project by right clicking it and choosing **Add -> Existing Item...** from the opened menu.
1. Select the file in the Solution Explorer and set **Build Action** **to Embedded resource** in the **Properties** window.
1. In your code, invoke [SetLicense](https://apireference.aspose.com/html/net/aspose.html.license/setlicense/methods/1) passing only the short name of the resource file.

{{< highlight java >}}

 // Instantiate the License object.

Aspose.Html.License htmlLicense = new Aspose.Html.License();

// Apply a license using the embedded resource name.

htmlLicense.SetLicense("Aspose.HTML.lic");

{{< /highlight >}}

{{% alert color="primary" %}} 

Please note, that resources are embedded in to assembly without modification. If you add a text file as an embedded resource in application and open the resultant EXE in notepad, you will see the exact contents of the added text file. So, when using a license file as an embedded resource, anyone can open EXE file in some simple text editor and see/extract the contents of the embedded license.

{{% /alert %}} 
### **Applying a Metered License**
Metered license - is a new licensing mechanism, which is used along with existing licensing method. Those customers who want to be billed based on the usage of the API features can use the metered licensing. For more details, please refer to the [Metered Licensing FAQ](http://www.aspose.com/corporate/purchase/policies/Licensing-Faqs/metered-faq.aspx) section.

The following code snippet demonstrates how to apply the metered license using the private and public keys:

{{< highlight java >}}

 // Instantiate the Metered object.

Aspose.Html.Metered metered = new Aspose.Html.Metered();

// Apply the metered license using the public and private keys.

metered.SetMeteredKey("*****", "*****");

{{< /highlight >}}
