using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Svg.Saving;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Merger
{

	public abstract class SvgMergeHelper
	{
		protected struct BorderDescription
		{

			#region Initialization

			/// <summary>
			/// Border description parameters
			/// </summary>
			/// <param name="stroke">Stroke width.</param>
			/// <param name="x">Start point X position.</param>
			/// <param name="y">Start point Y position.</param>
			/// <param name="width">Border width.</param>
			/// <param name="height">Border height.</param>
			/// <param name="strokeColor">Stroke color.</param>
			public BorderDescription(double stroke, double x, double y, double width, double height, string strokeColor)
			{
				Stroke = stroke;
				X = x;
				Y = y;
				Width = width;
				Height = height;
				StrokeColor = strokeColor;
			}

			#endregion

			#region Properties

			public double Stroke { get; }

			public double Width { get; }

			public double Height { get; }

			public double X { get; }

			public double Y { get; }

			public string StrokeColor { get; }

			#endregion
		}

		protected struct SeparatorDescription
		{
			#region Initialization

			/// <summary>
			/// 
			/// </summary>
			/// <param name="amount">Separator line amount.</param>
			/// <param name="stroke">Stroke width.</param>
			/// <param name="x">First separator start point X position.</param>
			/// <param name="y">First separator start point Y position.</param>
			/// <param name="width">Separator line width.</param>
			/// <param name="height">Separator line height.</param>
			/// <param name="strokeColor"></param>
			public SeparatorDescription(int amount,
				double stroke,
				double x, double y,
				double width, double height, string strokeColor)
			{
				Amount = amount;
				Stroke = stroke;
				X = x;
				Y = y;
				Width = width;
				Height = height;
				StrokeColor = strokeColor;
			}

			#endregion

			#region Properties

			public double Stroke { get; }

			public double Width { get; }

			public double Height { get; }

			public string StrokeColor { get; }

			public int Amount { get; }

			public double X { get; }

			public double Y { get; }

			#endregion

		}

		public static SvgMergeHelper GetHelper(string or)
		{
			switch(or.ToLower())
			{
				case "v":
				case "vertical":
					return new SvgMergeVerticalHelper();
				case "h":
				case "horizontal":
					return new SvgMergeHorizontalHelper();
				default:
					return null;
			}
		}

		public void Merge(string[] inputFiles, string outFile, MergeOptions options = null)
		{
			if (options == null)
				options = MergeOptions.Empty;

			using(var svgContainer = new SVGDocument())
			{
				try
				{
					Merge_Internal(inputFiles, options, svgContainer);
					svgContainer.Save(outFile, SVGSaveFormat.SVG);
				}
				catch(Exception ex)
				{
					string message = ex.Message;
					throw ex;
				}
			
			}
		}

		protected abstract void Merge_Internal(string[] svgFiles, MergeOptions options, SVGDocument svgContainer);

		protected abstract SVGElement GetSeparatorContainer(SVGDocument parentDocument, SeparatorDescription description);

		protected SVGElement GetBorderContainer(SVGDocument parentDocument, BorderDescription description)
		{
			var gBorderContainer =
				(SVGGElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "g");
			gBorderContainer.SetAttribute("stroke", description.StrokeColor);
			gBorderContainer.SetAttribute("stroke-width", GetCulturedString(description.Stroke));
			gBorderContainer.SetAttribute("stroke-linecap", "round");
			gBorderContainer.SetAttribute("stroke-linejoin", "round");

			// Lines around content
			// ================================
			// Border Line top
			var lineTop =
				(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
			lineTop.SetAttribute("x1", GetCulturedString(description.X));
			lineTop.SetAttribute("y1", GetCulturedString(description.Y));
			lineTop.SetAttribute("x2", GetCulturedString(description.X + description.Width));
			lineTop.SetAttribute("y2", GetCulturedString(description.Y));
			// Border Line right
			var lineRight =
				(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
			lineRight.SetAttribute("x1", GetCulturedString(description.X + description.Width));
			lineRight.SetAttribute("y1", GetCulturedString(description.Y));
			lineRight.SetAttribute("x2", GetCulturedString(description.X + description.Width));
			lineRight.SetAttribute("y2", GetCulturedString(description.Y + description.Height));
			// Border Line bottom
			var lineBottom =
				(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
			lineBottom.SetAttribute("x1", GetCulturedString(description.X + description.Width));
			lineBottom.SetAttribute("y1", GetCulturedString(description.Y + description.Height));
			lineBottom.SetAttribute("x2", GetCulturedString(description.X));
			lineBottom.SetAttribute("y2", GetCulturedString(description.Y + description.Height));
			// Border Line left
			var lineLeft =
				(SVGLineElement)parentDocument.CreateElementNS("http://www.w3.org/2000/svg", "line");
			lineLeft.SetAttribute("x1", GetCulturedString(description.X));
			lineLeft.SetAttribute("y1", GetCulturedString(description.Y + description.Height));
			lineLeft.SetAttribute("x2", GetCulturedString(description.X));
			lineLeft.SetAttribute("y2", GetCulturedString(description.Y));

			gBorderContainer.AppendChild(lineTop);
			gBorderContainer.AppendChild(lineRight);
			gBorderContainer.AppendChild(lineBottom);
			gBorderContainer.AppendChild(lineLeft);

			return gBorderContainer;
		}

		protected static string GetCulturedString(double value)
		{
			return value.ToString(CultureInfo.GetCultureInfo("EN-us"));
		}
	}
}
