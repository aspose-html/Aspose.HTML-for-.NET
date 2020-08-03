---
title: Aspose.HTML for .NET 18.12 Release Notes
type: docs
weight: 10
url: /net/aspose-html-for-net-18-12-release-notes/
---

### **Aspose.HTML for .NET 18.12 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce December release of Aspose.HTML for .NET. In this release, we have also improved the event broadcasting and style processing. Apart from that we have made some internal bug fixes and enhancements as mentioned in the table below:
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1628|Option for ignoring exceptions when rendering HTML into image|Bug|
|HTMLNET-1584|Alignment problem with HTML to Image|Bug|
|HTMLNET-1625|OnLoad event fired incorrectly|Bug|
|HTMLNET-1566|Incorrect result page dimension during HTML to PDF conversion|Bug|
### **Added APIs:**
Added 'Sandbox.Images' flag in order to restrict resources processing

{{< highlight java >}}

 namespace Aspose.Html

{

    /// <summary>

    /// A sandboxing flag set is a set of zero or more of the following flags, which are used to restrict the abilities that potentially untrusted resources.

    /// </summary>

    [Flags]

    public enum Sandbox

    {

        /// <summary>

        /// This flag disables image loading.

        /// </summary>

        Images = 0x1 << 11

    }

}

{{< /highlight >}}
### **Changed APIs:**
Spelling mistake for 'compression' enumeration was fixed

{{< highlight java >}}

 namespace Aspose.Html.Rendering.Image

{

    public class ImageRenderingOptions : RenderingOptions

    {

        public enum Comression

        {

            /// <summary>

            /// The LZW compression schema is used.

            /// </summary>

            LZW = 2,

            /// <summary>

            /// The CCITT3 compression schema is used.

            /// </summary>

            CCITT3 = 3,

            /// <summary>

            /// The CCITT4 compression schema is used.

            /// </summary>

            CCITT4 = 4,

            /// <summary>

            /// The RLE compression schema is used.

            /// </summary>

            Rle = 5,

            /// <summary>

            /// The Tagged Image File Format (TIFF) image is not compressed.

            /// </summary>

            None = 6

        }

    }

}

{{< /highlight >}}

{{< highlight java >}}

 namespace Aspose.Html.Rendering.Image

{

    /// <summary>

    /// Specifies the possible compression schemes for Tagged Image File Format (TIFF) bitmap images.

    /// </summary>

    public enum Compression

    {

        /// <summary>

        /// The LZW compression schema is used.

        /// </summary>

        LZW = 2,

        /// <summary>

        /// The CCITT3 compression schema is used.

        /// </summary>

        CCITT3 = 3,

        /// <summary>

        /// The CCITT4 compression schema is used.

        /// </summary>

        CCITT4 = 4,

        /// <summary>

        /// The RLE compression schema is used.

        /// </summary>

        Rle = 5,

        /// <summary>

        /// The Tagged Image File Format (TIFF) image is not compressed.

        /// </summary>

        None = 6

    }

}

{{< /highlight >}}
