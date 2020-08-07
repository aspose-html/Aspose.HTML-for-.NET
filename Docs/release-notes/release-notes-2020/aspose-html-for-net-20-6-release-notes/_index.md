---
title: Aspose.HTML for .NET 20.6 Release Notes
type: docs
weight: 70
url: /net/aspose-html-for-net-20-6-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes information for Aspose.HTML for .NET 20.6.

{{% /alert %}} 

As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the June release of Aspose.HTML for .NET.

In this release we have added the support of new output format - DOCX. Now you can convert MHTML, EPUB, SVG and HTML to DOCX with just a couple lines of code! We have also made the number of rendering quality improvements, here are some of them:

- improved size calculation of BODY and HTML elements, now they are correctly rendered in different DOCTYPEs;
- improved handling of the TABLE elements which have multiple CAPTIONs;
- increased document loading speed;
- updated the clipping processing algorithm according to the latest documentation;
- increased precision of the LEGEND element positioning;
- updated the URL parsing algorithm according to the latest documentation.

## **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-2559|Exception on loading HTML file|Bug|
|HTMLNET-2658|Add ability to determine elements heights for PdfFragmentDevice|Bug|
|HTMLNET-2313|HTML to Image conversion never ends|Bug|
|HTMLNET-2667|Html to PDF - Object reference not set to an instance of an object.|Bug|
|HTMLNET-2716|Exception during mht to pdf conversion|Bug|
|HTMLNET-2661|Html to png - incorrect rendering|Bug|
|HTMLNET-2664|Html to png - incorrect rendering|Bug|
|HTMLNET-2665|Html to png - incorrect rendering|Bug|
|HTMLNET-1875|Support to convert HTML to Word format DOC and DOCX|Feature|

## **Public API and Backward Incompatible Changes**
### **Added APIs**

{{< highlight java >}}

