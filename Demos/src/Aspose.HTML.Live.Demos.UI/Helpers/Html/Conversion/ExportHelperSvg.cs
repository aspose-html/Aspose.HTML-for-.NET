using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Html.Rendering;
using Aspose.Html.Dom.Svg;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	public class ExportHelperSvg : ExportHelper
	{
		public ExportHelperSvg(ExportFormat format) : base(format)
		{ }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sourcePath"></param>
		/// <param name="device"></param>
		protected override void Render(string sourcePath, IDevice device)
		{
			using (SVGDocument document = new SVGDocument(sourcePath))
			{
				var renderer = new SvgRenderer();
				renderer.Render(device, document);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sourcePathList"></param>
		/// <param name="device"></param>
		protected override void Render(string[] sourcePathList, IDevice device)
		{
			SVGDocument[] docList = sourcePathList.Select<string, SVGDocument>(
				path => new SVGDocument(path))
				.ToArray();
			try
			{
				using (SvgRenderer renderer = new SvgRenderer())
				{
					renderer.Render(device, docList);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				foreach (var doc in docList)
					doc.Dispose();
			}
		}
	}
}
