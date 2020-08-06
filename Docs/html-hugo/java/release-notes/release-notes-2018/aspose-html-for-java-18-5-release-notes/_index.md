---
title: Aspose.HTML for Java 18.5 Release Notes
type: docs
weight: 70
url: /java/aspose-html-for-java-18-5-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.HTML for Java 18.5](https://repository.aspose.com/webapp/#/artifacts/browse/tree/General/repo/com/aspose/aspose-html/18.5.1)

{{% /alert %}} 
## **Release Notes of Aspose.HTML for Java 18.5**
### **Major Features**
We are pleased to announce that our series of W3C formats has been extended and now we support Scale-able Vector Graphics (SVG) format. Our API offers the capabilities to manipulate SVG, both as a part of HTML document and single SVGDocument object. This API is fully compatible with the W3C SVG 2 recommendation and previously implemented HTML format, so every manipulation features: loading, saving, editing, navigation or rendering features supported exactly in the same way. In this release, we have added support for Aspose Metered License mechanism; reworked the request message object and created more flexible way to set up the message content as well as user credentials; we have improved the rendering options and added capability to specify CSS MediaType. Also, we have reorganized caching mechanism and increased the document loading performance.
### **Improvements and Changes**

|**Summary**|**Category**|
| :- | :- |
|Support for metered license|Enhancement|
|HTML to PNG image conversion|Enhancement|
|Support for media commands @print and @screen|Enhancement|
|The RequestMessage.Method property does not work|Bug|
|<input> elements of new HTML5 types does not rendered|Bug|
### **Public API changes in Aspose.HTML for Java 18.5**
#### **Added APIs:**
-----
{{< highlight java >}}

 // These methods has been migrated from deleted abstract class DOMConfiguration

com.aspose.html.Configuration.addService<T>(T service, java.lang.Class<T> clazz)

com.aspose.html.Configuration.getService<T>(java.lang.Class<T> clazz)

{{< /highlight >}}

{{< highlight java >}}

 // These changes have been made according to W3C Shadow DOM recommendation

com.aspose.html.dom.ShadowRoot com.aspose.html.dom.Element.attachShadow(com.aspose.html.dom.ShadowRootMode mode)

com.aspose.html.dom.ShadowRoot com.aspose.html.dom.Element.getShadowRoot()

{{< /highlight >}}

{{< highlight java >}}

 // Added the default constructors to all devices to simplify usage

com.aspose.html.rendering.image.ImageDevice(java.lang.String file)

com.aspose.html.rendering.image.ImageDevice(com.aspose.html.internal.ms.System.IO.Stream stream)

com.aspose.html.rendering.pdf.PdfDevice(com.aspose.html.internal.ms.System.IO.Stream stream)

com.aspose.html.rendering.pdf.PdfDevice(java.lang.String file)

com.aspose.html.rendering.xps.XpsDevice(com.aspose.html.internal.ms.System.IO.Stream stream)

com.aspose.html.rendering.xps.XpsDevice(java.lang.String file)

{{< /highlight >}}

{{< highlight java >}}

 // Added ability to specify the image resolution during the rendering to the output device

com.aspose.html.rendering.RenderingOptions.getHorizontalResolution()

com.aspose.html.rendering.RenderingOptions.setHorizontalResolution(com.aspose.html.drawing.Resolution value)

com.aspose.html.rendering.RenderingOptions.getVerticalResolution()

com.aspose.html.rendering.RenderingOptions.setVerticalResolution(com.aspose.html.drawing.Resolution value)

{{< /highlight >}}

{{< highlight java >}}

 // Added the new SvgRenderer object for processing SVG documents

com.aspose.html.rendering.SvgRenderer

com.aspose.html.rendering.SvgRenderer.render(com.aspose.html.rendering.IDevice ddevice, com.aspose.html.dom.svg.SVGDocument document)

{{< /highlight >}}

{{< highlight java >}}

 // Default and overloading constructors have been added.

com.aspose.html.dom.svg.SVGDocument()

com.aspose.html.dom.svg.SVGDocument(com.aspose.html.net.RequestMessage requestMessage)

{{< /highlight >}}

{{< highlight java >}}

 // Introduced the new SVG namespace. All classes in this namespace are based on w3c SVG2 recomendation (https://www.w3.org/TR/SVG2/)

com.aspose.html.dom.svg.datatypes.SVGAngle

com.aspose.html.dom.svg.datatypes.SVGAnimatedAngle

com.aspose.html.dom.svg.datatypes.SVGAnimatedBoolean

com.aspose.html.dom.svg.datatypes.SVGAnimatedEnumeration

com.aspose.html.dom.svg.datatypes.SVGAnimatedInteger

com.aspose.html.dom.svg.datatypes.SVGAnimatedLength

com.aspose.html.dom.svg.datatypes.SVGAnimatedLengthList

com.aspose.html.dom.svg.datatypes.SVGAnimatedNumber

com.aspose.html.dom.svg.datatypes.SVGAnimatedNumberList

com.aspose.html.dom.svg.datatypes.SVGAnimatedPreserveAspectRatio

com.aspose.html.dom.svg.datatypes.SVGAnimatedRect

com.aspose.html.dom.svg.datatypes.SVGAnimatedString

com.aspose.html.dom.svg.datatypes.SVGAnimatedTransformList

com.aspose.html.dom.svg.datatypes.SVGLength

com.aspose.html.dom.svg.datatypes.SVGLengthList

com.aspose.html.dom.svg.datatypes.SVGMatrix

com.aspose.html.dom.svg.datatypes.SVGNumber

com.aspose.html.dom.svg.datatypes.SVGNumberList

com.aspose.html.dom.svg.datatypes.SVGPoint

com.aspose.html.dom.svg.datatypes.SVGPointList

com.aspose.html.dom.svg.datatypes.SVGPreserveAspectRatio

com.aspose.html.dom.svg.datatypes.SVGRect

com.aspose.html.dom.svg.datatypes.SVGStringList

com.aspose.html.dom.svg.datatypes.SVGTransform

com.aspose.html.dom.svg.datatypes.SVGTransformList

com.aspose.html.dom.svg.datatypes.SVGValueType

com.aspose.html.dom.svg.events.SVGZoomEvent

com.aspose.html.dom.svg.events.TimeEvent

com.aspose.html.dom.svg.filters.ISVGFilterPrimitiveStandardAttributes

com.aspose.html.dom.svg.filters.SVGFEBlendElement

com.aspose.html.dom.svg.filters.SVGFEColorMatrixElement

com.aspose.html.dom.svg.filters.SVGFEComponentTransferElement

com.aspose.html.dom.svg.filters.SVGFECompositeElement

com.aspose.html.dom.svg.filters.SVGFEConvolveMatrixElement

com.aspose.html.dom.svg.filters.SVGFEDiffuseLightingElement

com.aspose.html.dom.svg.filters.SVGFEDisplacementMapElement

com.aspose.html.dom.svg.filters.SVGFEDistantLightElement

com.aspose.html.dom.svg.filters.SVGFEDropShadowElement

com.aspose.html.dom.svg.filters.SVGFEFloodElement

com.aspose.html.dom.svg.filters.SVGFEFuncAElement

com.aspose.html.dom.svg.filters.SVGFEFuncBElement

com.aspose.html.dom.svg.filters.SVGFEFuncGElement

com.aspose.html.dom.svg.filters.SVGFEFuncRElement

com.aspose.html.dom.svg.filters.SVGFEGaussianBlurElement

com.aspose.html.dom.svg.filters.SVGFEImageElement

com.aspose.html.dom.svg.filters.SVGFEMergeElement

com.aspose.html.dom.svg.filters.SVGFEMergeNodeElement

com.aspose.html.dom.svg.filters.SVGFEMorphologyElement

com.aspose.html.dom.svg.filters.SVGFEOffsetElement

com.aspose.html.dom.svg.filters.SVGFEPointLightElement

com.aspose.html.dom.svg.filters.SVGFESpecularLightingElement

com.aspose.html.dom.svg.filters.SVGFESpotLightElement

com.aspose.html.dom.svg.filters.SVGFETileElement

com.aspose.html.dom.svg.filters.SVGFETurbulenceElement

com.aspose.html.dom.svg.ISVGAnimatedPoints

com.aspose.html.dom.svg.ISVGFitToViewBox

com.aspose.html.dom.svg.ISVGRenderingIntent

com.aspose.html.dom.svg.ISVGTests

com.aspose.html.dom.svg.ISVGUnitTypes

com.aspose.html.dom.svg.ISVGURIReference

com.aspose.html.dom.svg.ISVGZoomAndPan

com.aspose.html.dom.svg.paths.ISVGAnimatedPathData

com.aspose.html.dom.svg.paths.SVGPathSeg

com.aspose.html.dom.svg.paths.SVGPathSegArcAbs

com.aspose.html.dom.svg.paths.SVGPathSegArcRel

com.aspose.html.dom.svg.paths.SVGPathSegClosePath

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoCubicAbs

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoCubicRel

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoCubicSmoothAbs

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoCubicSmoothRel

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoQuadraticAbs

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoQuadraticRel

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoQuadraticSmoothAbs

com.aspose.html.dom.svg.paths.SVGPathSegCurvetoQuadraticSmoothRel

com.aspose.html.dom.svg.paths.SVGPathSegLinetoAbs

com.aspose.html.dom.svg.paths.SVGPathSegLinetoHorizontalAbs

com.aspose.html.dom.svg.paths.SVGPathSegLinetoHorizontalRel

com.aspose.html.dom.svg.paths.SVGPathSegLinetoRel

com.aspose.html.dom.svg.paths.SVGPathSegLinetoVerticalAbs

com.aspose.html.dom.svg.paths.SVGPathSegLinetoVerticalRel

com.aspose.html.dom.svg.paths.SVGPathSegList

com.aspose.html.dom.svg.paths.SVGPathSegMovetoAbs

com.aspose.html.dom.svg.paths.SVGPathSegMovetoRel

com.aspose.html.dom.svg.SVGAElement

com.aspose.html.dom.svg.SVGAnimateElement

com.aspose.html.dom.svg.SVGAnimateMotionElement

com.aspose.html.dom.svg.SVGAnimateTransformElement

com.aspose.html.dom.svg.SVGAnimationElement

com.aspose.html.dom.svg.SVGCircleElement

com.aspose.html.dom.svg.SVGClipPathElement

com.aspose.html.dom.svg.SVGComponentTransferFunctionElement

com.aspose.html.dom.svg.SVGCursorElement

com.aspose.html.dom.svg.SVGDefsElement

com.aspose.html.dom.svg.SVGDescElement

com.aspose.html.dom.svg.SVGDocument

com.aspose.html.dom.svg.SVGElement

com.aspose.html.dom.svg.SVGElementInstance

com.aspose.html.dom.svg.SVGEllipseElement

com.aspose.html.dom.svg.SVGException

com.aspose.html.dom.svg.SVGFilterElement

com.aspose.html.dom.svg.SVGForeignObjectElement

com.aspose.html.dom.svg.SVGGElement

com.aspose.html.dom.svg.SVGGeometryElement

com.aspose.html.dom.svg.SVGGradientElement

com.aspose.html.dom.svg.SVGGraphicsElement

com.aspose.html.dom.svg.SVGImageElement

com.aspose.html.dom.svg.SVGLinearGradientElement

com.aspose.html.dom.svg.SVGLineElement

com.aspose.html.dom.svg.SVGMarkerElement

com.aspose.html.dom.svg.SVGMaskElement

com.aspose.html.dom.svg.SVGMetadataElement

com.aspose.html.dom.svg.SVGMPathElement

com.aspose.html.dom.svg.SVGPathElement

com.aspose.html.dom.svg.SVGPatternElement

com.aspose.html.dom.svg.SVGPolygonElement

com.aspose.html.dom.svg.SVGPolylineElement

com.aspose.html.dom.svg.SVGRadialGradientElement

com.aspose.html.dom.svg.SVGRectElement

com.aspose.html.dom.svg.SVGRenderingIntent

com.aspose.html.dom.svg.SVGScriptElement

com.aspose.html.dom.svg.SVGSetElement

com.aspose.html.dom.svg.SVGStopElement

com.aspose.html.dom.svg.SVGStyleElement

com.aspose.html.dom.svg.SVGSVGElement

com.aspose.html.dom.svg.SVGSwitchElement

com.aspose.html.dom.svg.SVGSymbolElement

com.aspose.html.dom.svg.SVGTextContentElement

com.aspose.html.dom.svg.SVGTextElement

com.aspose.html.dom.svg.SVGTextPathElement

com.aspose.html.dom.svg.SVGTextPositioningElement

com.aspose.html.dom.svg.SVGTitleElement

com.aspose.html.dom.svg.SVGTSpanElement

com.aspose.html.dom.svg.SVGUnitTypes

com.aspose.html.dom.svg.SVGUseElement

com.aspose.html.dom.svg.SVGViewElement

com.aspose.html.dom.svg.SVGZoomAndPan

{{< /highlight >}}

{{< highlight java >}}

 // Aspose Metered Licensing mechanism has been added. Please, see https://purchase.aspose.com/faqs/licensing/metered for additional information.

com.aspose.html.Metered

com.aspose.html.Metered.setMeteredKey(java.lang.String, java.lang.String)

com.aspose.html.Metered.getConsumptionQuantity()

{{< /highlight >}}

{{< highlight java >}}

 // Provides HTTP content based on different data types and headers.

com.aspose.html.net.Content

com.aspose.html.net.ByteArrayContent

com.aspose.html.net.StreamContent

com.aspose.html.net.StringContent

com.aspose.html.net.FormUrlEncodedContent

{{< /highlight >}}

{{< highlight java >}}

 // Provides extended properties to setup the request message.

com.aspose.html.net.RequestMessage.getCredentials()

com.aspose.html.net.RequestMessage.getPreAuthenticate()

com.aspose.html.net.RequestMessage.getCookieContainer()

com.aspose.html.net.RequestMessage.getTimeout()

{{< /highlight >}}

{{< highlight java >}}

 // This is specialized object to describe the HTTP Content-Type header parameter.

com.aspose.html.net.headers.ContentTypeHeaderValue

{{< /highlight >}}

{{< highlight java >}}

 // Added possibility to specify the CSS media type during the rendering, the default value has been changed from 'Screen' to 'Print'. In order to receive an old behavior, please specify 'Screen' type.

com.aspose.html.rendering.RenderingOptions.Css.MediaType

enumeration com.aspose.html.rendering.MediaType

{{< /highlight >}}

{{< highlight java >}}

 // Since the 'page size' and 'page margin' could be defined both in CSS styles of document and user setting to resolve the priority conflict we have introduced 'AtPagePriority' property.

com.aspose.html.rendering.PageSetup.setAtPagePriority(int value)

enumeration com.aspose.html.rendering.AtPagePriority

{{< /highlight >}}
#### **Changed APIs:**
-----
{{< highlight java >}}

 com.aspose.html.net.RequestMessage.getBody()

com.aspose.html.net.ResponseMessage.getBody()

// The 'Body' property has been replaced with com.aspose.html.net.Content object.

// The inherited types com.aspose.html.net.ByteArrayContent, com.aspose.html.net.StreamContent, com.aspose.html.net.StringContent and com.aspose.html.net.FormUrlEncodedContent are available to set as a message content.

com.aspose.html.net.RequestMessage.setContent(com.aspose.html.net.Content value)

{{< /highlight >}}
#### **Removed APIs:**
-----
{{< highlight java >}}

 // The abstract class DOMConfiguration has been removed as unnecessary, all exists functionality have been moved to concrete implementation Aspose.Html.Configuration

class com.aspose.html.dom.DOMConfiguration

{{< /highlight >}}

{{< highlight java >}}

 // ContentEncoding and ContentType properties have been moved to the specialized com.aspose.html.net.ResponseHeaders.ContentType property.

com.aspose.html.net.ResponseMessage.getContentEncoding()

com.aspose.html.net.ResponseMessage.getContentType()

{{< /highlight >}}
#### **Loading, Navigation and Rendering by using SVG APIs:**
-----
{{< highlight java >}}

 // Simple SVG file

com.aspose.html.internal.ms.File.writeAllText("my.svg",

    "<svg xmlns=\"http://www.w3.org/2000/svg\" height=\"140\" width=\"500\">" +

    "<ellipse cx=\"200\" cy=\"80\" rx=\"100\" ry=\"50\" style=\"fill:yellow;stroke:purple;stroke-width:2\" />" +

    "</svg>");

// Create the new SVG document

com.aspose.html.dom.svg.SVGDocument document = new com.aspose.html.dom.svg.SVGDocument("my.svg");

// Simple navigation and inspection the element properties

com.aspose.html.dom.svg.SVGEllipseElement ellipse = (SVGEllipseElement)document.getElementsByTagName("ellipse").get_Item(0);

System.out.println(ellipse.getStyle().getCSSText());  // fill: yellow; stroke: purple; stroke-width: 2;

// Create the new SVG renderer & XPS device

com.aspose.html.rendering.SvgRenderer renderer = new SvgRenderer()

com.aspose.html.rendering.xps.XpsDevice device = new XpsDevice("my.xps")

// Render to the output device

renderer.render(device, document);

{{< /highlight >}}
