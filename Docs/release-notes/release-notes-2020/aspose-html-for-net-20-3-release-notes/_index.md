---
title: Aspose.HTML for .NET 20.3 Release Notes
type: docs
weight: 100
url: /net/aspose-html-for-net-20-3-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes information for Aspose.HTML for .NET 20.3.

{{% /alert %}} 

As per the regular monthly update process of all APIs being offered by Aspose, we are honored to announce the March release of Aspose.HTML for .NET. In this release, we have improved the handling of broken fonts and invalid URLs. We have also made some improvements to the rendering process that includes:

- Handling of the negative table margins
- Improved JavaScript parsing algorithm
- Improved PDF document encryption
- Increased accuracy of the table size calculation algorithm

We have also changed the default behavior of [MarkdownSaveOption](https://apireference.aspose.com/net/html/aspose.html.saving/markdownsaveoptions). Now all the features, defined in the original Markdown documentation, will be enabled by default. This will let you receive appropriate results without the necessity of additional configuration.

Improvements and Changes

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-2436|HTML not properly converted to PDF|Bug|
|HTMLNET-2452|HTML to Image - NullReferenceException Occurs|Bug|
|HTMLNET-2439|Exception during localhost site to image conversion|Bug|
|HTMLNET-2461|Html to Image conversion hangs|Bug|
|HTMLNET-2441|Aspose.HTML 20.1 Failed to parse URL|Bug|
|HTMLNET-2343|Documentation on how Aspose libraries cache user data/files for performance|Bug|
## **Public API and Backward Incompatible Changes**
The default value of [Features](https://apireference.aspose.com/net/html/aspose.html.saving/markdownsaveoptions/properties/features) property, defined in the [MarkdownSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/markdownsaveoptions) class, has changed. Now it contains a list of features defined in the original Markdown documentation.

{{< highlight java >}}

 namespace Aspose.Html.Saving

{

    public class MarkdownSaveOptions : SaveOptions

    {

        public MarkdownFeatures Features { get; set; }

    }

}

{{< /highlight >}}
### **Added APIs**
We have added new signatures to the EPUB and MHTML converters. Now you can specify an input file using an [URL](https://apireference.aspose.com/net/html/aspose.html/url) or string path.

{{< highlight java >}}

 namespace Aspose.Html.Converters

{

    public static class Converter

    {

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion epub source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(string sourcePath, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, XpsSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, PdfSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, ImageSaveOptions options, string outputPath);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Conversion mhtml source file path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(string sourcePath, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider);

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="sourceUrl">The source URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>

        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider);

    }

}

{{< /highlight >}}

We have also added the empty constructor to the [ImageSaveOptions](https://apireference.aspose.com/net/html/aspose.html.saving/imagesaveoptions) class.

{{< highlight java >}}

 namespace Aspose.Html.Saving

{

    public class ImageSaveOptions : ImageRenderingOptions

    {

        /// <summary>

        /// Initializes a new instance of the <see cref="ImageSaveOptions"/> class; <see cref="ImageFormat.Png"/> will be used as default image format.

        /// </summary>

        public ImageSaveOptions();

    }

}

{{< /highlight >}}

