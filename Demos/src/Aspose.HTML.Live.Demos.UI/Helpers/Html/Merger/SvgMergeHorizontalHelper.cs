using Aspose.Html.Dom.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Merger
{
	public class SvgMergeHorizontalHelper : SvgMergeHelper
	{
		protected override SVGElement GetSeparatorContainer(SVGDocument parentDocument, SeparatorDescription description)
		{
			var gSeparatorContainer =
				  (SVGGElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "g");
			gSeparatorContainer.SetAttribute("stroke", description.StrokeColor);
			gSeparatorContainer.SetAttribute("stroke-width", GetCulturedString(description.Stroke));
			gSeparatorContainer.SetAttribute("stroke-linecap", "bevel");
			gSeparatorContainer.SetAttribute("stroke-linejoin", "round");

			var height = description.Y + description.Height;
			var width = description.X + description.Width + description.Stroke / 2;
			for (int i = 0; i < description.Amount; i++)
			{
				var lineSeparator =
					(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
				lineSeparator.SetAttribute("x1", GetCulturedString(width));
				lineSeparator.SetAttribute("y1", GetCulturedString(description.Y));
				lineSeparator.SetAttribute("x2", GetCulturedString(width));
				lineSeparator.SetAttribute("y2", GetCulturedString(height));
				width += description.Width + description.Stroke;

				gSeparatorContainer.AppendChild(lineSeparator);
			}

			return gSeparatorContainer;
		}

		protected override void Merge_Internal(string[] svgFiles, MergeOptions options, SVGDocument svgContainer)
		{
			double borderStrokeFloat = options.BorderStroke;
			double separatorStrokeFloat = options.SeparatorStroke;

			var viewBoxHeight = 400f; //100f; //300f;

			float heightDocumentRootElement = 0;
			for (int i = 0; i < svgFiles.Length; i++)
			{
				using (var svgDocument = new SVGDocument(svgFiles[i]))
				{
					var currentHeight = svgDocument.RootElement.GetBBox().Height;
					if (heightDocumentRootElement < currentHeight)
					{
						heightDocumentRootElement = currentHeight;
					}
				}
			}
			var childHeightFloat = heightDocumentRootElement;
			int separatorAmount = svgFiles.Length - 1;

			// 0. "Global" "g" root Container
			// ================================
			var gRootContainer =
				(SVGGElement)svgContainer.CreateElementNS("http://www.w3.org/2000/svg", "g");
			// 1. First Step
			// Obtain height of single SVG block and total height
			// ================================
			double ratio;
			float svgFirstDocumentWidth;
			using (var svgFirstDocument = new SVGDocument(svgFiles[0]))
			{
				var heightFirstDocumentRootElement = svgFirstDocument.RootElement.GetBBox().Height;
				ratio = childHeightFloat / heightFirstDocumentRootElement;
				svgFirstDocumentWidth = svgFirstDocument.RootElement.GetBBox().Width;
			}
			var currentWidthFloat = ratio * svgFirstDocumentWidth;
			var currentWidthString = GetCulturedString(currentWidthFloat);
			var totalWidthFloat =
				currentWidthFloat * svgFiles.Length + separatorStrokeFloat * svgFiles.Length - 1;

			// 2. RootElement attributes
			// ================================
			svgContainer.RootElement.ViewBox.BaseVal.X = 0;
			svgContainer.RootElement.ViewBox.BaseVal.Y = 0;
			svgContainer.RootElement.ViewBox.BaseVal.Width =
				(float)(totalWidthFloat + 2 * borderStrokeFloat + 2 * separatorStrokeFloat);
			svgContainer.RootElement.ViewBox.BaseVal.Height = viewBoxHeight;

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
					totalWidthFloat + 2 * separatorStrokeFloat + borderStrokeFloat,
					childHeightFloat + 2 * separatorStrokeFloat + borderStrokeFloat,
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
					borderStrokeFloat + separatorStrokeFloat,
					borderStrokeFloat,
					currentWidthFloat,
					childHeightFloat + 2 * separatorStrokeFloat,
					options.SeparatorColor);
				var gSeparatorContainer = GetSeparatorContainer(svgContainer, separatorDescription);
				gRootContainer.AppendChild(gSeparatorContainer);
			}

			// 5. Add child svg content
			// ================================
			double currentX = borderStrokeFloat + separatorStrokeFloat;
			var childHeightSting = GetCulturedString(childHeightFloat);
			var yOffsetString = GetCulturedString(borderStrokeFloat + separatorStrokeFloat);
			foreach (var svgFile in svgFiles)
			{
				var svgDocument = new SVGDocument(svgFile);
				svgDocument.RootElement.SetAttribute("width", currentWidthString);
				svgDocument.RootElement.SetAttribute("height", childHeightSting);
				svgDocument.RootElement.SetAttribute("x", GetCulturedString(currentX));
				svgDocument.RootElement.SetAttribute("y", yOffsetString);

				var gSampleContainer =
					(SVGGElement)svgContainer.CreateElementNS("http://www.w3.org/2000/svg", "g");

				currentX += currentWidthFloat + separatorStrokeFloat;
				gSampleContainer.AppendChild(svgDocument.RootElement);

				gRootContainer.AppendChild(gSampleContainer);
				svgDocument.Dispose();
			}

			svgContainer.RootElement.AppendChild(gRootContainer);
		}
	}
}