namespace Aspose.Html.Converters
{
    public static class Converter
    {
        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(Stream stream, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion source path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(string sourcePath, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(Url sourceUrl, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(Stream stream, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion epub source file path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(string sourcePath, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(Stream stream, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion epub source file path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(string sourcePath, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(Url sourceUrl, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(Stream stream, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion epub source file path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(string sourcePath, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert EPUB source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertEPUB(Url sourceUrl, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source stream.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(Stream stream, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion mhtml source file path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(string sourcePath, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(Url sourceUrl, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source stream.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(Stream stream, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion mhtml source file path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(string sourcePath, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source stream.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(Stream stream, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion mhtml source file path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(string sourcePath, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(Url sourceUrl, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="stream">Conversion source stream.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(Stream stream, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Conversion mhtml source file path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(string sourcePath, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert MHTML source to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourceUrl">The source URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertMHTML(Url sourceUrl, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="source">Conversion source.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(SVGDocument source, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">Source document URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(Url url, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">Source document URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(Url url, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Svg file source path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(string sourcePath, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Svg file source path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(string sourcePath, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string svg content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(string content, string baseUri, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string svg content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertSVG(string content, string baseUri, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="document">Conversion source.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(SVGDocument document, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(Url url, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(Url url, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Svg file source path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(string sourcePath, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Svg file source path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(string sourcePath, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string svg content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(string content, string baseUri, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert SVG document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string svg content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertSVG(string content, string baseUri, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="document">Conversion source <see cref="HTMLDocument"/>.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(HTMLDocument document, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(Url url, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(Url url, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">Html file source path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(string sourcePath, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">HTML file source path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(string sourcePath, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string HTML content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(string content, string baseUri, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string html content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="outputPath">Output file path.</param>
        public static void ConvertHTML(string content, string baseUri, Configuration configuration, DocSaveOptions options, string outputPath);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="document">Conversion source <see cref="HTMLDocument"/>.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(HTMLDocument document, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(Url url, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="url">The document URL.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(Url url, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">HTML file source path.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(string sourcePath, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="sourcePath">HTML file source path.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(string sourcePath, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string HTML content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(string content, string baseUri, DocSaveOptions options, ICreateStreamProvider provider);

        /// <summary>
        /// Convert HTML source document to DOCX. Result is docx file.
        /// </summary>
        /// <param name="content">Inline string HTML content.</param>
        /// <param name="baseUri">The base URI of the document.</param>
        /// <param name="configuration">The environment configuration.</param>
        /// <param name="options">Conversion options.</param>
        /// <param name="provider">Implementation of the <see cref="ICreateStreamProvider"/> interface, which will be used to get an output stream.</param>
        public static void ConvertHTML(string content, string baseUri, Configuration configuration, DocSaveOptions options, ICreateStreamProvider provider);
    }
}

{{< /highlight >}}

{{< highlight java >}}

namespace Aspose.Html.Saving
{
    /// <summary>
    /// Specific options data class.
    /// </summary>
    public class DocSaveOptions : DocRenderingOptions
    {
    }
}

{{< /highlight >}}

{{< highlight java >}}

namespace Aspose.Html.Rendering.Doc
{
    /// <summary>
    /// Represents the file format of the output document.
    /// </summary>
    public enum DocumentFormat
    {
        /// <summary>
        /// The XML-based document format.
        /// </summary>
        DOCX = 1
    }
}

{{< /highlight >}}

{{< highlight java >}}

namespace Aspose.Html.Rendering.Doc
{
    /// <summary>
    /// Represents the font embedding rules.
    /// </summary>
    public enum FontEmbeddingRule
    {
        /// <summary>
        /// All the used fonts will be embedded as-is. Be aware that some font could be licensed, this will make the resulting document uneditable. Also the embedded font files could significantly increase the size of the resulting document.
        /// </summary>
        Full = 1,

        /// <summary>
        /// Fonts won't be embedded.
        /// </summary>
        None = 2
    }
}

{{< /highlight >}}

{{< highlight java >}}

namespace Aspose.Html.Rendering.Doc
{
    /// <summary>
    /// Represents the rendering options for <see cref="DocDevice"/>.
    /// </summary>
    public class DocRenderingOptions : RenderingOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocRenderingOptions"/> class.
        /// </summary>
        public DocRenderingOptions();

        /// <summary>
        /// Initializes a new instance of the <see cref="DocRenderingOptions"/> class with the specified font embedding rule.
        /// </summary>
        /// <param name="fontEmbeddingRule">The font embedding rule.</param>
        public DocRenderingOptions(FontEmbeddingRule fontEmbeddingRule);

        /// <summary>
        /// Gets or sets the font embedding rule. The default value is <see cref="Aspose.Html.Rendering.Doc.FontEmbeddingRule.None"/>.
        /// </summary>
        public FontEmbeddingRule FontEmbeddingRule { get; set; }

        /// <summary>
        /// Gets or sets the file format of the output document. The default value is <see cref="Aspose.Html.Rendering.Doc.DocumentFormat.DOCX"/>.
        /// </summary>
        public DocumentFormat DocumentFormat { get; set; }
    }
}

{{< /highlight >}}

{{< highlight java >}}

namespace Aspose.Html.Rendering.Doc
{
    /// <summary>
    /// Represents rendering to a DOCX document.
    /// </summary>
    public class DocDevice : Device<DocDevice.DocGraphicContext, DocRenderingOptions> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class.
        /// </summary>
        /// <param name="streamProvider">Object that implements the <see cref="ICreateStreamProvider"/> interface</param>
        public DocDevice(ICreateStreamProvider streamProvider);

        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class by rendering options and stream provider.
        /// </summary>
        /// <param name="options">Rendering options.</param>
        /// <param name="streamProvider">Object that implements the <see cref="ICreateStreamProvider"/> interface</param>
        public DocDevice(DocRenderingOptions options, ICreateStreamProvider streamProvider);

        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class by output file name.
        /// </summary>
        /// <param name="file">The output file name</param>
        public DocDevice(string file);

        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class by rendering options and output file name.
        /// </summary>
        /// <param name="options">Rendering options.</param>
        /// <param name="file">The output file name</param>
        public DocDevice(DocRenderingOptions options, string file);

        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class by output stream.
        /// </summary>
        /// <param name="stream">The output stream</param>
        public DocDevice(Stream stream);

        /// <summary>
        /// Initializes a new instance of the <see cref="DocDevice"/> class by rendering options and output stream. 
        /// </summary>
        /// <param name="options">Rendering options.</param>
        /// <param name="stream">The output stream</param>
        public DocDevice(DocRenderingOptions options, Stream stream);

        /// <summary>
        /// Holds current graphics control parameters for the DocDevice.
        /// These parameters define the global framework within which the graphics operators execute.
        /// </summary>
        public class DocGraphicContext : GraphicContext 
        {
        }
    }
}

{{< /highlight >}}
