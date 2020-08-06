---
title: Aspose.HTML for .NET 19.10 Release Notes
type: docs
weight: 30
url: /net/aspose-html-for-net-19-10-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.HTML for .NET 19.10](https://www.nuget.org/packages/Aspose.Html/19.10.0).

{{% /alert %}} 

As per the regular monthly update process of all APIs being offered by Aspose, we are honored to announce the October release of Aspose.HTML for .NET.

In this release, we have implemented a set of features that will increase the quality of text rendering. The most significant of them is **Kerning**. Kerning is used to adjust the spacing between character and it's supported by a majority of fonts. Also, we have improved the positioning of characters by implementing correct emulation of bold fonts which is used when such fonts are not available. With improved processing of HTML document modes, now the document works better in limited-quirks mode.

This release also includes some general fixes related to element attributes processing, which further add to the overall stability and functionality of the API.

Improvements and Changes

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-2156|MHT to XPS formatting issue|Bug|
|HTMLNET-2105|HTML to image difference|Bug|
## **Public API Changes**
The behavior of text rendering methods has been changed. To correctly render each character, its position should be determined from GraphicContext.TextInfo.CharacterInfos.\

{{< highlight java >}}

 namespace Aspose.Html.Rendering

{

    public interface IDevice : IDisposable

    {

        /// <summary>

        /// Fills the specified text string at the specified location.

        /// </summary>

        /// <param name="text">String to fill.</param>

        /// <param name="pt">Point that specifies the coordinates of the text.</param>

        void FillText(string text, PointF pt);

        /// <summary>

        /// Strokes the specified text string at the specified location.

        /// </summary>

        /// <param name="text">String to stroke.</param>

        /// <param name="pt">Point that specifies the coordinates where to start the text.</param>

        void StrokeText(string text, PointF pt);

    }

}

{{< /highlight >}}
### **Added APIs**
GraphicContext has been extended with information about rendered characters.

{{< highlight java >}}

 namespace Aspose.Html.Rendering

{

    public class GraphicContext : ICloneable

    {

        /// <summary>

        /// Gets a <see cref="Rendering.TextInfo"/> object which contains information about rendered text.

        /// </summary>

        /// <value>

        /// The <see cref="Rendering.TextInfo"/> object.

        /// </value>

        public virtual TextInfo TextInfo { get; }

    }

}

{{< /highlight >}}

Added class and struct which contains information about rendered characters.

{{< highlight java >}}

 namespace Aspose.Html.Rendering

{

    /// <summary>

    /// Contains information about rendered text.

    /// </summary>

    public class TextInfo

    {

        /// <summary>

        /// Gets information about rendered characters.

        /// </summary>

        /// <value>

        /// A <see cref="IList{CharacterInfo}" /> that contains information about rendered characters.

        /// </value>

        public IList<CharacterInfo> CharacterInfos { get; }

    }

    /// <summary>

    /// Contains character related information.

    /// </summary>

    public struct CharacterInfo

    {

        /// <summary>

        /// Gets characters width in points.

        /// </summary>

        /// <value>

        /// Width in points.

        /// </value>

        public float Width { get; }

        /// <summary>

        /// Gets offset to the next character in points.

        /// </summary>

        /// <value>

        /// Offset in points.

        /// </value>

        public float Offset { get; }

        /// <summary>

        /// Returns a <see cref="string" /> that represents this instance.

        /// </summary>

        /// <returns>

        /// A <see cref="string" /> that represents this instance.

        /// </returns>

        public override string ToString();

    }

}

{{< /highlight >}}




