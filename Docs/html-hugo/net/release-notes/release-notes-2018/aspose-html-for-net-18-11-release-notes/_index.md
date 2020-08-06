---
title: Aspose.HTML for .NET 18.11 Release Notes
type: docs
weight: 20
url: /net/aspose-html-for-net-18-11-release-notes/
---

### **Aspose.HTML for .NET 18.11 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce November release of Aspose.HTML for .NET. In this release, we have made fixes related to the paralleling of microtask and event broadcasting. Apart from that we have made some internal bug fixes and enhancements following in the table below:
### **Improvements and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1498|HTML to XPS: incorrect offsets when object is wrapped into div|Bug|
|HTMLNET-1505|MHT to PDF: the file content is overlapping|Bug|
|HTMLNET-1515|CSS rules do not apply correctly|Bug|
|HTMLNET-1548|SVGDocument constructor corrupts stream|Bug|
|HTMLNET-1549|HTML table rendered improperly|Bug|
|HTMLNET-1535|HTML to XPS: XpsRenderer throws InvalidCastException|Bug|
|HTMLNET-1530|The SVG image is not displayed in PDF|Bug|
### **Added APIs:**
Added property SmoothingMode that allows to specify whether smoothing (antialiasing) is applied to lines and curves and the edges of filled areas.

{{< highlight java >}}

 namespace Aspose.Html.Rendering.Image

{

    public class ImageRenderingOptions : RenderingOptions

    {

        /// <summary>

        /// Gets or sets the rendering quality for this Graphics.

        /// </summary>

        public SmoothingMode SmoothingMode { get; set; }

    }

}

{{< /highlight >}}
### **Changed APIs:**
According to changes in specification the document events were moved from *HTMLDocument* to base *Document* class.

{{< highlight java >}}

 namespace Aspose.Html

{

    public class HTMLDocument : Document

    {

        /// <summary>

        /// Gets or sets event handler for OnAbort event.

        /// </summary>

        public event DOMEventHandler OnAbort;

        /// <summary>

        /// Gets or sets event handler for OnBlur event.

        /// </summary>

        public event DOMEventHandler OnBlur;

        /// <summary>

        /// Gets or sets event handler for OnCancel event.

        /// </summary>

        public event DOMEventHandler OnCancel;

        /// <summary>

        /// Gets or sets event handler for OnCanplay event.

        /// </summary>

        public event DOMEventHandler OnCanplay;

        /// <summary>

        /// Gets or sets event handler for OnCanPlayThrough event.

        /// </summary>

        public event DOMEventHandler OnCanPlayThrough;

        /// <summary>

        /// Gets or sets event handler for OnChange event.

        /// </summary>

        public event DOMEventHandler OnChange;

        /// <summary>

        /// Gets or sets event handler for OnClick event.

        /// </summary>

        public event DOMEventHandler OnClick;

        /// <summary>

        /// Gets or sets event handler for OnCueChange event.

        /// </summary>

        public event DOMEventHandler OnCueChange;

        /// <summary>

        /// Gets or sets event handler for OnDblClick event.

        /// </summary>

        public event DOMEventHandler OnDblClick;

        /// <summary>

        /// Gets or sets event handler for OnDurationChange event.

        /// </summary>

        public event DOMEventHandler OnDurationChange;

        /// <summary>

        /// Gets or sets event handler for OnEmptied event.

        /// </summary>

        public event DOMEventHandler OnEmptied;

        /// <summary>

        /// Gets or sets event handler for OnEnded event.

        /// </summary>

        public event DOMEventHandler OnEnded;

        /// <summary>

        /// Gets or sets event handler for OnError event.

        /// </summary>

        public event DOMEventHandler OnError;

        /// <summary>

        /// Gets or sets event handler for OnFocus event.

        /// </summary>

        public event DOMEventHandler OnFocus;

        /// <summary>

        /// Gets or sets event handler for OnInput event.

        /// </summary>

        public event DOMEventHandler OnInput;

        /// <summary>

        /// Gets or sets event handler for OnInvalid event.

        /// </summary>

        public event DOMEventHandler OnInvalid;

        /// <summary>

        /// Gets or sets event handler for OnKeyDown event.

        /// </summary>

        public event DOMEventHandler OnKeyDown;

        /// <summary>

        /// Gets or sets event handler for OnKeyPress event.

        /// </summary>

        public event DOMEventHandler OnKeyPress;

        /// <summary>

        /// Gets or sets event handler for OnKeyUp event.

        /// </summary>

        public event DOMEventHandler OnKeyUp;

