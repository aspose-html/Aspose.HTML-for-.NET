---
title: Aspose.HTML for .NET 18.1 Release Notes
type: docs
weight: 130
url: /net/aspose-html-for-net-18-1-release-notes/
---

### **Release Notes of Aspose.HTML for .NET 18.1**
We are pleased to announce that our series of W3C formats has been extended and now we support Scale-able Vector Graphics (SVG) format. Our API offers the capabilities to manipulate SVG, both as a part of HTML document and single SVGDocument object. This API is fully compatible with the W3C SVG 2 recommendation and previously implemented HTML format, so every manipulation features: loading, saving, editing, navigation or rendering features supported exactly in the same way.
### **Public API changes**
#### **Added APIs:**
{{< highlight csharp >}}

 // These methods has been migrated from deleted abstract class DOMConfiguration

Aspose.Html.Configuration.AddService<T>(T service)

Aspose.Html.Configuration.GetService<T>()

// These changes have been made according to W3C Shadow DOM recommendation

Aspose.Html.Dom.ShadowRoot Aspose.Html.Dom.Element.AttachShadow(Aspose.Html.Dom.ShadowRootMode mode)

Aspose.Html.Dom.ShadowRoot Aspose.Html.Dom.Element.ShadowRoot { get; }

// Added the default constructors to all devices to simplify usage

Aspose.Html.Rendering.Image.ImageDevice.#ctor(System.String)

Aspose.Html.Rendering.Image.ImageDevice.#ctor(System.IO.Stream)

Aspose.Html.Rendering.Pdf.PdfDevice.#ctor(System.IO.Stream)

Aspose.Html.Rendering.Pdf.PdfDevice.#ctor(System.String)

Aspose.Html.Rendering.Xps.XpsDevice.#ctor(System.IO.Stream)

Aspose.Html.Rendering.Xps.XpsDevice.#ctor(System.String)

// Added ability to specify the image resolution during the rendering to the output device

Aspose.Html.Rendering.RenderingOptions.HorizontalResolution { get; set; }

Aspose.Html.Rendering.RenderingOptions.VerticalResolution { get; set; }

// Added the new SvgRenderer object for processing SVG documents

Aspose.Html.Rendering.SvgRenderer

Aspose.Html.Rendering.SvgRenderer.Render(Aspose.Html.Rendering.IDevice ddevice, Aspose.Html.Dom.Svg.SVGDocument document)

// Introduced the new SVG namespace. All classes in this namespace are based on w3c SVG2 recomendation (https://www.w3.org/TR/SVG2/)

Aspose.Html.Dom.Svg.DataTypes.SVGAngle

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedAngle

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedBoolean

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedEnumeration

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedInteger

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedLength

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedLengthList

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedNumber

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedNumberList

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedPreserveAspectRatio

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedRect

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedString

Aspose.Html.Dom.Svg.DataTypes.SVGAnimatedTransformList

Aspose.Html.Dom.Svg.DataTypes.SVGLength

Aspose.Html.Dom.Svg.DataTypes.SVGLengthList

Aspose.Html.Dom.Svg.DataTypes.SVGMatrix

Aspose.Html.Dom.Svg.DataTypes.SVGNumber

Aspose.Html.Dom.Svg.DataTypes.SVGNumberList

Aspose.Html.Dom.Svg.DataTypes.SVGPoint

Aspose.Html.Dom.Svg.DataTypes.SVGPointList

Aspose.Html.Dom.Svg.DataTypes.SVGPreserveAspectRatio

Aspose.Html.Dom.Svg.DataTypes.SVGRect

Aspose.Html.Dom.Svg.DataTypes.SVGStringList

Aspose.Html.Dom.Svg.DataTypes.SVGTransform

Aspose.Html.Dom.Svg.DataTypes.SVGTransformList

Aspose.Html.Dom.Svg.DataTypes.SVGValueType

Aspose.Html.Dom.Svg.Events.SVGZoomEvent

Aspose.Html.Dom.Svg.Events.TimeEvent

Aspose.Html.Dom.Svg.Filters.ISVGFilterPrimitiveStandardAttributes

Aspose.Html.Dom.Svg.Filters.SVGFEBlendElement

Aspose.Html.Dom.Svg.Filters.SVGFEColorMatrixElement

Aspose.Html.Dom.Svg.Filters.SVGFEComponentTransferElement

Aspose.Html.Dom.Svg.Filters.SVGFECompositeElement

Aspose.Html.Dom.Svg.Filters.SVGFEConvolveMatrixElement

Aspose.Html.Dom.Svg.Filters.SVGFEDiffuseLightingElement

Aspose.Html.Dom.Svg.Filters.SVGFEDisplacementMapElement

Aspose.Html.Dom.Svg.Filters.SVGFEDistantLightElement

Aspose.Html.Dom.Svg.Filters.SVGFEDropShadowElement

Aspose.Html.Dom.Svg.Filters.SVGFEFloodElement

Aspose.Html.Dom.Svg.Filters.SVGFEFuncAElement

Aspose.Html.Dom.Svg.Filters.SVGFEFuncBElement

Aspose.Html.Dom.Svg.Filters.SVGFEFuncGElement

Aspose.Html.Dom.Svg.Filters.SVGFEFuncRElement

Aspose.Html.Dom.Svg.Filters.SVGFEGaussianBlurElement

Aspose.Html.Dom.Svg.Filters.SVGFEImageElement

Aspose.Html.Dom.Svg.Filters.SVGFEMergeElement

Aspose.Html.Dom.Svg.Filters.SVGFEMergeNodeElement

