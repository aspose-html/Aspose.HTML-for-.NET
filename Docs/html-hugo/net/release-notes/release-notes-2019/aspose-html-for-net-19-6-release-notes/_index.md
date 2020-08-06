---
title: Aspose.HTML for .NET 19.6 Release Notes
type: docs
weight: 70
url: /net/aspose-html-for-net-19-6-release-notes/
---

### **Aspose.HTML for .NET 19.6 Release Notes**
-----
As per the regular monthly update process of all APIs being offered by Aspose, we are honored to announce the June release of Aspose.HTML for .NET. In this release, we have introduced a new function of conversion from Markdown, which is developed as an easy-to-read, easy-to-write plain text format, to HTML document. Along with the new functional, we did improvements in processing table elements and revised the MHTML document process.
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1854|Implement Markdown to HTML converter|New Feature|
|HTMLNET-1931|Loading MHTML file hangs|Bug|
|HTMLNET-1932|The table is missing in the PDF rendition|Bug|
|HTMLNET-1810|HTML to PDF - Images do not render|Bug|
|HTMLNET-1920|An application hangs while loading MHT file|Bug|
### **Added APIs:**
Converter object was extended with methods to create HTML document from the Markdown file.

{{< highlight java >}}

 namespace Aspose.Html.Converters 

{

    public static class Converter 

    {

        /// <summary>

        /// Convert Markdown source to html. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <returns>Conversion result <see cref="HTMLDocument"/>.</returns>

        public static HTMLDocument ConvertMarkdown(Stream stream, string baseUri) {}

        /// <summary>

        /// Convert Markdown source to html. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <returns>Conversion result <see cref="HTMLDocument"/>.</returns>

        public static HTMLDocument ConvertMarkdown(Stream stream, string baseUri, Configuration configuration) {}

        /// <summary>

        /// Convert Markdown source to html. Result is html file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMarkdown(Stream stream, string baseUri, string outputPath) {}

        /// <summary>

        /// Convert Markdown source to html. Result is html file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="baseUri">The base URI of the document.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMarkdown(Stream stream, string baseUri, Configuration configuration, string outputPath) {}

        /// <summary>

        /// Convert Markdown source to html. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="sourcePath">Path to source Markdown file.</param>

        /// <returns>Conversion result <see cref="HTMLDocument"/>.</returns>

        public static HTMLDocument ConvertMarkdown(string sourcePath) {}

        /// <summary>

        /// Convert Markdown source to html. Result is <see cref="HTMLDocument"/>.

        /// </summary>

        /// <param name="sourcePath">Path to source Markdown file.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <returns>Conversion result <see cref="HTMLDocument"/>.</returns>

        public static HTMLDocument ConvertMarkdown(string sourcePath, Configuration configuration) {}

        /// <summary>

        /// Convert Markdown source to html. Result is html file.

        /// </summary>

        /// <param name="sourcePath">Path to source Markdown file.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMarkdown(string sourcePath, string outputPath) {}

        /// <summary>

        /// Convert Markdown source to html. Result is html file.

        /// </summary>

        /// <param name="sourcePath">Path to source Markdown file.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMarkdown(string sourcePath, Configuration configuration, string outputPath) {}

    }

}

{{< /highlight >}}

Added overridden methods for ConvertEPUB() and ConvertMHTML() in order to add ability to set up a user configuration.

{{< highlight java >}}

 namespace Aspose.Html.Converters 

{

    public static class Converter 

    {

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, PdfSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert epub source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertEPUB(Stream stream, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}


        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, XpsSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert mhtml source to xps. Result is xps file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, XpsSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, PdfSaveOptions options, string outputPath)  {}

        /// <summary>

        /// Convert mhtml source to pdf. Result is pdf file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, PdfSaveOptions options, ICreateStreamProvider provider) {}

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="outputPath">Output file path.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, ImageSaveOptions options, string outputPath) {}

        /// <summary>

        /// Convert mhtml source to image. Result is image file.

        /// </summary>

        /// <param name="stream">Conversion source.</param>

        /// <param name="configuration">The environment configuration.</param>

        /// <param name="options">Conversion options.</param>

        /// <param name="provider"><see cref="ICreateStreamProvider"/> implementation.</param>

        public static void ConvertMHTML(Stream stream, Configuration configuration, ImageSaveOptions options, ICreateStreamProvider provider) {}

    }

}

{{< /highlight >}}
