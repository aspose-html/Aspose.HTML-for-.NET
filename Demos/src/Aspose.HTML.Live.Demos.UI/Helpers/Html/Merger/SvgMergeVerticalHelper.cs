using Aspose.Html.Dom.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Merger
{
	public class SvgMergeVerticalHelper : SvgMergeHelper
	{
		protected override SVGElement GetSeparatorContainer(SVGDocument parentDocument, SeparatorDescription description)
		{
			var gSeparatorContainer =
				 (SVGGElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "g");
			gSeparatorContainer.SetAttribute("stroke", description.StrokeColor);
			gSeparatorContainer.SetAttribute("stroke-width", GetCulturedString(description.Stroke));
			gSeparatorContainer.SetAttribute("stroke-linecap", "bevel");
			gSeparatorContainer.SetAttribute("stroke-linejoin", "round");

			var width = description.X + description.Width;
			var height = description.Y + description.Height + description.Stroke / 2;
			for (int i = 0; i < description.Amount; i++)
			{
				var lineSeparator =
					(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
				lineSeparator.SetAttribute("x1", GetCulturedString(description.X));
				lineSeparator.SetAttribute("y1", GetCulturedString(height));
				lineSeparator.SetAttribute("x2", GetCulturedString(width));
				lineSeparator.SetAttribute("y2", GetCulturedString(height));
				height += description.Height + description.Stroke;

				gSeparatorContainer.AppendChild(lineSeparator);
			}

			return gSeparatorContainer;
		}

		protected override void Merge_Internal(string[] svgFiles, MergeOptions options, SVGDocument svgContainer)
		{
			double borderStrokeFloat = options.BorderStroke;
			double separatorStrokeFloat = options.SeparatorStroke;

			var gRootContainer =
				(SVGGElement)svgContainer.CreateElementNS("http://www.w3.org/2000/svg", "g");

			var viewBoxWidth = 400f; //100f; //300f;

			float widthDocumentRootElement = 0;
			for (int i = 0; i < svgFiles.Length; i++)
			{
				using (var svgDocument = new SVGDocument(svgFiles[i]))
				{
					var currentWidth = svgDocument.RootElement.GetBBox().Width;
					if (widthDocumentRootElement < currentWidth)
					{
						widthDocumentRootElement = currentWidth;
					}
				}
			}
			var childWidthFloat = widthDocumentRootElement;

			int separatorAmount = svgFiles.Length - 1;

			// 1. First Step
			// Obtain height of single SVG block and total height
			// ================================
			double ratio;
			float svgFirstDocumentHeight;
			using (var svgFirstDocument = new SVGDocument(svgFiles[0]))
			{
				var widthFirstDocumentRootElement = svgFirstDocument.RootElement.GetBBox().Width;
				ratio = childWidthFloat / widthFirstDocumentRootElement;
				svgFirstDocumentHeight = svgFirstDocument.RootElement.GetBBox().Height;
			}
			var currentHeightFloat = ratio * svgFirstDocumentHeight;
			var currentHeightString = GetCulturedString(currentHeightFloat);
			var totalHeightFloat =
				currentHeightFloat * svgFiles.Length + separatorStrokeFloat * svgFiles.Length - 1;

			// 2. RootElement attributes
			// ================================
			svgContainer.RootElement.ViewBox.BaseVal.X = 0;
			svgContainer.RootElement.ViewBox.BaseVal.Y = 0;
			svgContainer.RootElement.ViewBox.BaseVal.Width = viewBoxWidth;
			svgContainer.RootElement.ViewBox.BaseVal.Height =
			   (float)(totalHeightFloat + 2 * borderStrokeFloat + 2 * separatorStrokeFloat);

			svgContainer.RootElement.SetAttribute("width", "100%");
			svgContainer.RootElement.SetAttribute("height", "100%");

			// 3. Border Container
			// ================================
			if (options.IsBordered && options.BorderStroke > 0)
			{
				var borderDescription = new BorderDescription(
					borderStrokeFloat,
					borderStrokeFloat / 2,
					borderStrokeFloat / 2,
					childWidthFloat + 2 * separatorStrokeFloat + borderStrokeFloat,
					totalHeightFloat + 2 * separatorStrokeFloat + borderStrokeFloat,
					options.BorderColor);
				var gBorderContainer = GetBorderContainer(svgContainer, borderDescription);
				gRootContainer.AppendChild(gBorderContainer);
			}

			// 4. Separator Container
			// ================================
			if (options.IsWithSeparator && options.SeparatorStroke > 0)
			{
				var separatorDescription = new SeparatorDescription(
					separatorAmount,
					separatorStrokeFloat,
					borderStrokeFloat,
					borderStrokeFloat + separatorStrokeFloat,
					childWidthFloat + 2 * separatorStrokeFloat,
					currentHeightFloat,
					options.SeparatorColor);
				var gSeparatorContainer = GetSeparatorContainer(svgContainer, separatorDescription);
				gRootContainer.AppendChild(gSeparatorContainer);
			}

			// 5. Add child svg content
			// ================================
			double currentY = borderStrokeFloat + separatorStrokeFloat;
			var childWidthSting = GetCulturedString(childWidthFloat);
			var xOffsetString = GetCulturedString(borderStrokeFloat + separatorStrokeFloat);
			foreach (var svgFile in svgFiles)
			{
				var svgDocument = new SVGDocument(svgFile);
				svgDocument.RootElement.SetAttribute("width", childWidthSting);
				svgDocument.RootElement.SetAttribute("height", currentHeightString);
				svgDocument.RootElement.SetAttribute("x", xOffsetString);
				svgDocument.RootElement.SetAttribute("y", GetCulturedString(currentY));

				var gSampleContainer =
					(SVGGElement)svgContainer.CreateElementNS("http://www.w3.org/2000/svg", "g");

				currentY += currentHeightFloat + separatorStrokeFloat;
				gSampleContainer.AppendChild(svgDocument.RootElement);

				gRootContainer.AppendChild(gSampleContainer);
				svgDocument.Dispose();
			}
			svgContainer.RootElement.AppendChild(gRootContainer);
		}
	}
}
