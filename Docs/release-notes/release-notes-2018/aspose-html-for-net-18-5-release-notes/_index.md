---
title: Aspose.HTML for .NET 18.5 Release Notes
type: docs
weight: 80
url: /net/aspose-html-for-net-18-5-release-notes/
---

### **Aspose.HTML for .NET 18.5 Release Notes**
-----
As per regular monthly update process of all APIs being offered by Aspose, we are honored to announce the May release of Aspose.HTML for .NET. In this release, we have increased numbers of supported platforms and our library is available for .NET Core now. Moreover, we have also extended numbers of supported formats. [W3C HTML Canvas](https://www.w3.org/TR/2dcontext/) is part of our library now, it supports rendering of HTML Canvas elements as a part of HTML document as well as direct access and manipulation of HTML Canvas 2D Context. Additionally, we have improved CSS engine as result we have increased performance of parsing of CSS documents up to 20 percent.
### **Improvement and Changes**

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|HTMLNET-1081|Support for rendering HTML Canvas 2D Context, Level 2|Enhancement|
|HTMLNET-1037|HTML to PNG - different image quality|Bug|
|HTMLNET-1120|Parameter is not valid exception|Bug|
### **Public API changes**
#### **Added APIs:**
TextOptions has been introduced in order to specify text rendering quality options
{{< highlight java >}}

 /// <summary>

/// Represents text rendering options for <see cref="ImageDevice"/>.

/// </summary>

class Aspose.Html.Rendering.Image.TextOptions

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Sets or gets <see cref="System.Drawing.Text.TextRenderingHint"/> which influences text rendering quality. By default this property is <see cref="System.Drawing.Text.TextRenderingHint.SystemDefault"/>.

/// </summary>

TextRenderingHint TextRenderingHint { get; set; }

{{< /highlight >}}
HTMLCanvasElement provides methods properties for manipulating W3C HTML Canvas layout.
{{< highlight java >}}

 /// <summary>

/// The HTMLCanvasElement interface provides properties and methods for manipulating the layout and presentation of canvas elements. 

/// The HTMLCanvasElement interface also inherits the properties and methods of the HTMLElement interface. 

/// </summary>

class Aspose.Html.HTMLCanvasElement

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Returns a drawing context on the canvas, or null if the context ID is not supported. A drawing context lets you draw on the canvas.

/// </summary>

/// <param name="contextId">Is a string containing the context identifier defining the drawing context associated to the canvas</param>

/// <param name="args">Context attributes</param>

/// <returns>A RenderingContext</returns>

object GetContext(string contextId, params object[] args)

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// returns a data URI containing a representation of the image in the format specified by the type parameter (defaults to PNG). 

/// The returned image is in a resolution of 96 dpi.

/// </summary>

/// <param name="type">A string indicating the image format. The default format type is image/png.</param>

/// <param name="encoderOptions">A Number between 0 and 1 indicating image quality if the requested type is image/jpeg or image/webp.</param>

string ToDataURL(string type, double encoderOptions)

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Is a positive integer reflecting the width HTML attribute of the canvas element interpreted in CSS pixels. 

/// When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 300 is used.

/// </summary>

ulong Width{ get; set; }

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Is a positive integer reflecting the height HTML attribute of the canvas element interpreted in CSS pixels. 

/// When the attribute is not specified, or if it is set to an invalid value, like a negative, 

/// the default value of 150 is used.

/// </summary>

ulong Height{ get; set; }

{{< /highlight >}}
HTML Canvas interfaces based on official specification (https://www.w3.org/TR/2dcontext/). All interfaces are located in Aspose.Html.Dom.Canvas namespace.
{{< highlight java >}}

 /// <summary>

/// The ICanvasRenderingContext2D interface is used for drawing rectangles, text, images and other objects onto the canvas element. It provides the 2D rendering context for the drawing surface of a canvas element.

/// </summary>

interface ICanvasRenderingContext2D : ICanvasDrawingStyles, ICanvasPathMethods

{

    // back-reference to the canvas

    /// <summary>

    /// A read-only back-reference to the HTMLCanvasElement. Might be null if it is not associated with a canvas element.

    /// </summary>

    HTMLCanvasElement Canvas { get; }

    // state

    /// <summary>

    /// Saves the current drawing style state using a stack so you can revert any change you make to it using restore().

    /// </summary>

    void Save(); // push state on state stack

    /// <summary>

    /// Restores the drawing style state to the last element on the 'state stack' saved by save().

    /// </summary>

    void Restore(); 

    // transformations (default: transform is the identity matrix)

    /// <summary>

    /// Adds a scaling transformation to the canvas units by x horizontally and by y vertically.

    /// </summary>

    /// <param name="x">Scaling factor in the horizontal direction.</param>

    /// <param name="y">Scaling factor in the vertical direction.</param>

    void Scale(double x, double y);

    /// <summary>

    /// Adds a rotation to the transformation matrix. The angle argument represents a clockwise rotation angle and is expressed in radians.

    /// </summary>

    /// <param name="angle">Represents a clockwise rotation angle expressed in radians.</param>

    void Rotate(double angle);

    /// <summary>

    /// Adds a translation transformation by moving the canvas and its origin x horzontally and y vertically on the grid.

    /// </summary>

    /// <param name="x">Distance to move in the horizontal direction.</param>

    /// <param name="y">Distance to move in the vertical direction.</param>

    void Translate(double x, double y);

    /// <summary>

    /// Multiplies the current transformation matrix with the matrix described by its arguments.

    /// </summary>

    /// <param name="a">Horizontal scaling.</param>

    /// <param name="b">Horizontal skewing.</param>

    /// <param name="c">Vertical skewing.</param>

    /// <param name="d">Vertical scaling.</param>

    /// <param name="e">Horizontal moving.</param>

    /// <param name="f">Vertical moving.</param>>

    void Transform(double a, double b, double c, double d, double e, double f);

    /// <summary>

    /// Resets the current transform to the identity matrix, and then invokes the transform() method with the same arguments.

    /// </summary>

    /// <param name="a">Horizontal scaling.</param>

    /// <param name="b">Horizontal skewing.</param>

    /// <param name="c">Vertical skewing.</param>

    /// <param name="d">Vertical scaling.</param>

    /// <param name="e">Horizontal moving.</param>

    /// <param name="f">Vertical moving.</param>

    void SetTransform(double a, double b, double c, double d, double e, double f);

    /// <summary>

    /// Resets the current transform by the identity matrix.

    /// </summary>

    void ResetTransform();

    // compositing

    /// <summary>

    ///  Alpha value that is applied to shapes and images before they are composited onto the canvas. Default 1.0 (opaque).

    /// </summary>

    double GlobalAlpha { get; set; } 

    /// <summary>

    /// With globalAlpha applied this sets how shapes and images are drawn onto the existing bitmap. Default: (source-over)

    /// </summary>

    string GlobalCompositeOperation { get; set; }

    // colors and styles (see also the CanvasDrawingStyles interface)

    /// <summary>

    /// Color or style to use for the lines around shapes. Default: (black).

    /// </summary>

    object StrokeStyle { get; set; } 

    /// <summary>

    /// Color or style to use inside shapes. Default: (black).

    /// </summary>

    object FillStyle { get; set; } 

    /// <summary>

    /// Creates a linear gradient along the line given by the coordinates represented by the parameters.

    /// </summary>

    /// <param name="x0">The x axis of the coordinate of the start point.</param>

    /// <param name="y0">The y axis of the coordinate of the start point.</param>

    /// <param name="x1">The x axis of the coordinate of the end point.</param>

    /// <param name="y1">The y axis of the coordinate of the end point.</param>

    /// <returns>The linear CanvasGradient.</returns>

    ICanvasGradient CreateLinearGradient(double x0, double y0, double x1, double y1);

    /// <summary>

    /// Creates a radial gradient given by the coordinates of the two circles represented by the parameters.

    /// </summary>

    /// <param name="x0">The x axis of the coordinate of the start circle.</param>

    /// <param name="y0">The y axis of the coordinate of the start circle</param>

    /// <param name="r0">The radius of the start circle.</param>

    /// <param name="x1">The x axis of the coordinate of the end circle.</param>

    /// <param name="y1">The y axis of the coordinate of the end circle.</param>

    /// <param name="r1">The radius of the end circle.</param>

    /// <returns>A radial CanvasGradient initialized with the two specified circles.</returns>

    ICanvasGradient CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1);

    /// <summary>

    /// Creates a pattern using the specified image (a CanvasImageSource). 

    /// It repeats the source in the directions specified by the repetition argument. 

    /// </summary>

    /// <param name="image">A HTMLImageElement to be used as the image to repeat</param>

    /// <param name="repetition">A string indicating how to repeat the image.</param>

    /// <returns>An opaque object describing a pattern.</returns>

    ICanvasPattern CreatePattern(HTMLImageElement image, string repetition);

    /// <summary>

    /// Creates a pattern using the specified image (a CanvasImageSource). 

    /// It repeats the source in the directions specified by the repetition argument. 

    /// </summary>

    /// <param name="image">A HTMLCanvasElement to be used as the image to repeat</param>

    /// <param name="repetition">A string indicating how to repeat the image.</param>

    /// <returns>An opaque object describing a pattern.</returns>

    ICanvasPattern CreatePattern(HTMLCanvasElement image, string repetition);

    // shadows

    /// <summary>

    /// Horizontal distance the shadow will be offset. Default 0.

    /// </summary>

    double ShadowOffsetX { get; set; }

    /// <summary>

    /// Vertical distance the shadow will be offset. Default 0.

    /// </summary>

    double ShadowOffsetY { get; set; } 

    /// <summary>

    /// Specifies the blurring effect. Default 0

    /// </summary>

    double ShadowBlur { get; set; }

    /// <summary>

    /// Color of the shadow. Default fully-transparent black.

    /// </summary>

    string ShadowColor { get; set; }

    // rects

    /// <summary>

    /// Sets all pixels in the rectangle defined by starting point (x, y) and size (width, height) to transparent black, erasing any previously drawn content.

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the rectangle starting point.</param>

    /// <param name="y">The y axis of the coordinate for the rectangle starting point.</param>

    /// <param name="w">The rectangle's width.</param>

    /// <param name="h">The rectangle's height.</param>

    void ClearRect(double x, double y, double w, double h);

    /// <summary>

    /// Draws a filled rectangle at (x, y) position whose size is determined by width and height.

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the rectangle starting point.</param>

    /// <param name="y">The y axis of the coordinate for the rectangle starting point.</param>

    /// <param name="w">The rectangle's width.</param>

    /// <param name="h">The rectangle's height.</param>

    void FillRect(double x, double y, double w, double h);

    /// <summary>

    /// Paints a rectangle which has a starting point at (x, y) and has a w width and an h height onto the canvas, using the current stroke style.

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the rectangle starting point.</param>

    /// <param name="y">The y axis of the coordinate for the rectangle starting point.</param>

    /// <param name="w">The rectangle's width.</param>

    /// <param name="h">The rectangle's height.</param>

    void StrokeRect(double x, double y, double w, double h);

    // path API (see also CanvasPathMethods)

    /// <summary>

    /// Starts a new path by emptying the list of sub-paths. Call this method when you want to create a new path.

    /// </summary>

    void BeginPath();

    /// <summary>

    /// Fills the subpaths with the current fill style and default algorithm CanvasFillRule.Nonzero.

    /// </summary>

    void Fill();

    /// <summary>

    /// Fills the subpaths with the current fill style.

    /// </summary>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path.</param>

    void Fill(CanvasFillRule fillRule);

    /// <summary>

    /// Fills the subpaths with the current fill style and default algorithm CanvasFillRule.Nonzero.

    /// </summary>

    /// <param name="path">A Path2D path to fill.</param>

    void Fill(Path2D path);

    /// <summary>

    /// Fills the subpaths with the current fill style.

    /// </summary>

    /// <param name="path">A Path2D path to fill.</param>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path.</param>

    void Fill(Path2D path, CanvasFillRule fillRule);

    /// <summary>

    /// Strokes the subpaths with the current stroke style.

    /// </summary>

    void Stroke();

    /// <summary>

    /// Strokes the subpaths with the current stroke style.

    /// </summary>

    /// <param name="path">A Path2D path to stroke.</param>

    void Stroke(Path2D path);

    /// <summary>

    /// If a given element is focused, this method draws a focus ring around the current path.

    /// </summary>

    /// <param name="element">The element to check whether it is focused or not.</param>

    void DrawFocusIfNeeded(Html.Dom.Element element);

    /// <summary>

    /// Creates a new clipping region by calculating the intersection of the current clipping region and the area described by the path, using the non-zero winding number rule.

    /// Open subpaths must be implicitly closed when computing the clipping region, without affecting the actual subpaths.

    /// The new clipping region replaces the current clipping region.

    /// </summary>

    void Clip();

    /// <summary>

    /// Creates a new clipping region by calculating the intersection of the current clipping region and the area described by the path, using the non-zero winding number rule. 

    /// Open subpaths must be implicitly closed when computing the clipping region, without affecting the actual subpaths.

    /// The new clipping region replaces the current clipping region.

    /// </summary>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path</param>

    void Clip(CanvasFillRule fillRule);

    /// <summary>

    /// Creates a new clipping region by calculating the intersection of the current clipping region and the area described by the path, using the non-zero winding number rule. 

    /// Open subpaths must be implicitly closed when computing the clipping region, without affecting the actual subpaths.

    /// The new clipping region replaces the current clipping region.

    /// </summary>

    /// <param name="path">A Path2D path to clip.</param>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path.</param>

    void Clip(Path2D path, CanvasFillRule fillRule);

    /// <summary>

    /// Reports whether or not the specified point is contained in the current path. 

    /// </summary>

    /// <param name="x">The X coordinate of the point to check.</param>

    /// <param name="y">The Y coordinate of the point to check.</param>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path.</param>

    /// <returns>Returns true if the point is inside the area contained by the filling of a path, otherwise false.</returns>

    bool IsPointInPath(double x, double y, CanvasFillRule fillRule);

    /// <summary>

    /// Reports whether or not the specified point is contained in the current path. 

    /// </summary>

    /// <param name="path">A Path2D path to check.</param>

    /// <param name="x">The X coordinate of the point to check.</param>

    /// <param name="y">The Y coordinate of the point to check.</param>

    /// <param name="fillRule">The algorithm by which to determine if a point is inside a path or outside a path.</param>

    /// <returns>Returns true if the point is inside the area contained by the filling of a path, otherwise false.</returns>

    bool IsPointInPath(Path2D path, double x, double y, CanvasFillRule fillRule);

    /// <summary>

    /// Reports whether or not the specified point is inside the area contained by the stroking of a path. 

    /// </summary>

    /// <param name="x">The X coordinate of the point to check.</param>

    /// <param name="y">The Y coordinate of the point to check.</param>

    /// <returns>Returns true if the point is inside the area contained by the stroking of a path, otherwise false.</returns>

    bool IsPointInStroke(double x, double y);

    /// <summary>

    /// Reports whether or not the specified point is inside the area contained by the stroking of a path. 

    /// </summary>

    /// <param name="path">A Path2D path to check.</param>

    /// <param name="x">The X coordinate of the point to check.</param>

    /// <param name="y">The Y coordinate of the point to check.</param>

    /// <returns>Returns true if the point is inside the area contained by the stroking of a path, otherwise false.</returns>

    bool IsPointInStroke(Path2D path, double x, double y);

    /// <summary>

    /// Draws (fills) a given text at the given (x,y) position.

    /// </summary>

    /// <param name="text">The text to draw using the current font, textAlign, textBaseline, and direction values.</param>

    /// <param name="x">The x axis of the coordinate for the text starting point.</param>

    /// <param name="y">The y axis of the coordinate for the text starting point.</param>

    /// <param name="maxWidth">The maximum width to draw. If specified, and the string is computed to be wider than this width, the font is adjusted to use a more horizontally condensed font (if one is available or if a reasonably readable one can be synthesized by scaling the current font horizontally) or a smaller font.</param>

    void FillText(string text, double x, double y, double? maxWidth);

    /// <summary>

    /// Draws (strokes) a given text at the given (x, y) position.

    /// </summary>

    /// <param name="text">The text to draw using the current font, textAlign, textBaseline, and direction values.</param>

    /// <param name="x">The x axis of the coordinate for the text starting point.</param>

    /// <param name="y">The y axis of the coordinate for the text starting point.</param>

    /// <param name="maxWidth">The maximum width to draw. If specified, and the string is computed to be wider than this width, the font is adjusted to use a more horizontally condensed font (if one is available or if a reasonably readable one can be synthesized by scaling the current font horizontally) or a smaller font.</param>

    void StrokeText(string text, double x, double y, double? maxWidth);

    /// <summary>

    /// Returns a TextMetrics object.

    /// </summary>

    /// <param name="text">The text to measure.</param>

    /// <returns>A TextMetrics object.</returns>

    ITextMetrics MeasureText(string text);

    // drawing images

    /// <summary>

    /// Draws the specified image.

    /// </summary>

    /// <param name="image">The HTMLImageElement to draw into the context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    void DrawImage(HTMLImageElement image, double dx, double dy);

    /// <summary>

    /// Draws the specified image.

    /// </summary>

    /// <param name="image">The HTMLCanvasElement to draw into the context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    void DrawImage(HTMLCanvasElement image, double dx, double dy);

    /// <summary>

    ///  Draws the specified image.

    /// </summary>

    /// <param name="image">The HTMLImageElement to draw into the context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dw">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn.</param>

    /// <param name="dh">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn.</param>

    void DrawImage(HTMLImageElement image, double dx, double dy, double dw, double dh);

    /// <summary>

    ///  Draws the specified image.

    /// </summary>

    /// <param name="image">The HTMLCanvasElement to draw into the context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dw">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn.</param>

    /// <param name="dh">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn.</param>

    void DrawImage(HTMLCanvasElement image, double dx, double dy, double dw, double dh);

    /// <summary>

    /// Draws the specified image. 

    /// </summary>

    /// <param name="image">The HTMLImageElement to draw into the context.</param>

    /// <param name="sx">The X coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="sy">The Y coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="sw">The width of the sub-rectangle of the source image to draw into the destination context. If not specified, the entire rectangle from the coordinates specified by sx and sy to the bottom-right corner of the image is used.</param>

    /// <param name="sh">The height of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dw">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn.</param>

    /// <param name="dh">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn.</param>

    void DrawImage(HTMLImageElement image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh);

    /// <summary>

    /// Draws the specified image. 

    /// </summary>

    /// <param name="image">The HTMLCanvasElement to draw into the context.</param>

    /// <param name="sx">The X coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="sy">The Y coordinate of the top left corner of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="sw">The width of the sub-rectangle of the source image to draw into the destination context. If not specified, the entire rectangle from the coordinates specified by sx and sy to the bottom-right corner of the image is used.</param>

    /// <param name="sh">The height of the sub-rectangle of the source image to draw into the destination context.</param>

    /// <param name="dx">The X coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dy">The Y coordinate in the destination canvas at which to place the top-left corner of the source image.</param>

    /// <param name="dw">The width to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in width when drawn.</param>

    /// <param name="dh">The height to draw the image in the destination canvas. This allows scaling of the drawn image. If not specified, the image is not scaled in height when drawn.</param>

    void DrawImage(HTMLCanvasElement image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh);

    // hit regions

    /// <summary>

    /// Adds a hit region to the canvas. 

    /// This allows you to make hit detection easier, lets you route events to DOM elements, 

    /// and makes it possible for users to explore the canvas without seeing it.

    /// </summary>

    /// <param name="options">The options argument is optional. When provided, it is an Object which can contain properties.</param>

    void AddHitRegion(Dictionary<string,string> options);

    /// <summary>

    /// Removes the hit region with the specified id from the canvas.

    /// </summary>

    /// <param name="id">A string representing the id of the region that is to be removed.</param>

    void RemoveHitRegion(string id);

    /// <summary>

    /// Removes all hit regions from the canvas.

    /// </summary>

    void ClearHitRegions();

    // pixel manipulation

    /// <summary>

    /// Creates a new, blank ImageData object with the specified dimensions. 

    /// All of the pixels in the new object are transparent black.

    /// </summary>

    /// <param name="sw">The width to give the new ImageData object.</param>

    /// <param name="sh">The height to give the new ImageData object.</param>

    /// <returns>A new ImageData object with the specified width and height. The new object is filled with transparent black pixels.</returns>

    IImageData CreateImageData(double sw, double sh);

    /// <summary>

    /// Creates a new, blank ImageData object with the specified dimensions. 

    /// All of the pixels in the new object are transparent black.

    /// </summary>

    /// <param name="imagedata">An existing ImageData object from which to copy the width and height. The image itself is not copied.</param>

    /// <returns>A new ImageData object with the specified width and height. The new object is filled with transparent black pixels.</returns>

    IImageData CreateImageData(IImageData imagedata);

    /// <summary>

    /// Returns an ImageData object representing the underlying pixel data for the area of the canvas denoted by the rectangle which starts at (sx, sy) and has an sw width and sh height.

    /// This method is not affected by the canvas transformation matrix.

    /// </summary>

    /// <param name="sx">The x coordinate of the upper left corner of the rectangle from which the ImageData will be extracted.</param>

    /// <param name="sy">The y coordinate of the upper left corner of the rectangle from which the ImageData will be extracted.</param>

    /// <param name="sw">The width of the rectangle from which the ImageData will be extracted.</param>

    /// <param name="sh">The height of the rectangle from which the ImageData will be extracted.</param>

    /// <returns>An ImageData object containing the image data for the given rectangle of the canvas.</returns>

    IImageData GetImageData(double sx, double sy, double sw, double sh);

    /// <summary>

    /// Paints data from the given ImageData object onto the bitmap. 

    /// If a dirty rectangle is provided, only the pixels from that rectangle are painted. 

    /// This method is not affected by the canvas transformation matrix.

    /// </summary>

    /// <param name="imagedata">An ImageData object containing the array of pixel values.</param>

    /// <param name="dx">Horizontal position (x-coordinate) at which to place the image data in the destination canvas.</param>

    /// <param name="dy">Vertical position (y-coordinate) at which to place the image data in the destination canvas.</param>

    void PutImageData(IImageData imagedata, double dx, double dy);

    /// <summary>

    /// Paints data from the given ImageData object onto the bitmap. 

    /// If a dirty rectangle is provided, only the pixels from that rectangle are painted. 

    /// This method is not affected by the canvas transformation matrix.

    /// </summary>

    /// <param name="imagedata">An ImageData object containing the array of pixel values.</param>

    /// <param name="dx">Horizontal position (x-coordinate) at which to place the image data in the destination canvas.</param>

    /// <param name="dy">Vertical position (y-coordinate) at which to place the image data in the destination canvas.</param>

    /// <param name="dirtyX">Horizontal position (x-coordinate). The x coordinate of the top left hand corner of your Image data. Defaults to 0.</param>

    /// <param name="dirtyY">Vertical position (y-coordinate). The y coordinate of the top left hand corner of your Image data. Defaults to 0.</param>

    /// <param name="dirtyWidth">Width of the rectangle to be painted. Defaults to the width of the image data.</param>

    /// <param name="dirtyHeight">Height of the rectangle to be painted. Defaults to the height of the image data.</param>

    void PutImageData(IImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight);

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// The ICanvasDrawingStyles interface provides methods and properties control how lines are drawn and how text is laid out.

/// </summary>

interface ICanvasDrawingStyles

{

    // line caps/joins

    /// <summary>

    /// Width of lines. Default 1.0

    /// </summary>

    double LineWidth { get; set; }

    /// <summary>

    /// Type of endings on the end of lines. Possible values: butt (default), round, square.

    /// </summary>

    string LineCap { get; set; }

    /// <summary>

    /// Defines the type of corners where two lines meet. Possible values: round, bevel, miter (default).

    /// </summary>

    string LineJoin { get; set; }

    /// <summary>

    /// Miter limit ratio. Default 10.

    /// </summary>

    double MiterLimit { get; set; }

    // dashed lines

    /// <summary>

    /// Sets the current line dash pattern.

    /// </summary>

    /// <param name="segments">An Array of numbers which specify distances to alternately draw a line and a gap (in coordinate space units)</param>

    void SetLineDash(double[] segments);

    /// <summary>

    /// Returns the current line dash pattern array containing an even number of non-negative numbers.

    /// </summary>

    /// <returns>An Array. A list of numbers that specifies distances to alternately draw a line and a gap (in coordinate space units).</returns>

    double[] GetLineDash();

    /// <summary>

    /// Specifies where to start a dash array on a line.

    /// </summary>

    double LineDashOffset { get; set; }

    // text

    /// <summary>

    /// Font setting. Default value 10px sans-serif

    /// </summary>

    string Font { get; set; }

    /// <summary>

    /// Text alignment setting. Possible values: start (default), end, left, right or center.

    /// </summary>

    string TextAlign { get; set; }

    /// <summary>

    /// Baseline alignment setting. Possible values: top, hanging, middle, alphabetic (default), ideographic, bottom.

    /// </summary>

    string TextBaseline { get; set; } 

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

///  Represents an opaque object describing a gradient.

/// </summary>

interface ICanvasGradient

{

    /// <summary>

    ///  Adds a new stop, defined by an offset and a color, to the gradient.

    /// </summary>

    /// <param name="offset">A number between 0 and 1.</param>

    /// <param name="color">A CSS color</param>

    void AddColorStop(double offset, string color);

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// The ICanvasPathMethods interface is used to manipulate paths of objects.

/// </summary>

interface ICanvasPathMethods

{

    /// <summary>

    /// Causes the point of the pen to move back to the start of the current sub-path. 

    /// It tries to draw a straight line from the current point to the start. 

    /// If the shape has already been closed or has only one point, this function does nothing.

    /// </summary>

    void ClosePath();

    /// <summary>

    /// Moves the starting point of a new sub-path to the (x, y) coordinates.

    /// </summary>

    /// <param name="x">The x axis of the point</param>

    /// <param name="y">The y axis of the point</param>

    void MoveTo(double x, double y);

    /// <summary>

    /// Connects the last point in the subpath to the x, y coordinates with a straight line.

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the end of the line.</param>

    /// <param name="y">The y axis of the coordinate for the end of the line.</param>

    void LineTo(double x, double y);

    /// <summary>

    /// Adds a quadratic Bézier curve to the current path.

    /// </summary>

    /// <param name="cpx">The x axis of the coordinate for the control point.</param>

    /// <param name="cpy">The y axis of the coordinate for the control point.</param>

    /// <param name="x">The x axis of the coordinate for the end point.</param>

    /// <param name="y">The y axis of the coordinate for the end point.</param>

    void QuadraticCurveTo(double cpx, double cpy, double x, double y);

    /// <summary>

    /// Adds a cubic Bézier curve to the path. It requires three points. 

    /// The first two points are control points and the third one is the end point. 

    /// The starting point is the last point in the current path, 

    /// which can be changed using moveTo() before creating the Bézier curve.

    /// </summary>

    /// <param name="cp1x">The x axis of the coordinate for the first control point.</param>

    /// <param name="cp1y">The y axis of the coordinate for the first control point.</param>

    /// <param name="cp2x">The x axis of the coordinate for the second control point.</param>

    /// <param name="cp2y">The y axis of the coordinate for the second control point.</param>

    /// <param name="x">The x axis of the coordinate for the end point.</param>

    /// <param name="y">The y axis of the coordinate for the end point.</param>

    void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y);

    /// <summary>

    /// Adds an arc to the path with the given control points and radius, connected to the previous point by a straight line.

    /// </summary>

    /// <param name="x1">x-axis coordinates for the first control point.</param>

    /// <param name="y1">y-axis coordinates for the first control point.</param>

    /// <param name="x2">x-axis coordinates for the second control point.</param>

    /// <param name="y2">y-axis coordinates for the second control point.</param>

    /// <param name="radius">The arc's radius.</param>

    void ArcTo(double x1, double y1, double x2, double y2, double radius);

    /// <summary>

    /// Creates a path for a rectangle at position (x, y) with a size that is determined by width and height.

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the rectangle starting point.</param>

    /// <param name="y">The y axis of the coordinate for the rectangle starting point.</param>

    /// <param name="w">The rectangle's width.</param>

    /// <param name="h">The rectangle's height.</param>

    void Rect(double x, double y, double w, double h);

    /// <summary>

    /// Adds an arc to the path which is centered at (x, y) position with radius r starting at startAngle and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise).

    /// </summary>

    /// <param name="x">The x coordinate of the arc's center.</param>

    /// <param name="y">The y coordinate of the arc's center.</param>

    /// <param name="radius">The arc's radius.</param>

    /// <param name="startAngle">The angle at which the arc starts, measured clockwise from the positive x axis and expressed in radians.</param>

    /// <param name="endAngle">The angle at which the arc ends, measured clockwise from the positive x axis and expressed in radians.</param>

    void Arc(double x, double y, double radius, double startAngle, double endAngle);

    /// <summary>

    /// Adds an arc to the path which is centered at (x, y) position with radius r starting at startAngle and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise).

    /// </summary>

    /// <param name="x">The x coordinate of the arc's center.</param>

    /// <param name="y">The y coordinate of the arc's center.</param>

    /// <param name="radius">The arc's radius.</param>

    /// <param name="startAngle">The angle at which the arc starts, measured clockwise from the positive x axis and expressed in radians.</param>

    /// <param name="endAngle">The angle at which the arc ends, measured clockwise from the positive x axis and expressed in radians.</param>

    /// <param name="counterclockwise">Causes the arc to be drawn counter-clockwise between the two angles. By default it is drawn clockwise.</param>

    void Arc(double x, double y, double radius, double startAngle, double endAngle, bool counterclockwise);

    /// <summary>

    ///  Adds an ellipse to the path which is centered at (x, y) position with the radii radiusX and radiusY starting at startAngle

    ///  and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise).

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the ellipse's center.</param>

    /// <param name="y">The y axis of the coordinate for the ellipse's center.</param>

    /// <param name="radiusX">The ellipse's major-axis radius.</param>

    /// <param name="radiusY">The ellipse's minor-axis radius.</param>

    /// <param name="rotation">The rotation for this ellipse, expressed in radians.</param>

    /// <param name="startAngle">The starting point, measured from the x axis, from which it will be drawn, expressed in radians.</param>

    /// <param name="endAngle">The end ellipse's angle to which it will be drawn, expressed in radians.</param>

    void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle);

    /// <summary>

    ///  Adds an ellipse to the path which is centered at (x, y) position with the radii radiusX and radiusY starting at startAngle

    ///  and ending at endAngle going in the given direction by anticlockwise (defaulting to clockwise).

    /// </summary>

    /// <param name="x">The x axis of the coordinate for the ellipse's center.</param>

    /// <param name="y">The y axis of the coordinate for the ellipse's center.</param>

    /// <param name="radiusX">The ellipse's major-axis radius.</param>

    /// <param name="radiusY">The ellipse's minor-axis radius.</param>

    /// <param name="rotation">The rotation for this ellipse, expressed in radians.</param>

    /// <param name="startAngle">The starting point, measured from the x axis, from which it will be drawn, expressed in radians.</param>

    /// <param name="endAngle">The end ellipse's angle to which it will be drawn, expressed in radians.</param>

    /// <param name="anticlockwise">An optional boolean which, if true, draws the ellipse anticlockwise (counter-clockwise), otherwise in a clockwise direction.</param>

    void Ellipse(double x, double y, double radiusX, double radiusY, double rotation, double startAngle, double endAngle, bool anticlockwise);

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Represents an opaque object describing a pattern, based on an image, a canvas or a video.

/// </summary>

interface ICanvasPattern

{

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Creates an ImageData object from a given Uint8ClampedArray and the size of the image it contains. 

/// If no array is given, it creates an image of a black rectangle.

/// </summary>

interface IImageData

{

    /// <summary>

    /// Is an unsigned long representing the actual width, in pixels, of the ImageData.

    /// </summary>

    ulong Width { get; }

    /// <summary>

    /// Is an unsigned long representing the actual height, in pixels, of the ImageData.

    /// </summary>

    ulong Height { get; }

    /// <summary>

    /// Is a Uint8ClampedArray representing a one-dimensional array containing the data in the RGBA order, 

    /// with integer values between 0 and 255 (included).

    /// </summary>

    byte[] Data { get; }

}

{{< /highlight >}}

{{< highlight java >}}

 /// <summary>

/// Represents the dimension of a text in the canvas.

/// </summary>

interface ITextMetrics

{

    /// <summary>

    /// Is a double giving the calculated width of a segment of inline text in CSS pixels.

    /// </summary>

    double Width { get; }

}

{{< /highlight >}}




