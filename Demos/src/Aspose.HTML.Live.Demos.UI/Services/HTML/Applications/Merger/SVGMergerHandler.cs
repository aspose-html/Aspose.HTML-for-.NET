using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.Extensions;
using Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Conversion;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Svg.Saving;
using Aspose.Html.Rendering;

namespace Aspose.HTML.Live.Demos.UI.Services.HTML.Applications.Merger
{
	class SVGMergerHandler : MergerHandler
	{
		public SVGMergerHandler(params ConversionHandlerFilter[] filters)
			: base(filters)
		{

		}

		protected override RenderingWorkUnit CreateWorkItem(DataSource source, Configuration configuration)
		{
			return new UrlWorkUnit(source.Uri, configuration);
		}

		public override Result Execute(InputDataProvider data, MergerApplicationOptions options)
		{
			try
			{
				var configuration = GetConfiguration(options);

				var files = data.GetData()
					.Where(x => x.IsValid())
					.Select(x => CreateWorkItem(x, configuration))
					.Cast<UrlWorkUnit>()
					.Select(x => x.Data)
					.ToArray();

				var outputFilePath = Path.Combine(
					HTMLOperationContextScope.Context.OutputFolder,
					HTMLOperationContextScope.Context.Service.FileNameProvider
						.GetNextFileName(Application.DEFAULT_NAME_FOR_MERGED_SET_OF_FILES, options.OutputFormat.ToFileExtension()));


				SvgMergeHelper.GetHelper(options)
					.Merge(files, outputFilePath);

				return Result.FromFiles(outputFilePath);
			}
			catch (Exception e)
			{
				return Result.Error(e);
			}
		}



		abstract class SvgMergeHelper
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

			public static SvgMergeHelper GetHelper(MergerApplicationOptions options)
			{
				return options.MergeSVGAsVertically
					? (SvgMergeHelper) new SvgMergeVerticalHelper()
					: (SvgMergeHelper) new SvgMergeHorizontalHelper();
			}

			public void Merge(string[] inputFiles, string outFile, MergeOptions options = null)
			{
				if (options == null)
					options = MergeOptions.Empty;

				using (var svgContainer = new SVGDocument())
				{
					try
					{
						Merge_Internal(inputFiles, options, svgContainer);
						svgContainer.Save(outFile, SVGSaveFormat.SVG);
					}
					catch (Exception ex)
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

		class SvgMergeHorizontalHelper : SvgMergeHelper
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

		class SvgMergeVerticalHelper : SvgMergeHelper
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

		sealed class MergeOptions
		{

			#region Fields

			private static MergeOptions empty = new MergeOptions();

			#endregion

			#region Properties

			/// <summary>
			/// Border flag. Default - false.
			/// </summary>
			public bool IsBordered { get; set; } = false;

			/// <summary>
			/// Separator flag. Default - false.
			/// </summary>
			public bool IsWithSeparator { get; set; } = false;

			/// <summary>
			/// Border line color. Default - "orange".
			/// </summary>
			public string BorderColor { get; set; } = "orange";

			/// <summary>
			/// Separator line color. Default - "orange".
			/// </summary>
			public string SeparatorColor { get; set; } = "orange";

			/// <summary>
			/// Border stroke width. Default - 5f.
			/// </summary>
			public double BorderStroke { get; set; } = 5f;

			/// <summary>
			/// Separator stroke width. Default - 5f.
			/// </summary>
			public double SeparatorStroke { get; set; } = 5f;

			/// <summary>
			/// Default options instance: non bordered and not stroked 
			/// </summary>
			public static MergeOptions Empty => empty;

			#endregion

		}

	}
}
