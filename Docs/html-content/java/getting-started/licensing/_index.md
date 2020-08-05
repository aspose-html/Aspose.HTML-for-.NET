---
title: Licensing
type: docs
weight: 60
url: /java/licensing/
---

## **Evaluation Version Limitations**
We want our customers to test our components thoroughly before buying so the evaluation version allows you to use it as you would normally.

**HTML created with an evaluation watermark**

The evaluation version of Aspose.HTML for Java provides full product functionality, but all the pages in the generated HTML file are watermarked with "Aspose.HTML Evaluation Only. Created with Aspose.HTML. Copyright 2002-2017 Aspose Pty Ltd." at the top.

**Limit of the Number of Collection Items that can be Processed**

The evaluation version (without a license initialization) provides full product functionality, but it has two limitations: it inserts an evaluation watermark, and only four elements of any collection can be manipulated/converted. Please note that currently our API provides following two features

1. Working with document features
1. Conversion Features

For “conversion features”, we insert an evaluation watermark and convert only first four pages.

For “Working with Document Features”, we limit the saving operation by adding watermark into every image on the page and insert “Evaluation Text” on the document. It’s only way to limit “working with a document features”. However currently we are not limiting any collections, because it affects the JS Scripts and rendering features.
## **Apply License using File or Stream Object**
The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the aspose-html-xx.x.jar file and specify the filename, without a path, as shown in the example below.

{{% alert color="primary" %}} 

If you use are using any other Aspose for Java component along with Aspose.HTML for Java, please specify complete namespace for License like com.aspose.html.License.

{{% /alert %}} 
### **Loading a License from File**
The easiest way to apply a license is to put the license file in the same folder as the Aspose.HTML.jar file and specify just the filename without a path.

When you call the setLicense method, the license name that you pass should be that of your license file. For example, if you change the license file name to "Aspose.HTML.lic.xml" pass that filename to the com.aspose.html.License.setLicense(…) method. The license file can be specific for Aspose.HTML for Java or you can use Aspose.Total for Java license file.

{{< highlight java >}}

     // instantiate License object

    com.aspose.html.License license = new com.aspose.html.License();

    // license file path information

    license.setLicense("Aspose.HTML.lic");

{{< /highlight >}}
### **Loading a License from a Stream Object**
The following example shows how to load a license from a stream.

{{< highlight java >}}

 // Initialize License Instance

com.aspose.html.License license = new com.aspose.html.License();

// Set license from Stream

license.setLicense(new java.io.FileInputStream("Aspose.HTML.lic"));    

{{< /highlight >}}
