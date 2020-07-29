---
title: Aspose.HTML for .NET 19.5 Release Notes
type: docs
weight: 80
url: /net/aspose-html-for-net-19-5-release-notes/
---

### **Aspose.HTML for .NET 19.5 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honoured to announce the May release of Aspose.HTML for .NET. In this release, we have introduced a new function that is called 'Template Merging'. This function is used to create HTML documents based on user templates and populate them from the various data sources. Additionally, we have prepared a specialized 'Aspose.Html.Converters.Converter' object. The main goal of creating this object is to simplify access to all conversion scenarios available with Aspose.HTML library. Along with mentioned changes we did some minor improvements in processing java scripts.
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1855|Implement Template Merger|New Feature|
|HTMLNET-1868|Implement unified class for all conversion scenarios|New Feature|
### **Added APIs:**
Added a 'Converter' class that is used as a shared endpoint for all conversion scenarios.

{{< highlight java >}}

 namespace Aspose.Html.Converters 

{

    /// <summary>

    /// Shared facade only for most often conversion scenarios. It includes template merging, html conversions as well as epub and svg conversion to XPS, PDF and Image files.

    /// More specific conversion (rendering, saving) user cases are presented by well known and documented low level API functions

    /// </summary>

    public static class Converter 

    {

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="document">Source skeleton html doc.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(HTMLDocument document, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="url">Template source document URL.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(Url url, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="url">Template source document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(Url url, Configuration configuration, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="sourcePath">Path to template source html file.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(string sourcePath, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="sourcePath">Path to template source html file.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(string sourcePath, Configuration configuration, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="content">Inline html template - skeleton.</param>

        /// <param name="baseUrl">Base URI of the html template.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(string content, string baseUrl, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is html file.

        /// </summary>

        /// <param name="content">Inline html template - skeleton.</param>

        /// <param name="baseUrl">Base URI of the html template.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertTemplate(string content, string baseUrl, Configuration configuration, TemplateData data, TemplateLoadOptions options, string outputPath) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="document">Source skeleton html doc.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(HTMLDocument document, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="url">Template source document URL.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(Url url, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="url">Template source document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(Url url, Configuration configuration, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="sourcePath">Path to template source html file.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(string sourcePath, TemplateData data, TemplateLoadOptions options){}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="sourcePath">Path to template source html file.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(string sourcePath, Configuration configuration, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="content">Inline html template - skeleton.</param>

        /// <param name="baseUrl">Base URI of the html template.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(string content, string baseUrl, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Merge html template with user data. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="content">Inline html template - skeleton.</param>

        /// <param name="baseUrl">Base URI of the html template.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="data">Data for merging (XML, JSON).</param>

        /// <param name="options">Merging options object.</param>

        /// <returns>Conversion result HTMLDocument.</returns>

        public static HTMLDocument ConvertTemplate(string content, string baseUrl, Configuration configuration, TemplateData data, TemplateLoadOptions options) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="document">Conversion source <see cref="HTMLDocument"/>.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(HTMLDocument document, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="document">Conversion source <see cref="HTMLDocument"/>.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(HTMLDocument document, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source document to PDF. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider">Conversion result wrapped in

        /// <see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(HTMLDocument document, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, Configuration configuration, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to mhtml. Result is mhtml file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, MHTMLSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to markdown. Result is md file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(HTMLDocument document, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, Configuration configuration, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to markdown. Result is md file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, MarkdownSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(HTMLDocument document, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(HTMLDocument document, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(HTMLDocument document, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(Url url, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html document to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(HTMLDocument document, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(Url url, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Html file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string sourcePath, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert html source to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string html content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertHTML(string content, string baseUri, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg document to xps.Result is xps file.

        /// </summary>

        /// <param name="source">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(SVGDocument source, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">Source document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">Source document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(SVGDocument document, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to xps. Result is xps file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="source">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(SVGDocument source, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(SVGDocument document, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="content">Source document content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="source">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(SVGDocument source, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(Url url, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg document to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="document">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(SVGDocument document, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="url">The document URL.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(Url url, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="sourcePath">Svg file source path.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string sourcePath, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert svg source to image. Result is image file.

        /// </summary>

        /// <param name="content">Inline string svg content.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertSVG(string content, string baseUri, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertEPUB(Stream stream, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertEPUB(Stream stream, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertEPUB(Stream stream, ImageSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertMHTML(Stream stream, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertMHTML(Stream stream, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation</param>

        public static void ConvertMHTML(Stream stream, ImageSaveOptions options, ICreateStreamProvider provider) {}

    }

    /// <summary>

    /// Merging (User) data object.

    /// </summary>

    public sealed class TemplateData

    {

        /// <summary>

        /// Inline content based on initialization (XML, JSON).

        /// </summary>

        /// <param name="contentOptions">Content description object.</param>

        public TemplateData(TemplateContentOptions contentOptions) {}

        /// <summary>

        /// Path to data file (XML, JSON) based on initialization.

        /// </summary>

        /// <param name="dataPath">Path to data file (XML, JSON)</param>

        public TemplateData(string dataPath) {}

        /// <summary>

        /// Data path property.

        /// </summary>

        public string DataPath { get; }

        /// <summary>

        /// Content object property.

        /// </summary>

        public TemplateContentOptions ContentOptions { get; }

    }

    /// <summary>

    /// Inline content object for merging processing.

    /// </summary>

    public sealed class TemplateContentOptions 

    {

        /// <summary>

        /// Inline (String) based initialization

        /// </summary>

        /// <param name="dataContent">Inline (String) content.</param>

        /// <param name="contentType">Content type.</param>

        public TemplateContentOptions(string dataContent, TemplateContent contentType) {}

        /// <summary>

        /// Data content property.

        /// </summary>

        public string DataContent { get; }

        /// <summary>

        /// Content type property.

        /// </summary>

        public TemplateContent ContentType { get; }

        /// <summary>

        /// String representation of <see cref="ContentType"/> property.

        /// </summary>

        public string Format { get; }

    }

    /// <summary>

    /// Content type identifier.

    /// </summary>

    public enum TemplateContent 

    {

        /// <summary>

        /// Undetermined value.

        /// </summary>

        Undefined,

        /// <summary>

        /// XML content identifier.

        /// </summary>

        XML,

        /// <summary>

        /// JSON content identifier.

        /// </summary>

        JSON

    }

}

{{< /highlight >}}
