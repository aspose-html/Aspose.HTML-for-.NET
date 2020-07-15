using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Aspose.Html.Rendering;

namespace Aspose.HTML.Live.Demos.UI.Helpers.Html.Conversion
{
	public class ExportHelperEpub : ExportHelper
	{
		public ExportHelperEpub(ExportFormat format) : base(format)
		{ }

		protected override void Render(string sourcePath, IDevice device)
		{
			using (FileStream fstr = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
			{
				var renderer = new EpubRenderer();
				renderer.Render(device, fstr);
			}
		}

		protected override void Render(string[] sourcePathList, IDevice device)
		{
			FileStream[] streams = sourcePathList.Select<string, FileStream>(
				path => new FileStream(path, FileMode.Open, FileAccess.Read))
				.ToArray();
			try
			{
				using (EpubRenderer renderer = new EpubRenderer())
				{
					renderer.Render(device, streams);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				foreach (var str in streams)
					str.Dispose();
			}
		}
	}
}