        /// <summary>

        /// Gets or sets event handler for OnLoad event.

        /// </summary>

        public event DOMEventHandler OnLoad;

        /// <summary>

        /// Gets or sets event handler for OnLoadedData event.

        /// </summary>

        public event DOMEventHandler OnLoadedData;

        /// <summary>

        /// Gets or sets event handler for OnLoadedMetadata event.

        /// </summary>

        public event DOMEventHandler OnLoadedMetadata;

        /// <summary>

        /// Gets or sets event handler for OnLoadStart event.

        /// </summary>

        public event DOMEventHandler OnLoadStart;

        /// <summary>

        /// Gets or sets event handler for OnMouseDown event.

        /// </summary>

        public event DOMEventHandler OnMouseDown;

        /// <summary>

        /// Gets or sets event handler for OnMouseEnter event.

        /// </summary>

        public event DOMEventHandler OnMouseEnter;

        /// <summary>

        /// Gets or sets event handler for OnMouseLeave event.

        /// </summary>

        public event DOMEventHandler OnMouseLeave;

        /// <summary>

        /// Gets or sets event handler for OnMouseMove event.

        /// </summary>

        public event DOMEventHandler OnMouseMove;

        /// <summary>

        /// Gets or sets event handler for OnMouseOut event.

        /// </summary>

        public event DOMEventHandler OnMouseOut;

        /// <summary>

        /// Gets or sets event handler for OnMouseOver event.

        /// </summary>

        public event DOMEventHandler OnMouseOver;

        /// <summary>

        /// Gets or sets event handler for OnMouseUp event.

        /// </summary>

        public event DOMEventHandler OnMouseUp;

        /// <summary>

        /// Gets or sets event handler for OnMouseWheel event.

        /// </summary>

        public event DOMEventHandler OnMouseWheel;

        /// <summary>

        /// Gets or sets event handler for OnPause event.

        /// </summary>

        public event DOMEventHandler OnPause;

        /// <summary>

        /// Gets or sets event handler for OnPlay event.

        /// </summary>

        public event DOMEventHandler OnPlay;

        /// <summary>

        /// Gets or sets event handler for OnPlaying event.

        /// </summary>

        public event DOMEventHandler OnPlaying;

        /// <summary>

        /// Gets or sets event handler for OnProgress event.

        /// </summary>

        public event DOMEventHandler OnProgress;

        /// <summary>

        /// Gets or sets event handler for OnRateChange event.

        /// </summary>

        public event DOMEventHandler OnRateChange;

        /// <summary>

        /// Gets or sets event handler for OnReset event.

        /// </summary>

        public event DOMEventHandler OnReset;

        /// <summary>

        /// Gets or sets event handler for OnResize event.

        /// </summary>

        public event DOMEventHandler OnResize;

        /// <summary>

        /// Gets or sets event handler for OnScroll event.

        /// </summary>

        public event DOMEventHandler OnScroll;

        /// <summary>

        /// Gets or sets event handler for OnSeeked event.

        /// </summary>

        public event DOMEventHandler OnSeeked;

        /// <summary>

        /// Gets or sets event handler for OnSeeking event.

        /// </summary>

        public event DOMEventHandler OnSeeking;

        /// <summary>

        /// Gets or sets event handler for OnSelect event.

        /// </summary>

        public event DOMEventHandler OnSelect;

        /// <summary>

        /// Gets or sets event handler for OnShow event.

        /// </summary>

        public event DOMEventHandler OnShow;

        /// <summary>

        /// Gets or sets event handler for OnStalled event.

        /// </summary>

        public event DOMEventHandler OnStalled;

        /// <summary>

        /// Gets or sets event handler for OnSubmit event.

        /// </summary>

        public event DOMEventHandler OnSubmit;

        /// <summary>

        /// Gets or sets event handler for OnSuspend event.

        /// </summary>

        public event DOMEventHandler OnSuspend;

        /// <summary>

        /// Gets or sets event handler for OnTimeUpdate event.

        /// </summary>

        public event DOMEventHandler OnTimeUpdate;

        /// <summary>

        /// Gets or sets event handler for OnToggle event.

        /// </summary>

        public event DOMEventHandler OnToggle;

        /// <summary>

        /// Gets or sets event handler for OnVolumeChange event.

        /// </summary>

        public event DOMEventHandler OnVolumeChange;

        /// <summary>

        /// Gets or sets event handler for OnWaiting event.

        /// </summary>

        public event DOMEventHandler OnWaiting;

    }

}

{{< /highlight >}}