Aspose.Html.Dom.Svg.Filters.SVGFEMorphologyElement

Aspose.Html.Dom.Svg.Filters.SVGFEOffsetElement

Aspose.Html.Dom.Svg.Filters.SVGFEPointLightElement

Aspose.Html.Dom.Svg.Filters.SVGFESpecularLightingElement

Aspose.Html.Dom.Svg.Filters.SVGFESpotLightElement

Aspose.Html.Dom.Svg.Filters.SVGFETileElement

Aspose.Html.Dom.Svg.Filters.SVGFETurbulenceElement

Aspose.Html.Dom.Svg.ISVGAnimatedPoints

Aspose.Html.Dom.Svg.ISVGFitToViewBox

Aspose.Html.Dom.Svg.ISVGRenderingIntent

Aspose.Html.Dom.Svg.ISVGTests

Aspose.Html.Dom.Svg.ISVGUnitTypes

Aspose.Html.Dom.Svg.ISVGURIReference

Aspose.Html.Dom.Svg.ISVGZoomAndPan

Aspose.Html.Dom.Svg.Paths.ISVGAnimatedPathData

Aspose.Html.Dom.Svg.Paths.SVGPathSeg

Aspose.Html.Dom.Svg.Paths.SVGPathSegArcAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegArcRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegClosePath

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoCubicAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoCubicRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoCubicSmoothAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoCubicSmoothRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoQuadraticAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoQuadraticRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoQuadraticSmoothAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegCurvetoQuadraticSmoothRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoHorizontalAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoHorizontalRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoVerticalAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegLinetoVerticalRel

Aspose.Html.Dom.Svg.Paths.SVGPathSegList

Aspose.Html.Dom.Svg.Paths.SVGPathSegMovetoAbs

Aspose.Html.Dom.Svg.Paths.SVGPathSegMovetoRel

Aspose.Html.Dom.Svg.SVGAElement

Aspose.Html.Dom.Svg.SVGAnimateElement

Aspose.Html.Dom.Svg.SVGAnimateMotionElement

Aspose.Html.Dom.Svg.SVGAnimateTransformElement

Aspose.Html.Dom.Svg.SVGAnimationElement

Aspose.Html.Dom.Svg.SVGCircleElement

Aspose.Html.Dom.Svg.SVGClipPathElement

Aspose.Html.Dom.Svg.SVGComponentTransferFunctionElement

Aspose.Html.Dom.Svg.SVGCursorElement

Aspose.Html.Dom.Svg.SVGDefsElement

Aspose.Html.Dom.Svg.SVGDescElement

Aspose.Html.Dom.Svg.SVGDocument

Aspose.Html.Dom.Svg.SVGElement

Aspose.Html.Dom.Svg.SVGElementInstance

Aspose.Html.Dom.Svg.SVGEllipseElement

Aspose.Html.Dom.Svg.SVGException

Aspose.Html.Dom.Svg.SVGFilterElement

Aspose.Html.Dom.Svg.SVGForeignObjectElement

Aspose.Html.Dom.Svg.SVGGElement

Aspose.Html.Dom.Svg.SVGGeometryElement

Aspose.Html.Dom.Svg.SVGGradientElement

Aspose.Html.Dom.Svg.SVGGraphicsElement

Aspose.Html.Dom.Svg.SVGImageElement

Aspose.Html.Dom.Svg.SVGLinearGradientElement

Aspose.Html.Dom.Svg.SVGLineElement

Aspose.Html.Dom.Svg.SVGMarkerElement

Aspose.Html.Dom.Svg.SVGMaskElement

Aspose.Html.Dom.Svg.SVGMetadataElement

Aspose.Html.Dom.Svg.SVGMPathElement

Aspose.Html.Dom.Svg.SVGPathElement

Aspose.Html.Dom.Svg.SVGPatternElement

Aspose.Html.Dom.Svg.SVGPolygonElement

Aspose.Html.Dom.Svg.SVGPolylineElement

Aspose.Html.Dom.Svg.SVGRadialGradientElement

Aspose.Html.Dom.Svg.SVGRectElement

Aspose.Html.Dom.Svg.SVGRenderingIntent

Aspose.Html.Dom.Svg.SVGScriptElement

Aspose.Html.Dom.Svg.SVGSetElement

Aspose.Html.Dom.Svg.SVGStopElement

Aspose.Html.Dom.Svg.SVGStyleElement

Aspose.Html.Dom.Svg.SVGSVGElement

Aspose.Html.Dom.Svg.SVGSwitchElement

Aspose.Html.Dom.Svg.SVGSymbolElement

Aspose.Html.Dom.Svg.SVGTextContentElement

Aspose.Html.Dom.Svg.SVGTextElement

Aspose.Html.Dom.Svg.SVGTextPathElement

Aspose.Html.Dom.Svg.SVGTextPositioningElement

Aspose.Html.Dom.Svg.SVGTitleElement

Aspose.Html.Dom.Svg.SVGTSpanElement

Aspose.Html.Dom.Svg.SVGUnitTypes

Aspose.Html.Dom.Svg.SVGUseElement

Aspose.Html.Dom.Svg.SVGViewElement

Aspose.Html.Dom.Svg.SVGZoomAndPan

{{< /highlight >}}
#### **Removed APIs:**
{{< highlight csharp >}}

 // The abstract class DOMConfiguration has been removed as unnecessary, all exists functionality have been moved to concrete implementation Aspose.Html.Configuration

class Aspose.Html.Dom.DOMConfiguration

{{< /highlight >}}

