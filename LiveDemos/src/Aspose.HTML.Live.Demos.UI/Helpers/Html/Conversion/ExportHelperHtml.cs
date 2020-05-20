using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Html.Dom;
using Aspose.Html.Rendering;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	public class ExportHelperHtml : ExportHelper
	{
		public ExportHelperHtml(ExportFormat format) : base(format)
		{ }

		protected override void Render(string sourcePath, IDevice device)
		{
			using (Aspose.Html.HTMLDocument html_document = new Aspose.Html.HTMLDocument(sourcePath))
			{
				using (HtmlRenderer renderer = new HtmlRenderer())
				{
					renderer.Render(device, html_document);
				}
			}
		}

		protected override void Render(string[] sourcePathList, IDevice device)
		{
			Document[] docList = sourcePathList.Select<string, Document>(
				path => new Aspose.Html.HTMLDocument(path))
				.ToArray();
			try
			{
				using (HtmlRenderer renderer = new HtmlRenderer())
				{
					renderer.Render(device, docList);
				}
			}
			catch(Exception ex)
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
